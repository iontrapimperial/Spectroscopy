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
        // List for plotting all bad counts
        private PointPairList badCountsAll = new PointPairList();

        // Lists for plotting histogram of counts
        private PointPairList histogramCoolPlot = new PointPairList();
        private PointPairList histogramCountPlot = new PointPairList();

        // Arrays for storing histogram data
        public int[] histogramCool;
        public int[] histogramCount;

        // Various bits of information about the spectrum
        private int dataSize;           // Number of data points
        private int coolThreshold;      // Cooling threshold
        private int countThreshold;     // Count threshold
        private bool beenInitialised = false;   // Has the initial data analysis taken place?

        // Metadata from file / live experiment
        private string[] metadata;
        private int repeats = new int();

        // Spectrum number/name stored in Viewer only
        private string spectrumName = "Default";
        private int spectrumNumber = new int();


        // Internal variables
        private int coolThresholdChanged = new int();       // Which direction cooling threshold has moved
        private int countThresholdChanged = new int();      // Which direction count threshold has moved


        //**************************//

        // Constructor given a list of data points
        public spectrum(List<dataPoint> dataPointsPassed, int spectrumNumberPassed,
                        string spectrumNamePassed, ref string[] metadataPassed)
        {
            myDataPoints = dataPointsPassed;        // Store list of data points
            dataSize = myDataPoints.Count;          // Count number of data points

            // Set spectrum name, number
            spectrumNumber = spectrumNumberPassed;
            spectrumName = spectrumNamePassed;

            this.createHistogram(myDataPoints, false);      // Create data for histograms

            // Fill in metadata
            metadata = new string[metadataPassed.Length];
            for (int i = 0; i < metadataPassed.Length; i++)
            {
                metadata[i] = metadataPassed[i];
            }

        }

        // Constructor given metadata and spectrum number
        public spectrum(ref string[] metadataPassed, int spectrumNumberPassed)
        {
            metadata = new string[metadataPassed.Length];
            // Fill in metadata
            for (int i = 0; i < metadataPassed.Length; i++)
            {
                metadata[i] = metadataPassed[i];
            }

            // Set spectrum number & name
            this.spectrumNumber = spectrumNumberPassed;
            this.spectrumName = metadata[15 + spectrumNumber];
            // Create empty list of data points
            myDataPoints = new List<dataPoint>();

            dataSize = 0;   //List of data points is currently empty so .Count method not valid.
            this.createHistogram(myDataPoints, false);      // Create blank histogram data reading for updating
        }
            
        // Methods
        //**************************//          
        // Method to add new list of data points to existing data
        public void addToSpectrum(List<dataPoint> dataPointsPassed)
        {
            // Add new data onto the end of list
            myDataPoints.AddRange(dataPointsPassed);
            dataSize = myDataPoints.Count();        // Update data size variable
            beenInitialised = false;                // Flag to recalculate all data
            // NB this is slightly slower than just calculating the data that has been added
            // but it should be fast enough, and it is much easier/quicker to write!
            
            // Update histograms from new data points. 'True' flags that this is an update to existing histograms
            createHistogram(dataPointsPassed, true);
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
        private void createHistogram(List<dataPoint> dataPointsPassed, bool update)
        {
            // Declare variables to be used in if statements (compiler complains if they haven't been initialised)
            // listSize stores size of new data points to be processed - for update only
            int listSize = new int();       
            // existingSize stores size of existing array - for update only
            int existingSize = new int();
           

            // To do whether we are updating or creating histogram
            int maxSize = 0;            // Store maximum size overall
            int[] maxSizeDataPoint;     // Store maximum size of each data point
            int loopSize;               // Store length of the for loop (how many data points to process)  

            // If we are updating the histogram
            if (update)
            {
                listSize = dataPointsPassed.Count();
                maxSizeDataPoint = new int[listSize];
                existingSize = histogramCool.Length;
                loopSize = listSize;            // Loop through new data points in the list
            }
            else
            {   // Otherwise, we create for the first time
                // Variable to keep track of the maximum number of counts
                maxSizeDataPoint = new int[dataSize];
                loopSize = dataSize;                // Loop through full length of myDataPoints
            }
            
            // Find maximum bin size
            // For each data point
            for (int i = 0; i < loopSize; i++)
            {
                // Use temp variable to store max count from each data point
                // Avoids calling function getMax() twice
                maxSizeDataPoint[i] = dataPointsPassed[i].getHistogramSize();
                // If the max counts in this data point is larger than any found previously
                if (maxSizeDataPoint[i] > maxSize)
                {
                    maxSize = maxSizeDataPoint[i];        // Update to new max
                }
            }

            // If we are updating, check size of arrays and extend if necessary
            if (update)
            {
                // If the new max size is larger than the existing array
                if (maxSize > histogramCool.Length)
                {
                    // Extend arrays to add new bins
                    Array.Resize(ref histogramCool, (maxSize));
                    Array.Resize(ref histogramCount, (maxSize));
                }
            }
            else
            {   // If we are creating the histogram for the first time, initialise arrays
                histogramCool = new int[maxSize];
                histogramCount = new int[maxSize];
            }



            // Add data to histogram
            // For each data point
            for (int i = 0; i < loopSize; i++)
            {
                // Retrieve the histogram for this data point
                int[] tempHistogramCool_DataPoint = dataPointsPassed[i].getHistogramCool();
                int[] tempHistogramCount_DataPoint = dataPointsPassed[i].getHistogramCount();

                // For each bin
                for (int j = 0; j < maxSizeDataPoint[i]; j++)
                {
                    // Add histogram data from this data point to total histogram
                    histogramCool[j] += tempHistogramCool_DataPoint[j];
                    histogramCount[j] += tempHistogramCount_DataPoint[j];
                }
            }
        }

        // Method to create data for plotting to graph
        // Also creates lists of bad counts
        private void createDataPlot()
        {
            // Temporary variable for storing freq of each point
            int freq = new int();
            int temp_badCountsThreshold = new int();
            int temp_badCountsErrors = new int();

            // Loop through each data point
            for (int i = 0; i < dataSize; i++)
            {
                freq = myDataPoints[i].getFreq();                    // Frequency

                temp_badCountsErrors = myDataPoints[i].getBadCountsErrors();
                temp_badCountsThreshold = myDataPoints[i].getBadCountsThreshold();

                // Add correct data to all three lists
                dataPlot.Add( freq, myDataPoints[i].getDarkProb() );
                badCountsThreshold.Add(freq, temp_badCountsThreshold);
                badCountsErrors.Add(freq, temp_badCountsErrors);
                badCountsAll.Add(freq, (temp_badCountsThreshold + temp_badCountsErrors) );
            }

        }
            
        // Method to create data for plotting to graph
        // Also creates the list of bad counts due to cooling threshold failures
        // NB badCountsErrors will not need updating
        private void updateDataPlot()
        {
            // Clear lists of data
            dataPlot.Clear();

            // Only clear bad counts lists if cooling threshold has changed
            if (coolThresholdChanged != 2)
            {
                badCountsThreshold.Clear();
                badCountsAll.Clear();
            }

            // Temporary variables for frequency, bad counts due to threshold
            int freq = new int();
            int temp_badCountsThreshold = new int();
            int temp_badCountsErrors = new int();

            // Loop through each data point
            for (int i = 0; i < dataSize; i++)
            {
                freq = myDataPoints[i].getFreq();              // Frequency

                // Add correct data to lists
                dataPlot.Add( freq, myDataPoints[i].getDarkProb() );
                
                // Only update bad counts list if cooling threshold has changed
                if (coolThresholdChanged != 2)
                {
                    // Retrive bad counts due to errors/threshold for this data point
                    temp_badCountsThreshold = myDataPoints[i].getBadCountsThreshold();
                    temp_badCountsErrors = (int) badCountsErrors[i].Y;

                    // Add data to lists for plotting:
                    // Bad counts due to threshold
                    badCountsThreshold.Add(freq, temp_badCountsThreshold);
                    // All bad counts
                    badCountsAll.Add(freq, (temp_badCountsThreshold + temp_badCountsErrors) );

                }
            }
        }

        public void writePlotData(ref TextWriter myDataFile)
        {
            myDataFile.WriteLine("Frequency\tDark ion prob");

            for (int i = 0; i < dataSize; i++)
            {
                myDataFile.WriteLine(dataPlot[i].X + "\t" + dataPlot[i].Y);
            }

            myDataFile.Flush();
            myDataFile.Close();
        }
            
        // Method to write histogram data to a given file
        public void writeHistogramData(ref TextWriter histogramFile)
        {
            // Create streamwriter object to write to file
            // With filename given from user input
            // Write column titles
            histogramFile.WriteLine("Bin\tTotal\tCooling period\tCountperiod");

            // Go through each bin, write data to the file
            for (int j = 0; j < histogramCool.Count(); j++)
            {
                histogramFile.WriteLine(j + "\t" + (histogramCool[j] + histogramCount[j]) + "\t"
                                        + histogramCool[j] + "\t" + histogramCount[j]);
            }
            // Flush & close file when finished
            histogramFile.Flush();
            histogramFile.Close();
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

        // Method to return list of bad counts due to ALL errors
        public PointPairList getBadCountsAll()
        {
            return badCountsAll;
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
