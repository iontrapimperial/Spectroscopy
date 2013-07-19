// Main form for Spectroscopy Viewer


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private spectrum[] spectrumData = new spectrum[10];      
        private PointPairList dataPlot = new PointPairList();       // Create object to store data for graph

        public SpectroscopyViewerForm()
        {
            InitializeComponent();
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

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
            zedGraphControl1.Location = new Point(10, 40);
            // Leave a small margin around the outside of the control
            zedGraphControl1.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 50);
        }

        // Respond to form 'Load' event
        private void Form1_Load(object sender, EventArgs e)
        {
            // Setup the graph
            CreateGraph(zedGraphControl1);
            // Size the control to fill the form with a margin
            SetSize();
        }

        // Build the Chart
        private void CreateGraph(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            // Set the Titles
            myPane.Title.Text = "My Test Graph\n(For CodeProject Sample)";
            myPane.XAxis.Title.Text = "My X Axis";
            myPane.YAxis.Title.Text = "My Y Axis";
/*
            // Make up some data arrays based on the Sine function
            double x, y1, y2;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            for (int i = 0; i < 36; i++)
            {
                x = (double)i + 5;
                y1 = 1.5 + Math.Sin((double)i * 0.2);
                y2 = 3.0 * (1.5 + Math.Sin((double)i * 0.2));
                list1.Add(x, y1);
                list2.Add(x, y2);
            }
*/

            // Generate a red curve with diamond
            // symbols, and "Porsche" in the legend
            LineItem myCurve = myPane.AddCurve("Data Plot",
                  dataPlot, Color.Red, SymbolType.Diamond);

            // Generate a blue curve with circle
            // symbols, and "Piper" in the legend
//            LineItem myCurve2 = myPane.AddCurve("Piper",
//                  list2, Color.Blue, SymbolType.Circle);

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.AxisChange();
        }


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }


        // Respond to 'Load data' button press
        private void loadDataButton_Click(object sender, EventArgs e)
        {
            // Configuring dialog to open a new data file
            openDataFile.InitialDirectory = "Z:/Data";   // Initialise to share drive
            openDataFile.RestoreDirectory = true;   // Open to last viewed directory

            // Show dialog to open new data file
            // Do not attempt to open file if user has pressed cancel
            if (openDataFile.ShowDialog() != DialogResult.Cancel)
            {

                try
                {
                    // Create new StreamReader instance to open file
                    System.IO.StreamReader myFile = new System.IO.StreamReader(openDataFile.FileName);
                    // Create new instance of fileHandler to open & process file (pass by reference!)
                    fileHandler myFilehandler = new fileHandler(ref myFile);
                    // Clean up StreamReader instance after fileHandler has finished with it
                    myFile.Close();           // Close object & release resources

                    // Get the list filled with data points
                    spectrumData[0] = new spectrum(myFilehandler.getDataPoints());

                    // Want to have an option to create new spectrum/add to existing, but for now just focus on one spectrum
                    // Can do this by merging lists 

                }
                catch (Exception)   // If any general exception is thrown
                {
                    MessageBox.Show("Invalid file");

                }
            }
        }


        // Method to respond to 'Plot data' button press
        private void plotDataButton_Click(object sender, EventArgs e)
        {

            // Want to put in an if statement to check that some data has been loaded
            // Currently just plot a single spectrum, more complex later
            

            // Need far more code here to analyse data before plotting can take place.....





        }



    }
}
