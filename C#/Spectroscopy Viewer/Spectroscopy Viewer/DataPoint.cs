using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Spectroscopy_Viewer
{

    // Class to contain raw data for each frequency data point, and methods to access
    public class dataPoint
    {

        // Private members:
        private int[] readingCool;          // Array to hold raw counts from cooling period
        private int[] readingCount;         // Array to hold raw counts from state detection
        private bool[] readingErrorCool;    // Error flag from cooling period
        private bool[] readingErrorCount;   // Error flag from count period
        private int frequency;              // Frequency of the data point
        private int spectrum;               // Which spectrum the data point belongs to
        private int date;                   // Date when the data point was taken
        private int coolThreshold;          // Threshold value for min counts during cooling period
        private int countThreshold;         // Threshold value for distinguishing bright/dark
        private int repeats = 0;                // Number of repeats



        // Default constructor
        public dataPoint()
        {
           // Cannot create a data point without a file - display error message
           System.Windows.Forms.MessageBox.Show("No file selected");
        }

        // Construct instance given an array of data,a starting point & a number of repeats
        // NB should be able to use the privately stored no. of repeats, but would fail if this has not been set, so more robust to pass no. of repeats
        public dataPoint(ref List<byte[]> fullData, int startPoint, int repeatsPassed)
        {
            

        }



        // Set methods
        //******************************

        // Method to set the cooling count threshold for calculating bad counts
        public void setCoolThresh(int x)
        {
            coolThreshold = x;
        }

        // Method to set the threshold for distinguishing bright/dark
        public void setCountThresh(int x)
        {
            countThreshold = x;
        }

        // Method to set number of repeats
        public void setRepeats(int x)
        {
            repeats = x;
        }

        // Method to set frequency of data point
        public void setFreq(int x)
        {
            frequency = x;
        }





        // Get methods
        //******************************

        // Method to return the frequency of the data point
        public int getFreq()
        {
            return frequency;
        }

        // Method to return the number of bad counts
        public int getBadCounts()
        {
        }

        // Method to return excitation probability
        public int getExcitation()
        {
            
            
        }

        // Method to return number of repeats
        public int getRepeats()
        {
            return repeats;
        }

        // Method to return cooling threshold
        public int getCoolThresh()
        {
            return coolThreshold;
        }

        // Method to return count threshold
        public int getCountThresh()
        {
            return countThreshold;
        }







    }
}
