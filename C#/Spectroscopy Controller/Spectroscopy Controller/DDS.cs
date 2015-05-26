using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spectroscopy_Controller
{
    // Methods for DDS
    class DDS
    {
        public static int CalculateFTW(int fo)
        {
            double fc = Math.Pow(10, 9); // clock frequency
            double FTW = fo * Math.Pow(2, 32) / fc; // calculate FTW
            FTW = Math.Round(FTW); // round to closest integer
            int FTWRounded = (int)FTW; // transforms the double into an int
            return FTWRounded;
        }

        public static int CalculatePOW(double phase)
        {
            double POW = phase * Math.Pow(2, 16) / 360;
            POW = Math.Round(POW);
            int POWRounded = (int)POW;
            return POWRounded;
        }

        public static string CalculateFTWBinary(int FTW)
        {
            string FTWBinary = Convert.ToString(FTW, 2); // converts a integer into a string of binary digits
            if (FTWBinary.Length < 32)
            {
                int diff = 32 - FTWBinary.Length;
                for (int i = 0; i < diff; i++)
                {
                    FTWBinary = 0 + FTWBinary;  // adds 0s if the lenght of the string is smaller than 32
                }
            }
            else
            { }

            return FTWBinary;
        }

        public static string Calculate16Binary(int value)
        {
            string binary = Convert.ToString(value, 2);
            if(binary.Length < 16)
            {
                int diff = 16 - binary.Length;
                for(int i = 0; i < diff; i++)
                {
                    binary = 0 + binary;
                }
            }
            else { }

            return binary;
        }

        static string CalculateByte(string binaryString, int start) // function to extract 8 characters out of a string of binary digits and convert them into a byte
        {
            int end = start + 8;

            string binaryStringByte = "";

            for (int i = start; i < end; i++)
            {
                binaryStringByte = binaryStringByte + Convert.ToString(binaryString[i]);
            }

            byte decimalByte = Convert.ToByte(binaryStringByte, 2);

            string FTWByteString = Convert.ToString(decimalByte);

            return FTWByteString;
        }

        public static void GetFTW(decimal value, out string FTWbyte0, out string FTWbyte1, out string FTWbyte2, out string FTWbyte3)
        {
            FTWbyte0 = "0";
            FTWbyte1 = "0";
            FTWbyte2 = "0";
            FTWbyte3 = "0";

            int FTW = CalculateFTW(Convert.ToInt32(value)); // calculates FTW
            string FTWBinary = CalculateFTWBinary(FTW); // converts in binary string

            FTWbyte0 = CalculateByte(FTWBinary, 0);
            FTWbyte1 = CalculateByte(FTWBinary, 8);
            FTWbyte2 = CalculateByte(FTWBinary, 16);
            FTWbyte3 = CalculateByte(FTWBinary, 24);
        }

        public static void GetASF(decimal value, decimal amp, out string ASFbyte0, out string ASFbyte1)
        {
           ASFbyte0 = "63"; // first byte of the ASF in decimal, full scale value
           ASFbyte1 = "255"; // second byte of the ASF in decimal, full scale value
           
            double frequency = Convert.ToDouble(value);
               
           if(frequency <= 300000000 && frequency >= 200000000) // checks the value of the frequency is in the range covered by the LUT
           {

               /*double rank = Math.Round(frequency / 100000) - 2000; // converts the frequency into the number of a line in the LUT
               int line = (int)rank;
               string[] amplitudeScaleFactor = System.IO.File.ReadAllLines(@"C:\Users\localadmin\Desktop\ASF_200_300MHz_33dBm.txt"); // open and read the LUT (text file)
               int ASF = Convert.ToInt32(amplitudeScaleFactor[line]); // converts the ASF into an int*/
               double freqMHz = frequency / Math.Pow(10, 6);
               int ASF = (int)Math.Round(194*0.826*Math.Pow(2,14)/(-8.59478*Math.Pow(10,-7)*Math.Pow(freqMHz,4) + 8.37290*Math.Pow(10,-4)*Math.Pow(freqMHz,3) - 0.302463*Math.Pow(freqMHz,2) + 47.6572*freqMHz - 2526.30));
               ASF = (int)Math.Round(ASF * amp / 100); // multiplies the ASF by the amp percentage

               string ASFBinary = Calculate16Binary(ASF); // converts ASF in binary string

               ASFbyte0 = CalculateByte(ASFBinary, 0);
               ASFbyte1 = CalculateByte(ASFBinary, 8);
            }
            else
            {
                   ASFbyte0 = "63";
                   ASFbyte1 = "255";
            }    
        }

        public static void GetPOW(decimal value, out string POWbyte0, out string POWbyte1)
        {
            POWbyte0 = "0";
            POWbyte1 = "0";

            int POW = CalculatePOW(Convert.ToDouble(value)); // calculates POW
            string POWBinary = Calculate16Binary(POW); // converts in binary string 

            POWbyte0 = CalculateByte(POWBinary, 0);
            POWbyte1 = CalculateByte(POWBinary, 8);
        }
    }
}
