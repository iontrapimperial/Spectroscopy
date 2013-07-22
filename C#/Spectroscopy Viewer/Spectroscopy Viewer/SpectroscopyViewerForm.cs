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

            // Generate a red curve with diamond
            // symbols
            LineItem myCurve = myPane.AddCurve("Data Plot",
                  dataPlot[0], Color.Red, SymbolType.Diamond);


            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.AxisChange();
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
                    
                    // Create spectrumSelect form, give it list of existing spectra
                    spectrumSelect mySpectrumSelectBox = new spectrumSelect(mySpectrum);
                    mySpectrumSelectBox.ShowDialog();         // Display form

                    int selectedIndex = mySpectrumSelectBox.selectedIndex;      // Which option has been chosen by user
                    int existingSpectra = mySpectrum.Count();                   // How many spectra exist already

                    // If the index is equal to the number of existing spectra, then "Create new spectrum" must be selected
                    // (since for a list of N items, index runs from 0 to N-1)
                    if (selectedIndex == existingSpectra)
                    {
                        // Get the list filled with data points, add to list of spectra
                        mySpectrum.Add(new spectrum(myFilehandler.getDataPoints()));

                        // Set number
                        mySpectrum[existingSpectra].setNumber(existingSpectra);
                        // Set the name of the spectrum
                        mySpectrum[existingSpectra].setName(mySpectrumSelectBox.newSpectrumName);

                        // Add blank PointPairList for storing plot data
                        dataPlot.Add(new PointPairList());
                    }
                    else if (mySpectrumSelectBox.DialogResult == DialogResult.Cancel)
                    {
                        // If user closes the form without clicking "Add to spectrum"
                        MessageBox.Show("Canceled loading data");
                    }
                    else
                    {
                        // Add list of data points from file handler into existing spectrum
                        mySpectrum[selectedIndex].addToSpectrum(myFilehandler.getDataPoints());
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

            // Want to put in an if statement to check that some data has been loaded
            // Currently just plot a single spectrum, more complex later

            if (mySpectrum.Count == 0) MessageBox.Show("No data loaded");

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
        }








    }
}
