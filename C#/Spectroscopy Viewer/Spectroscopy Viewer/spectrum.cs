using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Diagnostics;       // To write lines to Debug Output for debugging

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


        // Various bits of information about the spectrum
        private int dataSize;           // Number of data points
        private int coolThreshold;      // Cooling threshold
        private int countThreshold;     // Count threshold
        private bool beenInitialised = false;   // Has the initial data analysis taken place?
        private string spectrumName = "Spectrum";
        private int spectrumNumber = new int();


        // Constructor given a list of data points
        public spectrum(List<dataPoint> dataPointsPassed)
        {
            myDataPoints = dataPointsPassed;
            dataSize = myDataPoints.Count;      // Count number of data points
        }


        // Methods
        //**************************//





        // Method to add new list of data points to existing data
        public void addToSpectrum(ref List<dataPoint> dataPointsPassed)
        {
            // Need to merge lists here

            dataSize = myDataPoints.Count();        // Update data size variable
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
            beenInitialised = true;
        }

        // Method to analyse data given updated thresholds
        private void analyseUpdate(int cool, int count)
        {
            // Update private members
            coolThreshold = cool;
            countThreshold = count;

            // Get number of data points
            dataSize = myDataPoints.Count();

            for (int i = 0; i < dataSize; i++)
            {
                myDataPoints[i].analyseUpdate(coolThreshold, countThreshold);        // Update each data point
            }


        }




        // Method to create data for plotting to graph
        private void createDataPlot()
        {
            int x = new int();
            float y = new float();

            for (int i = 0; i < dataSize; i++)
            {
                x = myDataPoints[i].getFreq();
                y = myDataPoints[i].getDarkProb();
                dataPlot.Add(x, y);
            }

        }



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

        // Method to return data for plotting - by reference
        public PointPairList getDataPlot()
        {
            this.createDataPlot();        // Create the list of data
            return dataPlot;
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













    }
}
