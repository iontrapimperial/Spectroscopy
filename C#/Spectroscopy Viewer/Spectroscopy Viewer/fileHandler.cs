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
        // Create a list of dataPoint objects
        private List<dataPoint> dataPoints = new List<dataPoint>();

        private int repeats;        // Need to know number of repeats in this class as well as in dataPoint


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

            repeats = 100;      // For now, set no. of repeats to 100 (known)


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

            // Construct data points from this instance of fileHandler
            this.constructDataPoints();

        }


        // Method to populate list of dataPoint objects (dataPoints)
        public void constructDataPoints()
        {
            dataPoint dataPointTemp;        // dataPoint object used in loop
            // 
            for (int i = 0; i < fullData.Counts; i+repeats)
            {
                // Create new instance of dataPoint
                dataPointTemp = new dataPoint(ref fullData, i, repeats);
                // Add to the list
                dataPoints.Add(dataPointTemp);
            }


        }

        // Method to return list of dataPoint objects (dataPoints)
        public List<dataPoint> getDataPoints()
        {
            return dataPoints;
        }



    }
}
