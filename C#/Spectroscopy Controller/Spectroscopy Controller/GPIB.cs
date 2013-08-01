using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments.NI4882;
using System.Windows.Forms;

namespace Spectroscopy_Controller
{
    class GPIB
    {
        private static NationalInstruments.NI4882.Device device;
        private static bool bDeviceOpen = false;

        /*public static bool IsDeviceOpen()
        {
            return bDeviceOpen;
        }*/

        public static void InitDevice(byte Address)    //Open device at specified address. GPIB address of each function generator set via front panel controls
        {
            if (!bDeviceOpen)
            {
                try
                {
                    device = new Device(0, Address, 0);
                    device.Write("AMPL:STATE ON");    //Try switching on RF output for selected device, if no device present, exception will be thrown
                    bDeviceOpen = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void SetAmplitude(float Amplitude)
        {
            if (bDeviceOpen)
            {
                device.Write("AMPL:STATE ON");
                device.Write("AMPL:LEV " + Amplitude.ToString() + " DBM");
            }
        }

        public static void SetFrequency(int FreqInHz)
        {
            if (bDeviceOpen)
            {
                String S = "FREQ:CW " + FreqInHz + " Hz";
                device.Write(S);
                System.Threading.Thread.Sleep(250); //Pause while frequency changes
            }
        }

        public static void CloseDevice()
        {
            if (bDeviceOpen)
            {
                device.Dispose();
                bDeviceOpen = false;
            }
        }
    }
}
