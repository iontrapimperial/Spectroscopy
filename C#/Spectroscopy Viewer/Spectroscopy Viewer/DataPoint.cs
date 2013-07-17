using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO

namespace Spectroscopy_Viewer
{

    // Class to contain raw data for each frequency data point, and methods to access
    public class dataPoint
    {

        // Private members:
        private int N;                      // Number of readings
        private int[N] readingCool;         // Array to hold raw counts from cooling period
        private int[N] readingCount;        // Array to hold raw counts from state detection
        private bool[N] readingErrorCool;   // Error flag from cooling period
        private bol[N] readingErrorCount;   // Error flag from count period
        private int spectrum;               // Which spectrum the data point belongs to
        private int date;                   // Date when the data point was taken





        // 100 raw data readings

        // Default constructor
        public dataPoint()
        {
           // Cannot create a data point without a file - display error message
           System.Windows.Forms.MessageBox.Show("No file selected");
        }

        // Construct instance give a file
        public dataPoint(System.IO.StreamReader filename)
        {
            
        }




        // Important things go here


        // Set methods

        // Method to set the cooling count threshold for calculating bad counts
        public void setCoolThresh(int thresh)
        {

        }

        // Get methods

        // Method to return the frequency of the data point
        public int getFreq()
        {
        }

        // Method to return the number of bad counts
        public int getBadCounts()
        {
        }

        // Method to return excitation probability
        public int getExcitation()
        {
            // Must be 
        }






    }
}
