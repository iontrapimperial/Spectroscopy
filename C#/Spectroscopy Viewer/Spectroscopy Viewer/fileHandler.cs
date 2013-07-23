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
        private List<int[]>[] fullData;
        // Create a list of dataPoint objects
        private List<dataPoint>[] dataPoints;

        // Metadata read from file
        private int startFrequency;         // Starting frequency of the file
        private int stepSize;               // Step size in frequency
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
            numberInterleaved = 2;

            repeats = 100;      // For now, set no. of repeats to 100 (known)

            // Initialise arrays for storing Lists of raw data & dataPoints
            fullData = new List<int[]>[numberInterleaved];
            dataPoints = new List<dataPoint>[numberInterleaved];

            // Have to initialise the array and then each List in the array individually... tedious!!
            for (int i = 0; i < numberInterleaved; i++)
            {
                fullData[i] = new List<int[]>();
                dataPoints[i] = new List<dataPoint>();
            }

            

            int[] myIntArray = new int[4];

            string myString = filename.ReadLine();              // Read first line of file
            int j = 0;                                          // Counter for data points
            while (myString != null)                            // Only read further lines until end is reached
            {
                for (int k = 0; k < numberInterleaved; k++)
                {

                    
                    fullData[k].Add(myIntArray);                        // Add new reading to the list, reading will contain 4 ints

                    // Extract blocks of 4 data points (each reading)
                    for (int i = 0; i < 4; i++)
                    {
                        fullData[k][j][i] = int.Parse(myString);        // Convert string to int, put into array
                        myString = filename.ReadLine();                 // Read next line
                    }

                }
                j++;
            }


            // Create array of data point lists
            for (int i = 0; i < numberInterleaved; i++)
            {
                this.constructDataPoints(i);
            }


          
        }


        // Method to populate list of dataPoint objects (dataPoints), including metadata
        // Integer x tells which number spectrum (e.g. 0(first), 1(second)) in file to use
        private void constructDataPoints(int x)
        {
            dataPoint dataPointTemp;        // dataPoint object used in loop

            // Loop through list of data elements, but only create a new dataPoint object for each frequency
            // 
            for (int i = 0; i < fullData[x].Count; i += numberInterleaved*repeats)
            {
                // Create new instance of dataPoint
                dataPointTemp = new dataPoint(ref fullData[x], i, repeats);
                
                // Set metadata (nb. repeats already set in constructor)
                dataPointTemp.setFreq(startFrequency + i*stepSize);
               
                // Add to the list
                dataPoints[x].Add(dataPointTemp);
            }

        }

        // Method to return number of interleaved spectra in the file
        public int getNumberInterleaved()
        {
            return numberInterleaved;
        }


        // Method to return list of dataPoint objects (dataPoints)
        // NB List<> is a reference type so it behaves like a pointer
        public List<dataPoint> getDataPoints(int x)
        {
            
            return dataPoints[x];
        }

    }
}
