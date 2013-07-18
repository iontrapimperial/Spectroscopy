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
        private int[] readingCool;                  // Array to hold raw counts from cooling period
        private int[] readingCount;                 // Array to hold raw counts from state detection
        private bool[] readingErrorCool;            // Error flag from cooling period
        private bool[] readingErrorCount;           // Error flag from count period
        private bool[] readingErrorThreshold;       // To keep track of whether the min threshold was met during cooling
        private int darkProb;                       // Probability of ion being dark
        private int badCountsErrors;                // No. of bad counts due to error flags
        private int badCountsThreshold;             // No. of bad counts due to not meeting minimum threshold
        private int darkCount;                      // No. of dark counts
        private int validReadings;                  // Total no. of valid readings (bright + dark)
        private int brightMean;                     // Mean fluorescence reading for bright counts
        private int darkMean;                       // Mean fluorescence reading for dark counts
        

        // Metadata
        private int frequency;              // Frequency of the data point
        private int spectrum;               // Which spectrum the data point belongs to
        private string date;                // Date when the data point was taken
        private int coolThreshold;          // Threshold value for min counts during cooling period
        private int countThreshold;         // Threshold value for distinguishing bright/dark
        private int repeats;                // Number of repeats



        // Default constructor
        public dataPoint()
        {
           // Cannot create a data point without a file - display error message
           System.Windows.Forms.MessageBox.Show("No file selected");
        }

        // Construct instance given an array of data,a starting point & a number of repeats
        // NB should be able to use the privately stored no. of repeats, but would fail if this has not been set, so more robust to pass no. of repeats
        public dataPoint(ref List<int[]> fullData, int startPoint, int repeatsPassed)
        {
            // For each repeat, populate array of private members
            for (int i = startPoint; i < (startPoint + repeatsPassed); i++)
            {
                readingCool[i] = fullData[i][0];                            // First int is the cooling period count
                readingErrorCool[i] = getBoolFromInt(fullData[i][1]);       // Second int is error flag for cooling period
                readingCount[i] = fullData[i][2];                           // Third int is the bright/dark count
                readingErrorCount[i] = getBoolFromInt(fullData[i][3]);      // Fourth int is the error flag for count period
                // Not certain the [i][0] etc is the right way around... first thing to check if there are errors
            }

            this.setRepeats(repeatsPassed);     // May as well set the metadata for no. of repeats straight away!

        }


        // Method to analyse data given a set of initial thresholds
        public void analyseInit(int cool, int count)
        {
            this.calcBadCountsErrors();         // Calculate no. of bad counts due to error flags
            this.analyseUpdate(cool, count);           // Call function to analyse from updated thresholds
        }

        // Method to analyse data from updated thresholds
        public void analyseUpdate(int cool, int count)
        {
            coolThreshold = cool;
            countThreshold = count;

            // Calculate no. of bad counts based on new threshold
            this.calcBadCountsThreshold();
            validReadings = repeats - (badCountsErrors + badCountsThreshold);   // Calculate no. of valid readings

            if (validReadings > 0.1 * repeats)
            {
                this.calcDarkProb();
            }
        }
        

        // Method to calculate probablity of ion being dark, based on thresholds
        private void calcDarkProb()
        {
            // Initialise averages to zero
            brightMean = 0;
            darkMean = 0;

            // For each reading
            for (int i = 0; i < repeats; i++)
            {
                // Only consider data point if no errors
                if (!readingErrorCool[i] && !readingErrorCount[i] && !readingErrorThreshold[i])
                {
                    if (readingCount[i] <= countThreshold)
                    {
                        darkCount++;                              // If count below threshold, then dark
                        darkMean += readingCount[i];              // Add fluorescence reading to average
                    }
                    else                                          // Otherwise, bright
                    {
                        brightMean += readingCount[i];            // Add fluorescence reading to average
                    }
                }
            }

            // Calculate averages
            brightMean = brightMean / validReadings;
            darkMean = darkMean / validReadings;

            // Calculate probability of ion being in dark state
            darkProb = darkCount / validReadings;

        }



        // Method to calculate number of bad counts due to error flags
        private void calcBadCountsErrors()
        {
            badCountsErrors = 0;                    // Reset to zero
            for (int i = 0; i < repeats; i++)       // For each reading
            {
                if(readingErrorCool[i]) badCountsErrors++;             // If cooling error flag is true, increase count
                else if(readingErrorCount[i]) badCountsErrors++;       // If count error flag is true
            }
        }

        // Method to calculate number of bad counts due to low cooling counts
        private void calcBadCountsThreshold()
        {
            badCountsThreshold = 0;                 // Reset to zero
            for (int i = 0; i < repeats; i++)       // For each reading
            {
                if (readingCool[i] <= coolThreshold)
                {
                    badCountsThreshold++;           // Increase count
                    readingErrorThreshold[i] = true;       // Flag that threshold was NOT met
                }
                else readingErrorThreshold[i] = false;     // Flag that threshold was met
            }
        }




        // Method to determine a boolean true/false from an integer value
        private bool getBoolFromInt(int x)
        {
            bool y;
            if (x == 0)
            {
                y = false;        // If x = 0, should return false
            }
            else
            {
                y = true;        // If x != 0, should return true
            }

            return y;
        }


        // Set methods
        //******************************

        // Method to set the cooling count threshold for calculating bad counts
        public void setCoolThresh(int x)
        {
            coolThreshold = x;
            // Check for bad counts caused by cooling period count not meeting threshold
        }

        // Method to set the threshold for distinguishing bright/dark
        public void setCountThresh(int x)
        {
            countThreshold = x;
            // Recalculate excitation prob every time this is changed

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

        // Method to set date
        public void setDate(string x)
        {
            date = x;
        }

        // Method to set which spectrum the data point belongs to
        public void setSpectrum(int x)
        {
            spectrum = x;
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
            // Calculated in separate method & stored - just return it here
            return excitationProb;
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

        // Method to return date
        public string getDate()
        {
            return date;
        }

        // Method to return which spectrum the data point belongs to
        public int getSpectrum()
        {
            return spectrum;
        }







    }
}
