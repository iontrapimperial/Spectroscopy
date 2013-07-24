using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            /*if (!FPGA.bUSBPortIsOpen)
            {
                MessageBox.Show("USB Port not open");
                return;
            }*/
           
            string RFtype = "Laser";

           if (sender is System.Windows.Forms.CheckBox)     //this needs resolving
            {
                RFtype = "Laser";
            }
            else if (sender is System.Windows.Forms.RadioButton)       //this also needs resolving
            {
            RFtype = ((RadioButton)sender).Tag.ToString();    //So does this
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
            /*FPGA.SetLasers(LiveLaserBox397B1.Checked,
                           LiveLaserBox397B1.Checked,
                           LiveLaserBox397B1.Checked,
                           LiveLaserBox397B1.Checked,
                           LiveLaserBox397B1.Checked,
                           LiveLaserBox397B1.Checked,
                           LiveLaserBox397B1.Checked,
                           LiveLaserBox397B1.Checked,
                           RFSwitch1State,
                           RFSwitch2State);*/
        }
    }
}
