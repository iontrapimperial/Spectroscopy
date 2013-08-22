using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using System.Math;
using Spectroscopy_Viewer;



namespace Spectroscopy_Controller
{
    public partial class CoreForm : Form
    {
        // Store viewer as a private member - we can then access it from different parts of the program (need access from FPGAcontrols)
        private SpectroscopyViewerForm myViewer;


        // This has to be a member since we cannot pass parameters to FPGAReadMethod (due to threading)
        // Array of file names for data files
        string[] myFileName;



        TreeNode PreviewNode = new TreeNode();
        //TemplateSelector TemplateForm;

        private bool PauseExperiment = false;

        private bool bIsFreqGenEnabled = false;

        private bool IsViewerOpen = false;

        public bool updating = false;

        //Logic to select which source is used for 729 via RF switches
        private bool RFSwitch1State = false;
        private bool RFSwitch2State = false;
        
        //Trap and ion parameters
        private float dnought = 0.0189F;
        private float bField = 1.845F;
        private float ionmass = 40;
        private float ioncharge = 1;
        private int angtruecycFreq;
        private float stabilitylimit;
        private float pi = 3.1415927F;
        private float emratio = 0.9648533E8F;//(=1/1.036427E-8F);
 
        //Scan parameters for given run (taken from user selected values on form)
        private string specType, specDir;
        private int axFreq, modcycFreq, magFreq, startFreq, carFreq, stepSize, sbToScan, sbWidth;//, axFreqTemp, modcycFreqTemp;
        private float trapV, angaxFreq, angmodcycFreq, angmagFreq, rfAmp;
        // Parameters for a fixed frequency run
        private int fixed_startLength, fixed_stepSize;

        private int[] startFreqArray;

        public CoreForm()
        {   
            InitializeComponent();

            specTypeBox.SelectedItem = "Continuous";
            specDirBox.SelectedItem = "Axial";

            angtruecycFreq = (int)(emratio * ioncharge * bField / ionmass);
            stabilitylimit = dnought * dnought * bField * bField * ioncharge * emratio / 8 / ionmass;
            trapV = 80000;
            UpdateTrapFreqs();

            // Set up event handler to deal with this form closing                
            this.FormClosing += new FormClosingEventHandler(this.OnFormClosing);

            StopButton.Enabled = false;
            PauseButton.Enabled = false;
        }


        #region Laser control methods

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
                    break; 
               case "Spec":
                    RFSwitch1State = false;
                    RFSwitch2State = false;
                    SB1RFSourceButton.Checked = false;
                    SB2RFSourceButton.Checked = false;
                    SB3RFSourceButton.Checked = false;                              
                    SetOutputs();
                    break; 
               case "SB1":
                    RFSwitch1State = true;
                    RFSwitch2State = false;
                    SpecRFSourceButton.Checked = false;
                    SB2RFSourceButton.Checked = false;
                    SB3RFSourceButton.Checked = false;
                    SetOutputs();
                    break; 
               case "SB2":
                    RFSwitch1State = false;
                    RFSwitch2State = true;
                    SpecRFSourceButton.Checked = false;
                    SB1RFSourceButton.Checked = false;
                    SB3RFSourceButton.Checked = false;
                    SetOutputs();
                    break; 
               case "SB3":
                    RFSwitch1State = true;
                    RFSwitch2State = true;
                    SpecRFSourceButton.Checked = false;
                    SB1RFSourceButton.Checked = false;
                    SB2RFSourceButton.Checked = false;
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

        #endregion

        // Method to handle form closing
        //Clean up any threads left running
        private void OnFormClosing(object sender, EventArgs e) 
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
        }

        #region Methods defined in FPGAControls.cs

        private void OpenUSBButton_Click(object sender, EventArgs e)
        {
            OpenUSBPort();       
        }

        #endregion
      
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

        #endregion

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

        private int tickRounder()
        {
            //Find nearest number of integer ticks (640ns per tick) to desired pulse length
            int roundedTicks = (int)(TicksBox.Value * 1000 / 640);
            //Console.WriteLine(roundedTicks);
            //Calculate rounded pulse length and display on form
            float roundedLength = (float)(roundedTicks * 0.64);
            string roundedLengthString = roundedLength.ToString("0.##");
            TimeLabel.Text = "Length = " + roundedLengthString + "us";

            return roundedTicks;
        }

        private void TicksBox_ValueChanged(object sender, EventArgs e)
        {
            tickRounder();
        }

        #endregion
              
        #region Methods defined in HexFileIO.cs

        private void BinaryCompileButton_Click(object sender, EventArgs e)
        {
            saveHexFileDialog.ShowDialog();
        }

        private void saveHexFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            SaveHexFile();
        }

        private void UploadButton_Click(object sender, EventArgs e)
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
                   /*
        private void sendBinaryFileStartSignalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sendBinaryFileOnlyToolStripMenuItem_Click(null, null);
            sendStartSignalToolStripMenuItem_Click(null, null);
        }            */


        #endregion        

        /*private void CreateFromTemplateButton_Click(object sender, EventArgs e)
        {            
            TemplateForm.ShowDialog();            
        }*/

        private void StopButton_Click(object sender, EventArgs e)
        {
            // Signal to stop the experiment
            bShouldQuitThread = true;
            // Print message to user
            WriteMessage("Experiment stopped by user\r\n");
            // Call method to deal with enabling/disabling buttons etc
            this.ExperimentFinished();
            this.Reset();           // Reset
        }

        
        // Threadsafe method to enable/disable appropriate buttons & inform viewer when experiment is finished
        // This gets called from inside FPGAcontrols
        delegate void Delegate_ExperimentFinished();
        private void ExperimentFinished()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Delegate_ExperimentFinished(ExperimentFinished));
            }
            else
            {
                
                StartButton.Enabled = true;     // Enable start button
                OpenUSBButton.Enabled = true;   // Enable open USB button                        
                StopButton.Enabled = false;     // Disable stop button
                PauseButton.Enabled = false;    // Disable pause button

                if (IsViewerOpen)
                {
                    myViewer.StopRunningLive();
                }
            }
        }


        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.Reset();
            this.ExperimentFinished();
        }

        private void Reset()
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
                PauseExperiment = false;        // Set flag
                PauseButton.Enabled = true;     // Re-enable pause button
                StartButton.Enabled = false;    // Disable start button
                OpenUSBButton.Enabled = false;  // Disable open USB button
            }
            else
            {   // Otherwise, start experiment
                this.Reset();       // Reset first

                if (FPGA.bUSBPortIsOpen == false)
                {
                    WriteMessage("Can't Send Start Signal to FPGA: USB port is not open", true);
                    return;
                }
                else
                {
                    //Grab all scan and trap parameters from form:
                    specType = specTypeBox.SelectedItem.ToString();
                    specDir = specDirBox.SelectedItem.ToString();
                    trapV = (float)(1000 * trapVBox.Value);   //Trap voltage stored in millivolts
                    axFreq = (int)(1000 * axFreqBox.Value);
                    modcycFreq = (int)(1000 * modcycFreqBox.Value);
                    magFreq = (int)(1000 * magFreqBox.Value);
                    startFreq = (int)(1000000 * startFreqBox.Value);
                    carFreq = (int)(1000000 * carFreqBox.Value);
                    stepSize = (int)(1000 * stepSizeBox.Value);
                    sbToScan = (int)sbToScanBox.Value;
                    sbWidth = (int)sbWidthBox.Value;
                    rfAmp = (float)rfAmpBox.Value;
                    
                    // Metadata ordering in array:
                    // 0: Date
                    // 1: Spectrum type
                    // 2: 729 direction
                    // 3: Trap voltage
                    // 4: Axial freq (kHz)
                    // 5: Modified cyc freq (kHz)
                    // 6: Magnetron freq (kHz)
                    // 7: AOM start freq (MHz)
                    // 8: Carrier freq (MHz)
                    // 9: Step size (kHz or ticks)
                    // 10: Sidebands/side
                    // 11: Sideband width (steps)
                    // 12: 729 RF amplitude
                    // 13: Number of repeats
                    // 14: Number interleaved
                    // 15: Which sideband
                    // 16: Starting pulse length (fixed)
                    // 17: Number of steps (fixed)
                    // 18 + i: spectrum i name


                    

                    // Create new dialog to get data from user before starting the experiment
                    StartExperimentDialog myExperimentDialog = new StartExperimentDialog();
                    myExperimentDialog.ShowDialog();
                    if (myExperimentDialog.DialogResult != DialogResult.Cancel)
                    {
                        // Create & fill in metadata
                        string[] metadata = new string[23];
                        metadata[0] = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss");
                        // This is all from the CoreForm
                        metadata[1] = specType;
                        metadata[2] = specDir;
                        metadata[3] = this.trapVBox.Value.ToString();
                        metadata[4] = this.axFreqBox.Value.ToString();
                        metadata[5] = this.modcycFreqBox.Value.ToString();
                        metadata[6] = this.magFreqBox.Value.ToString();
                        metadata[7] = this.startFreqBox.Value.ToString();
                        metadata[8] = this.carFreqBox.Value.ToString();
                        metadata[9] = this.stepSizeBox.Value.ToString();
                        metadata[10] = this.sbToScanBox.Value.ToString();
                        metadata[11] = this.sbWidthBox.Value.ToString();
                        metadata[12] = this.rfAmpBox.Value.ToString();
                        // Fill in remaining metadata from form
                        metadata[13] = myExperimentDialog.NumberOfRepeats.Value.ToString();
                        metadata[14] = myExperimentDialog.NumberOfSpectra.Value.ToString();
                        metadata[15] = "N/A";
                        metadata[16] = "N/A";   // For fixed spectra only
                        metadata[17] = "N/A";   // For fixed spectra only

                        int numberOfSpectra = (int)myExperimentDialog.NumberOfSpectra.Value;
                        for (int i = 0; i < numberOfSpectra; i++)
                        {
                            metadata[i + 18] = myExperimentDialog.SpectrumNames[i].Text;
                        }

                        metadata[18 + numberOfSpectra] = myExperimentDialog.NotesBox.Text;


                        // Retrieve the folder path selected by the user
                        string FolderPath = myExperimentDialog.getFilePath();
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
                                int offsetFreq = (int)stepSize*sbWidth/2;
                                //Determine window spacing from trap frequencys and the type of spectrum selected

                                int windowSpace = 0;
                                if (specDir == "Axial") windowSpace = (int)axFreq;
                                else if (specDir == "Radial") windowSpace = (int)modcycFreq;

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
                        }
                        else
                        {
                            MessageBox.Show("Error selecting folder. Please try again.");
                        }

                        // Code required to start the experiment running:
                        bShouldQuitThread = false;
                                                
                        GPIB.InitDevice(19);
                        GPIB.SetAmplitude(rfAmp);
                        GPIB.SetFrequency(startFreq);
                                            
                        SendSetupFinish();

                        // Start experiment
                        StartReadingData();
                        
                    }

                }

            }

        }



        // Method to respond to using clicking Pause button
        private void PauseButton_Click(object sender, EventArgs e)
        {
            // Make sure pause button isn't disabled (since we call this method from several events, not just from pause button)
            if (this.PauseButton.Enabled)
            {
                // Only let it pause if the experiment is running (need to check this)
                if (FPGAReadThread != null && FPGAReadThread.IsAlive)
                {
                    // Flag to pause. This is detected within the FPGARead method (in FPGAControls)
                    PauseExperiment = true;
                    PauseButton.Enabled = false;
                    StartButton.Enabled = true;
                }
            }
        }

        // Method to write the metadata to files
        // Gets filenames from private member myFileName
        private void writeMetadataToFile(   ref StartExperimentDialog myExperimentDialog, ref RabiSelector myRabiSelector,
                                            ref string FolderPath, ref TextWriter[] myFile, int numberOfFiles  )
        {
            // These variables are needed for windowed files only
            // But need to create them anyway else C# will complain...
            //*****************//
            // Store the number sideband we are on
            int sbCurrent = sbToScan;
            // Store whether we are on a red or blue sideband
            char sbRedOrBlue = 'R';
            // Store the current sideband in readable format e.g. 001R
            string sbCurrentString = "";
            //*****************//

            // Go through each file (this will only be run once for continuous & fixed files)
            for (int i = 0; i < numberOfFiles; i++)
            {
                // Generating the current filename:
                //*******************************//
                // This line happens for both continuous & windowed files
                myFileName[i] = FolderPath + @"\" + myExperimentDialog.ExperimentName.Text + "_readings";

                // These bits only need adding to windowed files
                if (specType == "Windowed")
                {
                    myFileName[i] += "_";

                    // Add preceding 0s to keep format of sideband number as XXX
                    if (sbCurrent < 10) sbCurrentString = "00";
                    else if (sbCurrent < 100) sbCurrentString = "0";
                    else sbCurrentString = "";

                    // Add current sideband number to filename
                    sbCurrentString += sbCurrent;
                    // If not on carrier, add R or B
                    if (sbCurrent != 0) sbCurrentString += sbRedOrBlue;

                    // Add string to filename
                    myFileName[i] += sbCurrentString;
                }
                myFileName[i] += ".txt";
                //*******************************//

                // Now we get to actually create the file!
                myFile[i] = new StreamWriter(myFileName[i]);

                //*********************************//
                // Write the metadata to the file
                //
                myFile[i].WriteLine("Spectroscopy data file");
                myFile[i].WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                // Spectrum type
                myFile[i].WriteLine("Spectrum Type:");
                myFile[i].WriteLine(specType);
                // 729 direction
                myFile[i].WriteLine("729 Direction:");
                myFile[i].WriteLine(specDir);
                // Trap voltage
                myFile[i].WriteLine("Trap Voltage (V):");
                myFile[i].WriteLine(this.trapVBox.Value);
                // Axial frequency
                myFile[i].WriteLine("Axial Frequency (kHz):");
                myFile[i].WriteLine(this.axFreqBox.Value);
                // Modified cyc freq
                myFile[i].WriteLine("Modified Cyclotron Frequency (kHz):");
                myFile[i].WriteLine(this.modcycFreqBox.Value);
                // Magnetron freq
                myFile[i].WriteLine("Magnetron Frequency (kHz):");
                myFile[i].WriteLine(this.magFreqBox.Value);
                // AOM start freq
                myFile[i].WriteLine("AOM Start Frequency (MHz):");
                double startFreqMHz = (double)(startFreqArray[i] / 1000000d);       // Calculate in MHz (stored in Hz)
                myFile[i].WriteLine(startFreqMHz);
                // Carrier frequency
                myFile[i].WriteLine("Carrier Frequency (MHz):");
                myFile[i].WriteLine(this.carFreqBox.Value);
                // Step size
                myFile[i].WriteLine("Step Size (kHz or ticks):");
                // For fixed spectra, put in step size of pulse length variation
                if (specType == "Fixed") myFile[i].WriteLine(fixed_stepSize);
                else  myFile[i].WriteLine(this.stepSizeBox.Value);  // Othewise, take from core form
                // Sidebands/side
                myFile[i].WriteLine("Sidebands to scan / side:");
                if (specType == "Windowed") myFile[i].WriteLine(sbToScan);
                else myFile[i].WriteLine("N/A");
                // Sideband width
                myFile[i].WriteLine("Sideband Width (steps):");
                if (specType == "Windowed") myFile[i].WriteLine(sbWidth);
                else myFile[i].WriteLine("N/A");
                // 729 RF amplitude
                myFile[i].WriteLine("729 RF Amplitude (dBm):");
                myFile[i].WriteLine(rfAmp);
                // Number of repeats
                myFile[i].WriteLine("Number of repeats per frequency:");
                myFile[i].WriteLine(myExperimentDialog.NumberOfRepeats.Value);
                // Number interleaved
                myFile[i].WriteLine("File contains interleaved spectra:");
                myFile[i].WriteLine(myExperimentDialog.NumberOfSpectra.Value);
                // Sideband number
                myFile[i].WriteLine("This is sideband:");
                if (specType == "Windowed") myFile[i].WriteLine(sbCurrentString);   // Windowed spectrum, print out readable string
                else myFile[i].WriteLine("N/A");            // Non-windowed spectra, print "N/A" 
                // Fixed spectrum - pulse start length
                myFile[i].WriteLine("Pulse Start Length (fixed freq):");
                if (specType == "Fixed") myFile[i].WriteLine(fixed_startLength);
                else myFile[i].WriteLine("N/A");
                // Fixed spectrum - number of steps
                myFile[i].WriteLine("Number of Steps (fixed freq):");
                if (specType == "Fixed") myFile[i].WriteLine(myRabiSelector.stepsSelect.Value.ToString());
                else myFile[i].WriteLine("N/A");      
                // Name for each spectrum
                for (int j = 0; j < myExperimentDialog.NumberOfSpectra.Value; j++)
                {
                    myFile[i].WriteLine("Spectrum " + (j+1) + " name:");
                    myFile[i].WriteLine(myExperimentDialog.SpectrumNames[j].Text);
                }
                // Notes section
                myFile[i].WriteLine("Notes:");
                myFile[i].WriteLine("#" + myExperimentDialog.NotesBox.Text);
                // Title for data
                myFile[i].WriteLine("Data:");

                // Flush & close the file
                myFile[i].Flush();
                myFile[i].Close();
                //*********************************//

                // For the next filename:
                // Only needs to happen for windowed files
                //*********************//
                if (specType == "Windowed")
                {

                    // If we are still on the red side, just decrease the sideband number
                    if (i < sbToScan) sbCurrent--;
                    else if (i == sbToScan)
                    // If we have reached the carrier
                    {
                        // Change R to B
                        sbRedOrBlue = 'B';
                        // Increase sideband number
                        sbCurrent++;
                    }
                    // If we are on the blue side, just increase the sideband number
                    else sbCurrent++;
                }

            } //End of loop which goes through each file
        }



        private void trapVBox_ValueChanged(object sender, EventArgs e)
        {
            if (updating == false)
            {
                trapV = (float)(1000 * trapVBox.Value);
                if (trapV > 1000 * stabilitylimit - 1) trapV = 1000 * stabilitylimit - 1;
                UpdateTrapFreqs();
            }
        }

        private void axFreqBox_ValueChanged(object sender, EventArgs e)
        {
            if (updating == false)
            {
                angaxFreq = 2 * pi * 1000 * (float)axFreqBox.Value;
                if (angaxFreq > angtruecycFreq / (float)Math.Sqrt(2) - 1) angaxFreq = angtruecycFreq / (float)Math.Sqrt(2) - 1;
                trapV = (float)(1000 * Math.Pow(angaxFreq, 2) * Math.Pow(dnought, 2) * ionmass / ioncharge / emratio / 4);
                UpdateTrapFreqs();
            }
        }

        private void modcycFreqBox_ValueChanged(object sender, EventArgs e)
        {
            if (updating == false)
            {
                angmodcycFreq = 2 * pi * 1000 * (float)modcycFreqBox.Value;
                if (angmodcycFreq > angtruecycFreq) angmodcycFreq = angtruecycFreq;
                else if (angmodcycFreq < angtruecycFreq / 2 + 1000) angmodcycFreq = angtruecycFreq / 2 + 1000;
                trapV = (float)((1000 * Math.Pow(dnought, 2) * ionmass / ioncharge / emratio / 2) * (angtruecycFreq * angmodcycFreq - Math.Pow(angmodcycFreq, 2)));
                UpdateTrapFreqs();
            }
        }

        private void magFreqBox_ValueChanged(object sender, EventArgs e)
        {
            if (updating == false)
            {
               angmagFreq = (int)(2 * pi * 1000 * (float)(magFreqBox.Value));
               if (angmagFreq > angtruecycFreq / 2 - 1000) angmagFreq = angtruecycFreq / 2 - 1000;
               trapV = (float)((1000 * Math.Pow(dnought, 2) * ionmass / ioncharge / emratio / 2) * (angtruecycFreq * angmagFreq - Math.Pow(angmagFreq, 2)));
               UpdateTrapFreqs();
            }
        }

        private void UpdateTrapFreqs()
        {
            updating = true;
            angaxFreq = (float)(Math.Sqrt(4 * emratio * ioncharge * trapV / 1000 / ionmass / Math.Pow(dnought,2) ) );
            angmagFreq = (float)((angtruecycFreq - Math.Sqrt(Math.Pow(angtruecycFreq,2) - 2 * Math.Pow(angaxFreq,2) ) ) / 2);
            angmodcycFreq = (float)((angtruecycFreq + Math.Sqrt(Math.Pow(angtruecycFreq, 2) - 2 * Math.Pow(angaxFreq,2) ) ) / 2);
            axFreqBox.Value = (decimal)(angaxFreq/1000/2/pi);
            magFreqBox.Value = (decimal)(angmagFreq/1000/2/pi);
            modcycFreqBox.Value = (decimal)(angmodcycFreq/1000/2/pi);
            trapVBox.Value = (decimal)(trapV / 1000);
            updateWindowParam();
            updating = false;
        }

        private void specTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            specType = specTypeBox.SelectedItem.ToString();
            if (specType == "Fixed")
            {
                startFreqBox.Enabled = true;
                carFreqBox.Enabled = false;
                stepSizeBox.Enabled = false;
                sbToScanBox.Enabled = false;
                sbWidthBox.Enabled = false;
            }
            if (specType == "Continuous")
            {
                startFreqBox.Enabled = true;
                carFreqBox.Enabled = false;
                stepSizeBox.Enabled = true;
                sbToScanBox.Enabled = false;
                sbWidthBox.Enabled = false;
            }
            if (specType == "Windowed")
            {
                startFreqBox.Enabled = false;
                carFreqBox.Enabled = true;
                stepSizeBox.Enabled = true;
                sbToScanBox.Enabled = true;
                sbWidthBox.Enabled = true;
                updateWindowParam();
            }
        }

        private void sbWidthBox_ValueChanged(object sender, EventArgs e)
        {
            updateWindowParam();
        }

        private void sbToScanBox_ValueChanged(object sender, EventArgs e)
        {
            updateWindowParam();
        }

        private void carFreqBox_ValueChanged(object sender, EventArgs e)
        {
            updateWindowParam();
        }

        private void stepSizeBox_ValueChanged(object sender, EventArgs e)
        {
            updateWindowParam();
        }
        
        private void specDirBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateWindowParam();
        }

        private void updateWindowParam()
        {
            string specTypeTemp = specTypeBox.SelectedItem.ToString();
            string specDirTemp = specDirBox.SelectedItem.ToString();

            if (specTypeTemp == "Windowed")
            {
                int windowSpaceTemp = 0;
                if (specDirTemp == "Axial") windowSpaceTemp = (int)(1000 * axFreqBox.Value);
                else if (specDirTemp == "Radial") windowSpaceTemp = (int)(1000 * modcycFreqBox.Value);
                int offsetFreq = (int)(1000 * stepSizeBox.Value * sbWidthBox.Value / 2);
                startFreqBox.Value = (decimal)(((1000000 * carFreqBox.Value) - (windowSpaceTemp * sbToScanBox.Value) - offsetFreq) / 1000000);
            }

        }

        private void OpenViewerButton_Click(object sender, EventArgs e)
        {
            if (!IsViewerOpen)
            {
                OpenViewer();
            }            
        }

        private void OpenViewer()
        {
            // Create new instance of viewer (blank)
            myViewer = new Spectroscopy_Viewer.SpectroscopyViewerForm();
            // Set up event handler for form closing - this must be done after it is constructed
            myViewer.FormClosing += new FormClosingEventHandler(myViewer_FormClosing);
            // Set up event handler to deal with event raised when pause button on viewer is clicked
            // This should trigger the pause button in the main window
            myViewer.PauseEvent += new SpectroscopyViewerForm.PauseEventHandler(PauseButton_Click);
            // Show viewer
            myViewer.Show();
            // Set boolean indicating that the viewer is now open
            IsViewerOpen = true;
        }


        private void myViewer_FormClosing(object sender, EventArgs e)
        {
            IsViewerOpen = false;

            // If viewer dialog result indicates that we should restart the form
            if (myViewer.DialogResult == DialogResult.Retry)
            {
                // Re-open form
                OpenViewer();   
            }
        }

        private void CoreForm_KeyDown(object sender, KeyEventArgs e)
        {
            // If the space bar has been pressed
            if (e.KeyCode == Keys.Space)
            {
                // Press pause button
                this.PauseButton_Click(sender, e);
            }
        }


        private void CreateFromTemplateButton_Click(object sender, EventArgs e)
        {
            RabiSelector myRabiSelector = new RabiSelector(PulseTree.Nodes);
            myRabiSelector.ShowDialog();

            TreeView newPulseTree = new TreeView();

            // Grab sweep parameters from form
            int startLength = (int)myRabiSelector.startLengthSelect.Value;
            int stepSize = (int)myRabiSelector.stepSizeSelect.Value;
            int steps = (int)myRabiSelector.stepsSelect.Value;
            int repeats = (int)myRabiSelector.repeatsSelect.Value;

            int pulseLength = new int();

            // If the user pressed OK, create the Rabi-type sequence using data from form
            if (myRabiSelector.DialogResult == DialogResult.OK)
            {
                LoopState[] myLoopStates = new LoopState[steps];
                TreeNode[] myLoopNodes = new TreeNode[steps];
                LaserState[] myLaserStates = new LaserState[steps];
                TreeNode[] myLaserNodes = new TreeNode[steps];


                // For each step
                for (int i = 0; i < steps; i++)
                {
                    // Calculate pulse length
                    pulseLength = startLength + i * stepSize;
                    Console.WriteLine("Adding loop ({0} ticks)", pulseLength);
                    // Add a new loop with this pulse length
                    addRabiLoop(newPulseTree, myLoopStates[i], myLoopNodes[i], myLaserStates[i], myLaserNodes[i], pulseLength, repeats);

                }
            }

            // Create 'Stop Experiment' state
            LaserState stop = new LaserState();
            stop.Name = "Stop Experiment";
            stop.StateType = LaserState.PulseType.STOP;
            // Add 'Stop Experiment' state as a node to new pulse tree
            TreeNode stopNode = newPulseTree.Nodes.Add(stop.Name);
            stopNode.Tag = stop;

            // Disable redrawing while we update
            PulseTree.BeginUpdate();
            // Clear old nodes from PulseTree
            PulseTree.Nodes.Clear();
            // Clone nodes from newPulseTree into main PulseTree control
            for (int i = 0; i < newPulseTree.Nodes.Count; i++)
            {
                PulseTree.Nodes.Add((TreeNode)newPulseTree.Nodes[i].Clone());
            }

            PulseTree.CollapseAll();
            PulseTree.EndUpdate();      // Re-enable redrawing
        }

        private void addRabiLoop(TreeView newPulseTree,LoopState loop, TreeNode loopNode,
                                    LaserState oldState, TreeNode laserNode, int pulseLength, int repeats)
        {
            // Create loop state for this pulse length
            loop = new LoopState();
            loop.Name = "Pulse length: " + (float)pulseLength * 0.64 / 1000 + "ms";
            loop.LoopCount = repeats;
            loop.bIsFPGALoop = true;            // Always make it an FPGA loop  

            // Add loop to top level of nodes on new pulse tree
            loopNode = newPulseTree.Nodes.Add(loop.Name);
            loopNode.Tag = loop;
            // Select the loop node so that we can add children to it
            newPulseTree.SelectedNode = loopNode;

            LaserState[] newState = new LaserState[PulseTree.Nodes.Count];

            for (int i = 0; i < PulseTree.Nodes.Count; i++)
            {
                newState[i] = new LaserState();

                oldState = (LaserState)PulseTree.Nodes[i].Tag;
                copyState(oldState, newState[i]);
                // If we want to sweep this state, set the pulse length
                if (newState[i].toSweep)
                {
                    // Set correct ticks & target length
                    newState[i].Ticks = pulseLength;
                    newState[i].TargetLength = pulseLength * 640;
                }
                // If not to sweep, just leave it as it is

                // Add the state as a child of the loop
                laserNode = newPulseTree.SelectedNode.Nodes.Add(newState[i].Name);
                laserNode.Tag = newState[i];
            }

            // Create 'Send Data' LaserState
            LaserState sendData = new LaserState();
            sendData.Name = "Send Data";
            sendData.StateType = LaserState.PulseType.SENDDATA;
            // Add 'Send Data' LaserState as a node to new pulse tree
            TreeNode sendDataNode = newPulseTree.Nodes.Add(sendData.Name);
            sendDataNode.Tag = sendData;
        }


        // Copies all the properties of one state into another (without any funny linking!)
        private void copyState(LaserState oldState, LaserState newState)
        {
            newState.Laser397B1 = oldState.Laser397B1;
            newState.Laser397B2 = oldState.Laser397B2;
            newState.Laser729 = oldState.Laser729;
            newState.Laser729RF1 = oldState.Laser729RF1;
            newState.Laser729RF2 = oldState.Laser729RF2;
            newState.Laser854 = oldState.Laser854;
            newState.Laser854FREQ = oldState.Laser854FREQ;
            newState.Laser854POWER = oldState.Laser854POWER;
            newState.LaserAux1 = oldState.LaserAux1;
            newState.LaserAux2 = oldState.LaserAux2;
            newState.Name = oldState.Name;
            newState.StateType = oldState.StateType;
            newState.TargetLength = oldState.TargetLength;
            newState.Ticks = oldState.Ticks;
            newState.toSweep = oldState.toSweep;
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
