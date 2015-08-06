using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ATMCD32CS;
using ImageProc;



namespace Camera_Control
{
    public partial class CameraForm : Form
    {
        AndorSDK myAndor = new AndorSDK();
        private int shutter = 1;
        ATMCD32CS.AndorSDK.AndorCapabilities caps;                     // AndorCapabilities structure
        string model;                // headmodel
        int gblXPixels;       				// dims of
        int gblYPixels;       				// CCD chip
        int VSnumber;                 // Vertical Speed Index
        int HSnumber;                 // Horizontal Speed Index
        int ADnumber;                 // AD Index
        public int acquisitionMode;   // read from xxxxWndw.c
        public int readMode;          // read from xxxxWndw.c
        bool gblData = false;
        bool gblCooler = false;
        bool abortCont;
        const int SPI_GETSCREENSAVERRUNNING = 114;  // screensaver running ID
        const int Color = 256;// 65536;                      // Number of colors in the palette
        int hbin, vbin, hstart, hend, vstart, vend, hDim, vDim;
        int[] hBoxStart, hBoxEnd, vBoxStart, vBoxEnd;
        int ROICount = 0;
        int temperature = 20;                                                              
        int setTemperature; 
        // Function Prototypes
        double freqStep;
        double freqStart;
        BackgroundWorker bw = new BackgroundWorker();
        private static System.Windows.Forms.Timer aTimer, tempTimer;
        List <int[]> fluorescContData = new List<int[]>();




        // Set up acquisition parameters here to be set in common.c *****************

        int[] ionLocations;					// locations of ions that are passed to the drawing function to display on screen
        int[,] fluorescenceData;				// 2D pointer array that will store the fluorenscence data for each ion.
        double[,] spectrumData;
        int[] pImageArray;



        // int runCounter;                    //Counts the number of rusn in a multi image run-til-abort acquisition.
        int numIons = 1;						// The number of ions. Used for tracking and spectroscopy.
        int ionSquarePixelDim = 10;			// dimensions of box to be drawn around ions in camera pixels.
        int repeatPos;
        int repeatNum;
        int giNumberLoops;					// number of loops (images) for multi image run-til-abort acquisition
        int giTrigger = 10;					// type of trigger (software or external)
        int acqType;
        int threshold = 235;


        private void InitializeBackgroundWorker()
        {
            bw.DoWork +=
                new DoWorkEventHandler(bw_DoWork);
        }





        public CameraForm()
        {
            this.FormClosing += new FormClosingEventHandler(this.OnFormClosing);
            aTimer = new System.Windows.Forms.Timer();
            tempTimer = new System.Windows.Forms.Timer();
            tempTimer.Interval = (int)(10000);
            tempTimer.Tick += new EventHandler(TempMeasureEvent);
            tempTimer.Enabled = true;
            tempTimer.Start();
            InitializeBackgroundWorker();
            freqStep = 1;
            freqStart = 1.0;
            readMode = 4;
            acquisitionMode = 7;
            uint errorValue;
            float speed = 0, STemp;
            int iSpeed, iAD, nAD = 0, index = 0;
            InitializeComponent();
            errorValue = myAndor.Initialize(Directory.GetCurrentDirectory());

            hBoxStart = new int[10];
            hBoxEnd = new int[10];
            vBoxStart = new int[10];
            vBoxEnd = new int[10];  



            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
            {
                MessageBox.Show("Initialization Failed.",
             "Error!",
               MessageBoxButtons.OK,
              MessageBoxIcon.Exclamation,
              MessageBoxDefaultButton.Button1);
            }

            errorValue = myAndor.GetCapabilities(ref caps);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
            {
                MessageBox.Show("Get Andor Capabilities information Error.",
              "Error!",
                MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation,
               MessageBoxDefaultButton.Button1);
            }

            // Get Head Model
            errorValue = myAndor.GetHeadModel(ref model);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
            {
                MessageBox.Show("Get Head Model Error.",
              "Error!",
                MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation,
               MessageBoxDefaultButton.Button1);
            }

            // Get detector information
            errorValue = myAndor.GetDetector(ref gblXPixels, ref gblYPixels);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
            {
                MessageBox.Show("Get Detector Error.",
              "Error!",
                MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation,
               MessageBoxDefaultButton.Button1);
            }

            // Set acquisition mode to required setting specified in xxxxWndw.c
            errorValue = myAndor.SetAcquisitionMode(acquisitionMode);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
            {
                MessageBox.Show("Error setting acquisition.",
             "Error!",
               MessageBoxButtons.OK,
              MessageBoxIcon.Exclamation,
              MessageBoxDefaultButton.Button1);
            }

            // Set read mode to required setting specified in xxxxWndw.c
            errorValue = myAndor.SetReadMode(readMode);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
            {
                MessageBox.Show("Error setting read mode.",
             "Error!",
               MessageBoxButtons.OK,
              MessageBoxIcon.Exclamation,
              MessageBoxDefaultButton.Button1);
            }

            // Set Vertical speed to recommended
            myAndor.GetFastestRecommendedVSSpeed(ref VSnumber, ref speed);
            errorValue = myAndor.SetVSSpeed(0);
            myAndor.GetVSSpeed(0, ref speed);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
            {
                MessageBox.Show("Error Setting VS Speed.",
             "Error!",
               MessageBoxButtons.OK,
              MessageBoxIcon.Exclamation,
              MessageBoxDefaultButton.Button1);
            }
            Console.WriteLine("VSpeed:  " + speed);

            // Set Horizontal Speed to max
            STemp = 0;
            HSnumber = 0;
            ADnumber = 0;
            errorValue = myAndor.GetNumberADChannels(ref nAD);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
            {
                MessageBox.Show("Get Number of ADC Channels error.",
             "Error!",
               MessageBoxButtons.OK,
              MessageBoxIcon.Exclamation,
              MessageBoxDefaultButton.Button1);
            }
            else
            {
                for (iAD = 0; iAD < nAD; iAD++)
                {
                    myAndor.GetNumberHSSpeeds(iAD, 0, ref index);
                    for (iSpeed = 0; iSpeed < index; iSpeed++)
                    {
                        myAndor.GetHSSpeed(iAD, 0, iSpeed, ref speed);
                        if (speed > STemp)
                        {
                            STemp = speed;
                            HSnumber = iSpeed;
                            ADnumber = iAD;
                        }
                    }
                }
            }

            errorValue = myAndor.SetVSAmplitude(2);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
            {
                MessageBox.Show("Error setting VS amplitude.",
             "Error!",
               MessageBoxButtons.OK,
              MessageBoxIcon.Exclamation,
              MessageBoxDefaultButton.Button1);
            }


            errorValue = myAndor.SetADChannel(ADnumber);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
            {
                MessageBox.Show("Error setting ADC Channel.",
             "Error!",
               MessageBoxButtons.OK,
              MessageBoxIcon.Exclamation,
              MessageBoxDefaultButton.Button1);
            }

            errorValue = myAndor.SetHSSpeed(0, 0);
            myAndor.GetHSSpeed(ADnumber, 0, HSnumber, ref speed);
            Console.WriteLine("HSpeed: " + speed);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
            {
                MessageBox.Show("Set HS Speed Error.",
             "Error!",
               MessageBoxButtons.OK,
              MessageBoxIcon.Exclamation,
              MessageBoxDefaultButton.Button1);
            }

            if ((caps.ulSetFunctions & ATMCD32CS.AndorSDK.AC_SETFUNCTION_BASELINECLAMP) != 0)
            {
                errorValue = myAndor.SetBaselineClamp(1);
                if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                {
                    MessageBox.Show("Set Baseline clamp Error.",
                 "Error!",
                     MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                }
            }

        }




        private void Shutter_Click(object sender, EventArgs e)
        {
            if (shutter == 1)
            {
                shutter = 2;
            }
            else
            {
                shutter = 1;

            }
            myAndor.SetShutter(0, shutter, 50, 50);
        }

        private void ShutDown_Click(object sender, EventArgs e)
        {
            uint errorValue;
            if ((caps.ulSetFunctions & ATMCD32CS.AndorSDK.AC_SETFUNCTION_TEMPERATURE) != 0)
            {
                errorValue = myAndor.CoolerOFF();        // Switch off cooler (if used)
                if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                    MessageBox.Show("Error switching cooler off.",
            "Error!",
              MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button1);
            }
            tempTimer.Stop();
            errorValue = myAndor.ShutDown();
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                MessageBox.Show("Error shutting down.",
            "Error!",
              MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button1);



        }


        private void numIonsUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void startAcqButton_Click(object sender, EventArgs e)
        {
            setSystem();
        }

        //Sets up hardware
        void setSystem()
        {



            float fExposure, fAccumTime = 0, fKineticTime = 0;
            uint errorValue;
            int i;
            int gain = (int)gainUpDown.Value;
            gblData = true;
            vbin = 1;
            hbin = 1;
            hstart = (int)horStartUpDown.Value;
            hend = (int)horEndUpDown.Value;
            vstart = (int)verStartUpDown.Value;
            vend = (int)vertEndUpDown.Value;
            hDim = (hend - hstart + 1) / hbin; // sets horizontal dimension
            vDim = (vend - vstart + 1) / vbin;// sets vertical dimension
              



            int countType = 0;
            //Set Exposure
            fExposure = (float)exposureUpDown.Value;
            errorValue = myAndor.SetExposureTime(fExposure);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                MessageBox.Show("Error setting exposure.",
            "Error!",
              MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button1);
            // System.Diagnostics.Debug.WriteLine(hDim);

            //Get acquisition timings
            myAndor.GetAcquisitionTimings(ref fExposure, ref fAccumTime, ref fKineticTime);

            //Set shutter  1,1,0,0 = always open
            errorValue = myAndor.SetShutter(1, 1, 0, 0);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                MessageBox.Show("Error setting shutter.",
            "Error!",
              MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button1);


            if (comboTrigger.SelectedItem.ToString() == "Software")
            {
                giTrigger = 10;
            }
            if (comboTrigger.SelectedItem.ToString() == "External")
            {
                giTrigger = 6;
            }
            // Get acquisition mode selection             
            if (acqTypeComboBox.SelectedItem.ToString() == "Single")
            {
                acqType = 0;
                acquisitionMode = 1;
            }
            if (acqTypeComboBox.SelectedItem.ToString() == "Multi")
            {
                acqType = 1;
                acquisitionMode = 5;
            }
            if (acqTypeComboBox.SelectedItem.ToString() == "Kinetic Series")
            {
                acqType = 2;
                acquisitionMode = 3;
            }
            if (acqTypeComboBox.SelectedItem.ToString() == "Continuous")
            {
                acqType = 3;
                acquisitionMode = 5;
            }
            if (comboCountType.SelectedItem.ToString() == "Counts")
            {
                countType = 0;
            }
            else if (comboTrigger.SelectedItem.ToString() == "Electrons")
            {
                countType = 1;
            }
            else if (comboTrigger.SelectedItem.ToString() == "Photons")
            {
                countType = 2;
            }

            myAndor.SetEMGainMode(3);
            myAndor.SetEMAdvanced(1);


            errorValue = myAndor.SetAcquisitionMode(acquisitionMode);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                MessageBox.Show("Error setting acquisition mode.",
            "Error!",
              MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button1);

            errorValue = myAndor.SetEMCCDGain(gain);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                MessageBox.Show("Error setting gain.",
            "Error!",
              MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button1);

            errorValue = myAndor.SetTriggerMode(giTrigger);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                MessageBox.Show("Error setting trigger mode.",
            "Error!",
              MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button1);

            errorValue = myAndor.SetPreAmpGain(2);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                MessageBox.Show("Error setting preamp.",
            "Error!",
              MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button1);



            errorValue = myAndor.SetCountConvertMode(countType);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                MessageBox.Show("Error setting count mode.",
            "Error!",
                MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation,
               MessageBoxDefaultButton.Button1);



            errorValue = myAndor.SetCountConvertWavelength((float)397);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                MessageBox.Show("Error setting wavelenght.",
            "Error!",
              MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button1);



            giNumberLoops = (int)numLoopsUpDown.Value;

            repeatNum = (int)numRepeatsUpDown.Value;

            numIons = (int)numIonsUpDown.Value;

            ionSquarePixelDim = (int)ionSquareDimUpDown.Value;

            threshold = (int)threshUpDown.Value;

            if (hstart > hend || vstart > vend)
            {
                MessageBox.Show("Image start positions must not be greater than end positions");
                gblData = false;
            }
            if ((hend - hstart + 1) % hbin != 0)
            {
                MessageBox.Show("Image width must be a multiple of Horizontal Binning.",
           "Error!",
             MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button1);
                gblData = false;
            }
            if ((vend - vstart + 1) % vbin != 0)
            {
                MessageBox.Show("Image height must be a multiple of Vertical Binning.",
           "Error!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button1);
                gblData = false;
            }

            if (ionSquarePixelDim > vDim || ionSquarePixelDim > hDim)
            {
                MessageBox.Show("Ion box dimensions must not be larger than sub image.",
               "Error!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                gblData = false;

            }
            





            repeatPos = 1;
            spectrumData = new double[numIons, repeatNum];

            // This function only needs to be called when acquiring an image. It sets
            // the horizontal and vertical binning and the area of the image to be
            // captured. In this example it is set to 1x1 binning and is acquiring the
            // whole image

            /* long ind=NULL;
             int test = GetSizeOfCircularBuffer(&ind);
             printf("size:  %ld %d",ind, test);*/


            bw.WorkerSupportsCancellation = true;




            myAndor.SetFrameTransferMode(1);
            errorValue = myAndor.SetImage(hbin, vbin, hstart, hend, vstart, vend);
            if (errorValue != 20002)
            {
                MessageBox.Show("Set Image error.",
               "Error!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                gblData = false;
            }
            else
            {


                if (acqType == 0)
                {
                    ionLocations = new int[numIons];
                    errorValue = myAndor.StartAcquisition();
                    if (giTrigger == 6)
                        errorMsgTxtBox.AppendText("Waiting for external trigger" + "\r\n");
                    if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                    {
                        errorMsgTxtBox.AppendText("Error Starting Acquisition" + "\r\n");
                        errorMsgTxtBox.AppendText(errorValue.ToString());
                        myAndor.AbortAcquisition();
                        gblData = false;
                    }
                    else
                    {
                        errorMsgTxtBox.AppendText("Starting Acquisition" + "\r\n");
                        AcquireImageData();

                    }
                    myAndor.AbortAcquisition();
                }




                if (acqType == 1)
                {
                    ionLocations = new int[numIons];
                    errorValue = myAndor.StartAcquisition();
                    if (giTrigger == 7)
                        errorMsgTxtBox.AppendText("Waiting for external trigger" + "\r\n");
                    if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                    {
                        errorMsgTxtBox.AppendText("Error Starting Acquisition" + "\r\n");
                        errorMsgTxtBox.AppendText(errorValue.ToString());
                        myAndor.AbortAcquisition();
                        gblData = false;
                    }
                    else
                    {
                        errorMsgTxtBox.AppendText("Starting Acquisition" + "\r\n");
                        for (i = 0; i < repeatNum; i++)
                        {
                            AcquireImageDataMulti();
                            repeatPos++;
                        }
                        myAndor.AbortAcquisition();
                        writeToFile();
                    }
                }
                if (acqType == 2)
                {
                    ionLocations = new int[numIons];
                    myAndor.SetFastExtTrigger(1);
                    myAndor.SetNumberAccumulations(repeatNum);
                    myAndor.SetNumberKinetics(giNumberLoops);

                    fKineticTime = (float)0.0001;
                    // myAndor.SetExposureTime((float) 0.001);
                    myAndor.SetKineticCycleTime(fKineticTime);

                    myAndor.GetAcquisitionTimings(ref fExposure, ref fAccumTime, ref fKineticTime);
                    errorMsgTxtBox.AppendText("exposure: " + fExposure + "  kinetic Cycle:  " + fKineticTime + "\r\n");
                    if (giTrigger == 10) myAndor.SetTriggerMode(0);
                    /*
                    errorValue = myAndor.StartAcquisition();                    
                    if (giTrigger == 1)
                        errorMsgTxtBox.AppendText("Waiting for external trigger" + "\r\n");
                     if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                    {
                        errorMsgTxtBox.AppendText("Error Starting Acquisition" + "\r\n");
                        errorMsgTxtBox.AppendText(errorValue.ToString());
                        myAndor.AbortAcquisition();
                        gblData = false;
                    }
                     */

                    //{                           
                    errorMsgTxtBox.AppendText("Starting Acquisition" + "\r\n");
                    AcquireImageDataKinetic();
                    myAndor.AbortAcquisition();
                    writeToFile();
                    //}
                }
                if (acqType == 3)
                {

                    // Hook up the Elapsed event for the timer. 

                    // aTimer.SynchronizingObject = this;
                    ionLocations = new int[numIons];
                    myAndor.SetKineticCycleTime(1);
                    myAndor.SetTriggerMode(0);
                    myAndor.GetAcquisitionTimings(ref fExposure, ref fAccumTime, ref fKineticTime);                            
                    errorMsgTxtBox.AppendText("exposure: " + fExposure + "  kinetic Cycle:  " + fKineticTime + "\r\n");
                    aTimer.Interval = (int)(1000 * fKineticTime);
                    aTimer.Tick += new EventHandler(OnTimedEvent);
                    errorValue = myAndor.StartAcquisition();
                    if (giTrigger == 6)
                        errorMsgTxtBox.AppendText("Waiting for external trigger" + "\r\n");
                    if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                    {
                        errorMsgTxtBox.AppendText("Error Starting Acquisition" + "\r\n");
                        errorMsgTxtBox.AppendText(errorValue.ToString());
                        myAndor.AbortAcquisition();
                        gblData = false;
                    }
                    else
                    {

                        abortCont = false;
                        errorMsgTxtBox.AppendText("Starting Acquisition" + "\r\n");

                        if (bw.IsBusy != true)
                        {
                            // Start the asynchronous operation.
                            Console.WriteLine("In front of worker");
                            bw.RunWorkerAsync();
                            Console.WriteLine("In front of time ");
                            Thread.Sleep(100);
                            aTimer.Enabled = true;
                            aTimer.Start();
                            Console.WriteLine("after time start");
                        }


                    }

                }

            }
            Console.WriteLine("Set system done");
        }// end of set system

        bool AcquireImageData()
        {
            uint size;
            uint errorValue;
            Random rnd = new Random();
            size = (uint)(hDim * vDim);
            myAndor.SendSoftwareTrigger();    // PHYSICAL CAMERA ACQUISITION STARTS
            errorMsgTxtBox.AppendText("trigger sent" + "\r\n");
            myAndor.WaitForAcquisition();       // THREAD RESUMES FROM SLEEP AT THE END OF ACQUISITION
            // WaitForAcquisitionTimeOut(200);
            errorMsgTxtBox.AppendText("acq wait over" + "\r\n");
            pImageArray = new int[size];
            // ACQUISTION PERFORMED HERE!!!
            errorValue = myAndor.GetAcquiredData(pImageArray, size);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
            {
                errorMsgTxtBox.AppendText("Error Starting Acquisition" + "\r\n");
                errorMsgTxtBox.AppendText(errorValue.ToString());
                return false;
            }


            if (!gblData)
            {														  // If there is no data the acq has
                errorMsgTxtBox.AppendText("Acquisition Aborted" + "\r\n"); // been aborted
            }
            else
            {
                // tell user acquisition is complete                
                errorMsgTxtBox.AppendText("Acquisition complete" + "\r\n");
                /*
                errorMsgTxtBox.AppendText("Max data value is %d counts\r\n", MaxValue);
                strcat(aBuffer, aBuffer2);
                wsprintf(aBuffer2, "Min data value is %d counts\r\n", MinValue);
                strcat(aBuffer, aBuffer2);

                wsprintf(aBuffer2, "Ions found at starting pixel: ");
                strcat(aBuffer, aBuffer2);
                for (i = 0; i < numIons; i++)
                {
                    sprintf(aBuffer2, "%d ", ionLocations[i]);
                    strcat(aBuffer, aBuffer2);
                }*/
                findIons();
                drawCameraImage();
            }



            return true;
        }

        bool AcquireImageDataMulti()
        {
            uint size;
            int i;

            Stopwatch sw = new Stopwatch();
            size = (uint)(hDim * vDim);
            fluorescenceData = new int[giNumberLoops, numIons];
            pImageArray = new int[size];
            // Loop over multiple image acquisitions
            sw.Start();
            for (i = 0; i < giNumberLoops; i++)
            {

                if (giTrigger == 10) myAndor.SendSoftwareTrigger();    // PHYSICAL CAMERA ACQUISITION STARTS

                myAndor.WaitForAcquisition();       // THREAD RESUMES FROM SLEEP AT THE END OF ACQUISITION



                if (myAndor.GetMostRecentImage(pImageArray, size) != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                {                 // ACQUISITION PERFORMED HERE!!
                    errorMsgTxtBox.AppendText("Acquisition Error" + "\r\n");

                    //i = giNumberLoops;
                }
                else
                {
                    errorMsgTxtBox.AppendText("Got Image: " + i + "\r\n");
                    findIons();
                    drawCameraImage();
                }


                getFluorescence(i);


                for (int j = 0; j < numIons; j++)
                {
                    errorMsgTxtBox.AppendText("FlourDetec  " + fluorescenceData[i, j]);
                }
                // Display data and query max data value to be displayed in status box   



            }
            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);
            flourThreshDetect(repeatPos, threshold, giNumberLoops);



            return true;
        }

        bool AcquireImageDataKinetic()
        {
            uint size;
            int i;
            int count = 0;
            Stopwatch sw = new Stopwatch();
            size = (uint)(hDim * vDim);
            fluorescenceData = new int[giNumberLoops, numIons];
            pImageArray = new int[size];
            // Loop over multiple image acquisitions


            myAndor.StartAcquisition();
            sw.Start();
            /*
            while (count < repeatNum * giNumberLoops == true)
            {
              
                 //myAndor.WaitForAcquisitionTimeOut(10);
                
                count++;
                
             
             */
            float exp = 0, b = 0, c = 0;
            myAndor.GetAcquisitionTimings(ref exp, ref b, ref c);
            exp = exp * 2000;
            Console.WriteLine("exp" + exp);
            for (i = 1; i < giNumberLoops * repeatNum + 1; i++)
            {
                myAndor.WaitForAcquisitionTimeOut((int)exp);
                if (i % repeatNum == 0)
                {
                    if (myAndor.GetOldestImage(pImageArray, size) != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                    {                 // ACQUISITION PERFORMED HERE!!
                        errorMsgTxtBox.AppendText("Acquisition Error" + "\r\n");

                        //i = giNumberLoops;
                    }
                    else
                    {
                        //if (i == 0) findIons();
                        errorMsgTxtBox.AppendText("Got Image: " + i / repeatNum + "\r\n");
                        findIons();
                        drawCameraImage();
                        getFluorescence(i / repeatNum - 1);
                        //myViewer.addLiveData(Readings, CurrentWindowStep, 0, CurrentPulseLength);
                    }
                }
            }                                      


               

                
                for (int j = 0; j < numIons; j++)
                {
                    errorMsgTxtBox.AppendText("FlourDetec  " + fluorescenceData[0, j]);
                }
                 


            /*
            for (int j = 0; j < repeatNum; j++)
            {
                for (i = 0; i < giNumberLoops; i++)
                {

                   // myAndor.WaitForAcquisition();
                    if(j!=0) myAndor.WaitForAcquisitionTimeOut(10);
                    if (myAndor.GetOldestImage(pImageArray, size) != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                    {                 // ACQUISITION PERFORMED HERE!!
                        errorMsgTxtBox.AppendText("Acquisition Error" + "\r\n");

                        //i = giNumberLoops;
                    }
                    else
                    {
                        //if (i == 0) findIons();
                        //errorMsgTxtBox.AppendText("Got Image: " + i + "\r\n");
                        //drawCameraImage();
                    }


                    //getFluorescence(i);
                     
                    for (int k = 0; k < numIons; k++)
                    {
                        errorMsgTxtBox.AppendText("FlourDetec  " + fluorescenceData[i, k]);
                    }
                    // Display data and query max data value to be displayed in status box 
                      

                }
                //flourThreshDetect(repeatPos, threshold, giNumberLoops);
            } */

            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);
            writeToFileSimple();
            return true;

        }

        bool AcquireImageDataCont()
        {
            uint size;
            uint errorValue;
            
            //Stopwatch sw = new Stopwatch();
            Console.WriteLine("Outside while loop");
            while (abortCont == false)
            {
                //sw.Start();
                Console.WriteLine("Inside while loop");
                size = (uint)(hDim * vDim);
                // errorMsgTxtBox.AppendText("Hey there" + "\r\n");

                myAndor.WaitForAcquisition();       // THREAD RESUMES FROM SLEEP AT THE END OF ACQUISITION                  // WaitForAcquisitionTimeOut(200);
                // errorMsgTxtBox.AppendText("acq wait over" + "\r\n");
                pImageArray = new int[size];
                // ACQUISTION PERFORMED HERE!!!
                errorValue = myAndor.GetOldestImage(pImageArray, size);
                //getFluorescence();
                // findIons();  
                fluorescContData.Add(getFluorescenceCont());
            }



            return true;

        }









        //------------------------------------------------------------------------------
        //	FUNCTION NAME:	findIons()
        //
        //  RETURNS:				TRUE: Function succeeded
        //									FALSE: No ions found. (Something went really wrong)
        //
        //  LAST MODIFIED:	Pavel	02/04/15
        //
        //  DESCRIPTION:    This function finds the ions by looking for the brightest squares of a user selected size. It ensures these squares
        //						dont overlap. It updates the ionLocations pointer array.
        //	ARGUMENTS: 			int noIons:     number of ions
        //						long *ionLocations:   Returns the positions of the ions in coordinates of the new grid.
        //
        //------------------------------------------------------------------------------            
        void findIons()
        {
            int i, j, k;
            int[] gridData;

            int gridDim = (hDim - ionSquarePixelDim + 1) * (vDim - ionSquarePixelDim + 1); // the size of the reduced grid is (N - boxSize  + )^2 for a square
            gridData = new int[gridDim];
            int gridLength = hDim - (ionSquarePixelDim - 1);

            // these nested loops scan the data array one user defined box at a time and store the number of counts in these sub boxes
            // because the data is stored in a 1D array things are a bit more complicated.
            if (gblData == true && pImageArray != null)
            {
                for (i = 0; i < gridDim; i++)
                { // this loops over all the elements in the reduced grid
                    for (j = 0; j < ionSquarePixelDim; j++)
                    { // this loop augments the vertical position
                        for (k = i; k < ionSquarePixelDim + i; k++)
                        { // This loop always scans horizontally by the box dimension
                            gridData[i] += pImageArray[(ionSquarePixelDim - 1) * (i / gridLength) + j * hDim + k];
                        } // j*hDim moves to the next line at, while the bit before is to force the skipping of boxes that try to loop over edges.
                    }

                }

            }



            int ionsFound = 0; // Counter for how many ions found so far in loop
            int ignore;       // tag for whether to record a particular ion or not

            // loop for storing ion locations. This for loop is not meant to complete and it is expected to be terminated by a break.
            // the code employs a partial quicksort.
            for (i = 0; i < gridDim; i++)
            {
                ignore = 0;
                int temp;
                int maxIndex = i;                 //stores position of highest count value so far.
                int maxValue = gridData[i];      // the highest value

                for (j = i + 1; j < gridDim; j++)
                {
                    if (gridData[j] > maxValue)
                    {         // updates the largest value and the position if a new maximum is found
                        maxIndex = j;
                        maxValue = gridData[j];
                    }
                }
                temp = gridData[i];                    // in these three lines the sorting is performed by reversing the position of the elements
                gridData[i] = gridData[maxIndex];
                gridData[maxIndex] = temp;
                /*if(ionsFound==0){
                        ionLocations[ionsFound]=maxIndex;
                        ionsFound++;
                        printf("Ion %d", ionsFound );
                        printf("  at position %d     ", maxIndex);
                        ignore=1;
                }else{
                */


                if (ionsFound != 0)
                { // this ensures that the first (brightest) ion will be recorded with no checks.
                    for (k = 0; k < ionsFound; k++)
                    { // compares the position of the k-th bright position to all the previous ones to ensure there is no overlap
                        if (Math.Abs(maxIndex % gridLength - ionLocations[k] % gridLength) < ionSquarePixelDim && Math.Abs((maxIndex - ionLocations[k])) / gridLength < ionSquarePixelDim)
                        {//&&(ionLocations[ionsFound-1]-maxIndex)%(hDim-(ionSquarePixelDim))<ionSquarePixelDim){//-&&(maxIndex-hDim-ionSquarePixelDim+1)!=ionLocations[i-1]&&(maxIndex+hDim+ionSquarePixelDim-1)!=ionLocations[i-1]){
                            //printf("blob  %d %d ", maxIndex, ionLocations[ionsFound-1]);
                            ignore = 1; // Updates the tag for recording and exists loop as soon as overlap is found with at least one ion.
                            break;
                        }
                    }
                }
                if (ignore == 0)
                {  // if there is no overlap store position of ion.
                    ionLocations[ionsFound] = maxIndex;
                    ionsFound++;
                    errorMsgTxtBox.AppendText("Ion " + ionsFound + " at position  " + maxIndex + " with counts " + maxValue + "\n");

                }


                if (ionsFound == numIons) break; // break out of for loop so that the sorting doesnt continue pointlessly

            }




            /*
           for(i=0;i<noIons;i++){
                printf("%d  ",ionLocations[i]);

            }
            printf("new \n");
            */
        }

        void getFluorescence(int run)
        {
            int i, j, k;
            int gridLength = hDim - (ionSquarePixelDim - 1);
            for (i = 0; i < numIons; i++)
            {
                fluorescenceData[run, i] = 0;
                for (j = 0; j < ionSquarePixelDim; j++)
                { // this loop augments the vertical position
                    for (k = ionLocations[i]; k < ionSquarePixelDim + ionLocations[i]; k++)
                    { // This loop always scans horizontally by the box dimension
                        fluorescenceData[run, i] += pImageArray[(ionSquarePixelDim - 1) * (ionLocations[i] / gridLength) + j * hDim + k];
                    } // j*hDim moves to the next line at, while the bit before is to force the skipping of boxes that try to loop over edges.
                }
            }

        }


        int[] getFluorescenceCont()
        {
            int k;
            int[] fluorescence = new int[ROICount];
            for (k = 0; k < ROICount; k++) 
            {
                int i, j;                   
                int hBoxDim = hBoxEnd[k] - hBoxStart[k] + 1;
                int vBoxDim = vBoxEnd[k] - vBoxStart[k] + 1;
                int hOffset = hBoxStart[k] - hstart;
                int vOffset = vBoxStart[k] - vstart;                
                for (i = 0; i < hBoxDim; i++)
                {
                    for (j = 0; j < vBoxDim; j++)
                    {
                        fluorescence[k] += pImageArray[i * hDim + j + hOffset + vOffset * hDim];
                    }
                }
            }
            return fluorescence;
        }



        void flourThreshDetect(int repeatN, int threshold, int loopNum)
        {
            int i, j, flourCount;
            for (i = 0; i < numIons; i++)
            {
                flourCount = 0;
                for (j = 0; j < loopNum; j++)
                {
                    if (fluorescenceData[j, i] > threshold)
                        flourCount++;
                }
                double exc = (double)flourCount / loopNum;
                errorMsgTxtBox.AppendText("The ion number: " + i + " has been fractionally excited  " + exc + "\n");
                spectrumData[i, repeatN - 1] = exc;

            }


        }

        void drawCameraImage()
        {
            long MaxValue;
            long MinValue;
            int i;
            MaxValue = 1;
            MinValue = 65536;
            float xscale, yscale, zscale, modrange;
            double dTemp;
            int width, height;
            int j, x, z, iTemp;

            for (i = 0; i < (hDim * vDim); i++)
            {
                if (pImageArray[i] > MaxValue)
                {
                    // printf("max %ld ", MaxValue);

                    MaxValue = pImageArray[i];
                }

                if (pImageArray[i] < MinValue)
                    MinValue = pImageArray[i];
            }
            modrange = MaxValue - MinValue;
            width = 400;//rect.right - rect.left + 1;
            // while(width%4!=0||width%hDim!=0)                 // width must be a multiple of 4 and the width should be divisble by the number of horizontal pixels
            //      width ++;// (4-width%4);
            height = width;//rect.bottom - rect.top + 1;
            xscale = (float)(hDim) / (float)(width);
            yscale = (float)(256.0) / (float)modrange;
            zscale = (float)(vDim) / (float)(height);


            double H = Math.Ceiling((double)(ionSquarePixelDim * width) / (double)hDim);
            double HH = (double)(width) / (double)hDim;
            int dimH = (int)H;  // Dimensions of the box are fixed        

            int dimV = (int)(Math.Ceiling((double)ionSquarePixelDim * height / vDim));
            double dimHH = (double)(ionSquarePixelDim * width / hDim);  // Dimensions of the box are fixed
            double dimVV = (double)(ionSquarePixelDim * height / vDim);
            byte[] byteArray = new byte[width * height];


            for (i = 0; i < height; i++)
            {
                z = (int)(i * zscale);
                for (j = 0; j < width; j++)
                {
                    x = (int)(j * xscale);
                    dTemp = Math.Ceiling(yscale * (pImageArray[x + z * hDim] - MinValue));
                    if (dTemp < 0) iTemp = 0;
                    else if (dTemp > Color - 1) iTemp = Color - 1;
                    else iTemp = (int)dTemp;
                    byteArray[j + i * width] = (byte)iTemp;
                }
            }

            for (int k = 0; k < ionLocations.Length; k++)
            {
                int xPos, yPos;
                xPos = (int)((ionLocations[k] % (hDim - (ionSquarePixelDim - 1))) * HH);
                yPos = (int)((ionLocations[k] / (hDim - (ionSquarePixelDim - 1))) * HH);
                for (i = yPos; i < yPos + dimH; i++)
                {
                    for (j = xPos; j < xPos + dimV; j++)
                    {
                        if (i == yPos || j == xPos || i == yPos + dimH - 1 || j == xPos + dimV - 1)
                            byteArray[j + i * width] = (byte)0;
                    }
                }
            }


            Size sizeImg = new Size(400, 400);
            GCHandle pinnedArray = GCHandle.Alloc(byteArray, GCHandleType.Pinned);
            IntPtr dataPtr = pinnedArray.AddrOfPinnedObject();
            pictureBox1.Size = new Size(400, 400);
            this.Controls.Add(pictureBox1);
            Bitmap flag = new Bitmap(width, height, width, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, dataPtr);    //Format8bppIndexed
            Image8Bit img = new Image8Bit(flag);
            img.MakeGrayscale();
            img.Dispose();
            Bitmap b = new Bitmap(sizeImg.Width, sizeImg.Height);
            using (Graphics gr = Graphics.FromImage(b))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                // gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(flag, new Rectangle(0, 0, sizeImg.Width, sizeImg.Height));
            }


            pictureBox1.Image = b;
            pictureBox1.Refresh();
            pinnedArray.Free();
        }

        void drawCameraImageCont()
        {                  
            long MaxValue;
            long MinValue;
            int i;
            MaxValue = 1;
            MinValue = 65536;
            float xscale, yscale, zscale, modrange;
            double dTemp;
            int width, height;
            int j, x, z, iTemp;

            for (i = 0; i < (hDim * vDim); i++)
            {
                if (pImageArray[i] > MaxValue)
                {
                    // printf("max %ld ", MaxValue);

                    MaxValue = pImageArray[i];
                }

                if (pImageArray[i] < MinValue)
                    MinValue = pImageArray[i];
            }
            modrange = MaxValue - MinValue;
            width = 400;//rect.right - rect.left + 1;
            // while(width%4!=0||width%hDim!=0)                 // width must be a multiple of 4 and the width should be divisble by the number of horizontal pixels
            //      width ++;// (4-width%4);
            height = width;//rect.bottom - rect.top + 1;
            xscale = (float)(hDim) / (float)(width);
            yscale = (float)(256.0) / (float)modrange;
            zscale = (float)(vDim) / (float)(height);


           
            double HH = (double)(width) / (double)hDim;
            double VH = (double)(height) / (double)vDim;
            
            
            byte[] byteArray = new byte[width * height];


            for (i = 0; i < height; i++)
            {
                z = (int)(i * zscale);
                for (j = 0; j < width; j++)
                {
                    x = (int)(j * xscale);
                    dTemp = Math.Ceiling(yscale * (pImageArray[x + z * hDim] - MinValue));
                    if (dTemp < 0) iTemp = 0;
                    else if (dTemp > Color - 1) iTemp = Color - 1;
                    else iTemp = (int)dTemp;
                    byteArray[j + i * width] = (byte)iTemp;
                }
            }
            int k;
            for (k = 0; k < ROICount;k++)
            {
                Console.WriteLine("draw roi: " + k);
                int hBoxDim = hBoxEnd[k] - hBoxStart[k] + 1;
                int vBoxDim = vBoxEnd[k] - vBoxStart[k] + 1;
                int hOffset = hBoxStart[k] - hstart;
                int vOffset = vBoxStart[k] - vstart;
                double H = Math.Ceiling((double)(hBoxDim * width) / (double)hDim);
                double V = Math.Ceiling((double)(vBoxDim * width) / (double)vDim);
                double dimHH = (double)(hBoxDim * width / hDim);  // Dimensions of the box are fixed
                double dimVV = (double)(vBoxDim * height / vDim);
                int dimH = (int)H;// Dimensions of the box are fixed          

                int dimV = (int)V;
                int xPos, yPos;
                xPos = (int)(((hOffset)) * HH);
                yPos = (int)(((vOffset)) * VH);
                for (i = yPos; i < yPos + dimV; i++)
                {
                    for (j = xPos; j < xPos + dimH; j++)
                    {
                        if (i == yPos || j == xPos || i == yPos + dimV - 1 || j == xPos + dimH - 1)
                            byteArray[j + i * width] = (byte)0;
                    }
                }
            }






            Size sizeImg = new Size(400, 400);
            GCHandle pinnedArray = GCHandle.Alloc(byteArray, GCHandleType.Pinned);
            IntPtr dataPtr = pinnedArray.AddrOfPinnedObject();
            pictureBox1.Size = new Size(400, 400);
            this.Controls.Add(pictureBox1);
            Bitmap flag = new Bitmap(width, height, width, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, dataPtr);    //Format8bppIndexed
            Image8Bit img = new Image8Bit(flag);
            img.MakeGrayscale();
            img.Dispose();
            Bitmap b = new Bitmap(sizeImg.Width, sizeImg.Height);
            using (Graphics gr = Graphics.FromImage(b))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                // gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(flag, new Rectangle(0, 0, sizeImg.Width, sizeImg.Height));
            }


            pictureBox1.Image = b;
            pictureBox1.Refresh();
            pinnedArray.Free();
            // abortCont = false;
            // bw.RunWorkerAsync();
        }
        void writeToFile()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\localadmin\Desktop\TestData\Raw.txt", true))
            {
                for (int i = 0; i < fluorescenceData.GetLength(0); i++)
                {
                    file.Write(i * freqStep + freqStart);
                    for (int j = 0; j < fluorescenceData.GetLength(1); j++)
                    {
                        file.Write("\t" + fluorescenceData[i, j] + "\t");
                    }
                    file.WriteLine();
                }
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\localadmin\Desktop\TestData\Processed.txt", true))
            {
                for (int i = 0; i < spectrumData.GetLength(1); i++)
                {
                    file.Write(i * freqStep + freqStart);
                    for (int j = 0; j < spectrumData.GetLength(0); j++)
                    {
                        file.Write("\t" + spectrumData[j, i] + "\t");
                    }
                    file.WriteLine();
                }
            }
        }
        void writeToFileSimple()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\localadmin\Desktop\TestData\Raw.txt", true))
            {
                for (int i = 0; i < fluorescenceData.GetLength(0); i++)
                {
                    file.Write(i * freqStep + freqStart);
                    for (int j = 0; j < fluorescenceData.GetLength(1); j++)
                    {
                        file.Write("\t" + fluorescenceData[i, j] + "\t");
                    }
                    file.WriteLine();
                }
            }            
        }

        void writeToFileCont()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\localadmin\Desktop\TestData\ContRaw.txt", true))
            {
               
                for (int i = 0; i < fluorescContData.Count; i++)
                {
                    file.Write(i * freqStep + freqStart);
                    for (int j = 0; j < fluorescContData[i].GetLength(0); j++)
                    {
                        file.Write("\t" + fluorescContData[i][j] + "\t");
                    }
                    file.WriteLine();
                }
            }
            errorMsgTxtBox.AppendText("Done saving.");
        }




        private void AbortAcquisition_Click(object sender, EventArgs e)
        {
            abortCont = true;
            bw.CancelAsync();
            myAndor.AbortAcquisition();
            aTimer.Stop();
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // errorMsgTxtBox.AppendText("Hi");
            // Run your while loop here and return result.
           
            AcquireImageDataCont();
        }

        // when you click on some cancel button  

        private void OnTimedEvent(Object source, EventArgs e)
        {

            int[] fluor = getFluorescenceCont();
            for (int i = 0; i < ROICount; i++)
            {
                errorMsgTxtBox.AppendText("Region - "+i+"  Fluorescence: " + fluor[i] +"\r\n");
            }
            drawCameraImageCont();
            //findIons();
            //drawCameraImage();

        }

        private void TempMeasureEvent(Object source, EventArgs e)
        {

            myAndor.GetTemperature(ref temperature);
            temperatureBox.Clear();
            temperatureBox.AppendText("" + temperature);



        }


        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            uint errorValue;
            myAndor.GetTemperature(ref temperature);
            if (temperature < 0)
            {
                if (gblCooler == true)
                {
                    setTemperature = 5;
                    //SwitchCoolerOn();
                    errorMsgTxtBox.AppendText("Raising temperature to above zero (C)");
                    errorMsgTxtBox.AppendText("\r\n Press close again when temp is above zero");
                }
                Console.WriteLine("Cancel quit");
                e.Cancel = true;
                return;
            }

            else
            {
                tempTimer.Stop();
                if ((caps.ulSetFunctions & ATMCD32CS.AndorSDK.AC_SETFUNCTION_TEMPERATURE) != 0)
                {
                    errorValue = myAndor.CoolerOFF();        // Switch off cooler (if used)
                    if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                        MessageBox.Show("Error switching cooler off.",
                 "Error!",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation,
                   MessageBoxDefaultButton.Button1);
                }

                errorValue = myAndor.ShutDown();
                if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                    MessageBox.Show("Error shutting down.",
                 "Error!",
              MessageBoxButtons.OK,
              MessageBoxIcon.Exclamation,
                 MessageBoxDefaultButton.Button1);
            }
        }

        void SwitchCoolerOn()
        {
            int MinTemp=0, MaxTemp=0;
            uint errorValue;


            setTemperature = (int)temperatureUpDown.Value;


            // check if temp is in valid range
            errorValue = myAndor.GetTemperatureRange(ref MinTemp, ref MaxTemp);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                errorMsgTxtBox.AppendText("Temperature Error");
            else
            {
                if (temperature < MinTemp || temperature > MaxTemp)
                    errorMsgTxtBox.AppendText("Temperature is out of range");
                else
                {
                    // if it is in range, switch on cooler and set temp
                    errorValue = myAndor.CoolerON();
                    if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                    {
                        errorMsgTxtBox.AppendText("Could not switch cooler on");
                    }
                    else
                    {
                        gblCooler = true;
                        //SetTimer(hwnd,gblTempTimer,1000,NULL);
                        errorValue = myAndor.SetTemperature(setTemperature);
                        if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                        {
                            errorMsgTxtBox.AppendText("Could not set temperature");
                        }
                        else
                            errorMsgTxtBox.AppendText("Temperature has been set to " + setTemperature + " (C)");
                    }
                }
            }
        }

        void SwitchCoolerOff() {
              uint 		errorValue;   
        //KillTimer(hwnd,gblTempTimer);
              errorValue=myAndor.CoolerOFF();
         if(errorValue!=ATMCD32CS.AndorSDK.DRV_SUCCESS){
             errorMsgTxtBox.AppendText("Could not switch cooler off");
    
          }
          else{
           gblCooler=false;
          errorMsgTxtBox.AppendText("Temperature control is disabled");   
         }
          
        }
                       
       
        private void AddROI_Click(object sender, EventArgs e)
        {
            hBoxStart[ROICount] = (int)hBoxStartUpDown.Value;
            hBoxEnd[ROICount] = (int)hBoxEndUpDown.Value;
            vBoxStart[ROICount] = (int)vBoxStartUpDown.Value;
            vBoxEnd[ROICount] = (int)vBoxEndUpDown.Value;
            if (hBoxStart[ROICount] < hstart)
            {
                hBoxStart[ROICount] = hstart;
            }
            if (hBoxEnd[ROICount] > hend)
            {
                hBoxEnd[ROICount] = hend;
            }
            if (vBoxStart[ROICount] < vstart)
            {
                vBoxStart[ROICount] = vstart;
            }
            if (vBoxEnd[ROICount] > vend)
            {
                vBoxEnd[ROICount] = vend;
            }



            ROICount++;
        }

        private void coolerBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gblCooler == false)
            {
                SwitchCoolerOn();
                gblCooler = true;
            }
            else
            {
                SwitchCoolerOff();
                gblCooler = false;
            }
            
        }

        private void temperatureUpDown_ValueChanged(object sender, EventArgs e)
        {
            setTemperature = (int)temperatureUpDown.Value;
            if (gblCooler == true)
            {
                myAndor.SetTemperature(setTemperature);
            }
        }

        private void saveContData_Click(object sender, EventArgs e)
        {
            if (abortCont == true)
            {
                writeToFileCont();
            }
            else
            {
                errorMsgTxtBox.AppendText("Stop acquisition before saving");
            }
        }
        /*
       private void viewInitiate()
       {

           // Create & fill in metadata
           string[] metadata = new string[23];
           metadata[0] = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss");
           // This is all from the CoreForm
           metadata[1] = "continuous";
           metadata[2] = @"C:\Users\localadmin\Desktop\TestData\Processed.txt";
           metadata[3] = "60";
           metadata[4] = "234";
           metadata[5] = "667";
           metadata[6] = "41";
           metadata[7] = "230";
           metadata[8] = "230";
           metadata[9] = "1";
           metadata[10] = "1";
           metadata[11] = "20";
           metadata[12] = "13";
           // Fill in remaining metadata from form
           metadata[13] = "100";
           metadata[14] = "1";
           metadata[15] = "N/A";
           metadata[16] = "N/A";   // For fixed spectra only
           metadata[17] = "N/A";   // For fixed spectra only

           int numberOfSpectra = 1;
           for (int i = 0; i < numberOfSpectra; i++)
           {
               metadata[i + 18] = "test";
           }

           metadata[18 + numberOfSpectra] = "notes";

           // Retrieve the folder path selected by the user
           string FolderPath = @"C:\Users\localadmin\Desktop\TestData\Processed.txt";
           // Make sure the 
           if (FolderPath != null)
           {
               TextWriter[] myFile;        // Declare array of files

               // If "Continuous" experiment type has been selected
               if (specType == "Continuous")
               {
                   //Turn on frequency generator
                   bIsFreqGenEnabled = true;

                   //Start frequency is the value taken directly from the form, no windowing
                   startFreqArray = new int[1];
                   startFreqArray[0] = startFreq;

                   // Create a single file and put all readings in there
                   myFileName = new string[1];
                   myFile = new TextWriter[1];

                   // Create empty RabiSelector object to pass to writeMetadataToFile (not used)
                   RabiSelector myRabiSelector = new RabiSelector();

                   // Create the file with appropriate name & write metadata to it
                   writeMetadataToFile(ref myExperimentDialog, ref myRabiSelector, ref FolderPath, ref myFile, 1);
               }
               else if (specType == "Windowed")
               {
                   //Turn on frequency generator
                   bIsFreqGenEnabled = true;

                   //Calculate frequency offset of sideband start frequencies from sideband centres
                   int offsetFreq = (int)stepSize * sbWidth / 2;
                   //Determine window spacing from trap frequencys and the type of spectrum selected

                   int windowSpace = 0;
                   if (specDir == "Axial") windowSpace = (int)(axFreq / 2);
                   else if (specDir == "Radial") windowSpace = (int)(modcycFreq / 2);

                   //Array of start frequencies for each sideband (from furthest red to furthest blue)            
                   startFreqArray = new int[sbToScan * 2 + 1];
                   for (int sb = 0; sb < (sbToScan * 2 + 1); sb++)
                   {
                       startFreqArray[sb] = carFreq - offsetFreq - (windowSpace * (sbToScan - sb));
                   }

                   // We want a file for each sideband with appropriate naming
                   // Calculate how many files we will need - one for each R/B sideband plus one for carrier
                   int numberOfFiles = (int)(sbToScan * 2 + 1);
                   // Create array of filenames & array of files
                   myFileName = new string[numberOfFiles];
                   myFile = new TextWriter[numberOfFiles];

                   // Create empty RabiSelector object to pass to writeMetadataToFile (not used)
                   RabiSelector myRabiSelector = new RabiSelector();

                   // Generate filenames and actually create files
                   writeMetadataToFile(ref myExperimentDialog, ref myRabiSelector, ref FolderPath, ref myFile, numberOfFiles);
               }
               else if (specType == "Fixed")
               {
                   // Maybe put a box for user to input which pulses are varied in length

                   //Start frequency is the value taken directly from the form, no windowing
                   startFreqArray = new int[1];
                   startFreqArray[0] = startFreq;

                   // Show form for user to enter details about fixed frequency sequence
                   // (need starting pulse length & step size)
                   RabiSelector myRabiSelector = new RabiSelector();
                   myRabiSelector.generateSequenceButton.Enabled = false;
                   myRabiSelector.pulseSelectBox.Enabled = false;
                   myRabiSelector.repeatsSelect.Enabled = false;
                   myRabiSelector.ShowDialog();

                   // Get starting pulse length & step size from user form
                   fixed_startLength = (int)myRabiSelector.startLengthSelect.Value;
                   fixed_stepSize = (int)myRabiSelector.stepSizeSelect.Value;
                   // Change step size in metadata
                   metadata[9] = fixed_stepSize.ToString();
                   metadata[16] = fixed_startLength.ToString();
                   metadata[17] = myRabiSelector.stepsSelect.Value.ToString();

                   // Create a single file and put all readings in there
                   myFileName = new string[1];
                   myFile = new TextWriter[1];

                   writeMetadataToFile(ref myExperimentDialog, ref myRabiSelector, ref FolderPath, ref myFile, 1);

                   bIsFreqGenEnabled = false;
               }

               // If myViewer is not open
               if (IsViewerOpen)
               {
                   myViewer.Close();
                   IsViewerOpen = false;
               }
               // Create new instance of viewer
               myViewer = new Spectroscopy_Viewer.SpectroscopyViewerForm(ref metadata);
               // Set up event handler to deal with viewer closing - must be done after it is constructed
               myViewer.FormClosing += new FormClosingEventHandler(myViewer_FormClosing);
               // Set up event handler to deal with event raised when pause button on viewer is clicked
               // This should trigger the pause button in the main window
               myViewer.PauseEvent += new SpectroscopyViewerForm.PauseEventHandler(PauseButton_Click);
               // Show viewer
               myViewer.Show();
               // Set boolean  to indicate that viewer is open
               IsViewerOpen = true;

               // Code required to start the experiment running:
               bShouldQuitThread = false;

               GPIB.InitDevice(19);
               GPIB.SetAmplitude(rfAmp);
               GPIB.SetFrequency(startFreq);

               SendSetupFinish();

               // Start experiment
               StartReadingData();
           }
           else
           {
               MessageBox.Show("Error selecting folder. Please try again.");

           }
            

       }
       */
    }
         



}



 


      





       
       


      