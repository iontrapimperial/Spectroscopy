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

namespace Camera_Control
{
    public partial class CameraForm : Form
    {
        AndorSDK myAndor = new AndorSDK();
        private int shutter = 1;
        ATMCD32CS.AndorSDK.AndorCapabilities caps;                     // AndorCapabilities structure
        string              model;                // headmodel
        int 							gblXPixels;       				// dims of
        int								gblYPixels;       				// CCD chip
        int               VSnumber;                 // Vertical Speed Index
        int               HSnumber;                 // Horizontal Speed Index
        int               ADnumber;                 // AD Index
        public int acquisitionMode;   // read from xxxxWndw.c
        public int readMode;          // read from xxxxWndw.c
       
        const int SPI_GETSCREENSAVERRUNNING = 114;  // screensaver running ID
        const int Color = 256;                      // Number of colors in the palette
        int 	hbin,vbin,hstart,hend,vstart,vend,hDim,vDim; 
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
        int runCounter;                    //Counts the number of rusn in a multi image run-til-abort acquisition.
        int numIons=1;						// The number of ions. Used for tracking and spectroscopy.
        int ionSquarePixelDim = 10;			// dimensions of box to be drawn around ions in camera pixels.
       // int *ionLocations;					// locations of ions that are passed to the drawing function to display on screen
      //  int **fluorescenceData;				// 2D pointer array that will store the fluorenscence data for each ion.
      //  double **spectrumData;
        int repeatPos;
        int repeatNum;
        int giNumberLoops;					// number of loops (images) for multi image run-til-abort acquisition
        int giTrigger  =10;					// type of trigger (software or external)
        int acqType;
        int threshold = 235; 				 // The threshold for determining whether an ion is bright or not based on count in ion square.
        // Set up acquisition parameters here to be set in common.c *****************
       */
       
        







        public CameraForm()
        {
            readMode = 4; 
            acquisitionMode = 1;
            uint errorValue;            
            float speed = 0, STemp;
            int iSpeed, iAD, nAD =0, index=0;
            InitializeComponent();
            errorValue = myAndor.Initialize(Directory.GetCurrentDirectory());
            if( errorValue!= ATMCD32CS.AndorSDK.DRV_SUCCESS){
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

            if ((caps.ulSetFunctions & ATMCD32CS.AndorSDK.AC_SETFUNCTION_BASELINECLAMP)!=0)
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
        void setSystem(){
            vbin = 1;
            hbin = 1;
            hstart = (int) horStartUpDown.Value;
            hend = (int) horEndUpDown.Value; 
            vstart = (int) verStartUpDown.Value;
            vend = (int) vertEndUpDown.Value;
            hDim = (hend - hstart + 1) / hbin; // sets horizontal dimension
            vDim = (vend - vstart + 1) / vbin;// sets vertical dimension

            System.Diagnostics.Debug.WriteLine(hDim);

        }
      





       
    }
}

      