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

        // Arrays of data for histograms - separate lists for cooling period, count period & all combined
        // Plus an integer to keep track of how large the arrays are
        private BindingList<int> histogramCool;
        private BindingList<int> histogramCount;
        private BindingList<int> histogramAll;
        private int histogramSize = new int();

        private int numberOfSpectra = new int();


        public SpectroscopyViewerForm()
        {
            InitializeComponent();
        }

        // Respond to form 'Load' event
        private void SpectroscopyViewerForm_Load(object sender, EventArgs e)
        {

            // Setup the graph
            createGraph(zedGraphSpectra);
            // Size the control to fill the form with a margin
            SetSize();
        }

        // Respond to the form 'Resize' event
        private void SpectroscopyViewerForm_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        // SetSize() is separate from Resize() so we can 
        // call it independently from the Form1_Load() method
        private void SetSize()
        {
            tabControl1.Location = new Point(10, 10);
            tabControl1.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 20);

            zedGraphSpectra.Location = new Point(10, 60);
            // Leave a small margin around the outside of the control
            zedGraphSpectra.Size = new Size(ClientRectangle.Width - 40,
                                    ClientRectangle.Height - 120);
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

        
        // Update the chart when data has been added/updated
        private void updateGraph(ZedGraphControl zgcSpectrum)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgcSpectrum.GraphPane;

            // Clear data
            zgcSpectrum.GraphPane.CurveList.Clear();

            for (int i = 0; i < mySpectrum.Count; i++)
            {
                // Generate a red curve with diamond
                // symbols
                LineItem myCurve = myPane.AddCurve("Data Plot",
                      dataPlot[i], Color.Red, SymbolType.Diamond);

                // Tell ZedGraph to refigure the
                // axes since the data have changed
                zgcSpectrum.AxisChange();
                zgcSpectrum.Invalidate();
                // Force redraw of control
            }
        }



        // Respond to 'Load data' button press
        private void loadDataButton_Click(object sender, EventArgs e)
        {
            // Configuring dialog to open a new data file
            openDataFile.InitialDirectory = "Z:/Data";      // Initialise to share drive
            openDataFile.RestoreDirectory = true;           // Open to last viewed directory
            openDataFile.FileName = "";                     // Set default filename to blank

            // Show dialog to open new data file
            // Do not attempt to open file if user has pressed cancel
            if (openDataFile.ShowDialog() != DialogResult.Cancel)
            {

 //               try
   //             {
                    // Create new StreamReader instance to open file
                    System.IO.StreamReader myFile = new System.IO.StreamReader(openDataFile.FileName);
                    // Create new instance of fileHandler to open & process file (pass by reference!)
                    fileHandler myFilehandler = new fileHandler(ref myFile);
                    // Clean up StreamReader instance after fileHandler has finished with it
                    myFile.Close();           // Close object & release resources

                    //*************************************************************//
                    // Pop up dialog box to select which spectrum to add data to, and act accordingly

                    // Check how many interleaved spectra there 
                    int numberInterleaved = myFilehandler.getNumberInterleaved();

                    // Get and store just the name of the file (without full path)
                    string myFileName = Path.GetFileName(openDataFile.FileName);

                    // Create spectrumSelect form, give it list of existing spectra and number of spectra in file
                    spectrumSelect mySpectrumSelectBox = new spectrumSelect(mySpectrum, numberInterleaved, myFileName);
                    mySpectrumSelectBox.ShowDialog();         // Display form & wait until it is closed to continue

                    // Get array of information about which data to add to which spectrum
                    int[] selectedSpectrum = new int[numberInterleaved];
                    selectedSpectrum = mySpectrumSelectBox.selectedSpectrum.ToArray();

                    // Make sure the user didn't press cancel or close the dialog box
                    if (mySpectrumSelectBox.DialogResult == DialogResult.OK)
                    {
                        // For each interleaved spectrum
                        for (int i = 0; i < numberInterleaved; i++)
                        {
                            // If the index >= number of existing spectra, new ones must have been added
                            // (since for a list of N items, index runs from 0 to N-1)
                            if (selectedSpectrum[i] >= numberOfSpectra)
                            {
                                // Get the list filled with data points, add to list of spectra
                                mySpectrum.Add(new spectrum(myFilehandler.getDataPoints(i)));

                                // Set number
                                mySpectrum[selectedSpectrum[i]].setNumber(selectedSpectrum[i]);
                                // Set the name of the spectrum
                                mySpectrum[selectedSpectrum[i]].setName(mySpectrumSelectBox.spectrumNames[selectedSpectrum[i]]);

                                // Add blank PointPairList for storing plot data
                                dataPlot.Add(new PointPairList());

                            }
                            else
                            {
                                // Add list of data points from file handler into existing spectrum
                                mySpectrum[selectedSpectrum[i]].addToSpectrum(myFilehandler.getDataPoints(i));
                            }
                        }
                    }

                    //**************************************************************

                    
  /*              }
                catch (Exception)   // If any general exception is thrown
                {
                    MessageBox.Show("Error");

                }*/
            }

            // Update number of spectra
            numberOfSpectra = mySpectrum.Count();
        }


        // Method to respond to 'Plot data' button press
        private void plotDataButton_Click(object sender, EventArgs e)
        {
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
                updateGraph(zedGraphSpectra);
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

            TextWriter histogramFile = new StreamWriter("C:/Users/localadmin/Documents/testFile_Histogram.txt");
            histogramFile.WriteLine("Counts\tCool period\tCount period\tAll");

            for (int j = 0; j < histogramSize; j++)
            {
                histogramFile.WriteLine(j + "\t" + histogramCool[j] + "\t" + histogramCount[j] + "\t" + histogramAll[j] + "\n");
            }



        }

        private void updateHistogramButton_Click(object sender, EventArgs e)
        {
            // Calculating data for histogram
            //********************************//

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

                    // Create binding lists using the histogram data
                    histogramCool = new BindingList<int>(tempHistogramCool);
                    histogramCount = new BindingList<int>(tempHistogramCount);
                    histogramAll = new BindingList<int>();

                    // Calculate total data and store in another list (cool + count)
                    for (int j = 0; j < histogramSize; j++)
                    {
                        histogramAll.Add(histogramCool[j] + histogramCount[j]);
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
                        // Add new bins to the end of each list
                        for (int j = histogramSize; j < tempHistogramSize; j++)
                        {
                            histogramCool.Add(tempHistogramCool[j]);
                            histogramCount.Add(tempHistogramCount[j]);
                        }

                        // Update size of list (could use tempHistogramSize, but recalculate just in case)
                        histogramSize = histogramCool.Count();
                    }
                }

            }

            //********************************//



            // Try to create a data table with the lists as columns
            DataSet histogramDataSet = new DataSet();
            DataTable histogramTable = new DataTable();

            histogramDataSet.Tables.Add(histogramTable);

            // Create columns
            histogramTable.Columns.Add(new DataColumn("Bin", typeof(int) ) );
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

            var enumerableTable = (histogramTable as System.ComponentModel.IListSource).GetList();
            this.histogramChart.DataBindTable(enumerableTable, "Bin");


        }

        // Method to be called when a change is made to the radio buttons controlling the histogram display
        private void radioButtonDisplay_CheckedChanged(object sender, EventArgs e)
        {
            // For each radio button (All, Cool, Count)
            // If the button is checked, display the corresponding series
            // If the button is unchecked, hide the corresponding series

            if (radioButtonAll.Checked) this.histogramChart.Series["All"].Enabled = true;
            else this.histogramChart.Series["All"].Enabled = false;

            if (radioButtonCool.Checked) this.histogramChart.Series["Cool period"].Enabled = true;
            else this.histogramChart.Series["Cool period"].Enabled = false;

            if (radioButtonCount.Checked) this.histogramChart.Series["Count period"].Enabled = true;
            else this.histogramChart.Series["Count period"].Enabled = false;

        }

    }
}
