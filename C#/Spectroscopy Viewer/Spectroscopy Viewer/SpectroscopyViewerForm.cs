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
        // An array of spectrum objects. Can't dynamically resize arrays so set max number to 10. Could maybe use a list instead??
        public List<spectrum> mySpectrum = new List<spectrum>();      
        private List<PointPairList> dataPlot = new List<PointPairList>();       // Create object to store data for graph

        public SpectroscopyViewerForm()
        {
            InitializeComponent();
        }

        // Respond to form 'Load' event
        private void SpectroscopyViewerForm_Load(object sender, EventArgs e)
        {
            // Setup the graph
            createGraph(zedGraphControl1);
            // Size the control to fill the form with a margin
            SetSize();
        }

        // Respond to the form 'Resize' event
        private void Form1_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        // SetSize() is separate from Resize() so we can 
        // call it independently from the Form1_Load() method
        // This leaves a 10 px margin around the outside of the control
        // Customize this to fit your needs
        private void SetSize()
        {
            zedGraphControl1.Location = new Point(10, 60);
            // Leave a small margin around the outside of the control
            zedGraphControl1.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 70);
        }


        



        // Build the Chart - before any data has been added
        private void createGraph(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            // Set the Titles
            myPane.Title.Text = "My Test Graph\n(For CodeProject Sample)";
            myPane.XAxis.Title.Text = "My X Axis";
            myPane.YAxis.Title.Text = "My Y Axis";

        }

        
        // Update the chart when data has been added/updated
        private void updateGraph(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            // Clear data
            zgc.GraphPane.CurveList.Clear();

            for (int i = 0; i < mySpectrum.Count; i++)
            {
                // Generate a red curve with diamond
                // symbols
                LineItem myCurve = myPane.AddCurve("Data Plot",
                      dataPlot[i], Color.Red, SymbolType.Diamond);


                // Tell ZedGraph to refigure the
                // axes since the data have changed
                zgc.AxisChange();
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

                    int existingSpectra = mySpectrum.Count();                   // How many spectra exist already

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
                            if (selectedSpectrum[i] >= existingSpectra)
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



        }


        // Method to respond to 'Plot data' button press
        private void plotDataButton_Click(object sender, EventArgs e)
        {

            // Currently just plot a single spectrum, more complex later

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
                updateGraph(zedGraphControl1);
                // Size the control to fill the form with a margin
                SetSize();
                this.writeToFile_test();
            }
        }


        // Function to output contents of spectra to file. For testing.
        private void writeToFile_test()
        {
            TextWriter[] testFile = new StreamWriter[mySpectrum.Count];

            // Write a separate file for each spectrum
            for (int i = 0; i < mySpectrum.Count; i++)
            {
                testFile[i] = new StreamWriter("C:/Users/localadmin/Documents/testFile_Spectrum" + i + ".txt");
                Console.WriteLine("File created successfully");
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





    }
}
