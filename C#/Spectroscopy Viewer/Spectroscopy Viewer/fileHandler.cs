using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Spectroscopy_Viewer
{
    // Class to open data files & create instances of dataPoint for each frequency
    class fileHandler : Object
    {

        // Create a list of arrays. Each array contains 4 integer values (i.e. the data for a single reading - cool, count & error flags)
        private List<int[]>[] fullData;
        // Create a list of dataPoint objects
        private List<dataPoint>[] dataPoints;

        // Metadata read from file
        private int startFrequency;         // Starting frequency of the file
        private int stepSize;               // Step size in frequency
        private string date;                // Date when file was taken
        private int repeats;                // Number of repeats
        private int numberInterleaved;      // How many spectra are interleaved in this file
        private float trapFrequency;          // Trap frequency
        private float trapVoltage;            // Trap voltage
        private string[] spectrumNames;          // Names of spectra stored in file
        private string notes = "";

        // Default constructor
        public fileHandler()
        {
            // Cannot handle data if a file is not chosen!
            System.Windows.Forms.MessageBox.Show("No file selected");
        }

        // Constructor given an array of data and an array of metadata (for live mode)
        public fileHandler(ref int[] IncomingData, ref string[] metadata)
        {
            // Need to convert the array of incoming data into a List<int[]>[]
            // Each list is for a separate spectrum
            // Each int[] is an array of 4 ints (one reading, inc cooling, counts & error flags)

            // Check that the number interleaved & number of repeats are valid ints, if not then we can't handle the data
            // TryParse method converts the string (1st argument) to an int, stores it in the int (2nd argument)
            // and returns true if the process was successful, false if not
            if( int.TryParse(metadata[5], out numberInterleaved) && int.TryParse(metadata[4], out repeats) )
            {

                // Initialise arrays for storing Lists of raw data & dataPoints
                fullData = new List<int[]>[numberInterleaved];
                dataPoints = new List<dataPoint>[numberInterleaved];

                // Have to initialise the array and then each List in the array individually... tedious!!
                for (int i = 0; i < numberInterleaved; i++)
                {
                    fullData[i] = new List<int[]>();
                    dataPoints[i] = new List<dataPoint>();
                }



                // row counter to keep track of which array of 4 readings within the list we are filling
                int j = 0;

                // Loop through incoming data array
                for (int m = 0; m < IncomingData.Length; m++)
                {
                    // Fill a separate list for each interleaved spectrum
                    for (int k = 0; k < numberInterleaved; k++)
                    {
                        // This MUST be a new int, cannot add any other array!!!!
                        fullData[k].Add(new int[4]);                        // Add new reading to the list, reading will contain 4 ints

                        // Loop through the 4 readings
                        for (int i = 0; i < 4; i++)
                        {
                            //
                            fullData[k][j][i] = IncomingData[m];
                            // Move to the next element in the array of incoming data
                            m++;
                        }
                    }
                    // Once we have filled one array of 4 readings, increment the row counter
                    j++;
                }

                // Create array of data point lists
                for (int i = 0; i < numberInterleaved; i++)
                {
                    this.constructDataPoints(i);
                }

            }   // End of if statement checking that repeats & numberInterleaved are valid numbers



        }


        // Constructor given a file (pass by reference!)
        public fileHandler(ref System.IO.StreamReader myFile, string myFileName)
        {
            //*************************************//
            // Metadata format
            // ---------------
            //
            // "Spectroscopy data file"
            // date
            // "Trap frequency:"
            // trapFrequency
            // "Trap voltage:"
            // trapVoltage
            // "AOM Start frequency:"
            // startFrequency
            // "Step size:"
            // stepSize
            // "Number of repeats per frequency:"
            // repeats
            // "File contains interleaved spectra:"
            // numberInterleaved
            // "Spectrum i name":
            // spectrumName[i]
            // "Notes:"
            // Notes section - all lines should start with a #
            // "Data:"


            // Two "name" labels - one in file, one for displaying on graph
            // Name spectra on creation rather than when loading file?
            // Include notes section - parse & display in a window

            //*************************************//

            // String to temporarily store data from the file
            string myString = myFile.ReadLine();              // Read first line of file

            // Make sure it is a valid data file - check for metadata
            if (myString == "Spectroscopy data file")
            {
                //******************************//
                // Processing metadata
                date = myFile.ReadLine();                   // Next line is the date

                myString = myFile.ReadLine();               // Next line is a title (throw away)
                myString = myFile.ReadLine();               // Next line is trap frequency
                Console.WriteLine("Trap freq {0}", myString);
                if (myString != "N/A") trapFrequency = float.Parse(myString);      // Convert to float and save

                myString = myFile.ReadLine();               // Next line is a title (throw away)
                myString = myFile.ReadLine();               // Next line is trap voltage
                Console.WriteLine("Trap voltage {0}", myString);
                if (myString != "N/A") trapVoltage = float.Parse(myString);        // Convert to float and save

                myString = myFile.ReadLine();               // Next line is a title (throw away)
                myString = myFile.ReadLine();               // Next line is AOM start frequency
                Console.WriteLine("Start freq {0}", myString);
                if (myString != "N/A") startFrequency = int.Parse(myString);       // Convert to int and save

                myString = myFile.ReadLine();               // Next line is a title (throw away)
                myString = myFile.ReadLine();               // Next line is step size
                Console.WriteLine("Step size {0}", myString);
                if (myString != "N/A") stepSize = int.Parse(myString);              // Convert to int and save

                myString = myFile.ReadLine();               // Next line is a title (throw away)
                myString = myFile.ReadLine();               // Next line is number of repeats
                Console.WriteLine("Repeats {0}", myString);
                if (myString != "N/A") repeats = int.Parse(myString);              // Convert to int and save

                myString = myFile.ReadLine();               // Next line is a title (throw away)
                myString = myFile.ReadLine();               // Next line is number of interleaved spectra
                Console.WriteLine("N interleaved {0}", myString);
                if (myString != "N/A") numberInterleaved = int.Parse(myString);    // Convert to int and save

                spectrumNames = new string[numberInterleaved];

                Console.WriteLine("Found {0} interleaved spectra", numberInterleaved);

                // Next we have a pair of lines for each interleaved spectrum, giving the spectrum name
                for (int i = 0; i < numberInterleaved; i++)
                {
                    myString = myFile.ReadLine();               // Next line is a title (throw away)
                    Console.WriteLine(myString);
                    spectrumNames[i] = myFile.ReadLine();        // Next line is the spectrum name
                    Console.WriteLine("Spectrum name: {0}", spectrumNames[i]);
                }

                myString = myFile.ReadLine();               // Next line is a title (throw away)

                myString = myFile.ReadLine();               // Read first line of notes section
                // Keep reading lines 
                while (myString[0] == '#')
                {
                    notes += myString.Substring(1);
                    notes += System.Environment.NewLine;
                    myString = myFile.ReadLine(); 
                }

                // NB this will read one line PAST the end of the notes section. This is ok since
                // the line after is a title to be thrown away
                
                //******************************//

                this.processData(ref myFile);

            }   // If there is no metadata
            else if (myString == "Spectroscopy data file (no metadata)")
            {
                // Open a form requesting metadata (start freq, repeats, step size, number of spectra)
                // & wait for it to be closed before continuing
                requestMetadata myRequestMetadata = new requestMetadata(ref myFileName);
                myRequestMetadata.ShowDialog();

                // Check that user has pressed ok
                if (myRequestMetadata.DialogResult == DialogResult.OK)
                {
                    // Set metadata from user input on form
                    startFrequency = myRequestMetadata.startFreq;
                    stepSize = myRequestMetadata.stepSize;
                    repeats = myRequestMetadata.repeats;
                    numberInterleaved = myRequestMetadata.numberInterleaved;

                    // Need to initialise this array
                    spectrumNames = new string[numberInterleaved];
                    for (int i = 0; i < numberInterleaved; i++)
                    {
                        spectrumNames[i] = "Default";
                    }

                    // Just process the raw data
                    this.processData(ref myFile);
                }

            }
            else System.Windows.Forms.MessageBox.Show("File not recognised");
        }


        // Method to deal with data (not metadata)
        private void processData(ref System.IO.StreamReader myFile)
        {
            // Initialise arrays for storing Lists of raw data & dataPoints
            fullData = new List<int[]>[numberInterleaved];
            dataPoints = new List<dataPoint>[numberInterleaved];

            // Have to initialise the array and then each List in the array individually... tedious!!
            for (int i = 0; i < numberInterleaved; i++)
            {
                fullData[i] = new List<int[]>();
                dataPoints[i] = new List<dataPoint>();
            }


            string myString = myFile.ReadLine();                       // Read first line of data
            int j = 0;                                          // Counter for data points
            while (myString != null)                            // Only read further lines until end is reached
            {
                for (int k = 0; k < numberInterleaved; k++)
                {
                    // This MUST be a new int, cannot add any other array!!!!
                    fullData[k].Add(new int[4]);                        // Add new reading to the list, reading will contain 4 ints

                    // Extract blocks of 4 data points (each reading)
                    for (int i = 0; i < 4; i++)
                    {
                        fullData[k][j][i] = int.Parse(myString);        // Convert string to int, put into array
                        myString = myFile.ReadLine();                 // Read next line
                    }
                }
                j++;
            }


            // Create array of data point lists
            for (int i = 0; i < numberInterleaved; i++)
            {
                this.constructDataPoints(i);
            }

        }


        // Method to populate list of dataPoint objects (dataPoints), including metadata
        // Integer x tells which number spectrum (e.g. 0(first), 1(second)) in file to use
        private void constructDataPoints(int x)
        {
            dataPoint dataPointTemp;        // dataPoint object used in loop
            int frequency = startFrequency;

            // Loop through list of data elements, but only create a new dataPoint object for each frequency
            // 
            for (int i = x; i < fullData[x].Count; i += numberInterleaved*repeats)
            {
                // Create new instance of dataPoint
                dataPointTemp = new dataPoint(ref fullData[x], i, repeats);
                
                // Set metadata (nb. repeats already set in constructor)
                dataPointTemp.setFreq(frequency);
               
                // Add to the list
                dataPoints[x].Add(dataPointTemp);
                frequency += stepSize;
            }

        } 

        // Method to return number of interleaved spectra in the file
        public int getNumberInterleaved()
        {
            return numberInterleaved;
        }


        // Method to return list of dataPoint objects (dataPoints)
        // NB List<> is a reference type so it behaves like a pointer
        public List<dataPoint> getDataPoints(int x)
        {
            return dataPoints[x];
        }

        // Method to return array of spectrum names from file
        public string[] getSpectrumNames()
        {
            return spectrumNames;
        }

        // Method to return the string containing the 'Notes' section from file
        public string getNotes()
        {
            return notes;
        }

    }
}
