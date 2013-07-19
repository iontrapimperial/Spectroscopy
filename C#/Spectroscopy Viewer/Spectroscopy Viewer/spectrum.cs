using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

namespace Spectroscopy_Viewer
{
    // Class contains all data for a spectrum
    class spectrum
    {

        // Private members:
        //**************************//

        // List of data point objects
        // NB this is NOT the same list as in fileHandler, this will contain data point objects for one spectrum not one file
        private List<dataPoint> myDataPoints = new List<dataPoint>();
        // PointPairList for plotting data. This will contain frequency and darkProb for each data point.
        private PointPairList dataPlot = new PointPairList();


        private int dataSize;           // Number of data points
        private int coolThreshold;      // Cooling threshold
        private int countThreshold;     // Count threshold



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



        // Method to analyse data given new thresholds
        public void analyseInit()
        {
            for (int i = 0; i < dataSize; i++)
            {
                myDataPoints[i].analyseInit(coolThreshold, countThreshold);        // Update each data point
            }
        }

        // Method to analyse data given updated thresholds
        public void analyseUpdate()
        {
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
            int x, y;

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
            return dataPlot;
        }















    }
}
