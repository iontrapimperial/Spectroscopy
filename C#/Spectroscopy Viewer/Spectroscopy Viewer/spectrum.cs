using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spectroscopy_Viewer
{
    // Class contains all data for a spectrum
    class spectrum
    {
        // List of data point objects
        private List<dataPoint> dataPoints = new List<dataPoint>();
        // NB this is NOT the same list as in fileHandler, this will contain data points for one spectrum not one file


        private int dataSize;           // Number of data points
        private int coolThreshold;      // Cooling threshold
        private int countThreshold;     // Count threshold





        // Method to analyse data given new thresholds
        public void analyseInit()
        {
            // Get number of data points
            dataSize = dataPoints.Count();

            for (int i = 0; i < dataSize; i++)
            {
                dataPoints[i].analyseInit(coolThreshold, countThreshold);        // Update each data point
            }
        }

        // Method to analyse data given updated thresholds
        public void analyseUpdate()
        {
            // Get number of data points
            dataSize = dataPoints.Count();

            for (int i = 0; i < dataSize; i++)
            {
                dataPoints[i].analyseUpdate(coolThreshold, countThreshold);        // Update each data point
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
















    }
}
