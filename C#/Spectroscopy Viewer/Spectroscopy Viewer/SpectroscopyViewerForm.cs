// Main form for Spectroscopy Viewer


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;           // For debugging
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;    
using ZedGraph;     // Includes ZedGraph for plotting graphs


namespace Spectroscopy_Viewer
{
    public partial class SpectroscopyViewerForm : Form
    {
        // A list of spectrum objects. List is basically just a dynamic array so we can add more objects as necessary
        public List<spectrum> mySpectrum = new List<spectrum>();
        // List to store data for plotting spectrum graph. PointPairList is the object needed for plotting with zedGraph 
        private List<PointPairList> dataPlot = new List<PointPairList>();
        // Lists to store data for plotting bad counts
        // Due to error flags (laser error), threshold error or all combined
        private List<PointPairList> badCountsPlotAll = new List<PointPairList>();
        private List<PointPairList> badCountsPlotLaser = new List<PointPairList>();
        private List<PointPairList> badCountsPlotThreshold = new List<PointPairList>();

        // Arrays of data for histograms - separate lists for cooling period, count period & all combined
        // Plus an integer to keep track of how large the arrays are
        private int[] histogramCool;
        private int[] histogramCount;
        private int[] histogramAll;
        private int histogramSize;

        // Number of spectra loaded to graph
        private int numberOfSpectra = new int();

        // List of colours to show on graph
        private List<Color> myColoursData = new List<Color>();
        private List<Color> myColoursBadCounts = new List<Color>();


        // Graph controls
        private static int maxGraphControl = 5;
        private GroupBox[] graphControlGroup = new GroupBox[maxGraphControl];
        private System.Windows.Forms.Label[] graphControlLabel = new System.Windows.Forms.Label[maxGraphControl];
        private CheckBox[] graphControlCheckBox = new CheckBox[maxGraphControl];
        private RadioButton[] graphControlBadCountsNone = new RadioButton[maxGraphControl];
        private RadioButton[] graphControlBadCountsAll = new RadioButton[maxGraphControl];
        private RadioButton[] graphControlBadCountsLaser = new RadioButton[maxGraphControl];
        private RadioButton[] graphControlBadCountsThreshold = new RadioButton[maxGraphControl];

        public SpectroscopyViewerForm()
        {
            InitializeComponent();

            initialiseColours();


        }




        // Method to build a list of colours for the graph
        private void initialiseColours()
        {
            // 10 different colours
            myColoursData.Add(Color.Crimson);
            myColoursBadCounts.Add(Color.OrangeRed);

            myColoursData.Add(Color.Blue);
            myColoursBadCounts.Add(Color.LightBlue);

            myColoursData.Add(Color.Green);
            myColoursBadCounts.Add(Color.PaleGreen);

            myColoursData.Add(Color.Magenta);
            myColoursBadCounts.Add(Color.Pink);

            myColoursData.Add(Color.YellowGreen);
            myColoursBadCounts.Add(Color.Yellow);

        }

        // Respond to form 'Load' event
        private void SpectroscopyViewerForm_Load(object sender, EventArgs e)
        {

            // Setup the graph
            createGraph(zedGraphSpectra);
            // Size the control to fill the form with a margin
            SetSize();

            // Disable radio buttons to select histogram display
            // If these are used before the histogram is created, program will crash
            this.histogramDisplayAll.Enabled = false;
            this.histogramDisplayCool.Enabled = false;
            this.histogramDisplayCount.Enabled = false;

            // Disable manual max bin select
            this.histogramMaxBinSelect.Enabled = false;


        }

        // Respond to the form 'Resize' event
        private void SpectroscopyViewerForm_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        // Method to set size of graphs depending on overall form size
        private void SetSize()
        {
            tabControl1.Location = new Point(10, 10);
            tabControl1.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 20);

            zedGraphSpectra.Location = new Point(10, 60);
            // Leave a small margin around the outside of the control
            zedGraphSpectra.Size = new Size(ClientRectangle.Width - 230,
                                    ClientRectangle.Height - 180);
        }



        // Build the Chart - before any data has been added
        private void createGraph(ZedGraphControl zgcSpectrum)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgcSpectrum.GraphPane;

            // Clear the Titles
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "";
        }



        private void createGraphControls()
        {

            // Create a set of controls for each spectrum displayed on the graph
            for (int i = 0; i < numberOfSpectra; i++)
            {
                // Can only fit in controls for up to 5 graphs
                if (i < 5)
                {
                    // Remove the existing controls
                    this.removeGraphControls(i);
                    // Create new controls
                    this.graphControlBadCountsAll[i] = new RadioButton();
                    this.graphControlBadCountsLaser[i] = new RadioButton();
                    this.graphControlBadCountsNone[i] = new RadioButton();
                    this.graphControlBadCountsThreshold[i] = new RadioButton();
                    this.graphControlCheckBox[i] = new CheckBox();
                    this.graphControlGroup[i] = new GroupBox();
                    this.graphControlLabel[i] = new System.Windows.Forms.Label();
                    //
                    // Add group box to the spectrum tab page
                    this.tabPageSpectra.Controls.Add(graphControlGroup[i]);
                    // Add controls to the groupbox - checkBox, label and radio buttons
                    this.graphControlGroup[i].Controls.Add(graphControlBadCountsAll[i]);
                    this.graphControlGroup[i].Controls.Add(graphControlBadCountsLaser[i]);
                    this.graphControlGroup[i].Controls.Add(graphControlBadCountsNone[i]);
                    this.graphControlGroup[i].Controls.Add(graphControlBadCountsThreshold[i]);
                    this.graphControlGroup[i].Controls.Add(graphControlCheckBox[i]);
                    this.graphControlGroup[i].Controls.Add(graphControlLabel[i]);
                    //
                    // Configure group box
                    this.graphControlGroup[i].Location = new System.Drawing.Point(790, (6 + 115 * i));
                    this.graphControlGroup[i].Size = new System.Drawing.Size(176, 109);
                    this.graphControlGroup[i].TabIndex = 10 + i;
                    this.graphControlGroup[i].TabStop = false;
                    this.graphControlGroup[i].Text = "Spectrum" + (i + 1);
                    //
                    // Configure check box
                    this.graphControlCheckBox[i].AutoSize = false;
                    this.graphControlCheckBox[i].Checked = true;
                    this.graphControlCheckBox[i].Location = new System.Drawing.Point(6, 14);
                    this.graphControlCheckBox[i].Size = new System.Drawing.Size(150, 30);
                    this.graphControlCheckBox[i].TabIndex = 0;
                    this.graphControlCheckBox[i].Text = "Show spectrum" + System.Environment.NewLine
                        + @" """ + mySpectrum[i].getName() + @""" ";
                    //
                    // Configure label to display text "Show bad counts:"
                    this.graphControlLabel[i].AutoSize = true;
                    this.graphControlLabel[i].Location = new System.Drawing.Point(6, 45);
                    this.graphControlLabel[i].Size = new System.Drawing.Size(61, 13);
                    this.graphControlLabel[i].TabIndex = 1;
                    this.graphControlLabel[i].Text = "Show bad counts:";
                    //
                    // Configure radio button to display no bad counts
                    this.graphControlBadCountsNone[i].AutoSize = true;
                    this.graphControlBadCountsNone[i].Checked = true;
                    this.graphControlBadCountsNone[i].Location = new System.Drawing.Point(6, 62);
                    this.graphControlBadCountsNone[i].Size = new System.Drawing.Size(85, 17);
                    this.graphControlBadCountsNone[i].TabIndex = 2;
                    this.graphControlBadCountsNone[i].Text = "None";
                    this.graphControlBadCountsNone[i].UseVisualStyleBackColor = true;
                    this.graphControlBadCountsNone[i].CheckedChanged +=
                        new System.EventHandler(this.graphControlRadioButton_CheckedChanged);
                    //
                    // Configure radio button to display all bad counts
                    this.graphControlBadCountsAll[i].AutoSize = true;
                    this.graphControlBadCountsAll[i].Location = new System.Drawing.Point(6, 85);
                    this.graphControlBadCountsAll[i].Size = new System.Drawing.Size(85, 17);
                    this.graphControlBadCountsAll[i].TabIndex = 3;
                    this.graphControlBadCountsAll[i].Text = "All";
                    this.graphControlBadCountsAll[i].UseVisualStyleBackColor = true;
                    this.graphControlBadCountsAll[i].CheckedChanged +=
                        new System.EventHandler(this.graphControlRadioButton_CheckedChanged);
                    //
                    // Configure radio button to display bad counts due to error flags only
                    this.graphControlBadCountsLaser[i].AutoSize = true;
                    this.graphControlBadCountsLaser[i].Location = new System.Drawing.Point(76, 62);
                    this.graphControlBadCountsLaser[i].Size = new System.Drawing.Size(85, 17);
                    this.graphControlBadCountsLaser[i].TabIndex = 4;
                    this.graphControlBadCountsLaser[i].Text = "Laser error";
                    this.graphControlBadCountsLaser[i].UseVisualStyleBackColor = true;
                    this.graphControlBadCountsLaser[i].CheckedChanged +=
                        new System.EventHandler(this.graphControlRadioButton_CheckedChanged);
                    //
                    // Configure radio button to display bad counts due to threshold only
                    this.graphControlBadCountsThreshold[i].AutoSize = true;
                    this.graphControlBadCountsThreshold[i].Location = new System.Drawing.Point(76, 85);
                    this.graphControlBadCountsThreshold[i].Size = new System.Drawing.Size(85, 17);
                    this.graphControlBadCountsThreshold[i].TabIndex = 5;
                    this.graphControlBadCountsThreshold[i].Text = "Threshold error";
                    this.graphControlBadCountsThreshold[i].UseVisualStyleBackColor = true;
                    this.graphControlBadCountsThreshold[i].CheckedChanged +=
                        new System.EventHandler(this.graphControlRadioButton_CheckedChanged);

                }


            }

        }

        // Method to remove graph controls from the form
        // Required so that we don't get an error when recreating controls
        private void removeGraphControls(int i)
        {
            if( this.tabPageSpectra.Controls.Contains(graphControlGroup[i]) )
            {
                // Remove objects from list of controls
                graphControlGroup[i].Controls.Clear();
                tabPageSpectra.Controls.Remove(graphControlGroup[i]);
                // Dispose of objects
                graphControlLabel[i].Dispose();
                graphControlCheckBox[i].Dispose();
                graphControlBadCountsAll[i].Dispose();
                graphControlBadCountsNone[i].Dispose();
                graphControlBadCountsLaser[i].Dispose();
                graphControlBadCountsThreshold[i].Dispose();
                graphControlGroup[i].Dispose();
            }
        }

        // Method to respond to user changing radio buttons in graph controls
        private void graphControlRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // get a reference to the GraphPane
            GraphPane myPane = this.zedGraphSpectra.GraphPane;
            // Clear data
            zedGraphSpectra.GraphPane.CurveList.Clear();
            LineItem myCurve;

            for (int i = 0; i < numberOfSpectra; i++)
            {
                // If the "show spectrum" checkBox is checked
                if (graphControlCheckBox[i].Checked)
                {

                    myCurve = myPane.AddCurve(mySpectrum[i].getName(),
                        dataPlot[i], myColoursData[i % 5], SymbolType.Diamond);
                }
                // NB if it is not checked, do nothing

                if (graphControlBadCountsAll[i].Checked)
                {
                    myCurve = myPane.AddCurve(mySpectrum[i].getName() + " bad counts",
                        mySpectrum[i].getBadCountsAll(), myColoursBadCounts[i % 5], SymbolType.Circle);
                    myCurve.IsY2Axis = true;
                }
                //
                else if (graphControlBadCountsLaser[i].Checked)
                {
                    myCurve = myPane.AddCurve(mySpectrum[i].getName() + " bad counts",
                        mySpectrum[i].getBadCountsErrors(), myColoursBadCounts[i % 5], SymbolType.Circle);
                    myCurve.IsY2Axis = true;
                }
                //
                else if (graphControlBadCountsThreshold[i].Checked)
                {
                    myCurve = myPane.AddCurve(mySpectrum[i].getName() + " bad counts",
                        mySpectrum[i].getBadCountsThreshold(), myColoursBadCounts[i % 5], SymbolType.Circle);
                    myCurve.IsY2Axis = true;
                }

            }

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zedGraphSpectra.AxisChange();
            zedGraphSpectra.Invalidate();
            // Force redraw of control

        }


        // Update the chart when data has been added/updated
        private void updateGraph()
        {
            // get a reference to the GraphPane
            GraphPane myPane = zedGraphSpectra.GraphPane;

            // Clear data
            zedGraphSpectra.GraphPane.CurveList.Clear();

            for (int i = 0; i < mySpectrum.Count; i++)
            {
                // Generate a curve from the dataPlot[i] list of data, with colour
                // determined by internal array of colours
                LineItem myCurve = myPane.AddCurve(mySpectrum[i].getName(),
                      dataPlot[i], myColoursData[i % 10], SymbolType.Diamond);

                // Tell ZedGraph to refigure the
                // axes since the data have changed
                zedGraphSpectra.AxisChange();
                zedGraphSpectra.Invalidate();
                // Force redraw of control
            }

            // Create the controls for the graph
            this.createGraphControls();
        }




        // Respond to 'Load data' button press
        private void loadDataButton_Click(object sender, EventArgs e)
        {
            // Configuring dialog to open a new data file
            openDataFile.InitialDirectory = "Z:/Data";      // Initialise to share drive
            openDataFile.RestoreDirectory = true;           // Open to last viewed directory
            openDataFile.FileName = "";                     // Set default filename to blank
            openDataFile.Multiselect = true;                // Allow selection of multiple files

            // Show dialog to open new data file
            // Do not attempt to open file if user has pressed cancel
            if (openDataFile.ShowDialog() != DialogResult.Cancel)
            {
                // Want to only open files if they have the same number of interleaved spectra
                // So keep a 'master' record of how many there are interleaved in the first file
                int numberInterleavedMaster = new int();
                bool selectionMade = false;     // Flag whether user made the selection successfully

                // These are variables which get initialised in the first loop (when i == 0)
                // Need to declare them here (not in if statement) to avoid compiler errors
                // Array to store user selection of where to assign spectra
                int[] selectedSpectrum = new int[1];        // Have to initialise this here
                spectrumSelect mySpectrumSelectBox = new spectrumSelect();

                // Store number of files being opened
                int numberOfFiles = openDataFile.FileNames.Length;

                // Loop through each file
                for (int i = 0; i < numberOfFiles; i++)
                {
                    // Get and store just the name of the file (without full path)
                    string myFileName = Path.GetFileName(openDataFile.FileNames[i]);

                    // Create new StreamReader instance to open file
                    System.IO.StreamReader myFile = new System.IO.StreamReader(openDataFile.FileNames[i]);
                    // Create new instance of fileHandler to open & process file (pass by reference!)
                    fileHandler myFilehandler = new fileHandler(ref myFile, myFileName);
                    // Clean up StreamReader instance after fileHandler has finished with it
                    myFile.Close();           // Close object & release resources


                    // Check how many interleaved spectra there are
                    int numberInterleaved = myFilehandler.getNumberInterleaved();


                    if (i == 0)
                    {
                        // Set number interleaved to compare other files to
                        numberInterleavedMaster = numberInterleaved;

                        //*************************************************************//
                        // Pop up dialog box to select which spectrum to add data to, and save selections

                        // Create spectrumSelect form, give it list of existing spectra, number of spectra in first file
                        // file name of first file, and number of files opened
                        string[] spectrumNamesFromFile = myFilehandler.getSpectrumNames();
                        mySpectrumSelectBox = new spectrumSelect(mySpectrum, ref spectrumNamesFromFile, numberInterleaved,
                                                                ref myFileName, numberOfFiles);
                        mySpectrumSelectBox.ShowDialog();         // Display form & wait until it is closed to continue

                        // Make sure the user didn't press cancel or close the dialog box
                        if (mySpectrumSelectBox.DialogResult == DialogResult.OK)
                        {
                            // Get array of information about which data to add to which spectrum
                            selectedSpectrum = new int[numberInterleaved];
                            selectedSpectrum = mySpectrumSelectBox.selectedSpectrum.ToArray();
                            selectionMade = true;
                        }   

                    } // End of if statement which checks if i == 0


                    // Check that number interleaved is correct
                    if (numberInterleaved == numberInterleavedMaster)
                    {
                        // Check that user has selected destinations for all spectra
                        if (selectionMade)
                        {
                            // For each interleaved spectrum, check where it is being assigned to
                            // 
                            for (int j = 0; j < numberInterleaved; j++)
                            {
                                // If the index >= number of existing spectra, new ones must have been added
                                // (since for a list of N items, index runs from 0 to N-1)
                                if (selectedSpectrum[j] >= numberOfSpectra)
                                {
                                    // Get the list filled with data points, add to list of spectra
                                    mySpectrum.Add(new spectrum(myFilehandler.getDataPoints(j),     // Data points for spectrum       
                                                    selectedSpectrum[j],         // Spectrum number
                                                    mySpectrumSelectBox.spectrumNamesForGraph[selectedSpectrum[j]]));  // Spectrum name

                                    // Add blank PointPairList for storing plot data
                                    dataPlot.Add(new PointPairList());
                                }
                                else
                                {
                                    // Add list of data points from file handler into existing spectrum
                                    mySpectrum[selectedSpectrum[j]].addToSpectrum(myFilehandler.getDataPoints(j));
                                }
                            }
                            // Update number of spectra
                            numberOfSpectra = mySpectrum.Count();
                            Console.WriteLine("{0} spectra", numberOfSpectra);
                        }
                        else
                        {
                            MessageBox.Show("Spectra destinations not assigned. Data not loaded.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Number of spectra interleaved in file " + myFileName +
                            " (" + numberInterleaved + " spectra) does not match previous files. File skipped.");
                    }

                    // Print out information to the user in the userDisplayText box
                    userDisplayText.Text += @"File """ + myFileName.Replace(".txt", "") +@""" loaded" + System.Environment.NewLine;
                    userDisplayText.Text += "Notes: " + myFilehandler.getNotes();
                    userDisplayText.SelectionStart = userDisplayText.Text.Length;
                    userDisplayText.ScrollToCaret();

                } // End of for loop which goes through each file
            }
        }
        


        // Method to respond to 'Plot data' button press
        private void plotDataButton_Click(object sender, EventArgs e)
        {
            // Do not attempt to do anything if no spectra have been created
            if (mySpectrum.Count == 0) MessageBox.Show("No data loaded");
            else
            {
                // Analyse each spectrum and get the data
                // NB if no spectra have been loaded, mySpectrum.Count will be 0 and this loop will not run
                for (int i = 0; i < mySpectrum.Count; i++)
                {
                    mySpectrum[i].analyse((int)coolingThresholdSelect.Value, (int)countThresholdSelect.Value);
                    dataPlot[i] = mySpectrum[i].getDataPlot();
                }

                // Setup the graph
                updateGraph();
                // Size the control to fill the form with a margin
                SetSize();
            }
        }


        // Function to output contents of spectra to file. For testing.
        private void writeToFile_test()
        {
            TextWriter[] testFile = new StreamWriter[mySpectrum.Count];


            // Write a separate file for each spectrum
            for (int i = 0; i < numberOfSpectra; i++)
            {
                testFile[i] = new StreamWriter("C:/Users/localadmin/Documents/testFile_Spectrum" + i + ".txt");
                testFile[i].WriteLine("Frequency\tDark ion prob");

                // For each point pair in the list
                for (int j = 0; j < dataPlot[i].Count; j++)
                {
                    testFile[i].WriteLine(dataPlot[i][j].X + "\t" + dataPlot[i][j].Y + "\n");
                }
                testFile[i].Flush();
                testFile[i].Close();
             }
        }


        // Method to respond to user clicking "Update histogram" button
        // Creates separate histogram for each spectrum, combines the data and plots it
        // NB histogram is recreated with every button click, since it is a fairly quick process and doesn't happen often
        private void updateHistogramButton_Click(object sender, EventArgs e)
        {
            // Do not attempt to do anything if no spectra have been created
            if (mySpectrum.Count == 0) MessageBox.Show("No data loaded");
            else
            {
                // Calculating data for histogram
                //********************************//

                // Initialise variables every time we re-create the histogram
                histogramSize = new int();

                // Local variables used within this method
                int[] tempHistogramCool;
                int[] tempHistogramCount;
                int tempHistogramSize = new int();


                // For each spectrum
                for (int i = 0; i < numberOfSpectra; i++)
                {
                    // Temporarily store histograms for this spectrum
                    tempHistogramCool = mySpectrum[i].getHistogramCool();
                    tempHistogramCount = mySpectrum[i].getHistogramCount();

                    // Find size of histograms for this spectrum
                    tempHistogramSize = tempHistogramCool.Length;

                    // For the first spectrum only
                    if (i == 0)
                    {
                        // Store size of lists
                        histogramSize = tempHistogramSize;

                        // Create arrays of the right size
                        histogramCool = new int[histogramSize];
                        histogramCount = new int[histogramSize];
                        histogramAll = new int[histogramSize];


                        // Loop through each histogram bin and populate arrays
                        for (int j = 0; j < histogramSize; j++)
                        {
                            // Populate arrays from temp histograms
                            // NB cannot just use e.g. histogramCool = tempHistogram, this will cause errors
                            // since arrays are a reference type. Need to manipulate each element individually
                            histogramCool[j] = tempHistogramCool[j];
                            histogramCount[j] = tempHistogramCount[j];

                            // Calculate total data and store in another array (cool + count)
                            histogramAll[j] = histogramCool[j] + histogramCount[j];
                        }

                    }
                    else
                    {   // For subsequent spectra, go through and add the data to existing lists
                        for (int j = 0; j < histogramSize; j++)
                        {
                            // Sum the data from each spectrum into the full list
                            histogramCool[j] += tempHistogramCool[j];
                            histogramCount[j] += tempHistogramCount[j];

                            histogramAll[j] = histogramCool[j] + histogramCount[j];

                        }

                        // If the histogram for the current spectrum is larger than the existing histogram
                        if (tempHistogramSize > histogramSize)
                        {
                            Array.Resize(ref histogramCool, tempHistogramSize);
                            Array.Resize(ref histogramCount, tempHistogramSize);
                            Array.Resize(ref histogramAll, tempHistogramSize);

                            // Fill in the data into the new bins
                            for (int j = histogramSize; j < tempHistogramSize; j++)
                            {
                                histogramCool[j] = tempHistogramCool[j];
                                histogramCount[j] = tempHistogramCount[j];
                                histogramAll[j] = histogramCool[j] + histogramCount[j];
                            }

                            // Update size of list (could use tempHistogramSize, but recalculate just in case)
                            histogramSize = histogramCool.Count();
                        }
                    }

                }       // End of loop which goes through spectra and creates histogram

                //********************************//


                // Store the data in a table for plotting to graph
                // Try to create a data table with the lists as columns
                DataSet histogramDataSet = new DataSet();
                DataTable histogramTable = new DataTable();

                histogramDataSet.Tables.Add(histogramTable);

                // Create columns
                histogramTable.Columns.Add(new DataColumn("Bin", typeof(int)));
                histogramTable.Columns.Add(new DataColumn("Cool period", typeof(int)));
                histogramTable.Columns.Add(new DataColumn("Count period", typeof(int)));
                histogramTable.Columns.Add(new DataColumn("All", typeof(int)));

                for (int i = 0; i < histogramSize; i++)
                {
                    DataRow myRow = histogramTable.NewRow();
                    myRow["Bin"] = i;
                    myRow["Cool period"] = histogramCool[i];
                    myRow["Count period"] = histogramCount[i];
                    myRow["All"] = histogramAll[i];
                    histogramTable.Rows.Add(myRow);
                }

                //********************************//
                // Plotting histogram data on graph
                // Need to convert to an enumerable type to get it to dataBind properly
                // Clear the chart first so that when we re-create the histogram it doesn't cause an error
                this.histogramChart.DataBindings.Clear();
                this.histogramChart.Series.Clear();

                var enumerableTable = (histogramTable as System.ComponentModel.IListSource).GetList();
                this.histogramChart.DataBindTable(enumerableTable, "Bin");

                // This line throws an error when chart already exists & update button is pressed

                // Turn off ticks on x axis
                histogramChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

                // Enable radio buttons to select display
                histogramDisplayAll.Enabled = true;
                histogramDisplayCool.Enabled = true;
                histogramDisplayCount.Enabled = true;

                // Set interval to 1 so that the number will be displayed for each bin
                histogramChart.ChartAreas[0].AxisX.Interval = 1;

                // Check which radio button is checked & plot correct series
                this.radioButtonDisplay_CheckedChanged(sender, e);

            }   // End of if statement checking that data has been loaded
    
        }

        // Method to be called when a change is made to the radio buttons controlling the histogram display
        private void radioButtonDisplay_CheckedChanged(object sender, EventArgs e)
        {
            // For each radio button (All, Cool, Count)
            // If the button is checked, display the corresponding series
            // If the button is unchecked, hide the corresponding series

            // For "All" radio button
            if (histogramDisplayAll.Checked)
            {
                this.histogramChart.Series["All"].Enabled = true;   // Enable series
                this.histogramAutoScale(histogramAll);              // Auto scale graph
            }
            else this.histogramChart.Series["All"].Enabled = false; // Disable series


            // For "Cooling period only" radio button
            if (histogramDisplayCool.Checked)
            {
                this.histogramChart.Series["Cool period"].Enabled = true;   // Enable series
                this.histogramAutoScale(histogramCool);                     // Auto scale graph
            }
            else this.histogramChart.Series["Cool period"].Enabled = false; // Disable series


            // For "Count period only" radio button
            if (histogramDisplayCount.Checked)
            {
                this.histogramChart.Series["Count period"].Enabled = true;      // Enable series
                this.histogramAutoScale(histogramCount);                        // Auto scale graph
            }
            else this.histogramChart.Series["Count period"].Enabled = false;    // Disable series
        }

        // Method to scale the axes based on the data being plotted (All, Cool or Counts)
        private void histogramAutoScale(int[] data)
        {
            // Specify an interval to round to based on size of data
            int maxData = data.Max();
            int interval = new int();
            if (maxData <= 100)
            {
                interval = 20;
            }
            else if (maxData <= 250)
            {
                interval = 50;
            }
            else if (maxData <= 500)
            {
                interval = 100;
            }
            else
            {
                interval = 200;
            }
            
            // Find out how many intervals fit into the data range
            // (rounded down to an integer)
            int x = data.Max() / interval;

            // Set the max to one interval greater
            histogramChart.ChartAreas[0].AxisY.Maximum = interval * (x + 1);
        }

        // Method to respond to "Auto" checkbox (under Histogram tab, Maximum bin group) changing
        private void histogramCheckBoxAuto_CheckedChanged(object sender, EventArgs e)
        {
            // If selecting auto, then disable user maxBinSelect
            if (histogramCheckBoxAuto.Checked)
            {
                histogramMaxBinSelect.Enabled = false;
                this.histogramChart.ChartAreas[0].AxisX.Maximum = histogramSize;
            }
            else
                // If not on auto, scale according to user max bin select
            {
                // Enable user select for max bin
                histogramMaxBinSelect.Enabled = true;
                // NB no code in place to create a ">= N" bin, all this does is change the display
                this.histogramChart.ChartAreas[0].AxisX.Maximum = (double)histogramMaxBinSelect.Value;
            }

        }

        // Method to respond to user changing value in the histogram max bin select
        private void histogramMaxBinSelect_ValueChanged(object sender, EventArgs e)
        {
            // NB nothing clever, we don't change the data, just the display

            // Set maximum bin to user input
            this.histogramChart.ChartAreas[0].AxisX.Maximum = (double)histogramMaxBinSelect.Value;
        }

        // Method to respond to user clicking "Export histogram data..." button
        // Opens a dialogue to save histogram data independently for each displayed spectrum
        private void histogramExportData_Click(object sender, EventArgs e)
        {
            // Do not attempt to do anything if no spectra have been created
            if (mySpectrum.Count == 0) MessageBox.Show("No data loaded");
            else
            {
                // Configuring dialog to save file
                saveFileDialog.InitialDirectory = "Z:/Data";      // Initialise to share drive
                saveFileDialog.RestoreDirectory = true;           // Open to last viewed directory
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                // Show new dialogue for each spectrum
                for (int i = 0; i < numberOfSpectra; i++)
                {
                    saveFileDialog.Title = "Save histogram data for spectrum" + (i + 1);
                    saveFileDialog.FileName = mySpectrum[i].getName() + " histogram data.txt";

                    // Show dialog to save file
                    // Check that user has not pressed cancel before continuing to save file
                    if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        // Create streamwriter object to write to file
                        // With filename given from user input
                        TextWriter histogramFile = new StreamWriter(saveFileDialog.FileName);

                        // Call method in the spectrum class to write data to the file
                        mySpectrum[i].writeHistogramData(ref histogramFile);
                    }
                }
            }

        }


        // Method to respond to user clicking "Export spectrum data..." button
        // Opens a save file dialog for each spectrum, saves data in a text file (tab separated)
        // Might want to put some metadata into this file??
        private void spectrumExportData_Click(object sender, EventArgs e)
        {
            // Do not attempt to do anything if no spectra have been created
            if (mySpectrum.Count == 0) MessageBox.Show("No data loaded");
            else
            {
                // Configuring dialog to save file
                saveFileDialog.InitialDirectory = "Z:/Data";      // Initialise to share drive
                saveFileDialog.RestoreDirectory = true;           // Open to last viewed directory
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                // Show new dialogue for each spectrum
                for (int i = 0; i < numberOfSpectra; i++)
                {
                    saveFileDialog.Title = "Save data for spectrum" + (i + 1);
                    saveFileDialog.FileName = mySpectrum[i].getName() + "_data.txt";

                    // Show dialog to save file
                    // Check that user has not pressed cancel before continuing to save file
                    if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        // Create streamwriter object to write to file
                        // With filename given from user input
                        TextWriter myDataFile = new StreamWriter(saveFileDialog.FileName);

                        // Call method in the spectrum class to write data to the file
                        mySpectrum[i].writePlotData(ref myDataFile);
                    }
                }
            }

        }




    }
}
