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
        private int ggThreshold; 

        // Internal variables - calculated within the class
        private bool[] readingErrorThreshold;           // To keep track of whether the min threshold was met during cooling
        private bool[] readingDark;                     // Whether the reading was dark or not (true => dark)
        
        private int badCountsErrors = new int();        // No. of bad counts due to error flags
        private int badCountsThreshold = new int();     // No. of bad counts due to not meeting minimum threshold
        private int darkCount = new int();              // No. of dark counts     
        private int validReadings = new int();          // Total no. of valid readings (bright + dark)
        private float darkProb = new float();           // Probability of ion being dark
        private float ggProb = new float();
        private float eggeProb = new float();
        private int[] histogramCool;
        private int[] histogramCount;
        private int histogramSize = new int();
           
        // Construct instance given an array of data, a starting point & a number of repeats
        // NB should be able to use the privately stored no. of repeats, but would fail if this has not been set, so more robust to pass no. of repeats
        public dataPoint(ref List<int[]> fullData, int startPoint, int repeatsPassed)
        {
            repeats = repeatsPassed;            // Set number of repeats
            // Initialise based on number of repeats
            readingCool = new int[repeats];
            readingErrorCool = new bool[repeats];
            readingCount = new int[repeats];
            readingErrorCount = new bool[repeats];
            readingDark = new bool[repeats];
            readingErrorThreshold = new bool[repeats];

            int j = 0;                  // Counter for internal data arrays
            // For each repeat, populate array of private members
            for (int i = startPoint; i < (startPoint + repeats); i++)
            {
                if (i < fullData.Count())
                {
                    if (i < fullData.Count())
                    {
                        readingCool[j] = fullData[i][0];                            // First int is the cooling period count
                        readingErrorCool[j] = getBoolFromInt(fullData[i][1]);       // Second int is error flag for cooling period
                        readingCount[j] = fullData[i][2];                           // Third int is the bright/dark count
                        readingErrorCount[j] = getBoolFromInt(fullData[i][3]);      // Fourth int is the error flag for count period
                        j++;
                    }
                    else
                    {
                        MessageBox.Show("Error: Incorrect number of repeats");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Error: Incorrect number of repeats entered");
                    return;
                }
            }

            this.createHistogram();             // Create histogram data
     
        }

        // Method to create the histogram
        private void createHistogram()
        {
            // Find max number of counts in the data set
            // Add 1 to give total array size (must include zero!)
            histogramSize = this.findMaxCounts() + 1;

            // Initialise histogram arrays based on maximum number of counts in the data set
            histogramCool = new int[histogramSize];
            histogramCount = new int[histogramSize];

            // For each reading
            for (int i = 0; i < repeats; i++)
            {
                // Only add the count to the histogram if there were no error flags
                //if (!readingErrorCool[i] && !readingErrorCount[i])
                if (!readingErrorCool[i])
                {
                    int x = readingCool[i];
                    int y = readingCount[i];

                    // Increment the value in the bin corresponding to the number of counts for this reading
                    // E.g. if readingCool[i] = 20, then this adds 1 to the value in bin 20 of histogramCool
                    histogramCool[x]++;
                    histogramCount[y]++;
                }
            }
        }
         
        // Method to analyse data given a set of initial thresholds
        public void analyseInit(int cool, int count, int gg)
        {
            this.calcBadCountsErrors();         // Calculate no. of bad counts due to error flags

            coolThreshold = cool;
            countThreshold = count;
            ggThreshold = gg; 

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
        public void analyseUpdate(int cool, int coolThresholdChanged, int count, int countThresholdChanged, int gg, int ggThresholdChanged)
        {
            // Update thresholds
            coolThreshold = cool;
            countThreshold = count;
            ggThreshold = gg;
        

            if (coolThresholdChanged != 2)     // Only if cooling threshold has changed
            {
                this.updateBadCountsThreshold(coolThresholdChanged);        // Update bad counts
                validReadings = repeats - (badCountsErrors + badCountsThreshold);   // Update no. of valid readings
            }

            // TEMPORARY FOR BUG FIX - *ALWAYS* DO THE FOLLOWING
            //if (countThresholdChanged != 2) // Only if count threshold has changed
            //{
            if (validReadings > 0.1 * repeats)
            {
                this.updateDarkProb(countThresholdChanged);         // Update dark prob
            }
            else darkProb = 0;
            //}
            //else    // Or if count threshold has not changed
            //{   // Update dark probability based only on the change in bad counts
            //    this.updateDarkProb_BadCountsOnly();
            //}
        }

        // Method to calculate probablity of ion being dark, based on initial thresholds
        private void calcDarkProb()
        {
            darkProb = new int();
            darkCount = 0;                  // Initialise dark count
            int tempGG = 0;
            // For each reading
            if (ggThreshold == 0)
            {
                for (int i = 0; i < repeats; i++)
                {
                    // Only consider data point if no errors
                    if (!readingErrorCool[i] && !readingErrorCount[i] && !readingErrorThreshold[i])
                    {
                        if (readingCount[i] < countThreshold)
                        {
                            darkCount++;                        // If count below threshold, then dark
                            readingDark[i] = true;              // Flag as dark
                        }
                        else readingDark[i] = false;            // Flag as not dark
                    }
                }
                // Calculate probability of ion being in dark state
                darkProb = (float)darkCount / validReadings;
            }
            else
            {
               
                for (int i = 0; i < repeats; i++)
                    if (!readingErrorCool[i] && !readingErrorCount[i] && !readingErrorThreshold[i])
                    {
                        if (readingCount[i] < countThreshold)
                        {
                            darkCount++;                        // If count below threshold, then dark
                            readingDark[i] = true;              // Flag as dark
                        }
                        else if(readingCount[i] > ggThreshold)
                        {
                            tempGG++;
                            readingDark[i] = false;            // Flag as not dark

                        }
                        else readingDark[i] = false;
                    }
            }
        
            // Calculate probability of ion being in dark state
            darkProb = (float)darkCount / validReadings;
            ggProb = (float)tempGG / validReadings;
            eggeProb = 1 - darkProb - ggProb;



        }
        

        // Method to calculate probability of ion being dark, based on updated thresholds
        // So only check the bright/dark status of those which may have changed
        private void updateDarkProb(int directionOfChange)
        {
            calcDarkProb();
            
            //Always check every point whether threshold moved up or down (BUG FIX)
            /*
            darkCount = 0;

            for (int i = 0; i < repeats; i++)       // For each data point
            {
                // Only consider data point if no errors
                 if (!readingErrorCool[i] && !readingErrorCount[i] && !readingErrorThreshold[i])
               
                {
                    if (readingCount[i] < countThreshold)
                    {
                        darkCount++;                        // If count below threshold, then dark
                        readingDark[i] = true;              // Flag as dark
                    }
                    else readingDark[i] = false;                 // Flag as NOT dark                  
                }
            }

             REMOVED THIS FOR BUG FIX
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

            */
        }

        // Method to update the probability of ion being dark if ONLY the cooling threshold has changed
        // (when count threshold has NOT changed). Only change will be due to bad counts being removed.
        // TEMPORARILY REMOVED FOR BUG FIX
        /*private void updateDarkProb_BadCountsOnly()
        {
            for (int i = 0; i < repeats; i++)
            {
                // Only check readings which were dark already
                if (readingDark[i])
                {   // If that reading has now got a threshold error
                    if (readingErrorThreshold[i])
                    {
                        darkCount--;                // Decrease dark count
                        readingDark[i] = false;     // Flag as NOT dark
                    }
                }
            }
            // Update probability of ion being in dark state
            darkProb = (float)darkCount / validReadings;
        }*/
        
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
                if (readingCool[i] < coolThreshold)
                {
                    if (!readingErrorCool[i] && !readingErrorCount[i]) badCountsThreshold++; // Increase count if NOT already cool/count badcount
                    readingErrorThreshold[i] = true;       // Flag that threshold was NOT met
                }
                else readingErrorThreshold[i] = false;     // Flag that threshold was met
            }
        }



        // Method to re-calculate number of bad counts due to low cooling counts, based on a changed threshold
        // Only re-checks those that might have changed
        private void updateBadCountsThreshold(int directionOfChange)
        {
            //Temporary (?) bug fix - will completely recalculate bad counts from scratch whether threshold raised or lowered
            
            badCountsThreshold = 0; //Reset bad counts

            for (int i = 0; i < repeats; i++)
            {
                if (readingCool[i] < coolThreshold)        // If it does NOT meet threshold
                {
                    if (!readingErrorCool[i] && !readingErrorCount[i]) badCountsThreshold++; // Increase count if NOT already cool/count badcount
                    readingErrorThreshold[i] = true;        // Flag that threshold was NOT met
                }
                else readingErrorThreshold[i] = false;       // Flag that threshold WAS met 
            }

            /* REMOVED FOR BUG FIX
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
            }*/
        } 
        
        // Method to find the maximum number of counts in all the readings
        private int findMaxCounts()
        {
            int maxCool = readingCool.Max();
            int maxCount = readingCount.Max();

            if (maxCool >= maxCount) return maxCool;
            else return maxCount;
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


        // Method to set frequency of data point
        public void setFreq(int x)
        {
            frequency = x;
        }
  
        // Get methods
        //******************************

        // Method to return the maximum count value from the set of readings
        public int getHistogramSize()
        {
            return histogramSize;
        }

        // Method to return histogram of counts from cooling period
        public int[] getHistogramCool()
        {
            return histogramCool;
        }

        // Method to return histogram of counts from state detection period
        public int[] getHistogramCount()
        {
            return histogramCount;
        }
 
        // Method to return the frequency of the data point
        public int getFreq()
        {
            return frequency;
        }

        // Method to return the number of bad counts due to cooling threshold failures
        public int getBadCountsThreshold()
        {
            return badCountsThreshold;
        }

        // Method to return the number of bad counts due to error flags
        public int getBadCountsErrors()
        {
            return badCountsErrors;
        }

        // Method to return excitation probability
        public float getDarkProb()
        {
            // Calculated in separate method & stored - just return it here
            return darkProb;
        }
        public float getGGProb()
        {
            // Calculated in separate method & stored - just return it here
            return ggProb;
        }

        public float getEGGEProb()
        {
            // Calculated in separate method & stored - just return it here
            return eggeProb;
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
        public int getGGThresh()
        {
            return ggThreshold;
        }


        public bool[] getReadingDark()
        {
            return readingDark;
        }
    }
}
