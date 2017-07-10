using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Spectroscopy_Controller
{
    public partial class CoreForm : Form
    {
        /// <summary>
        /// Thread to send Binary file to FPGA. Large files (100's of KB and up) take more than a few seconds to send to the FPGA
        /// so it is done in a seperate thread so that the form does not look like it has crashed.
        /// </summary>
        Thread BinarySendThread;

        /// <summary>
        /// Delegate allows thread safe writing of form properties.
        /// </summary>
        /// <param name="Progress"></param>
        delegate void CallbackDelegateProgress(float Progress);
                
        /// <summary>
        /// Thread safe method to change progress text on ProgressLabel
        /// </summary>
        /// <param name="Progress"></param>
        private void UpdateProgress(float Progress)
        {
            if (this.MessagesBox.InvokeRequired)
            {
                CallbackDelegateProgress d = new CallbackDelegateProgress(UpdateProgress);
                this.Invoke(d, new object[] { Progress });
            }
            else
            {
                ProgressLabel.Text = "Progress: " + Progress + "%";
            }
        }

        /// <summary>
        /// Opens chosen file and sends data to FPGA 2 bytes at a time.
        /// </summary>
        void BinarySendMethod()
        {
            FileStream F = File.Open(openHexFileDialog.FileName, FileMode.Open);

            using (BinaryReader b = new BinaryReader(F))
            {
                int FileSize = (int)b.BaseStream.Length;
                hexFileName = openHexFileDialog.FileName;
                WriteMessage("File name: " + hexFileName);
                WriteMessage("Length: " + FileSize.ToString() + " Bytes\r\n");
                
                if (FileSize > 8000000) //should this be 2^23-1 (8 388 607) instead?
                {
                    //don't bother if >8 MB
                    WriteMessage("File too big!!\r\n", true);                    
                    return;
                }
                else if (FileSize % 2 != 0) //if FileSize is an odd number
                {
                    WriteMessage("File size (in bytes) is not divisible by two!\r\n", true);
                    //FileText.Text += "File size (in bytes) is not divisible by two!\r\n";
                    return;
                }
                UpdateProgress(0);
                Byte[] Data = b.ReadBytes(FileSize);
                FPGA.ResetDevice();

                FPGA.SendFileUploadSignal(FileSize / 2);


                WriteMessage("Sending Data. Approx " + (int)(( (float)FileSize)*0.00002f ) + " seconds"   ) ;

                uint NumWritten = 0;
                FPGA.USBPort.Write(Data, FileSize, ref NumWritten);

                UpdateProgress(100);                
            }

            F.Close();
        }

        /// <summary>
        /// Called when OpenHexFileDialog closes successfully. Closes previous thread (if it exists) and creates a new one to send
        /// data to FPGA.
        /// </summary>
        void SendBinaryFile()
        {
            if ((BinarySendThread != null) && (BinarySendThread.IsAlive))
            {
                BinarySendThread.Abort();
                BinarySendThread.Join();
            }

            BinarySendThread = new Thread(new ThreadStart(this.BinarySendMethod));
            BinarySendThread.Name = "FileSendThread";
            BinarySendThread.Start();
        }

        bool bStopSignalPresent = false;
        int InstructionsWritten = 0;

        /// <summary>
        /// Called when SaveHexFileDialog closes successfully. Creates file at chosen location and writes binary 
        /// instructions to it based on what is currently in PulseTree
        /// </summary>
        void SaveHexFile()
        {
            string fileLoc = openHexFileDialog.InitialDirectory + "\\"+Path.GetFileNameWithoutExtension(saveXMLFileDialog.FileName) + ".hex";           
            bStopSignalPresent = false;
            InstructionsWritten = 0;         
            using (BinaryWriter Writer = new BinaryWriter(File.Open(fileLoc, FileMode.Create)))
           // using (BinaryWriter Writer = new BinaryWriter(File.Open( "testFile" + ".hex", FileMode.Create)))
            {
                WriteMessage("In Using", true);
                WriteMessage("Writing to file: " + fileLoc);
                ParseNodeCollection(PulseTree.Nodes, Writer);

                if (InstructionsWritten == 0)
                {
                    WriteMessage("Warning: No instructions written to file", true);
                }
                else
                {
                    WriteMessage(InstructionsWritten.ToString() + " Instructions written to file");
                    if (InstructionsWritten > 2000000)
                    {
                        WriteMessage("Too many instructions written to file. File can't be uploaded to FPGA", true);
                    }
                }

                if (!bStopSignalPresent) //no Stop signal written
                {
                    WriteMessage("Warning: No stop signal written to binary file", true);
                }

                WriteMessage("Finished writing file");
            }                       
        }

        /// <summary>
        /// Recursive method to parse a collection of Nodes and writes to binary file.
        /// </summary>
        /// <param name="Nodes"></param>
        /// <param name="Writer"></param>
        void ParseNodeCollection(TreeNodeCollection Nodes, BinaryWriter Writer)
        {
            foreach (TreeNode Node in Nodes)
            {
                if (Node.Tag is LaserState)
                {
                    WriteStateToBinary((LaserState)Node.Tag, Writer);
                }
                else
                {
                    int LoopCount = ((LoopState)Node.Tag).LoopCount;
                    if (LoopCount < 0)
                    {
                        WriteMessage("Warning: Loop state found zero loops", true);
                    }

                    if (((LoopState)Node.Tag).bIsFPGALoop == true)
                    {
                        LaserState Startloop = new LaserState();
                        Startloop.StateType = LaserState.PulseType.STARTLOOP;
                        Startloop.Ticks = LoopCount; //put loop number into ticks field.

                        WriteStateToBinary(Startloop, Writer);

                        ParseNodeCollection(Node.Nodes, Writer);

                        LaserState Endloop = new LaserState();
                        Endloop.StateType = LaserState.PulseType.ENDLOOP;

                        WriteStateToBinary(Endloop, Writer);
                    }
                    else
                    {
                        for (int i = 0; i < LoopCount; i++)
                        {
                            ParseNodeCollection(Node.Nodes, Writer);
                        }
                    }                     
                }
            }
        }
        
        void WriteStateToBinary(LaserState State, BinaryWriter Writer)
        {
            if (State.StateType == LaserState.PulseType.STOP)
            {
                if (bStopSignalPresent)
                {
                    WriteMessage("Warning: Multiple stop signals written to Binary file", true);
                }
                else //first stop signal written
                {
                    bStopSignalPresent = true;
                }
            }
            
            // Write 3 bytes of data for Ticks
            byte[] Data = new byte[4];
            byte[] Ticks = BitConverter.GetBytes(State.Ticks*32);

            if (BitConverter.IsLittleEndian) //Least significant bits are at start of array
            {
                for (int i = 2; i >= 0; i--)
                {
                    Data[i + 1] = Ticks[i];
                }
            }
            else MessageBox.Show("Byte Conversion Problem (Are you big endian?)");

            //Fill last 5 bits of Data[1] with laser state logic
            Data[1] += (byte)(GetIntFromBool(State.Laser729P2) << 4);
            Data[1] += (byte)(GetIntFromBool(State.LaserAux1) << 3);
            Data[1] += (byte)(GetIntFromBool(State.Laser854FREQ) << 2);
            Data[1] += (byte)(GetIntFromBool(State.Laser854POWER) << 1);
            Data[1] += (byte)(GetIntFromBool(State.Laser729P1));

            // Write one more byte (Data[0]) for lasers (bits 7:3)... 
            Data[0] = 0;
            Data[0] += (byte)(GetIntFromBool(State.Laser729P0) << 7);
            Data[0] += (byte)(GetIntFromBool(State.Laser854) << 6);
            Data[0] += (byte)(GetIntFromBool(State.Laser729) << 5);
            Data[0] += (byte)(GetIntFromBool(State.Laser397B2) << 4);
            Data[0] += (byte)(GetIntFromBool(State.Laser397B1) << 3);
            //...and pulse type (bits 2:0)
            Data[0] += (byte)State.StateType;

            //Write Data[] byte array to the hex file (in reverse order, MSB first)
            for (int i = 3; i >= 0; i--)
            {
                Writer.Write(Data[i]);
            }

            InstructionsWritten++;
        }

        /// <summary>
        /// Returns 1/0 for true/false.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        int GetIntFromBool(bool b)
        {
            if (b)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
