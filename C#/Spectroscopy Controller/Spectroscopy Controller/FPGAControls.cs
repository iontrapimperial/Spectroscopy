using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Collections.Generic;


namespace Spectroscopy_Controller
{
    public partial class CoreForm : Form
    {
        private void OpenUSBPort()
        {
            int devices = FPGA.CountDevices();
            
            if (devices > 0)
            {
                WriteMessage("Device(s) detected (" + devices + ")");
                FPGA.SelectDevice(0);
                if (FPGA.OpenDevice()) // device successfully connected
                {
                    FPGA.ResetDevice(0);
                    WriteMessage("Device Opened");
                    FPGA.bUSBPortIsOpen = true;

                    //SetUSBPortText(true);
                }
                else
                {
                    WriteMessage("Error: Device would not open", true);
                    FPGA.bUSBPortIsOpen = false;
                    //SetUSBPortText(false);
                }
            }
            else
            {
                FPGA.bUSBPortIsOpen = false;
                //SetUSBPortText(false);
                WriteMessage("Error: No devices detected", true);
            }
        }

        private void SendSetupFinish()
        {
            FPGA.SendSetupFinish();
        }


        delegate void CallbackDelegateOutput(string text);


        /// <summary>
        /// Thread safe method to write FPGA output to textbox.
        /// </summary>
        /// <param name="text">Message to output.</param>
        /*private void WriteOutput(string text)
        {
            if (this.FPGAOutput.InvokeRequired)
            {
                CallbackDelegateOutput d = new CallbackDelegateOutput(WriteOutput);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                FPGAOutput.Text += text;
            }
        }*/


        Thread FPGAReadThread;
        bool bShouldQuitThread = false;
        bool bResetFPGA = false;
        Byte[] Data = new Byte[4];
        public void FPGAReadMethod()
        {
          /*  
            int Frequency = FreqSelectForm.GetInitialFrequency();
            int FrequencyStep = FreqSelectForm.GetFreqStep();
            int CurrentWindowStep = 0;
            int WindowSize = FreqSelectForm.GetWindowSize();
            int WindowSpace = FreqSelectForm.GetSidebandSpacing() - FreqSelectForm.GetWindowSize();//Distance from end of one window to start of next
            
            TextWriter File = new StreamWriter(FilenameTextbox.Text);
            if (File != null)
            {
                WriteMessage("Opened File for Writing: " + FilenameTextbox.Text);
            }
            else
            {
                WriteMessage("Couldn't Open File for Writing: " + FilenameTextbox.Text, true);
            }

            List<int> Readings = new List<int>(2000);

            ResultsForm.ClearData();

            while (FPGAReadThread.IsAlive && bShouldQuitThread == false)
            {
                if (bResetFPGA)
                {
                    FPGA.SendResetSignal();
                    bResetFPGA = false;
                    File.Close();
                    return;
                }


                if (FPGA.CheckQueue() == 4)
                {
                }
                else
                {
                    if (FPGA.CheckQueue() > 4)
                    {
                        WriteMessage("Too Many Bytes in Queue!!", true);
                    }
                    else
                    {
                        continue;
                    }
                }

                byte[] Bytes = FPGA.ReadBytes();


                if (Bytes != null && Bytes.Length != 0)
                {
                    byte[] Data = Bytes;

                    if (Bytes[3] != 181 && Bytes[3] != 77 && Bytes[3] != 173)
                    {
                        WriteOutput("Warning: Received corrupted data!\r\n");

                        int Info1 = FPGA.InfoRequest();
                        int Info2 = FPGA.InfoRequest();
                        int Info3 = FPGA.InfoRequest();
                        int Info4 = FPGA.InfoRequest();

                        while ((Info1 != Info2) || (Info3 != Info4) || (Info1 != Info3))
                        {
                            Info1 = FPGA.InfoRequest();
                            Info2 = FPGA.InfoRequest();
                            Info3 = FPGA.InfoRequest();
                            Info4 = FPGA.InfoRequest();
                        }

                        Data = BitConverter.GetBytes(Info1);

                        WriteOutput("Recovered successfully\r\n");
                    }

                    
                    if (Data[3] == 181)
                    {
                        Data[3] = 0;
                        int NumReadings = BitConverter.ToInt32(Data, 0);
                        WriteOutput("Found " + NumReadings.ToString() + " Readings\r\n");

                        uint rxbytes = FPGA.CheckQueue();
                        uint NumRead = 0;
                        byte[] buffer = new byte[rxbytes];

                        if (rxbytes != 0) //clear out any bytes left in the buffer... shouldn't hit this
                        {
                            FPGA.USBPort.Read(buffer, rxbytes, ref NumRead);
                            WriteOutput("Warning: Found extra bytes in FPGA output queue\r\n");
                        }

                        FPGA.FinishInfoRequest();

                        List<byte> DataOut = new List<byte>(NumReadings*2);

                        rxbytes = FPGA.CheckQueue();

                        while (DataOut.Count < NumReadings * 2)
                        {
                            rxbytes = FPGA.CheckQueue();
                            if (rxbytes > 0)
                            {
                                buffer = new byte[rxbytes];
                                FPGA.USBPort.Read(buffer, rxbytes, ref NumRead);
                                DataOut.AddRange(buffer);
                            }
                        }

                        buffer = DataOut.ToArray();

                        for (int j = 0; j < buffer.Length; j = j + 2)
                        {
                            int Reading = buffer[j] + 256 * buffer[j + 1];
                            Readings.Add(Reading);
                        }

                        foreach (int j in Readings)
                        {
                            File.WriteLine(j.ToString());
                        }

                        ResultsForm.InputData(Readings.ToArray());

                        File.Flush();
                        Readings.Clear();

                        FPGA.ResetDevice();

                        while (PauseExperimentSelect.Checked)
                        {
                            //sleep for 1ms so we don't use all the CPU cycles
                            System.Threading.Thread.Sleep(1000);
                        }

                        FPGA.SendReadingFinish();
                        //break; 
                    }
                    else if (Data[3] == 77)
                    {

                        FPGA.FinishInfoRequest();

                        Data[3] = 0;
                        int ExtraData = BitConverter.ToInt32(Data, 0);
                        if (ExtraData == 0xAB25FC)
                        {
                            WriteOutput("Need to change frequency!\r\n");
                            if (bIsFreqGenEnabled)
                            {
                                //Change Frequency :)
                                if (bIsWindowingEnabled)
                                {
                                    if (CurrentWindowStep < WindowSize)
                                    {
                                        Frequency += FrequencyStep;
                                        GPIB.SetFrequency(Frequency);
                                        CurrentWindowStep++;
                                    }
                                    else if (CurrentWindowStep >= WindowSize)
                                    {
                                        Frequency += (WindowSpace * FrequencyStep);
                                        GPIB.SetFrequency(Frequency);
                                        CurrentWindowStep = 0;
                                    }

                                }
                                else
                                {
                                    Frequency += FrequencyStep;
                                    GPIB.SetFrequency(Frequency);
                                }
                            }
                            else
                            {
                                WriteOutput("Frequency Generator not enabled!\r\n");
                            }

                            while (PauseExperimentSelect.Checked)
                            {
                                //sleep for 1ms so we don't use all the CPU cycles
                                System.Threading.Thread.Sleep(1000);
                            }

                            FPGA.SendFreqChangeFinish();
                        }
                        else
                        {
                            WriteOutput("Received corrupted frequency change command!\r\n");
                        }
                    }
                    else if (Data[3] == 173)
                    {
                        FPGA.FinishInfoRequest();

                        Data[3] = 0;
                        int ExtraData = BitConverter.ToInt32(Data, 0);
                        if (ExtraData == 0xFC32DA)
                        {
                            WriteOutput("Received experiment stop command!\r\n");
                            MessageBox.Show("Experiment Finished!", "Bang");
                            bShouldQuitThread = true;
                        }
                        else
                        {
                            WriteOutput("Received corrupted experiment stop command!\r\n");
                        }
                        break;
                    }
                    else
                    {
                        WriteOutput("Received corrupted data (Unrecoverable)!\r\n");
                    }
                }
            }

            foreach (int i in Readings)  //this loop probably isn't needed now
            {
                File.WriteLine(i.ToString());
            }

            File.Flush();
            File.Close();
            FPGA.ResetDevice();*/
        }


        private void StartReadingData()
        {    
            if ((FPGAReadThread != null) && (FPGAReadThread.IsAlive))
            {
                FPGAReadThread.Abort();
                FPGAReadThread.Join();
            }

            FPGAReadThread = new Thread(new ThreadStart(this.FPGAReadMethod));
            FPGAReadThread.Name = "FPGACommThread";
            FPGAReadThread.Start();
        }

        private void CloseUSBPort()
        {
            FPGA.CloseDevice();
            FPGA.bUSBPortIsOpen = false;
            //SetUSBPortText(false);
        }
    }
}

