using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spectroscopy_Viewer
{
    // Class to open data files & create instances of dataPoint for each frequency
    class fileHandler
    {

        // Create a list of arrays. Each array contains 4 bytes (i.e. the data for a single reading - cool, count & error flags)
        // Assuming each data point will never take values larger than 255 (1 byte)
        private List<byte[]> fullData = new List<byte[]>();

        // Default constructor
        public fileHandler()
        {
            // Cannot handle data if a file is not chosen!
            System.Windows.Forms.MessageBox.Show("No file selected");
        }

        // Constructor given a file (pass by reference!)
        public fileHandler(ref System.IO.StreamReader filename)
        {

            /*
             * Need a section of code here to deal with the metadata
             * */


            byte[] dataBlock = new byte[4];             // Create array of 4 bytes
            string S = filename.ReadLine();             // Read first line of file

            while (S != null)                           // Only read further lines until end is reached
            {
                // Extract blocks of 4 data points (each reading)
                for (int i = 0; i < 4; i++)
                {
                    dataBlock[i] = byte.Parse(S);       // Convert string to byte, put into array
                    S = filename.ReadLine();            // Read next line
                }
                fullData.Add(dataBlock);                // Add data block to the list
            }

        }




    }
}
