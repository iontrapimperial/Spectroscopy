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
        //******************//

        // Raw data take from file
        private int[] readingCool;                  // Array to hold raw counts from cooling period
        private int[] readingCount;                 // Array to hold raw counts from state detection
        private bool[] readingErrorCool;            // Error flag from cooling period
        private bool[] readingErrorCount;           // Error flag from count period

        // Metadata
        private int frequency;              // Frequency of the data point
        private int repeats;                // Number of repeats
        
        // Thresholds
        private int coolThreshold;          // Threshold value for min counts during cooling period
        private int countThreshold;         // Threshold value for distinguishing bright/dark

        // Internal variables - calculated within the class
        private bool[] readingErrorThreshold;           // To keep track of whether the min threshold was met during cooling
        private bool[] readingDark;                     // Whether the reading was dark or not (true => dark)
        private int badCountsErrors = new int();        // No. of bad counts due to error flags
        private int badCountsThreshold = new int();     // No. of bad counts due to not meeting minimum threshold
        private int darkCount = new int();              // No. of dark counts
        private int validReadings = new int();          // Total no. of valid readings (bright + dark)
        private float darkProb = new float();           // Probability of ion being dark
   


        // Construct instance given an array of data, a starting point & a number of repeats
        // NB should be able to use the privately stored no. of repeats, but would fail if this has not been set, so more robust to pass no. of repeats
        public dataPoint(ref List<int[]> fullData, int startPoint, int repeatsPassed)
        {
            // Initialise based on number of repeats
            readingCool = new int[repeatsPassed];
            readingErrorCool = new bool[repeatsPassed];
            readingCount = new int[repeatsPassed];
            readingErrorCount = new bool[repeatsPassed];

            int j = 0;                  // Counter for internal data arrays
            // For each repeat, populate array of private members
            for (int i = startPoint; i < (startPoint + repeatsPassed); i++)
            {
                readingCool[j] = fullData[i][0];                            // First int is the cooling period count
                readingErrorCool[j] = getBoolFromInt(fullData[i][1]);       // Second int is error flag for cooling period
                readingCount[j] = fullData[i][2];                           // Third int is the bright/dark count
                readingErrorCount[j] = getBoolFromInt(fullData[i][3]);      // Fourth int is the error flag for count period
                j++;
            }

            this.setRepeats(repeatsPassed);     // May as well set the metadata for no. of repeats straight away!

        }


        // Method to analyse data given a set of initial thresholds
        public void analyseInit(int cool, int count)
        {
            this.calcBadCountsErrors();         // Calculate no. of bad counts due to error flags

            coolThreshold = cool;
            countThreshold = count;

            // Calculate no. of bad counts based on new threshold
            this.calcBadCountsThreshold();
            validReadings = repeats - (badCountsErrors + badCountsThreshold);   // Calculate no. of valid readings
            
            // Only calculate if there are enough valid readings
            if (validReadings > 0.1 * repeats)
            {
                this.calcDarkProb();
            }

        }

        // Method to analyse data from updated thresholds
        public void analyseUpdate(int cool, int count)
        {
            //****************************************
            // When thresholds change, we want to keep track of whether they have changed up or down and NOT recalculate
            // all threshold checks, just those that might have changed

            // Variable to store information about whether the cooling threshold is increased, decreased or unchanged
            // 0 => threshold has increased
            // 1 => threshold has decreased
            // 2 => threshold is unchanged
            int coolThresholdChanged;

            if (cool > coolThreshold) coolThresholdChanged = 0;
            else if (cool < coolThreshold) coolThresholdChanged = 1;
            else coolThresholdChanged = 2;


            // Variable to store information about whether the count threshold is increased, decreased or unchanged
            // 0 => threshold has increased
            // 1 => threshold has decreased
            // 2 => threshold is unchanged
            int countThresholdChanged;

            if (count > countThreshold) countThresholdChanged = 0;
            else if (count < countThreshold) countThresholdChanged = 1;
            else countThresholdChanged = 2;
            //******************************************


            // Update thresholds
            coolThreshold = cool;
            countThreshold = count;


            if (coolThresholdChanged != 2)     // Only if cooling threshold has changed
            {
                this.updateBadCountsThreshold(coolThresholdChanged);        // Update bad counts
                validReadings = repeats - (badCountsErrors + badCountsThreshold);   // Update no. of valid readings
            }
         

            
            if (countThresholdChanged != 2) // Only if count threshold has changed
            {
                if (validReadings > 0.1 * repeats)
                {
                    this.updateDarkProb(countThresholdChanged);         // Update dark prob
                }

            }
        }
        

        // Method to calculate probablity of ion being dark, based on initial thresholds
        private void calcDarkProb()
        {
            // Initialise array based on number of repeats
            readingDark = new bool[repeats];
            darkCount = 0;                  // Initialise dark count

            // For each reading
            for (int i = 0; i < repeats; i++)
            {
                // Only consider data point if no errors
                if (!readingErrorCool[i] && !readingErrorCount[i] && !readingErrorThreshold[i])
                {
                    if (readingCount[i] <= countThreshold)
                    {
                        darkCount++;                        // If count below threshold, then dark
                        readingDark[i] = true;              // Flag as dark
                    }
                    else readingDark[i] = false;            // Flag as not dark
                }
            }
            // Calculate probability of ion being in dark state
            darkProb = (float) darkCount / validReadings;

        }

        // Method to calculate probability of ion being dark, based on updated thresholds
        // So only check the bright/dark status of those which may have changed
        private void updateDarkProb(int directionOfChange)
        {
             // If threshold has gone up, only check those which were not dark last time
            if (directionOfChange == 0)
            {
                for (int i = 0; i < repeats; i++)       // For each data point
                {
                    // Only consider data point if no errors
                    if (!readingErrorCool[i] && !readingErrorCount[i] && !readingErrorThreshold[i])
                    {
                        if (!readingDark[i])                   // If it was NOT dark last time
                        {
                            if (readingCount[i] <= countThreshold)
                            {
                                darkCount++;                        // If count below threshold, then dark
                                readingDark[i] = true;              // Flag as dark
                            }
                        }
                    }
                }
            }
            else if (directionOfChange == 1)      // If it has gone down, only check those which were dark
            {
                for (int i = 0; i < repeats; i++)   // For each data point
                {
                    // Only consider data point if no errors
                    if (!readingErrorCool[i] && !readingErrorCount[i] && !readingErrorThreshold[i])
                    {
                        if (readingDark[i])        // If it WAS dark last time
                        {
                            if (readingCount[i] > countThreshold)       // If count is now above threshold
                            {
                                darkCount--;                            // Decrease count
                                readingDark[i] = false;                 // Flag as NOT dark
                            }
                        }
                    }
                }

                
                
            }
            // Update probability of ion being in dark state
            darkProb = (float) darkCount / validReadings;
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
            // Initialise based on number of repeats
            readingErrorThreshold = new bool[repeats];

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

        // Method to re-calculate number of bad counts due to low cooling counts, based on a changed threshold
        // Only re-checks those that might have changed
        private void updateBadCountsThreshold(int directionOfChange)
        {
            // If threshold has gone up, only check those which succeeded last time
            if (directionOfChange == 0)
            {
                for (int i = 0; i < repeats; i++)       // For each data point
                {
                    if (!readingErrorThreshold[i])      // If it succeeded last time
                    {
                        if (readingCool[i] <= coolThreshold)        // If it does NOT meet threshold
                        {
                            badCountsThreshold++;                   // Increase count
                            readingErrorThreshold[i] = true;        // Flag that threshold was NOT met
                        }
                    }
                }
            }
            else if (directionOfChange == 1)        // If it has gone down, only check those which failed
            {
                for (int i = 0; i < repeats; i++)       // For each data point
                {
                    if (readingErrorThreshold[i])       // If it failed last time
                    {
                        if (readingCool[i] > coolThreshold)         // If it DOES meet threshold
                        {
                            badCountsThreshold--;                   // Decrease count
                            readingErrorThreshold[i] = false;       // Flag that threshold WAS met
                        }
                    }
                }
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
            return badCountsErrors + badCountsThreshold;
        }

        // Method to return excitation probability
        public float getDarkProb()
        {
            // Calculated in separate method & stored - just return it here
            return darkProb;
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
