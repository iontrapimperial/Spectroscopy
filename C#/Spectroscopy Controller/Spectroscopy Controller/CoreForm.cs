using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;



namespace Spectroscopy_Controller
{
    public partial class CoreForm : Form
    {
        // Store viewer as a private member - this means we can check if it has been initialised or not without causing a crash
        private Spectroscopy_Viewer.SpectroscopyViewerForm myViewer;

        // This has to be a member since we cannot pass parameters to FPGAReadMethod (due to threading)
        // Array of StreamWriter objects to write file(s)
        // this is accessed by FPGAReadMethod and StartButton_Click
        TextWriter[] myFile;

        private bool PauseExperiment = false;

        //Logic to select which source is used for 729 via RF switches
        private bool RFSwitch1State = false;
        private bool RFSwitch2State = false;

        //Trap and ion parameters
        private float dnought, bField, massunits, truecycfreq;
        //Scan parameters for given run (taken from user selected values on form)
        private string specType, specDir;
        private int trapV, axFreq, modcycFreq, magFreq, startFreq, carFreq, stepSize, sbToScan, sbWidth;
        private float rfAmp;

        private int[] startFreqArray;

        public CoreForm()
        {
            InitializeComponent();
            this.LiveLaserBox397B1.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            this.LiveLaserBox397B2.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            this.LiveLaserBox729.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            this.LiveLaserBox854.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            this.LiveLaserBox854POWER.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            this.LiveLaserBox854FREQ.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            this.LiveLaserBoxAux1.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            this.LiveLaserBoxAux2.CheckedChanged += new System.EventHandler(this.LaserBoxChanged);
            this.SpecRFSourceButton.Click += new System.EventHandler(this.LaserBoxChanged);
            this.SB1RFSourceButton.Click += new System.EventHandler(this.LaserBoxChanged);
            this.SB2RFSourceButton.Click += new System.EventHandler(this.LaserBoxChanged);
            this.SB3RFSourceButton.Click += new System.EventHandler(this.LaserBoxChanged);
        }

        private void SetRFSpecButton_Click(object sender, EventArgs e)
        {
            int Frequency = (int)SpecRFFreq.Value;
            float Amplitude = (float)SpecRFAmp.Value;

            GPIB.InitDevice(19);
            GPIB.SetAmplitude(Amplitude);
            GPIB.SetFrequency(Frequency);
            GPIB.CloseDevice();
        }

        private void SetRFSB1Button_Click(object sender, EventArgs e)
        {
            int Frequency = (int)SB1RFFreq.Value;
            float Amplitude = (float)SB1RFAmp.Value;

            GPIB.InitDevice(20);
            GPIB.SetAmplitude(Amplitude);
            GPIB.SetFrequency(Frequency);
            GPIB.CloseDevice();
        }

        private void SetRFSB2Button_Click(object sender, EventArgs e)
        {
            int Frequency = (int)SB2RFFreq.Value;
            float Amplitude = (float)SB2RFAmp.Value;

            GPIB.InitDevice(21);
            GPIB.SetAmplitude(Amplitude);
            GPIB.SetFrequency(Frequency);
            GPIB.CloseDevice();
        }

        private void SetRFSB3Button_Click(object sender, EventArgs e)
        {
            int Frequency = (int)SB3RFFreq.Value;
            float Amplitude = (float)SB3RFAmp.Value;

            GPIB.InitDevice(22);
            GPIB.SetAmplitude(Amplitude);
            GPIB.SetFrequency(Frequency);
            GPIB.CloseDevice();
        }

        private void LaserBoxChanged(object sender, EventArgs e)
        {

            if (!FPGA.bUSBPortIsOpen)
            {
                MessageBox.Show("USB Port not open");
                return;
            }
           
            string RFtype = "Laser";

           if (sender is System.Windows.Forms.CheckBox)
            {
                RFtype = "Laser";
            }
            else if (sender is System.Windows.Forms.RadioButton)
            {
            RFtype = ((RadioButton)sender).Tag.ToString();
            }

            switch(RFtype)
            {
               case "Laser":
                    SetOutputs();
                    Console.WriteLine("Laser");
                    break; 
               case "Spec":
                    RFSwitch1State = false;
                    RFSwitch2State = false;
                    SB1RFSourceButton.Checked = false;
                    SB2RFSourceButton.Checked = false;
                    SB3RFSourceButton.Checked = false;              
                    Console.WriteLine("Spec");
                    SetOutputs();
                    break; 
               case "SB1":
                    RFSwitch1State = true;
                    RFSwitch2State = false;
                    SpecRFSourceButton.Checked = false;
                    SB2RFSourceButton.Checked = false;
                    SB3RFSourceButton.Checked = false;
                    Console.WriteLine("SB1");
                    SetOutputs();
                    break; 
               case "SB2":
                    RFSwitch1State = false;
                    RFSwitch2State = true;
                    SpecRFSourceButton.Checked = false;
                    SB1RFSourceButton.Checked = false;
                    SB3RFSourceButton.Checked = false;
                    Console.WriteLine("SB2");
                    SetOutputs();
                    break; 
               case "SB3":
                    RFSwitch1State = true;
                    RFSwitch2State = true;
                    SpecRFSourceButton.Checked = false;
                    SB1RFSourceButton.Checked = false;
                    SB2RFSourceButton.Checked = false;
                    Console.WriteLine("SB3");
                    SetOutputs();
                    break; 
            }
        }

        public void SetOutputs()
        {
            FPGA.SetLasers(LiveLaserBox397B1.Checked,
                           LiveLaserBox397B2.Checked,
                           LiveLaserBox729.Checked,
                           LiveLaserBox854.Checked,
                           RFSwitch1State,
                           RFSwitch2State,
                           LiveLaserBox854POWER.Checked,
                           LiveLaserBox854FREQ.Checked,
                           LiveLaserBoxAux1.Checked,
                           LiveLaserBoxAux2.Checked);
        }

        /*private void OnFormClosing(object sender, EventArgs e) //clean up any threads left running
        {
            if ((BinarySendThread != null) && (BinarySendThread.IsAlive))
            {
                BinarySendThread.Abort();
                BinarySendThread.Join();
            }

            if ((FPGAReadThread != null) && (FPGAReadThread.IsAlive))
            {
                FPGAReadThread.Abort();
                FPGAReadThread.Join();
            }
        } */

        #region Methods defined in FPGAControls.cs

        private void OpenUSBButton_Click(object sender, EventArgs e)
        {
            OpenUSBPort();       
        }

        /*private void StartButton_Click(object sender, EventArgs e)
        {
            if (FPGA.bUSBPortIsOpen == false)
            {
                WriteMessage("Can't Send Start Signal to FPGA: USB port is not open", true);
                return;
            }
            bShouldQuitThread = false;

            int WindowSize = 0;
            int WindowGap = 0;

            if (FreqSelectForm.GetFreqGenEnable())
            {
                bIsFreqGenEnabled = true;
                float Amplitude = FreqSelectForm.GetAmplitude();
                GPIB.InitDevice(Amplitude);
                int Frequency = FreqSelectForm.GetInitialFrequency();
                GPIB.SetFrequency(Frequency);
                if (FreqSelectForm.GetWindowingEnable())
                {
                    bIsWindowingEnabled = true;
                    WindowSize = FreqSelectForm.GetWindowSize();
                    WindowGap = FreqSelectForm.GetSidebandSpacing() - FreqSelectForm.GetWindowSize();                   
                }
                else bIsWindowingEnabled = false;
            }
            else
            {
                bIsFreqGenEnabled = false;
            }

            float FrequencyAmp = FreqSelectForm.GetAmplitude();
            int Frequencystep = FreqSelectForm.GetFreqStep();
            int Frequencystart = FreqSelectForm.GetInitialFrequency();

            ResultsForm.StartConditions(Frequencystart, Frequencystep, FrequencyAmp, bIsWindowingEnabled, WindowSize, WindowGap);

            SendSetupFinish();         
            StartReadingData();
            
        }*/

        #endregion

        /*#region Methods defined in DebugTools.cs

        private void SendDataButton_Click(object sender, EventArgs e)
        {
            SendData();   //defined in DebugTools.cs  
        }

        private void ReadDataButton_Click(object sender, EventArgs e)
        {
            ReadData();  //defined in DebugTools.cs
        }

        #endregion*/

        #region Methods defined in XMLFIleIO.cs


        private void SaveXMLButton_Click(object sender, EventArgs e)
        {
            saveXMLFileDialog.ShowDialog();
        }

        private void saveXMLFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            SaveXMLFile();
        }

        private void OpenXMLButton_Click(object sender, EventArgs e)
        {
            openXMLFileDialog.ShowDialog();
        }

        private void openXMLFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenXMLFile();
        }

        #endregion*/

        #region Methods defined in PulseTree.cs

        private void AddRootButton_Click(object sender, EventArgs e)
        {
            AddNewState(true);
        }

        private void AddChildButton_Click(object sender, EventArgs e)
        {
            AddNewState(false);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            RemoveState();
        }        

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            MoveState(true);
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            MoveState(false);
        }

        private void PulseTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PulseTreeSelect();            
        }

        private void SaveStateButton_Click(object sender, EventArgs e)
        {
            SaveStateFromForm();
        }

        private void AddRootButton_MouseEnter(object sender, EventArgs e)
        {
            ManagePreviewNode(true, true);
        }

        private void AddRootButton_MouseLeave(object sender, EventArgs e)
        {
            ManagePreviewNode(true, false);
        }

        private void AddChildButton_MouseEnter(object sender, EventArgs e)
        {
            ManagePreviewNode(false, true);
        }

        private void AddChildButton_MouseLeave(object sender, EventArgs e)
        {
            ManagePreviewNode(false, false);
        }


        private void TicksBox_ValueChanged(object sender, EventArgs e)
        {
            TimeLabel.Text = "Length: " + ((TicksBox.Value * 20) / (1000000)) + " ms";
        }

        #endregion
              
        /*#region Methods defined in HexFileIO.cs

        private void compileToBinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveHexFileDialog.ShowDialog();
        }

        private void saveHexFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            SaveHexFile();
        }

        private void sendBinaryFileOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FPGA.bUSBPortIsOpen == false)
            {
                WriteMessage("Can't Send Data to FPGA: USB port is not open", true);
                return;
            }

            openHexFileDialog.ShowDialog();
        }

        private void openHexFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            SendBinaryFile();
        }

        private void sendBinaryFileStartSignalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sendBinaryFileOnlyToolStripMenuItem_Click(null, null);
            sendStartSignalToolStripMenuItem_Click(null, null);
        }

        #endregion*/        

        /*private void ChooseFileButton_Click(object sender, EventArgs e)
        {
            saveResultsFileDialog.ShowDialog();
        }

        private void saveResultsFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            FilenameTextbox.Text = saveResultsFileDialog.FileName;
        }

        private void CreateFromTemplateButton_Click(object sender, EventArgs e)
        {            
            TemplateForm.ShowDialog();            
        }*/

        /*private void StopButton_Click(object sender, EventArgs e)
        {
            bShouldQuitThread = true;
        }*/

        /*private void frequencyGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FreqSelectForm.ShowDialog();            
        }*/

        private void ResetButton_Click(object sender, EventArgs e)
        {
            if (FPGA.bUSBPortIsOpen == false)
            {
                WriteMessage("Can't Send Reset Signal to FPGA: USB port is not open", true);
                return;
            }
            if (FPGAReadThread != null && FPGAReadThread.IsAlive)
            {
                bResetFPGA = true;
            }
            else
            {
                FPGA.SendResetSignal();
            }
            
        }

        // Method to respond to user clicking start button
        private void StartButton_Click(object sender, EventArgs e)
        {
            // If we are restarting the experiment after it being paused, just reset the PauseExperiment flag
            if (PauseExperiment == true)
            {
                PauseExperiment = false;
            }
            else
            {   // Otherwise, start experiment

                // Want to:
                //- open dialog for user to specify file name (save file??) & put in metadata - no. of repeats and no. of spectra
                //- open an instance of spectroscopy viewer (if not already open...!) and specify live mode
                //- Pass metadata to viewer
                //- write metadata to file
                //- do all the things that the previous program did to start running the experiment

                if (FPGA.bUSBPortIsOpen == false)
                {
                    WriteMessage("Can't Send Start Signal to FPGA: USB port is not open", true);
                    return;
                }
                else
                {
                    //Grab all scan and trap parameters from form:
                    specType = specTypeBox.SelectedValue.ToString();
                    specDir = specDirBox.SelectedValue.ToString();
                    trapV = (int)(1000000 * trapVBox.Value);
                    axFreq = (int)(1000 * axFreqBox.Value);
                    modcycFreq = (int)(1000 * modcycFreqBox.Value);
                    magFreq = (int)(1000 * magFreqBox.Value);
                    startFreq = (int)(10000000 * startFreqBox.Value);
                    carFreq = (int)(10000000 * carFreqBox.Value);
                    stepSize = (int)(1000 * stepSizeBox.Value);
                    sbToScan = (int)sbToScanBox.Value;
                    sbWidth = (int)(1000 * sbWidthBox.Value);
                    rfAmp = (float)rfAmpBox.Value;
                    
                    // Create new dialog to get data from user before starting the experiment
                    StartExperimentDialog myExperimentDialog = new StartExperimentDialog();
                    myExperimentDialog.ShowDialog();
                    if (myExperimentDialog.DialogResult != DialogResult.Cancel)
                    {
                        string[] metadata = new string[10];


                        // Retrieve the folder path selected by the user
                        string FolderPath = myExperimentDialog.getFilePath();
                        // Make sure the 
                        if (FolderPath != null)
                        {
                                                
                            string[] myFileName;

                            // If "Continuous" experiment type has been selected
                            if (specType == "Continuous")
                            {
                                // Put the metadata into array to pass to viewer
                                // Need to check about trap freq...

                                //Start frequency is the value taken directly from the form, no windowing
                                startFreqArray = new int[1];
                                startFreqArray[0] = startFreq;

                                // Create a single file and put all readings in there
                                myFileName = new string[1];
                                myFileName[0] = FolderPath + @"\" + myExperimentDialog.ExperimentName.Text + "_readings.txt";
                                myFile = new TextWriter[1];
                                myFile[0] = new StreamWriter(myFileName[0]);

                                // Write the metadata to the file
                                /////////////////////////////////////
                                myFile[0].WriteLine("Spectroscopy data file");
                                myFile[0].WriteLine(DateTime.Now.ToString("d/m/yyyy"));
                                // I assume we want to store Axial, Modified Cyc & Magnetron freqs? Need to amend metadata template
                                myFile[0].WriteLine("Trap Frequency:");
                                myFile[0].WriteLine("");
                                //
                                // Trap voltage
                                myFile[0].WriteLine("Trap Voltage:");
                                myFile[0].WriteLine(this.trapVBox.Value);
                                // AOM start freq
                                myFile[0].WriteLine("AOM Start Frequency (MHz):");
                                myFile[0].WriteLine(this.startFreqBox.Value);
                                // Step size
                                myFile[0].WriteLine("Step Size (kHz):");
                                myFile[0].WriteLine(this.stepSizeBox.Value);
                                // Number of repeats
                                myFile[0].WriteLine("Number of repeats per frequency:");
                                myFile[0].WriteLine(myExperimentDialog.NumberOfRepeats.Value);
                                // Number interleaved
                                myFile[0].WriteLine("File contains interleaved spectra:");
                                myFile[0].WriteLine(myExperimentDialog.NumberOfSpectra.Value);

                                // Name for each spectrum
                                for (int i = 0; i < myExperimentDialog.NumberOfSpectra.Value; i++)
                                {
                                    myFile[0].WriteLine("Spectrum " + i + " name:");
                                    myFile[0].WriteLine(myExperimentDialog.SpectrumNames[i].Text);
                                }

                                // Notes section
                                myFile[0].WriteLine("Notes:");
                                myFile[0].WriteLine(myExperimentDialog.NotesBox.Text);

                                // Title for data
                                myFile[0].WriteLine("Data:");




                                // If myViewer is not open
                                if (myViewer == null)
                                {
                                    // Create new instance of viewer
                                    myViewer = new Spectroscopy_Viewer.SpectroscopyViewerForm(ref metadata, IsWindowed);
                                }

                            }
                            else if (specType == "Windowed")
                            {
                                //Calculate frequency offset of sideband start frequencies from sideband centres
                                int offsetFreq = (int)stepSize*sbWidth/2;
                                //Determine window spacing from trap frequencys and the type of spectrum selected
                                int windowSpace;
                                if (specDir == "Axial") windowSpace = axFreq;
                                else if (specDir == "Radial") windowSpace = modcycFreq;

                                //Array of start frequencies for each sideband (from furthest red to furthest blue)            
                                startFreqArray = new int[sbToScan * 2 + 1];
                                for (int sb = 0; sb < (sbToScan * 2 + 1); sb++)
                                {
                                    startFreqArray[sb] = carFreq - offsetFreq - (windowSpace * (sbToScan - sb));
                                }

                                // Create a file for each sideband with appropriate naming

                                // Calculate how many files we will need - one for each R/B sideband plus one for carrier
                                int numberOfFiles = (int)(2 * this.sbToScanBox.Value + 1);

                                myFileName = new string[numberOfFiles];
                                myFile = new TextWriter[numberOfFiles];

                                for (int i = 0; i < numberOfFiles; i++)
                                {
                                    myFileName[i] = FolderPath + @"\" + myExperimentDialog.ExperimentName.Text + "_readings";
                                    // Some if statements here to figure out whether the sideband is R/B & which number it is
                                    // so we can add this to the file name
                                    // Need to know the order of the sidebands to calculate this

                                    myFile[i] = new StreamWriter(myFileName[i]);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error selecting folder. Please try again.");
                        }



                        // Start the experiment running
                        // The following code has been copied from MainForm.cs (method sendStartSignalToolStripMenuItem_Click)
                        /*
                        bShouldQuitThread = false;

                        int WindowSize = 0;
                        int WindowGap = 0;

                        if (FreqSelectForm.GetFreqGenEnable())
                        {
                            bIsFreqGenEnabled = true;
                            float Amplitude = FreqSelectForm.GetAmplitude();
                            GPIB.InitDevice(Amplitude);
                            int Frequency = FreqSelectForm.GetInitialFrequency();
                            GPIB.SetFrequency(Frequency);
                            if (FreqSelectForm.GetWindowingEnable())
                            {
                                bIsWindowingEnabled = true;
                                WindowSize = FreqSelectForm.GetWindowSize();
                                WindowGap = FreqSelectForm.GetSidebandSpacing() - FreqSelectForm.GetWindowSize();
                            }
                            else bIsWindowingEnabled = false;
                        }
                        else
                        {
                            bIsFreqGenEnabled = false;
                        }

                        float FrequencyAmp = FreqSelectForm.GetAmplitude();
                        int Frequencystep = FreqSelectForm.GetFreqStep();
                        int Frequencystart = FreqSelectForm.GetInitialFrequency();

                    
                        SendSetupFinish();
                        StartReadingData();
                        */
                    }

                }

            }

        }

        // Method to respond to using clicking Pause button
        private void PauseButton_Click(object sender, EventArgs e)
        {
            // Flag to pause. This is detected within the FPGARead method (in FPGAControls)
            PauseExperiment = true;
        }


        /*private void fPGAToolStripMenuItem_Click(object sender, EventArgs e)      //Greys out end read thread item when not running
        {
            if (FPGAReadThread != null && FPGAReadThread.IsAlive)
            {
                endReadThreadToolStripMenuItem.Enabled = true;
            }
            else
            {
                endReadThreadToolStripMenuItem.Enabled = false;
            }
        }*/
    }
}
