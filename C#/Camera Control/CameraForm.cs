using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ATMCD32CS;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using ImageProc;
using System.Drawing.Drawing2D;

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
        const int SPI_GETSCREENSAVERRUNNING = 114;  // screensaver running ID
        const int Color = 256;// 65536;                      // Number of colors in the palette
        int hbin, vbin, hstart, hend, vstart, vend, hDim, vDim;
        // Function Prototypes




        /*
        void UpdateDialogWindows();   // refreshes all windows
        void FillRectangle();         // clears paint area
        bool AcquireImageData();      // Acquires data from card
        void PaintDataWindow();       // Prepares paint area on screen
       // bool DrawLines(long ,long); 			// paints data to screen
        int AllocateBuffers();        // Allocates memory for buffers
        long gliStart, gliEnd, gliFreq;
        void getFluorescence(int run);  
        void FreeBuffers();           // Frees allocated memory
        void flourThreshDetect(int threshold);          // Detects whether ion is flourescing based on set threshold
        void PaintImage(long maxValue, long minValue, int Start); //Display data on screen
        void paintGraph(int width, int height);
        //void CreateIdentityPalette(HDC ScreenDC); //Palette for PaintData()
        //BOOL ProcessMessages(UINT message, WPARAM wparam, LPARAM lparam){return FALSE;} // No messages to process in this example
        //void findIons(int noIons, int ionLocations);

        // Ion image processing parameters
      
       
        // Set up acquisition parameters here to be set in common.c *****************
       */
        int[] ionLocations;					// locations of ions that are passed to the drawing function to display on screen
        int[,] fluorescenceData;				// 2D pointer array that will store the fluorenscence data for each ion.
        double[,] spectrumData;
        int[] pImageArray;



        int runCounter;                    //Counts the number of rusn in a multi image run-til-abort acquisition.
        int numIons = 1;						// The number of ions. Used for tracking and spectroscopy.
        int ionSquarePixelDim = 10;			// dimensions of box to be drawn around ions in camera pixels.
        int repeatPos;
        int repeatNum;
        int giNumberLoops;					// number of loops (images) for multi image run-til-abort acquisition
        int giTrigger = 10;					// type of trigger (software or external)
        int acqType;
        int threshold = 235;








        public CameraForm()
        {
            readMode = 4;
            acquisitionMode = 1;
            uint errorValue;
            float speed = 0, STemp;
            int iSpeed, iAD, nAD = 0, index = 0;
            InitializeComponent();
            errorValue = myAndor.Initialize(Directory.GetCurrentDirectory());
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
            errorValue = myAndor.SetVSSpeed(VSnumber);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
            {
                MessageBox.Show("Error Setting VS Speed.",
             "Error!",
               MessageBoxButtons.OK,
              MessageBoxIcon.Exclamation,
              MessageBoxDefaultButton.Button1);
            }

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

            errorValue = myAndor.SetADChannel(ADnumber);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
            {
                MessageBox.Show("Error setting ADC Channel.",
             "Error!",
               MessageBoxButtons.OK,
              MessageBoxIcon.Exclamation,
              MessageBoxDefaultButton.Button1);
            }

            errorValue = myAndor.SetHSSpeed(0, HSnumber);
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

            errorValue = myAndor.ShutDown();
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                MessageBox.Show("Error shutting down.",
            "Error!",
              MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button1);



        }

        private void CameraForm_Load(object sender, EventArgs e)
        {

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
            gblData = true;
            vbin = 1;
            hbin = 1;
            hstart = (int)horStartUpDown.Value;
            hend = (int)horEndUpDown.Value;
            vstart = (int)verStartUpDown.Value;
            vend = (int)vertEndUpDown.Value;
            hDim = (hend - hstart + 1) / hbin; // sets horizontal dimension
            vDim = (vend - vstart + 1) / vbin;// sets vertical dimension


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
                giTrigger = 1;
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

            errorValue = myAndor.SetAcquisitionMode(acquisitionMode);
            if (errorValue != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                MessageBox.Show("Error setting acquisition mode.",
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
                // Starting the acquisition also starts a timer which checks the card status
                // When the acquisition is complete the data is read from the card and
                // displayed in the paint area.

                if (acqType == 0)
                {
                    ionLocations = new int[numIons];
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
                    else
                    {
                        errorMsgTxtBox.AppendText("Starting Acquisition" + "\r\n");
                        AcquireImageData();
                        // SetTimer(hwnd,timer,100,NULL);
                    }
                    myAndor.AbortAcquisition();
                }




                if (acqType == 1)
                {
                    ionLocations = new int[numIons];
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
                    else
                    {
                        errorMsgTxtBox.AppendText("Starting Acquisition" + "\r\n");
                        //SetTimer(hwnd,timer,100,NULL);
                        for (i = 0; i < repeatNum; i++)
                        {
                            //AcquireImageDataMulti();
                            repeatPos++;
                        }
                        myAndor.AbortAcquisition();
                        //KillTimer(hwnd,timer);
                        //paintGraph(400,300);
                        //  free(spectrumData);
                        //spectrumData=NULL;
                    }
                }
            }
        }// end of set system

        bool AcquireImageData()
        {
            uint size;
            uint errorValue;
            long MaxValue;
            long MinValue;
            int i;
            size = (uint)(hDim * vDim);
            //CreateBitmapAtRuntime();
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

            }

            MaxValue=1;
            MinValue=65536;
           
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







            
            modrange     = MaxValue - MinValue;
              width        = 400;//rect.right - rect.left + 1;
            while(width%4!=0||width%hDim!=0)                 // width must be a multiple of 4 and the width should be divisble by the number of horizontal pixels
                 width ++;// (4-width%4);
             height       = width;//rect.bottom - rect.top + 1;
              xscale       = (float)(hDim)/(float)(width);
             yscale       = (float)(256.0)/(float)modrange;
                zscale       = (float)(vDim)/(float)(height);

            
            int dimH = (int) (Math.Ceiling((double)ionSquarePixelDim*width/hDim));  // Dimensions of the box are fixed
            int dimV = (int) (Math.Ceiling((double)ionSquarePixelDim*height/vDim));
            double dimHH = (double)(ionSquarePixelDim * width / hDim);  // Dimensions of the box are fixed
            double dimVV = (double)(ionSquarePixelDim * height / vDim);    
             byte[] byteArray = new byte[width*height];
             byte[] boxDataArray = new byte[dimH * dimV];
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
             
             for (i = 0; i < dimH; i++)
             {
                 for (j = 0; j < dimV; j++)
                 {
                     if (i == 0 || j == 0 || i == dimH - 1 || j == dimV - 1)// iTemp = 200;
                         boxDataArray[j + i * dimH] = (byte) 0;
                     else boxDataArray[j + i * dimH] = (byte)255; 
                     //printf("%d  ", BoxDataArray[j + i*ionSquarePixelDim]);
                 }

             }


             int xPos, yPos;
             xPos = (int) ((ionLocations[0] % (hDim - (ionSquarePixelDim - 1))) * (dimHH /ionSquarePixelDim));  // defines the x position from the ionLocations
             yPos = (int) ((ionLocations[0] / (hDim - (ionSquarePixelDim - 1))) * (dimVV /ionSquarePixelDim));// defines the y position from the ionLocations


            Size sizeImg = new Size(400, 400);
            GCHandle pinnedArray = GCHandle.Alloc(byteArray, GCHandleType.Pinned);
            GCHandle pinnedArray2 = GCHandle.Alloc(boxDataArray, GCHandleType.Pinned);
            IntPtr dataPtr = pinnedArray.AddrOfPinnedObject();
            IntPtr sqrPtr = pinnedArray2.AddrOfPinnedObject();
            // Do your stuff...
            pictureBox1.Size = new Size(400, 400);
            this.Controls.Add(pictureBox1);
            Bitmap flag = new Bitmap(width, height,width, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, dataPtr);    //Format8bppIndexed
            Image8Bit img = new Image8Bit(flag);
            img.MakeGrayscale();
            img.Dispose();            
            Bitmap b = new Bitmap(sizeImg.Width, sizeImg.Height);
            Bitmap square = new Bitmap(dimH, dimV, dimH, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, sqrPtr);
            using (Graphics gr = Graphics.FromImage(b))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                //gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(flag, new Rectangle(0, 0, sizeImg.Width, sizeImg.Height));
                square.MakeTransparent(System.Drawing.Color.White);
                gr.DrawImage((Image)square, xPos, yPos);
            }
            pictureBox1.Image = b;
            pinnedArray.Free();
            pinnedArray2.Free();
          
           
           // 
           // Bitmap square = new Bitmap(squareSize, squareSize, squareSize, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, sqrPtr);
            
           // square.MakeTransparent();
            
            
            
            return true;
        }

        /*
        bool AcquireImageDataMulti()
        {
            uint size;
            uint errorValue;
            long MaxValue;
            long MinValue;
            int i;

            runCounter = 0;
            size = (uint)(hDim * vDim);
            fluorescenceData = new int[giNumberLoops, numIons];





            // Loop over multiple image acquisitions
            for (i = 0; i < giNumberLoops; i++)
            {

                if (giTrigger == 10)
                    myAndor.SendSoftwareTrigger();    // PHYSICAL CAMERA ACQUISITION STARTS      
                myAndor.WaitForAcquisition();       // THREAD RESUMES FROM SLEEP AT THE END OF ACQUISITION
                // WaitForAcquisitionTimeOut(200);

                if (myAndor.GetMostRecentImage(pImageArray, size) != ATMCD32CS.AndorSDK.DRV_SUCCESS)
                {                 // ACQUISITION PERFORMED HERE!!
                    errorMsgTxtBox.AppendText("Acquisition Error" + "\r\n");

                    i = giNumberLoops;
                }
                else
                {
                    errorMsgTxtBox.AppendText("Got Image: " + i + "\r\n");
                }

                //if(i==0) findIons(numIons,ionLocations);


                // getFluorescence(i);


                for (j = 0; j < numIons; j++)
                {
                    errorMsgTxtBox.AppendText("FlourDetec  " + fluorescenceData[i, j]);
                }
                // Display data and query max data value to be displayed in status box

                /*
            for(j=0;j<numIons;j++){
               flourThreshDetect(threshold);
              }*/
                /*
                if(!DrawLines(&MaxValue,&MinValue)){

                  KillTimer(hwnd,timer);
                  wsprintf(aBuffer, "Data range is zero");
                  SendMessage(ebStatus,WM_SETTEXT,0,(LPARAM)(LPSTR)aBuffer);
                  return FALSE;
                }
                 
                runCounter++;
            }
            //flourThreshDetect(threshold);

            return true;
        }
        */
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
            if (gblData==true && pImageArray != null)
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
                    errorMsgTxtBox.AppendText("Ion " + ionsFound + " at position  " + maxIndex + " with counts "+ maxValue+ "\n");  
                   
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
                fluorescenceData[runCounter,i] = 0;
                for (j = 0; j < ionSquarePixelDim; j++)
                { // this loop augments the vertical position
                    for (k = ionLocations[i]; k < ionSquarePixelDim + ionLocations[i]; k++)
                    { // This loop always scans horizontally by the box dimension
                        fluorescenceData[runCounter,i] += pImageArray[(ionSquarePixelDim - 1) * (ionLocations[i] / gridLength) + j * hDim + k];
                    } // j*hDim moves to the next line at, while the bit before is to force the skipping of boxes that try to loop over edges.
                }
            }

        }


        void flourThreshDetect(int threshold)
        {
            int i, j, flourCount;
            for (i = 0; i < numIons; i++)
            {
                flourCount = 0;
                for (j = 0; j < giNumberLoops; j++)
                {
                    if (fluorescenceData[j,i] > threshold)
                        flourCount++;
                }
                double exc = (double)flourCount / giNumberLoops;
                errorMsgTxtBox.AppendText("The ion number: " + i + " has been fractionally excited  " + exc + "\n");                 
                spectrumData[i,repeatPos - 1] = exc;

            }


        }
       

        







    }
}


 


      





       
       


      