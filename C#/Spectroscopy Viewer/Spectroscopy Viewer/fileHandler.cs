using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Spectroscopy_Viewer
{
    // Class to open data files & create instances of dataPoint for each frequency
    class fileHandler
    {

        // Create a list of arrays. Each array contains 4 integer values (i.e. the data for a single reading - cool, count & error flags)
        private List<int[]> fullData = new List<int[]>();
        // Create a list of dataPoint objects
        private List<dataPoint> dataPoints = new List<dataPoint>();

        // Metadata read from file
        private int startFrequency;         // Starting frequency of the file
        private int stepSize;               // Step size in frequency
        private int spectrumNumber;         // Which spectrum the data point belongs to
        private string date;                // Date when file was taken
        private int repeats;                // Number of repeats
        private int numberInterleaved;      // How many spectra are interleaved in this file

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

            // Temporary values
            startFrequency = 1000;
            stepSize = 10;

            repeats = 100;      // For now, set no. of repeats to 100 (known)


            string myString = filename.ReadLine();             // Read first line of file
            int j = 0;
            while (myString != null)                           // Only read further lines until end is reached
            {
                fullData.Add(new int[4]);                       // Add new reading to the list, will contain 4 int

                // Extract blocks of 4 data points (each reading)
                for (int i = 0; i < 4; i++)
                {
                    fullData[j][i] = int.Parse(myString);       // Convert string to int, put into array
                    myString = filename.ReadLine();            // Read next line
                }
                j++;
            }

          
        }


        // Method to populate list of dataPoint objects (dataPoints), including metadata
        private void constructDataPoints()
        {
            dataPoint dataPointTemp;        // dataPoint object used in loop

            // Loop through list of data elements, but only create a new dataPoint object for each frequency 
            for (int i = 0; i < fullData.Count; i += repeats)
            {
                // Create new instance of dataPoint
                dataPointTemp = new dataPoint(ref fullData, i, repeats);
                
                // Set metadata (nb. repeats already set in constructor)
                dataPointTemp.setFreq(startFrequency + i*stepSize);
                dataPointTemp.setSpectrum(spectrumNumber);

                // Add to the list
                dataPoints.Add(dataPointTemp);
            }

        }

        // Method to return number of interleaved spectra in the file
        public int getNumberInterleaved()
        {
            return numberInterleaved;
        }


        // Method to return list of dataPoint objects (dataPoints)
        // NB List<> is a reference type so it behaves like a pointer
        public List<dataPoint> getDataPoints()
        {
            this.constructDataPoints();
            return dataPoints;
        }

    }
}
