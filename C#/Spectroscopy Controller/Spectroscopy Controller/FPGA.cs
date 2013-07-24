using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Spectroscopy_Controller
{
    /// <summary>
    /// Class that provides access to FPGA through USB port. Uses methods within FPGAController.dll library.
    /// </summary>
    partial class FPGA
    {
        public static FTDI USBPort = new FTDI();
        
        private static uint DeviceIndex = 0;

        static List<byte> TxDBuffer = new List<byte>(256);

        public static int CountDevices()
        {
            FTDI.FT_DEVICE_INFO_NODE[] Devices = new FTDI.FT_DEVICE_INFO_NODE[5]{null,null,null,null,null};
            USBPort.GetDeviceList(Devices);
            int numDevices = 0;
            foreach(FTDI.FT_DEVICE_INFO_NODE Device in Devices)
            {
                if (Device != null)
                {
                    numDevices++;
                }
            }
            return numDevices;
        }

        public static void SelectDevice(uint Device)
        {
            DeviceIndex = Device;
        }

        public static bool OpenDevice() //by default open device zero
        {
            if (bUSBPortIsOpen)
            {
                CloseDevice();
            }

            FTDI.FT_STATUS S = USBPort.OpenBySerialNumber("FTF5YLE8");
            if (S != FTDI.FT_STATUS.FT_OK) return false;

            S = USBPort.SetBaudRate(500000);
            if (S != FTDI.FT_STATUS.FT_OK) return false;

            S = USBPort.SetFlowControl(FTDI.FT_FLOW_CONTROL.FT_FLOW_RTS_CTS, 0, 0);
            if (S != FTDI.FT_STATUS.FT_OK) return false;

            S = USBPort.SetRTS(true);
            if (S != FTDI.FT_STATUS.FT_OK) return false;

            S = USBPort.SetDataCharacteristics(FTDI.FT_DATA_BITS.FT_BITS_8, FTDI.FT_STOP_BITS.FT_STOP_BITS_2, FTDI.FT_PARITY.FT_PARITY_NONE);
            if (S != FTDI.FT_STATUS.FT_OK) return false;

            bUSBPortIsOpen = true;
            
            //ResetDevice(0);

            return true;
        }

    
        public static bool CloseDevice()
        {
            FTDI.FT_STATUS Status = USBPort.Close();

            if (Status != FTDI.FT_STATUS.FT_OK) return false;

            bUSBPortIsOpen = false;

            return true;
        }


        public static void SetLasers(bool L397B1, bool L397B2, bool L729, bool L854, bool LRF1, bool LRF2, bool L854P, bool L854F, bool LAux1, bool LAux2 )
        {
            if (!bUSBPortIsOpen)
                return;

            byte Data= 0;
            Data += (byte)(GetIntFromBool(L854F) << 7);
            Data += (byte)(GetIntFromBool(L854P) << 6);
            Data += (byte)(GetIntFromBool(LRF2) << 5);
            Data += (byte)(GetIntFromBool(LRF1) << 4);
            Data += (byte)(GetIntFromBool(L854) << 3);
            Data += (byte)(GetIntFromBool(L729) << 2);
            Data += (byte)(GetIntFromBool(L397B2) << 1);
            Data += (byte)(GetIntFromBool(L397B1) << 0);

            byte Data2 = 255;
            Data += (byte)(GetIntFromBool(LAux2) << 1);
            Data += (byte)(GetIntFromBool(LAux1) << 0);

            byte[] x = new byte[8];
            x[0] = LASER_SETUP;
            x[1] = LASER_CMD;
            x[2] = 0xFF;
            x[3] = 0xFF;
            x[4] = 0xFF;
            x[5] = Data2; 
            x[6] = Data;
            x[7] = 0xFF;
            FPGA.ResetDevice(10);
            WriteData(x, 8, 0, true);
        }

        static int GetIntFromBool(bool b)
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

        public static void SendSDRamData(int Address, ushort Data, bool bImmediate)
        {
            if(!bUSBPortIsOpen)
		        return;
            	        
	        byte[] x = new byte[8];
	        x[0]=WRITE;
	        x[1]=SDRAM;
	        x[2]=(byte)(Address>>16);
	        x[3]=(byte)(Address>>8);
	        x[4]=(byte)(Address);
	        x[5]=(byte)(Data>>8);
	        x[6]=(byte)(Data);
	        x[7]=(byte)NORMAL;
	        //USB1.Reset_Device(0);
	        WriteData(x,8,0,bImmediate);
        }

        public static void SendFileUploadSignal(int NumInstructions )
        {
            if (!bUSBPortIsOpen)
                return;

            byte[] x = new byte[8];
            x[0] = WRITE;
            x[1] = SDRAM;
            x[2] = (byte)(NumInstructions >> 16);
            x[3] = (byte)(NumInstructions >> 8);
            x[4] = (byte)(NumInstructions);
            x[5] = 0;
            x[6] = 0;
            x[7] = (byte)FILEUPLOAD;
            //USB1.Reset_Device(0);
            WriteData(x, 8, 0, true);

            System.Threading.Thread.Sleep(10); //wait a bit so FPGA is ready to accept file.
        }

        public static void SendSRamData(int Address, ushort Data, bool bImmediate)
        {
            if (!bUSBPortIsOpen)
                return;

            byte[] x = new byte[8];
            x[0] = WRITE;
            x[1] = SRAM;
            x[2] = (byte)(Address >> 16);
            x[3] = (byte)(Address >> 8);
            x[4] = (byte)(Address);
            x[5] = (byte)(Data >> 8);
            x[6] = (byte)(Data);
            x[7] = (byte)NORMAL;

            WriteData(x, 8, 0, bImmediate);
        }

        public static void WriteData(byte[] Source, int Size, int WithRead, bool Immediate)
        {
            int i;            
            if(Size!=0)
            {
                for(i=0;i<Size;i++)
                {
                    TxDBuffer.Add(Source[i]);
                }
            }

            //   Transfer Queue To Array
            int Trans_Size = TxDBuffer.Count;
            int MAX_TXD_PACKET = 256;
            int ALMOST_FULL_SIZE = 20;
            if(Immediate || Trans_Size>(MAX_TXD_PACKET-ALMOST_FULL_SIZE))
            {
                uint NumOfWritten = 0;
                USBPort.Write(TxDBuffer.ToArray(), Trans_Size, ref NumOfWritten);
                TxDBuffer.Clear();
            }
        }

        public static int ReadSDRamData(int Address)
        {
            if (!bUSBPortIsOpen)
            return 0;

            byte[] x = new byte[8];

            // Send SDRAM Address To FPGA
            x[0]=READ;
            x[1]=SDRAM;
            x[2]=(byte)(Address>>16);
            x[3]=(byte)(Address>>8);
            x[4]=(byte)(Address);
            x[5]=0x00;
            x[6]=0x00;
            x[7]=NORMAL;
            WriteData(x,8,2,true);
            System.Threading.Thread.Sleep(10);
            // Sdram Random Read
            uint numRead = 0;
            FTDI.FT_STATUS Status = USBPort.Read(x,2,ref numRead);
            if(Status == FTDI.FT_STATUS.FT_OK)
            {
                return x[0]+x[1]*256;
            }
            // Show Get Value To Text Filed
            return -1;
        }

        public static int ReadSRamData(int Address)
        {
            if (!bUSBPortIsOpen)
                return 0;

            byte[] x = new byte[8];

            // Send SDRAM Address To FPGA
            x[0] = READ;
            x[1] = SRAM;
            x[2] = (byte)(Address >> 16);
            x[3] = (byte)(Address >> 8);
            x[4] = (byte)(Address);
            x[5] = 0x00;
            x[6] = 0x00;
            x[7] = NORMAL;
            WriteData(x, 8, 2, true);

            System.Threading.Thread.Sleep(10);
                        
            uint numRead = 0;
            FTDI.FT_STATUS Status = USBPort.Read(x, 2, ref numRead);
            if (Status == FTDI.FT_STATUS.FT_OK && numRead == 2)
            {
                return x[0] + x[1] * 256;
            }
            // Show Get Value To Text Filed
            return -1;
        }

        
        public static void SendSetupFinish() 
        { 
            if(!bUSBPortIsOpen)
                return;

            byte[] x = new byte[8];
            x[0]=SETUP; //56..63
            x[1]=SETUPFINISH; //48..55
            x[2]=0xFF; //40..47
            x[3]=0XFF; //32..39
            x[4]=0XFF; //24..31
            x[5]=0xFF; //16..23
            x[6]=0xFF; //8..15
            x[7]=0xFF; //0..7
            
            ResetDevice(50);
            WriteData(x,8,0,true);                        
        }

        public static void SendResetSignal()
        {
            if (!bUSBPortIsOpen)
                return;                      

            byte[] x = new byte[8];
            x[0] = SETUP; //56..63
            x[1] = RESETFPGA; //48..55
            x[2] = 0xFF; //40..47
            x[3] = 0XFF; //32..39
            x[4] = 0XFF; //24..31
            x[5] = 0xFF; //16..23
            x[6] = 0xFF; //8..15
            x[7] = 0xFF; //0..7

            ResetDevice(50);
            WriteData(x, 8, 0, true);

            SetLasers(true, true, false, true, false, false, false, false, false, false);

        }

        public static void SendFreqChangeFinish()
        {
            if (!bUSBPortIsOpen)
                return;

            byte[] x = new byte[8];
            x[0] = SETUP; //56..63
            x[1] = FREQFINISH; //48..55
            x[2] = 0xFF; //40..47
            x[3] = 0XFF; //32..39
            x[4] = 0XFF; //24..31
            x[5] = 0xFF; //16..23
            x[6] = 0xFF; //8..15
            x[7] = 0xFF; //0..7

            ResetDevice(50);
            WriteData(x, 8, 0, true);
        }

        public static void SendReadingFinish()
        {
            if (!bUSBPortIsOpen)
                return;

            byte[] x = new byte[8];
            x[0] = SETUP; //56..63
            x[1] = READINGFINISH; //48..55
            x[2] = 0xFF; //40..47
            x[3] = 0XFF; //32..39
            x[4] = 0XFF; //24..31
            x[5] = 0xFF; //16..23
            x[6] = 0xFF; //8..15
            x[7] = 0xFF; //0..7

            ResetDevice(50);
            WriteData(x, 8, 0, true);    
        }

       
        public static bool ResetDevice(int SleepTime = 0)
        {
            CloseDevice();
            System.Threading.Thread.Sleep(SleepTime);
            if (OpenDevice())
            {
                InitialJTAG();                              
                return true;
            }
            return false;
        }

        private static void InitialJTAG()
        {
            /*uint numWritten = 0;
            byte[] Init_CMD = new byte[5];
            Init_CMD[0] = 0x26;
            Init_CMD[1] = 0x27;
            Init_CMD[2] = 0x26;
            Init_CMD[3] = 0x81;
            Init_CMD[4] = 0x00;
            USBPort.Write(Init_CMD, 5, ref numWritten);*/
        }

        public static uint CheckQueue()
        {
            uint QueueSize = 0;            
            USBPort.GetRxBytesAvailable(ref QueueSize);
            return QueueSize;
        }

        public static void EmptyBuffer()
        {
            uint QueueSize = 0;
            uint NumBytesRead = 0;
            do
            {
                USBPort.GetRxBytesAvailable(ref QueueSize);
                byte[] Buffer = new byte[QueueSize];
                USBPort.Read(Buffer, QueueSize, ref NumBytesRead);
            } while (QueueSize != 0);            
        }

        public static int InfoRequest()
        {
            if (!bUSBPortIsOpen)
                return -1;

            byte[] x = new byte[8];
            x[0] = SETUP; //56..63
            x[1] = INFOREQUEST; //48..55
            x[2] = 0xFF; //40..47
            x[3] = 0XFF; //32..39
            x[4] = 0XFF; //24..31
            x[5] = 0xFF; //16..23
            x[6] = 0xFF; //8..15
            x[7] = 0xFF; //0..7

            ResetDevice();
            WriteData(x, 8, 4, true);
            System.Threading.Thread.Sleep(10);

            uint numRead = 0;
            byte[] Output = new byte[4];
            FTDI.FT_STATUS Status = USBPort.Read(Output, 4, ref numRead);
            if (Status == FTDI.FT_STATUS.FT_OK && numRead == 4)
            {
                return BitConverter.ToInt32(Output, 0);                
            }

            return -1;
        }

        public static void FinishInfoRequest()
        {
            if (!bUSBPortIsOpen)
                return;

            byte[] x = new byte[8];
            x[0] = SETUP; //56..63
            x[1] = FINISHREQUEST; //48..55
            x[2] = 0xFF; //40..47
            x[3] = 0XFF; //32..39
            x[4] = 0XFF; //24..31
            x[5] = 0xFF; //16..23
            x[6] = 0xFF; //8..15
            x[7] = 0xFF; //0..7

            ResetDevice(10);
            WriteData(x, 8, 0, true);
        }

        /// <summary>
        /// Reads 4 bytes from USB buffer and puts them into a single 32 bit integer (which has size of 4 bytes).
        /// </summary>
        /// <returns></returns>
        public static byte[] ReadBytes() 
        {
            uint BytesInQueue = CheckQueue();
            uint NumBytesRead = 0;
            byte[] Buffer = new byte[BytesInQueue];

            for (int i = 0; i < BytesInQueue; i++)
            {
                Buffer[i] = 0;
            }
            USBPort.Read(Buffer, BytesInQueue, ref NumBytesRead);
            return Buffer;
        }

        public static bool bUSBPortIsOpen = false;
    }
}
