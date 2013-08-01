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

        public bool RFSwitch1State = false;
        public bool RFSwitch2State = false;

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
                // Create new dialog to get data from user before starting the experiment
                StartExperimentDialog myExperimentDialog = new StartExperimentDialog();
                myExperimentDialog.ShowDialog();
                if (myExperimentDialog.DialogResult != DialogResult.Cancel)
                {
                    string[] metadata = new string[10];
                    
                    int isWindowed = this.SpecTypeBox.SelectedIndex;

                    // If "Continuous" experiment type has been selected
                    if (isWindowed == 0)
                    {
                        // Create a single file and put all readings in there

                        // Want an if statement to check whether an instance of viewer is already open
                        // Create new instance of viewer
                        Spectroscopy_Viewer.SpectroscopyViewerForm myViewer = new Spectroscopy_Viewer.SpectroscopyViewerForm(ref metadata, isWindowed);

                        

                    }
                    else
                    {
                        // Create a file for each sideband with appropriate naming
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
