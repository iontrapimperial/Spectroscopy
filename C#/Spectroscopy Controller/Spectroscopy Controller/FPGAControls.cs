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
        }  */


        Thread FPGAReadThread;
        bool bShouldQuitThread = false;
        bool bResetFPGA = false;
        Byte[] Data = new Byte[4];
        public void FPGAReadMethod()
        {
            int Frequency = startFreq;
            int CurrentWindowStep = 0;

            int CurrentSideband = 0;

            int CurrentPulseLength = fixed_startLength;     // For fixed spectra with a varying pulse length

            int numberOfFiles = this.myFileName.Length;

            TextWriter myFile = new StreamWriter(myFileName[CurrentSideband], true);
            if (myFile != null)
            {
                WriteMessage("Opened first file for writing");
            }
            else
            {
                WriteMessage("Couldn't open first file for writing", true);
            }

            // Create list for storing readings, get ready for 2000 data points
            List<int> Readings = new List<int>(2000);

            while (FPGAReadThread.IsAlive && bShouldQuitThread == false)
            {
                // If flag is set to reset FPGA, do so
                if (bResetFPGA)
                {
                    FPGA.SendResetSignal();
                    bResetFPGA = false;

                    myFile.Close();

                    return;
                }

                // If there are exactly 4 bytes in the queue... do nothing?
                // Might be able to restructure this bit. Don't quite understand - it seems to just write a message if there are 
                // too many bytes, but otherwise continues as normal. Not sure where the continue statement skips to
                // I think it skips the rest of this function...

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





                // Fill array of bytes with however many are in the queue
                byte[] Bytes = FPGA.ReadBytes();


                // So long as there are some bytes there
                // Statement above means that there should always be 4
                if (Bytes != null && Bytes.Length != 0)
                {
                    byte[] Data = Bytes;

                    // Check for certain error codes
                    // This if statement can be left as-is
                    if (Bytes[3] != 181 && Bytes[3] != 77 && Bytes[3] != 173)
                    {
                        // Changed from WriteOutout to WriteMessage
                        WriteMessage("Warning: Received corrupted data!\r\n");

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

                        // Changed from WriteOutout to WriteMessage
                        WriteMessage("Recovered successfully\r\n");
                    }



                    // Received data, need to deal with it
                    if (Data[3] == 181)
                    {
                        Data[3] = 0;
                        int NumReadings = BitConverter.ToInt32(Data, 0);
                        // Changed from WriteOutout to WriteMessage
                        WriteMessage("Found " + NumReadings.ToString() + " Readings\r\n");

                        uint rxbytes = FPGA.CheckQueue();
                        uint NumRead = 0;
                        byte[] buffer = new byte[rxbytes];

                        if (rxbytes != 0) //clear out any bytes left in the buffer... shouldn't hit this
                        {
                            FPGA.USBPort.Read(buffer, rxbytes, ref NumRead);
                            // Changed from WriteOutout to WriteMessage
                            WriteMessage("Warning: Found extra bytes in FPGA output queue\r\n");
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
                            myFile.WriteLine(j.ToString());
                        }

                        // Only send live data to the viewer if it is open
                        if (this.IsViewerOpen)
                        {
                            if (specType == "Fixed") myViewer.addLiveData(Readings, CurrentWindowStep, 0, CurrentPulseLength);
                            else myViewer.addLiveData(Readings, CurrentWindowStep, startFreqArray[CurrentSideband], 0);
                        }
                        // Clear buffers for writing to file, gets ready for writing more data next time
                        myFile.Flush();  
                        // Clear list of readings
                        Readings.Clear();

                        if (specType == "Fixed")
                        {
                            CurrentPulseLength += fixed_stepSize;
                        }

                        FPGA.ResetDevice();

                        // If the Pause flag is set
                        while (PauseExperiment)
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
                            WriteMessage("Need to change frequency!\r\n");
                            if (bIsFreqGenEnabled)
                            {
                                //Change Frequency :)
                                if (specType == "Windowed")
                                {
                                    if (CurrentWindowStep < sbWidth)
                                    {
                                        Frequency += stepSize;
                                        freq0.Value = Frequency;
                                        CurrentWindowStep++;
                                    }
                                    else if (CurrentWindowStep >= sbWidth)
                                    {
                                        // This means we have come to the end of one sideband
                                        // So flush & close that file
                                        myFile.Flush();
                                        myFile.Close();

                                        CurrentSideband++;

                                        if (CurrentSideband < (sbToScan * 2) + 1)
                                        {
                                            // New sideband, so open the next file, using filename from array
                                            myFile = new StreamWriter(myFileName[CurrentSideband], true);


                                            Frequency = startFreqArray[CurrentSideband];
                                            freq0.Value = Frequency;
                                            CurrentWindowStep = 0;
                                        }
                                        //if we reach end of final sideband, stop experiment (need to test this section)
                                        else
                                        {

                                            MessageBox.Show("Experiment Finished! (Reached final sideband)", "Bang");
                                            bShouldQuitThread = true;
                                            // break;       // might need this??
                                        }

                                    }

                                }
                                else if (specType == "Continuous")
                                {
                                    Frequency += stepSize;
                                    freq0.Value = Frequency;
                                    CurrentWindowStep++;
                                }
                                
                            }
                            else
                            {
                                WriteMessage("Frequency Generator not enabled!\r\n");
                            }

                            while (PauseExperiment)
                            {
                                //sleep for 1ms so we don't use all the CPU cycles
                                System.Threading.Thread.Sleep(1000);
                            }

                            FPGA.SendFreqChangeFinish();
                        }
                        else
                        {
                            WriteMessage("Received corrupted frequency change command!\r\n");
                        }
                    }
                    else if (Data[3] == 173)
                    {
                        FPGA.FinishInfoRequest();

                        Data[3] = 0;
                        int ExtraData = BitConverter.ToInt32(Data, 0);
                        if (ExtraData == 0xFC32DA)
                        {
                            WriteMessage("Received experiment stop command!\r\n");
                            MessageBox.Show("Experiment Finished!", "Bang");
                            bShouldQuitThread = true;
                        }
                        else
                        {
                            WriteMessage("Received corrupted experiment stop command!\r\n");
                        }
                        break;
                    }
                    else
                    {
                        WriteMessage("Received corrupted data (Unrecoverable)!\r\n");
                    }
                }
            }


            // If it's a windowed spectrum, we will already have closed the file. Otherwise, need to flush & close it
            if (specType != "Windowed")
            {
                myFile.Flush();
                myFile.Close();
            }

            this.ExperimentFinished();

            FPGA.ResetDevice();
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
            // Disable start & open USB buttons
            StartButton.Enabled = false;
            OpenUSBButton.Enabled = false;
            //Always enable Stop and pause buttons when running
            StopButton.Enabled = true;
            PauseButton.Enabled = true;
        }

        private void CloseUSBPort()
        {
            FPGA.CloseDevice();
            FPGA.bUSBPortIsOpen = false;
            //SetUSBPortText(false);
        }
    }
}

