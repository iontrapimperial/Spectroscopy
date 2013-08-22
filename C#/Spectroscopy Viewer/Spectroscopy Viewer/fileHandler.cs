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

        // Array to store metadata
        public string[] metadata = new string[23];

        // Metadata read from file
        private int startFrequency;         // Starting frequency of the file (of current sideband if windowed)
        private int repeats;                // Number of repeats
        private int stepSize;               // Step size in frequency
        private int numberInterleaved;      // How many spectra are interleaved in this file
        private int currentWindowStep;      // Current window step (within current sideband if windowed)
        private int startLength;            // Starting pulse length (fixed spectra only)
        
        private string[] spectrumNames;     // Names of spectra stored in file
        private string notes = "";

        // Default constructor
        public fileHandler()
        {
            // Cannot handle data if a file is not chosen!
            System.Windows.Forms.MessageBox.Show("No file selected");
        }

        //***********//
        // Need start frequency as well!!! (nb: Think I've done this - Joe)
        //***********//

        // Constructor given an array of data and some bits of metadata
        public fileHandler(ref int[] IncomingData, int repeatsPassed, int stepSizePassed, int numberInterleavedPassed,
                            int startFreqPassed, int currentWindowStepPassed, int startLengthPassed)
        {
            // Need to convert the array of incoming data into a List<int[]>[]
            // Each list is for a separate spectrum
            // Each int[] is an array of 4 ints (one reading, inc. cooling, counts & error flags)

            // Store crucial numbers
            repeats = repeatsPassed;
            stepSize = stepSizePassed;
            numberInterleaved = numberInterleavedPassed;
            startFrequency = startFreqPassed;
            currentWindowStep = currentWindowStepPassed;
            startLength = startLengthPassed;

            // Check that the important numbers are not zero (otherwise data will not process correctly)
            if( stepSize != 0 && repeats != 0 && numberInterleaved != 0)
            {
                // Initialise arrays for storing Lists of raw data & dataPoints
                fullData = new List<int[]>[numberInterleaved];
                dataPoints = new List<dataPoint>[numberInterleaved];

                // Have to initialise the array and then each List in the array individually
                for (int i = 0; i < numberInterleaved; i++)
                {
                    fullData[i] = new List<int[]>();
                    dataPoints[i] = new List<dataPoint>();
                }

                // row counter to keep track of which array of 4 readings within the list we are filling
                int j = 0;

                // Loop through incoming data array
                int m = 0;
                while (m < IncomingData.Length)                
                {
                    // Fill a separate list for each interleaved spectrum
                    for (int k = 0; k < numberInterleaved; k++)
                    {
                        // This MUST be a new int, cannot add any other array!!!!
                        fullData[k].Add(new int[4]);                        // Add new reading to the list, reading will contain 4 ints

                        // Loop through the 4 readings
                        for (int i = 0; i < 4; i++)
                        {
                            fullData[k][j][i] = IncomingData[m];
                            // Move to the next element in the array of incoming data
                            m++;
                        }
                    }
                    // Once we have filled one array of 4 readings for each interleaved spectrum, increment the row counter
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
            // "This is sideband:"
            // sidebandNumber
            // "Starting pulse length (fixed):"
            // startLength
            // "Number of steps (fixed):"
            // numberOfSteps (fixed)
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
                // Just dump it into an array of strings

                metadata = new string[25];

                // Next 36 lines are misc metadata with titles
                for (int i = 0; i < 18; i++)
                {
                    metadata[i] = myFile.ReadLine();               // First line is actual metadata
                    myString = myFile.ReadLine();                  // Alternating lines are just a title (throw away)

                }
                
                float stepSizekHz, startFrequencyMHz;

                // Store crucial metadata - no. of repeats, no. interleaved, step size, start freq
                // int.TryParse(myString, out myInt) converts myString to an int and stores it in myInt
                // then returns true if it was successful, false otherwise

                if (int.TryParse(metadata[13], out repeats) && int.TryParse(metadata[14], out numberInterleaved)
                    && float.TryParse(metadata[9], out stepSizekHz) && float.TryParse(metadata[7], out startFrequencyMHz))
                {
                    if (metadata[1] == "Fixed")
                    {
                        // Make sure starting pulse length is an int
                        if (int.TryParse(metadata[16], out startLength) )
                        {
                            // Don't convert - this is a number of ticks
                            stepSize = (int)stepSizekHz;
                        }
                        else MessageBox.Show("Error reading metadata (pulse length not an int)");
                    }
                    else
                    {
                        // These need converting to Hz and storing as ints
                        stepSize = (int)(stepSizekHz * 1000);
                        
                    }
                    // Always convert start freq to int
                    startFrequency = (int)(startFrequencyMHz * 1000000);
                }
                else
                {
                    MessageBox.Show("Error reading metadata");
                }

                spectrumNames = new string[numberInterleaved];

                // Depending on number of interleaved spectra, store the names in the array
                for (int i = 0; i < numberInterleaved; i++)
                {
                    if (i < 5) // Make sure we don't take more than 5 spectra from file
                    {
                        // Put spectrum name into arrays for both metadata and spectrumNames
                        // ( Need spectrumNames for spectrumSelect dialog)
                        // Bit messy but it's easiest to code this way for now, maybe tidy later
                        // using substrings
                        spectrumNames[i] = myFile.ReadLine();
                        metadata[i + 18] = spectrumNames[i];
                        myString = myFile.ReadLine();
                    }
                }



                myString = myFile.ReadLine();               // Read first line of notes section
                // Keep reading lines while each line begins with a #
                while (myString[0] == '#')
                {
                    notes += myString.Substring(1);
                    notes += System.Environment.NewLine;
                    myString = myFile.ReadLine();
                }


                // NB this will read one line PAST the end of the notes section. This should be the line that says "Data:"
                // Check this - if not then there will be errors reading the data
                if (myString != "Data:")
                {
                    MessageBox.Show("Error: File corrupted (wrong metadata format?)");
                    return;
                }

                // Store in array of metadata
                if (18 + numberInterleaved < 25 && numberInterleaved != 0) metadata[18 + numberInterleaved] = notes;
                else Console.WriteLine("Too many interleaved spectra - gone beyond the bounds of metadata array (line 184 fileHandler.cs)");

                // Process the actual numerical data
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

                        // Make sure we are not outside the bounds of the array
                        if (i + 18 < 24)
                        {
                            // Store default name in metadata
                            metadata[i + 18] = spectrumNames[i];
                        }
                    }

                    
                    // Just process the raw data
                    this.processData(ref myFile);

                    // Store what we have in the metadata array
                    metadata[8] = stepSize.ToString();
                    metadata[9] = stepSize.ToString();
                    metadata[13] = repeats.ToString();
                    metadata[14] = numberInterleaved.ToString();         

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


            string myString = myFile.ReadLine();                // Read first line of data
            int j = 0;                                          // Counter for data points
            while (myString != null)                            // Only read further lines until end is reached
            {
                for (int k = 0; k < numberInterleaved; k++)
                {
                    // This MUST be a new int, cannot add an existing array!!!!
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
            int frequency = new int();
            if (startLength != 0)
            {
                Console.WriteLine("Pulse length: {0}", startLength);
                frequency = startLength;
            }
            else frequency = startFrequency + currentWindowStep * stepSize;

            // Loop through list of data elements, but only create a new dataPoint object for each frequency
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
