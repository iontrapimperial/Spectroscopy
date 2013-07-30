using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Diagnostics;

namespace Spectroscopy_Viewer
{
    // Class contains all data for a spectrum
    public class spectrum
    {

        // Private members:
        //**************************//

        // List of data point objects
        // NB this is NOT the same list as in fileHandler, this will contain data point objects for one spectrum not one file
        private List<dataPoint> myDataPoints = new List<dataPoint>();
        // PointPairList for plotting data. This will contain frequency and darkProb for each data point.
        private PointPairList dataPlot = new PointPairList();

        // List for plotting bad counts due to failed cooling counts
        private PointPairList badCountsThreshold = new PointPairList();
        // List for plotting bad counts due to error flags
        private PointPairList badCountsErrors = new PointPairList();

        // Lists for plotting histogram of counts
        private PointPairList histogramCoolPlot = new PointPairList();
        private PointPairList histogramCountPlot = new PointPairList();

        // Arrays for storing histogram data
        int[] histogramCool;
        int[] histogramCount;

        // Various bits of information about the spectrum
        private int dataSize;           // Number of data points
        private int coolThreshold;      // Cooling threshold
        private int countThreshold;     // Count threshold
        private bool beenInitialised = false;   // Has the initial data analysis taken place?
        private string spectrumName = "Default";
        private int spectrumNumber = new int();

        // Internal variables
        private int coolThresholdChanged = new int();       // Which direction cooling threshold has moved
        private int countThresholdChanged = new int();      // Which direction count threshold has moved


        //**************************//

        // Constructor given a list of data points
        public spectrum(List<dataPoint> dataPointsPassed)
        {
            myDataPoints = dataPointsPassed;        // Store list of data points
            dataSize = myDataPoints.Count;          // Count number of data points
            this.createHistogram();                 // Create data for histogram
        }


        // Methods
        //**************************//


        // Method to add new list of data points to existing data
        public void addToSpectrum(List<dataPoint> dataPointsPassed)
        {
            // Add new data onto the end of list
            myDataPoints.AddRange(dataPointsPassed);
            dataSize = myDataPoints.Count();        // Update data size variable

            // Code for debugging

            TextWriter testFile = new StreamWriter("C:/Users/localadmin/Documents/New data points.txt");
            testFile.WriteLine("Frequency\tDark ion prob");

            for (int i = 0; i < dataSize; i++)
            {
                int x = myDataPoints[i].getFreq();
                float y = myDataPoints[i].getDarkProb();
                testFile.WriteLine(x + "\t" + y);
            }

            testFile.Flush();
            testFile.Close();

        }



        // General public method to analyse data
        // When we call this, we don't want to have to know about whether the initial analysis has taken place or not
        public void analyse(int cool, int count)
        {
            // If not yet initialised, carry out initial analysis
            if (!beenInitialised) this.analyseInit(cool, count);
            // Otherwise just update
            else this.analyseUpdate(cool, count);
        }


        // Method to analyse data given new thresholds
        private void analyseInit(int cool, int count)
        {
            // Update private members
            coolThreshold = cool;
            countThreshold = count;

            for (int i = 0; i < dataSize; i++)
            {
                myDataPoints[i].analyseInit(coolThreshold, countThreshold);          // Update each data point
            }
            this.createDataPlot();          // Always want to create data for plotting
            beenInitialised = true;         // Flag that initialisation has been completed
        }

        // Method to analyse data given updated thresholds
        private void analyseUpdate(int cool, int count)
        {

            // Calculate this here instead of within data point - saves doing it for every data point
            // & also update dataPlot, badCountsThreshold list differently depending on which thresholds changed


            //****************************************
            // When thresholds change, we want to keep track of whether they have changed up or down and NOT recalculate
            // all threshold checks, just those that might have changed

            // Variable to store information about whether the cooling threshold is increased, decreased or unchanged
            // 0 => threshold has increased
            // 1 => threshold has decreased
            // 2 => threshold is unchanged
            if (cool > coolThreshold) coolThresholdChanged = 0;
            else if (cool < coolThreshold) coolThresholdChanged = 1;
            else coolThresholdChanged = 2;


            // Variable to store information about whether the count threshold is increased, decreased or unchanged
            // 0 => threshold has increased
            // 1 => threshold has decreased
            // 2 => threshold is unchanged
            if (count > countThreshold) countThresholdChanged = 0;
            else if (count < countThreshold) countThresholdChanged = 1;
            else countThresholdChanged = 2;
            //******************************************


            // Update private members
            coolThreshold = cool;
            countThreshold = count;

            // Only do anything if thresholds have actually changed
            if (countThresholdChanged != 2 || coolThresholdChanged != 2)
            {
                for (int i = 0; i < dataSize; i++)
                {
                    // Update each data point
                    myDataPoints[i].analyseUpdate(coolThreshold, coolThresholdChanged,
                                                    countThreshold, countThresholdChanged);
                }
                this.updateDataPlot();
            }

        }

        // Method to create arrays of data for the histogram
        private void createHistogram()
        {
            // Variable to keep track of the maximum number of counts
            int[] maxSizeDataPoint = new int[dataSize];
            int maxSize = 0;

            // For each data point
            for (int i = 0; i < dataSize; i++)
            {
                // Use temp variable to store max count from each data point
                // Avoids calling function getMax() twice
                maxSizeDataPoint[i] = myDataPoints[i].getHistogramSize();
                // If the max counts in this data point is larger than any found previously
                if (maxSizeDataPoint[i] > maxSize)
                {
                    maxSize = maxSizeDataPoint[i];        // Update to new max
                }
            }

            histogramCool = new int[maxSize];
            histogramCount = new int[maxSize];

            // For each data point
            for (int i = 0; i < dataSize; i++)
            {
                // Retrieve the histogram for this data point
                int[] tempHistogramCool_DataPoint = myDataPoints[i].getHistogramCool();
                int[] tempHistogramCount_DataPoint = myDataPoints[i].getHistogramCount();

                // For each bin
                for (int j = 0; j < maxSizeDataPoint[i]; j++)
                {
                    // Add histogram data from this data point to total histogram
                    histogramCool[j] += tempHistogramCool_DataPoint[j];
                    histogramCount[j] += tempHistogramCount_DataPoint[j];
                }
            }

            /*
            TextWriter testFile = new StreamWriter("C:/Users/localadmin/Documents/Histogram.txt");

            for (int i = 0; i < maxSize; i++)
            {
                testFile.WriteLine("{0}, Cool: {1}, Count: {2}", i, histogramCool[i], histogramCount[i]);
            }

            testFile.Flush();
            testFile.Close();
            */
        }

        // Method to update histogram (called only when new data points are added to spectrum)
        private void updateHistogram(List<dataPoint> dataPointsPassed)
        {
            // Needs to be written!

        }



        // Method to create data for plotting to graph
        // Also creates lists of bad counts
        private void createDataPlot()
        {
            // Temporary variable for storing freq of each point
            int freq = new int();

            // Loop through each data point
            for (int i = 0; i < dataSize; i++)
            {
                freq = myDataPoints[i].getFreq();                    // Frequency

                // Add correct data to all three lists
                dataPlot.Add( freq, myDataPoints[i].getDarkProb() );
                badCountsThreshold.Add( freq, myDataPoints[i].getBadCountsThreshold() );
                badCountsErrors.Add( freq, myDataPoints[i].getBadCountsErrors() );
            }

        }


        // Method to create data for plotting to graph
        // Also creates the list of bad counts due to cooling threshold failures
        // NB badCountsErrors will not need updating
        private void updateDataPlot()
        {
            // Clear lists of data
            dataPlot.Clear();
            // Only clear bad counts list if cooling threshold has changed
            if (coolThresholdChanged != 2) badCountsThreshold.Clear();

            // Temporary variable for frequency
            int freq = new int();

            // Loop through each data point
            for (int i = 0; i < dataSize; i++)
            {
                freq = myDataPoints[i].getFreq();              // Frequency

                // Add correct data to lists
                dataPlot.Add( freq, myDataPoints[i].getDarkProb() );
                
                // Only update bad counts list if cooling threshold has changed
                if (coolThresholdChanged != 2)
                {
                    badCountsThreshold.Add(freq, myDataPoints[i].getBadCountsThreshold());
                }
            }
        }

        // 'Set' methods
        //**********************//

        // Method to set cooling threshold
        public void setCoolThreshold(int x)
        {
            coolThreshold = x;
        }

        // Method to set count threshold
        public void setCountThreshold(int x)
        {
            countThreshold = x;
        }

        // Method to set spectrum name
        public void setName(string S)
        {
            spectrumName = S;
        }

        // Method to set spectrum number
        public void setNumber(int x)
        {
            spectrumNumber = x;
        }


        // 'Get' methods
        //**********************//

        // Method to return cooling threshold
        public int getCoolThreshold()
        {
            return coolThreshold;
        }

        // Method to return count threshold
        public int getCountThreshold()
        {
            return countThreshold;
        }


        // Method to return number of data points
        public int getDataSize()
        {
            return dataSize;
        }

        // Method to return dark ion prob data for plotting - by reference
        public PointPairList getDataPlot()
        {
            return dataPlot;
        }

        // Method to return list of bad counts due to error flags
        public PointPairList getBadCountsErrors()
        {
            return badCountsErrors;
        }

        // Method to return list of bad counts due to threshold errors
        public PointPairList getBadCountsThreshold()
        {
            return badCountsThreshold;
        }
                      
        // Method to return name of spectrum
        public string getName()
        {
            return spectrumName;
        }

        // Method to return spectrum number
        public int getNumber()
        {
            return spectrumNumber;
        }

        // Method to return array of histogram data from cooling periods
        public int[] getHistogramCool()
        {
            return histogramCool;
        }

        // Method to return array of histogram data from count periods
        public int[] getHistogramCount()
        {
            return histogramCount;
        }

    }
}
