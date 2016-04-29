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
        public List<spectrum> myPMTSpectrum = new List<spectrum>();
        public List<spectrum>[] myCAMSpectrum;

        // List to store data for plotting spectrum graph. PointPairList is the object needed for plotting with zedGraph 
        private List<PointPairList> dataPMTPlot = new List<PointPairList>();
        private List<PointPairList>[] dataCAMPlot;

        // List to store data for derived plots (e.g. 1+2 Average, Parity, EE, GG, EG, GE etc)
        private List<PointPairList>[] derivedCAMPlot;

        // Arrays of data for histograms - separate lists for cooling period, count period & all combined
        // Plus an integer to keep track of how large the arrays are
        private int[] histogramCoolPMT;
        private int[] histogramCountPMT;
        private int[] histogramAllPMT;
        private int histogramSizePMT;

        private int[] histogramCoolCAM;
        private int[] histogramCountCAM;
        private int[] histogramAllCAM;
        private int histogramSizeCAM;


        private int cameraSpecNum = 0;
        private int numOfIons = 1;
        private int numDerivedPlots = 4;



        private bool useCamera = false;
        private int useDerivedPlots = 0; // 0 = NOT used , 1 = PMT, 2 = CAM
        private bool useMLE = false;
        private int numMLECounts = 1; 

        // Number of spectra loaded to graph
        private int numberOfSpectra = new int();

        // Permanent list of colours to display
        private List<Color> colourListData = new List<Color>();
        private List<Color> colourListBadCounts = new List<Color>();
        // List of colours to show on graph (can be changed around)
        private List<Color> myColoursData = new List<Color>();
        private List<Color> myColoursBadCounts = new List<Color>();

        // Boolean to tell the form whether the experiment is running or not
        // i.e. whether it has received live data
        // This isn't actually used for anything at the moment
        private bool IsExperimentRunning = new bool();

        // Array to store metadata for live experiment ONLY, save passing it every single time we add data
        private string[] metadataLive;
        // Store the number of spectra in the live experiment as an int for quick access
        private int numberOfSpectraLive = new int();
        private int repeatsLive = new int();
        private int stepSizeLive = new int();
        private int startFreqLive = new int();
        private int startLengthLive = 0;        // For fixed spectra



        // Graph controls
        private static int maxGraphControl = 5;
        private GroupBox[] graphControlGroup = new GroupBox[maxGraphControl];
        private System.Windows.Forms.Label[] graphControlLabel = new System.Windows.Forms.Label[maxGraphControl];
        private CheckBox[] graphControlCheckBox = new CheckBox[maxGraphControl];
        private RadioButton[] graphControlBadCountsNone = new RadioButton[maxGraphControl];
        private RadioButton[] graphControlBadCountsAll = new RadioButton[maxGraphControl];
        private RadioButton[] graphControlBadCountsLaser = new RadioButton[maxGraphControl];
        private RadioButton[] graphControlBadCountsThreshold = new RadioButton[maxGraphControl];
        private ContextMenu[] graphControlContextMenu = new ContextMenu[maxGraphControl];

        private GroupBox[] graphControlGroupCAM = new GroupBox[maxGraphControl];
        private System.Windows.Forms.Label[] graphControlLabelCAM = new System.Windows.Forms.Label[maxGraphControl];
        private CheckBox[] graphControlCheckBoxCAM = new CheckBox[maxGraphControl];
        private RadioButton[] graphControlBadCountsNoneCAM = new RadioButton[maxGraphControl];
        private RadioButton[] graphControlBadCountsAllCAM = new RadioButton[maxGraphControl];
        private RadioButton[] graphControlBadCountsLaserCAM = new RadioButton[maxGraphControl];
        private RadioButton[] graphControlBadCountsThresholdCAM = new RadioButton[maxGraphControl];
        private ContextMenu[] graphControlContextMenuCAM = new ContextMenu[maxGraphControl];

        



        private GroupBox[] graphControlGroupDER = new GroupBox[maxGraphControl];
        private System.Windows.Forms.Label[] graphControlLabelDER = new System.Windows.Forms.Label[maxGraphControl];
        private CheckBox[] graphControlCheckBoxDER = new CheckBox[maxGraphControl];
        private CheckBox[] graphControlAverage = new CheckBox[maxGraphControl];
        private CheckBox[] graphControlEE = new CheckBox[maxGraphControl];
        private CheckBox[] graphControlEGGE = new CheckBox[maxGraphControl];
        private CheckBox[] graphControlGG = new CheckBox[maxGraphControl];
        private CheckBox[] graphControlParity = new CheckBox[maxGraphControl];


        //Constructor called when running independently
        public SpectroscopyViewerForm()
        {
            InitializeComponent();
            initialiseColours();
        }

        public static int[] GetRow(int rowNum, int[,] readings)
        {

            int a = 0;
            int length = readings.GetLength(1);
            int[] row = new int[readings.GetLength(1)];
            for (a = 0; a < length; a++)
            {
                row[a] = readings[rowNum, a];
            }
            return row;
        }


        // Constructor to be called from Spectroscopy Controller. Needs passing an array containing metadata, and a boolean for whether the 
        // Metadata ordering in array:
        // 0: Date
        // 1: Spectrum type
        // 2: 729 direction
        // 3: Trap voltage
        // 4: Axial freq
        // 5: Modified cyc freq
        // 6: Magnetron freq
        // 7: AOM start freq (MHz)
        // 8: Carrier freq (MHz)
        // 9: Step size (kHz)
        // 10: Sidebands/side
        // 11: Sideband width (steps)
        // 12: 729 RF amplitude
        // 13: Number of repeats
        // 14: Number interleaved
        // 15: Which sideband
        // 16: Starting pulse length (fixed)
        // 17: Number of steps (fixed)
        // 18 + i: sideband i name
        // Notes
        public SpectroscopyViewerForm(ref string[] metadataPassed, bool isCamera, int numIons, bool isMLE, int mleCountPeriods)
        {
            this.FormClosing += new FormClosingEventHandler(this.OnFormClosing);
            useCamera = isCamera;
            InitializeComponent();
            initialiseColours();
            // Flag that experiment is running
            useMLE = isMLE;
            numMLECounts = mleCountPeriods;
            this.IsExperimentRunning = true;
            // While running in live mode, do the following for safety:
            this.loadDataButton.Enabled = false;                // Disable loading saved data 
            this.loadDataButtonCAM.Enabled = false;
            this.restartViewerButton.Enabled = false;           // Disable restarting viewer          
            this.spectrumExportDataButton.Enabled = false;      // Disable exporting spectrum data
            this.spectrumExportDataButtonCAM.Enabled = false;
            this.histogramExportDataButton.Enabled = false;     // Disable exporting histogram data
            this.histogramExportDataButtonCAM.Enabled = false;
            for (int i = 1; i <= numIons + 1; i++)
            {
                string[] numbers = { i.ToString() };
                ionBox.Items.AddRange(numbers);
                ionBox1.Items.AddRange(numbers);
            }
            if(numIons == 2 )
            {
                if (isCamera == true)
                    useDerivedPlots = 2;
                else useDerivedPlots = 1; 
            }
            numOfIons = numIons + 1;            
            /*ionBox.Items.Add("GG");
            ionBox.Items.Add("EE");
            ionBox.Items.Add("GE");
            ionBox.Items.Add("EG");
            ionBox.Items.Add("Parity");*/

            // Store metadata... might need to do this element by element, don't think so though
            // Metadata is passed element by element in spectrum constructor so this is OK
            metadataLive = metadataPassed;

            float stepSizeLivekHz = new float();
            float startFreqLiveMHz = new float();

            // Extract info that we need to pass to fileHandler
            // Make sure repeats, number of spectra & start frequency are real numbers
            if (int.TryParse(metadataLive[13], out repeatsLive)
                && int.TryParse(metadataLive[14], out numberOfSpectraLive)
                && float.TryParse(metadataLive[7], out startFreqLiveMHz)
                )
            {
                if (metadataLive[1] == "Fixed")
                {
                    if (int.TryParse(metadataLive[9], out stepSizeLive)
                        && int.TryParse(metadataLive[16], out startLengthLive))
                    {
                        startFreqLive = (int)(startFreqLiveMHz * 1000000);
                    }
                    else
                    {
                        // Show error, skip rest of this function
                        MessageBox.Show("Error parsing metadata when opening viewer");
                        return;
                    }
                }
                else
                {
                    if (float.TryParse(metadataLive[9], out stepSizeLivekHz))
                    {
                        stepSizeLive = (int)(stepSizeLivekHz * 1000);
                        startFreqLive = (int)(startFreqLiveMHz * 1000000);
                    }
                    else
                    {
                        // Show error, skip rest of this function
                        MessageBox.Show("Error parsing metadata when opening viewer");
                        return;
                    }
                }
            }

            // Save number of spectra
            int existingSpectra = numberOfSpectra;
            // Add number of spectra from new experiment
            numberOfSpectra += numberOfSpectraLive;




            // Create new spectra, with no data points, just metadata
            for (int i = existingSpectra; i < numberOfSpectra; i++)
            {
                myPMTSpectrum.Add(new spectrum(ref metadataLive, i, numberOfSpectraLive));
                dataPMTPlot.Add(new PointPairList());              // Add empty list for plotting data

                // Set cool/count thresholds from boxes on form
                myPMTSpectrum[i].setCoolThreshold((int)this.coolingThresholdSelect.Value);
                myPMTSpectrum[i].setCountThreshold((int)this.countThresholdSelect.Value);
                myPMTSpectrum[i].setGGThreshold((int)this.ggThresholdSelect.Value);
            }

            // Create the controls for the graph
            this.createGraphControls();
            this.createGraphControlsDER();

            // But since we haven't added any data yet, don't update thresholds or graph

            // Disable context menus on graph controls while running in live mode
            for (int i = 0; i < numberOfSpectra; i++)
            {
                for (int j = 0; j < graphControlContextMenu[i].MenuItems.Count; j++)
                {
                    this.graphControlContextMenu[i].MenuItems[j].Enabled = false;
                }
            }


            derivedCAMPlot = new List<PointPairList>[numDerivedPlots];
            for (int k = 0; k < numDerivedPlots; k++)
            {
                // Create new derived plotting lists, with no data points yet
                derivedCAMPlot[k] = new List<PointPairList>();
                for (int l = existingSpectra; l < numberOfSpectra; l++)
                {
                    derivedCAMPlot[k].Add(new PointPairList());
                }

                // Create the controls for the graph                  

            }




            if (isCamera == true)
            {
                myCAMSpectrum = new List<spectrum>[numIons + 1];
                dataCAMPlot = new List<PointPairList>[numIons + 1];              
                int j;
                

                for (j = 0; j < numIons + 1; j++)
                {
                    // Create new spectra, with no data points, just metadata
                    myCAMSpectrum[j] = new List<spectrum>();
                    dataCAMPlot[j] = new List<PointPairList>();
                    
                    for (int i = existingSpectra; i < numberOfSpectra; i++)
                    {

                        myCAMSpectrum[j].Add(new spectrum(ref metadataLive, i, numberOfSpectraLive));
                        dataCAMPlot[j].Add(new PointPairList());
                       
                        // Set cool/count thresholds from boxes on form                        
                        myCAMSpectrum[j][i].setCoolThreshold((int)this.coolingThresholdSelectCAM.Value);
                        myCAMSpectrum[j][i].setCountThreshold((int)this.countThresholdSelectCAM.Value);

                    }
                    
                    // Create the controls for the graph                  
                    this.createGraphControlsCAM();
                    //this.createGraphControlsDER();

                    // But since we haven't added any data yet, don't update thresholds or graph

                    // Disable context menus on graph controls while running in live mode
                    for (int i = 0; i < numberOfSpectra; i++)
                    {
                        for (int k = 0; k < graphControlContextMenuCAM[i].MenuItems.Count; k++)
                        {
                            this.graphControlContextMenuCAM[i].MenuItems[k].Enabled = false;
                        }
                    }
                }
                
                
                

            }


        }

        // Method to accept incoming data from live experiment
        // (nb: changed startFreqLive which was taken from metadata 
        // to sidebandStartFreq passed directly from FPGAControls - JOE)
        // Made threadsafe
        private delegate void Delegate_addLiveDataCAM(int[,] camReadings, int CurrentWindowStep, int sidebandStartFreq, int pulseLength);
        public void addLiveDataCAM(int[,] camReadings, int CurrentWindowStep, int sidebandStartFreq, int pulseLength)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Delegate_addLiveDataCAM(addLiveDataCAM), new object[] { camReadings, CurrentWindowStep, sidebandStartFreq, pulseLength });
            }
            else
            {

                // How many spectra were loaded before we started running live
                int existingSpectra = numberOfSpectra - numberOfSpectraLive;
                for (int j = 0; j < numOfIons; j++)
                {
                    int[] myData = GetRow(j, camReadings);
                    fileHandler myFileHandler = new fileHandler(ref myData, repeatsLive, stepSizeLive, numberOfSpectraLive,
                                                            sidebandStartFreq, CurrentWindowStep, pulseLength);//numOfIons
                    // Loop through the live spectra only
                    for (int i = existingSpectra; i < numberOfSpectra; i++)
                    {
                        // Add data points to the spectrum
                        //Console.WriteLine("In the data process loop of camera");
                        myCAMSpectrum[j][i].addToSpectrum(myFileHandler.getDataPoints(i));
                        //   myCAMSpectrum[i].addToSpectrum(myFileHandlerCAM.getDataPoints(i));
                        // Retrieve the data to plot to graph (has already been updated by the addToSpectrum method)    

                        dataCAMPlot[j][i] = myCAMSpectrum[j][i].getDataPlot();
                    }
                }

                // NB data gets updated automatically when points are added to spectra
                // So just update graph
                updateGraphCAM();
                // Size the control to fill the form with a margin
                SetSizeCAM();
                
                if (useDerivedPlots == 2)
                {
                    for (int k = 0; k < numDerivedPlots; k++)
                    {
                        // Loop through the live spectra only
                        for (int l = existingSpectra; l < numberOfSpectra; l++)
                        {
                            // Add data points to the spectrum
                            Console.WriteLine("In the data process loop of Derived plots");
                            // Retrieve the data to plot to graph (has already been updated by the addToSpectrum method)
                            PointPairList tempList = populateDerivedCAMPlot(k, l);
                            derivedCAMPlot[k][l] =tempList;
                        }
                    }

                    // NB data gets updated automatically when points are added to spectra
                    // So just update graph
                   updateGraphDER();
                    // Size the control to fill the form with a margin
                   SetSizeDER();
                }
                
            }
        }


        private delegate void Delegate_addLiveData(List<int> readings, int CurrentWindowStep, int sidebandStartFreq, int pulseLength);
        public void addLiveData(List<int> readings, int CurrentWindowStep, int sidebandStartFreq, int pulseLength)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Delegate_addLiveData(addLiveData), new object[] { readings, CurrentWindowStep, sidebandStartFreq, pulseLength });
            }
            else
            {
                // Copy data from readings into local array
                int[] myData;
                if(useMLE == true)
                {
                    int[] myDataN = readings.ToArray();
                    int dataPointSize = (2 + numMLECounts * 2);
                    myData = new int[4* repeatsLive];
                    for (int i = 0;i < repeatsLive; i++)
                    {
                        for(int j = 0;j < numMLECounts;j++)
                        {
                            myData[i* 4] = myDataN[dataPointSize*i];
                            myData[i* 4 + 1] = myDataN[dataPointSize * i + 1];
                            myData[i* 4 + 2] += myDataN[2 * i * numMLECounts + (1 + i) * 2 + j * 2];                            
                            myData[i* 4 + 3] += myDataN[2 * i * numMLECounts + (1 + i) * 2 + j * 2+1];
                        }
                    }
                }
                else
                {
                   myData = readings.ToArray();
                }



                // Create fileHandler object to process the incoming data (use current sidebandStartFreq and currentwindowstep to add datapoint at correct frequency
                fileHandler myFileHandler = new fileHandler(ref myData, repeatsLive, stepSizeLive, numberOfSpectraLive,
                                                            sidebandStartFreq, CurrentWindowStep, pulseLength);

                // How many spectra were loaded before we started running live
                int existingSpectra = numberOfSpectra - numberOfSpectraLive;

                // Loop through the live spectra only
                for (int i = existingSpectra; i < numberOfSpectra; i++)
                {
                    Console.WriteLine("In the data process loop of pmt");
                    // Add data points to the spectrum
                    myPMTSpectrum[i].addToSpectrum(myFileHandler.getDataPoints(i));

                    // Retrieve the data to plot to graph (has already been updated by the addToSpectrum method)
                    dataPMTPlot[i] = myPMTSpectrum[i].getDataPlot();

                }






                // NB data gets updated automatically when points are added to spectra
                // So just update graph
                updateGraph();
                // Size the control to fill the form with a margin
                SetSize();

                if (useDerivedPlots == 1)
                {
                    for (int k = 0; k < numDerivedPlots; k++)
                    {
                        // Loop through the live spectra only
                        for (int l = existingSpectra; l < numberOfSpectra; l++)
                        {
                            // Add data points to the spectrum
                            Console.WriteLine("In the data process loop of Derived plots");
                            // Retrieve the data to plot to graph (has already been updated by the addToSpectrum method)
                            PointPairList tempList = populateDerivedPlot(k, l);
                            derivedCAMPlot[k][l] = tempList;
                        }
                    }

                    // NB data gets updated automatically when points are added to spectra
                    // So just update graph
                    updateGraphDER();
                    // Size the control to fill the form with a margin
                    SetSizeDER();
                }
            }


        }





        // Threadsafe method to tell the viewer that we have stopped running a live experiment
        delegate void Delegate_StopRunningLive();
        public void StopRunningLive()
        {
            Console.WriteLine("in StopRunningLive");

            if (this.InvokeRequired)
            {
                this.Invoke(new Delegate_StopRunningLive(StopRunningLive));
            }
            else
            {
                if (IsExperimentRunning)
                {
                    // Flag that we are not running in live mode
                    Console.WriteLine("in else");
                    IsExperimentRunning = false;

                    // Now that we have stopped running in live mode:
                    this.loadDataButton.Enabled = true;                 // Re-enable loading saved data
                    this.restartViewerButton.Enabled = true;            // Re-enable restarting viewer
                    this.spectrumExportDataButton.Enabled = true;       // Re-enable exporting spectrum data
                    this.histogramExportDataButton.Enabled = true;      // Re-enable exporting histogram data
                    this.pauseButton.Enabled = false;
                    // Re-enable context menus on graph controls
                    for (int i = 0; i < numberOfSpectra; i++)
                    {
                        for (int j = 0; j < graphControlContextMenu[i].MenuItems.Count; j++)
                        {
                            this.graphControlContextMenu[i].MenuItems[j].Enabled = true;
                        }
                    }
                }

            }
        }

        // Method to build a list of colours for the graph - 5 different colour pairs
        private void initialiseColours()
        {

            // One list to store permanent record of the colours
            colourListData.Add(Color.Blue);
            colourListBadCounts.Add(Color.LightSkyBlue);

            colourListData.Add(Color.OrangeRed);
            colourListBadCounts.Add(Color.SandyBrown);

            colourListData.Add(Color.ForestGreen);
            colourListBadCounts.Add(Color.PaleGreen);

            colourListData.Add(Color.Magenta);
            colourListBadCounts.Add(Color.Pink);

            colourListData.Add(Color.Teal);
            colourListBadCounts.Add(Color.PaleTurquoise);

            // One list to store list of colours used in graph
            // Initially the same as colourList but these can change later through user control
            for (int i = 0; i < 5; i++)
            {
                myColoursData.Add(colourListData[i]);
                myColoursBadCounts.Add(colourListBadCounts[i]);
            }




        }

        // Respond to form 'Load' event
        private void SpectroscopyViewerForm_Load(object sender, EventArgs e)
        {

            // Setup the graph
            createGraph(zedGraphSpectra);
            createGraph(zedGraphSpectraCAM);
            createGraph(zedGraphSpectraDER);
            //zedGraphSpectra.GraphPane.YAxis.Scale.Max = 1;
            // Size the control to fill the form with a margin
            SetSize();
            SetSizeCAM();
            SetSizeDER();

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
            // Only try to resize if we are not running live
            if (!IsExperimentRunning)
            {
                SetSize();
                SetSizeCAM();
            }
        }

        // Method to set size of graphs depending on overall form size
        private void SetSize()
        {
            tabControl1.Location = new Point(10, 10);
            tabControl1.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 20);

            zedGraphSpectra.Location = new Point(55, 60);
            // Leave a small margin around the outside of the control
            zedGraphSpectra.Size = new Size(ClientRectangle.Width - 270,
                                    ClientRectangle.Height - 180);

            //Redraw the graph controls in appropriate position for new window size
            for (int i = 0; i < numberOfSpectra; i++)
            {
                if (i < 5)
                {
                    this.graphControlGroup[i].Location = new System.Drawing.Point(ClientRectangle.Width - 210, (6 + 115 * i));
                    this.graphControlGroup[i].Size = new System.Drawing.Size(176, 109);
                }
            }

        }

        private void SetSizeCAM()
        {


            tabControl1.Location = new Point(10, 10);
            tabControl1.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 20);

            zedGraphSpectraCAM.Location = new Point(55, 60);
            // Leave a small margin around the outside of the control
            zedGraphSpectraCAM.Size = new Size(ClientRectangle.Width - 270,
                                    ClientRectangle.Height - 180);
            if (useCamera == true)
            {
                //Redraw the graph controls in appropriate position for new window size
                for (int i = 0; i < numberOfSpectra; i++)
                {
                    if (i < 5)
                    {
                        this.graphControlGroupCAM[i].Location = new System.Drawing.Point(ClientRectangle.Width - 210, (6 + 115 * i));
                        this.graphControlGroupCAM[i].Size = new System.Drawing.Size(176, 109);
                    }
                }
            }

        }
        private void SetSizeDER()
        {


            tabControl1.Location = new Point(10, 10);
            tabControl1.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 20);

            zedGraphSpectraDER.Location = new Point(55, 60);
            // Leave a small margin around the outside of the control
            zedGraphSpectraDER.Size = new Size(ClientRectangle.Width - 270,
                                    ClientRectangle.Height - 180);
            if (useCamera == true)
            {
                //Redraw the graph controls in appropriate position for new window size
                for (int i = 0; i < numberOfSpectra; i++)
                {
                    if (i < 5)
                    {
                        this.graphControlGroupDER[i].Location = new System.Drawing.Point(ClientRectangle.Width - 210, (6 + 115 * i));
                        this.graphControlGroupDER[i].Size = new System.Drawing.Size(176, 109);
                    }
                }
            }

        }




        // Respond to 'Load file...' button press
        // Loads data from the file, opens dialog for user to assign data to existing/new spectra
        // and creates the list of spectra 
        private void loadFileButton_Click(object sender, EventArgs e)
        {
            // Configuring dialog to open a new data file
            openDataFile.InitialDirectory = "C:\\Users\\IonTrap\\Dropbox\\Current Data";      // Initialise to share drive
            openDataFile.RestoreDirectory = false;           // Open to last viewed directory
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
                spectrumSelect myPMTSpectrumSelectBox = new spectrumSelect();

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

                    // If numberInterleaved is zero, then trying to open spectrumSelect window will cause the progam to crash
                    // It would also mean that the fileHandler was not able to process the data correctly
                    if (numberInterleaved != 0)
                    {

                        if (i == 0)
                        {
                            // Set number interleaved to compare other files to
                            numberInterleavedMaster = numberInterleaved;

                            //*************************************************************
                            // Pop up dialog box to select which spectrum to add data to, and save selections

                            // Create spectrumSelect form, give it list of existing spectra, number of spectra in first file
                            // file name of first file, and number of files opened
                            string[] spectrumNamesFromFile = myFilehandler.getSpectrumNames();
                            myPMTSpectrumSelectBox = new spectrumSelect(myPMTSpectrum, ref spectrumNamesFromFile, numberInterleaved,
                                                                    ref myFileName, numberOfFiles);
                            myPMTSpectrumSelectBox.ShowDialog();         // Display form & wait until it is closed to continue

                            // Make sure the user didn't press cancel or close the dialog box
                            if (myPMTSpectrumSelectBox.DialogResult == DialogResult.OK)
                            {
                                // Get array of information about which data to add to which spectrum
                                selectedSpectrum = new int[numberInterleaved];
                                selectedSpectrum = myPMTSpectrumSelectBox.selectedSpectrum.ToArray();
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
                                        int specNumInFile = selectedSpectrum[j] - numberOfSpectra;
                                        // Get the list filled with data points, add to list of spectra
                                        myPMTSpectrum.Add(new spectrum(myFilehandler.getDataPoints(j),     // Data points for spectrum       
                                                        selectedSpectrum[j],            // Spectrum number
                                                        myPMTSpectrumSelectBox.spectrumNamesForGraph[selectedSpectrum[j]], // Spectrum name
                                                        ref myFilehandler.metadata,     // Metadata from file 
                                                        specNumInFile,                  // Which spectrum in the file
                                                        myFilehandler.getNumberInterleaved()));    // How many interleaved in file           

                                        // Add blank PointPairList for storing plot data
                                        dataPMTPlot.Add(new PointPairList());
                                    }
                                    else
                                    {


                                        // Add list of data points from file handler into existing spectrum
                                        myPMTSpectrum[selectedSpectrum[j]].addToSpectrum(myFilehandler.getDataPoints(j));


                                    }
                                }
                                // Update number of spectra
                                numberOfSpectra = myPMTSpectrum.Count();
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
                        userDisplayText.Text += @"File """ + myFileName.Replace(".txt", "") + @""" loaded" + System.Environment.NewLine;
                        userDisplayText.Text += "Notes: " + myFilehandler.getNotes();
                        userDisplayText.SelectionStart = userDisplayText.Text.Length;
                        userDisplayText.ScrollToCaret();

                    }   // End of if statement which checks for number interleaved != 0

                } // End of for loop which goes through each file



                // Create the controls for the graph
                this.createGraphControls();

                // Update thresholds & plot data
                this.updateThresholds();


            }
        }

        // Method to respond to 'Update thresholds' button press
        private void updateThresholdsButton_Click(object sender, EventArgs e)
        {
            updateThresholds();
        }
        private void updateThresholdsButtonCAM_Click(object sender, EventArgs e)
        {
            updateThresholdsCAM();
        }



        // Method to update the thresholds
        // Calculates bad counts/dark ion probs based on thresholds & plots graph
        private void updateThresholds()
        {
            // Do not attempt to do anything if no spectra have been created
            if (myPMTSpectrum.Count == 0) MessageBox.Show("No data loaded");
            else
            {
                // Analyse each spectrum and get the data
                // NB if no spectra have been loaded, myPMTSpectrum.Count will be 0 and this loop will not run
                for (int i = 0; i < myPMTSpectrum.Count; i++)
                {
                    myPMTSpectrum[i].analyse((int)coolingThresholdSelect.Value, (int)countThresholdSelect.Value, (int)ggThresholdSelect.Value);
                    dataPMTPlot[i] = myPMTSpectrum[i].getDataPlot();
                }

                // Setup the graph
                updateGraph();
                // Size the control to fill the form with a margin
                SetSize();
            }
        }
        private void updateThresholdsCAM()
        {
            // Do not attempt to do anything if no spectra have been created
            if (myCAMSpectrum != null)
            {
                if (myCAMSpectrum[cameraSpecNum].Count == 0) MessageBox.Show("No data loaded");
                else
                {
                    // Analyse each spectrum and get the data
                    // NB if no spectra have been loaded, myPMTSpectrum.Count will be 0 and this loop will not run
                    for (int i = 0; i < myCAMSpectrum[cameraSpecNum].Count; i++)
                    {
                        myCAMSpectrum[cameraSpecNum][i].analyse((int)coolingThresholdSelectCAM.Value, (int)countThresholdSelectCAM.Value, 0);
                        dataCAMPlot[cameraSpecNum][i] = myCAMSpectrum[cameraSpecNum][i].getDataPlot();
                    }

                    // Setup the graph
                    updateGraphCAM();
                    
                    // Size the control to fill the form with a margin
                    SetSizeCAM();
                }
            }
        }




        // Method to respond to user clicking "Export spectrum..." button
        // Opens a save file dialog for each spectrum, saves data in a text file (tab separated)
        // Might want to put some metadata into this file??
        private void spectrumExportDataButton_Click(object sender, EventArgs e)
        {
            // Do not attempt to do anything if no spectra have been created
            if (myPMTSpectrum.Count == 0) MessageBox.Show("No data loaded");
            else
            {
                // Configuring dialog to save file
                saveFileDialog.InitialDirectory = "C:\\Users\\IonTrap\\Dropbox\\Current Data\\";      // Initialise to share drive
                saveFileDialog.RestoreDirectory = true;           // Open to last viewed directory
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                // Show new dialogue for each spectrum
                for (int i = 0; i < numberOfSpectra; i++)
                {
                    saveFileDialog.Title = "Save data for spectrum" + (i + 1);
                    saveFileDialog.FileName = myPMTSpectrum[i].getName() + "_data.txt";

                    // Show dialog to save file
                    // Check that user has not pressed cancel before continuing to save file
                    if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        // Create streamwriter object to write to file
                        // With filename given from user input
                        TextWriter myDataFile = new StreamWriter(saveFileDialog.FileName);

                        // Call method in the spectrum class to write data to the file
                        myPMTSpectrum[i].writePlotData(ref myDataFile);
                    }
                }
            }

        }

        // Method to respond to user clicking "Restart viewer" button
        private void restartViewerButton_Click(object sender, EventArgs e)
        {
            // Set dialog result to indicate that we should restart form
            this.DialogResult = System.Windows.Forms.DialogResult.Retry;
            // Close form
            this.Close();
        }

        #region Code relating to generating, plotting & exporting histogram

        // Method to respond to user clicking "Update histogram" button
        // Creates separate histogram for each spectrum, combines the data and plots it
        // NB histogram is recreated with every button click, since it is a fairly quick process and doesn't happen often
        private void updateHistogramButton_Click(object sender, EventArgs e)
        {
            // Do not attempt to do anything if no spectra have been created
            if (myPMTSpectrum.Count == 0) MessageBox.Show("No data loaded");
            else
            {
                // Calculating data for histogram
                //********************************
                // Initialise variables every time we re-create the histogram
                histogramSizePMT = new int();

                // Local variables used within this method
                int[] temphistogramCoolPMT;
                int[] temphistogramCountPMT;
                int temphistogramSizePMT = new int();

                // For each spectrum
                for (int i = 0; i < numberOfSpectra; i++)
                {
                    // Temporarily store histograms for this spectrum
                    temphistogramCoolPMT = myPMTSpectrum[i].getHistogramCool();
                    temphistogramCountPMT = myPMTSpectrum[i].getHistogramCount();

                    // Find size of histograms for this spectrum
                    temphistogramSizePMT = temphistogramCoolPMT.Length;

                    // For the first spectrum only
                    if (i == 0)
                    {
                        // Store size of lists
                        histogramSizePMT = temphistogramSizePMT;

                        // Create arrays of the right size
                        histogramCoolPMT = new int[histogramSizePMT];
                        histogramCountPMT = new int[histogramSizePMT];
                        histogramAllPMT = new int[histogramSizePMT];


                        // Loop through each histogram bin and populate arrays
                        for (int j = 0; j < histogramSizePMT; j++)
                        {
                            // Populate arrays from temp histograms
                            // NB cannot just use e.g. histogramCoolPMT = tempHistogram, this will cause errors
                            // since arrays are a reference type. Need to manipulate each element individually
                            histogramCoolPMT[j] = temphistogramCoolPMT[j];
                            histogramCountPMT[j] = temphistogramCountPMT[j];

                            // Calculate total data and store in another array (cool + count)
                            histogramAllPMT[j] = histogramCoolPMT[j] + histogramCountPMT[j];
                        }
                    }
                    else
                    {   // For subsequent spectra, go through and add the data to existing lists


                        // If the histogram for the current spectrum is larger than the existing histogram
                        if (temphistogramSizePMT > histogramSizePMT)
                        {
                            Array.Resize(ref histogramCoolPMT, temphistogramSizePMT);
                            Array.Resize(ref histogramCountPMT, temphistogramSizePMT);
                            Array.Resize(ref histogramAllPMT, temphistogramSizePMT);

                            // Fill in the data into the new bins
                            for (int j = histogramSizePMT; j < temphistogramSizePMT; j++)
                            {
                                histogramCoolPMT[j] = temphistogramCoolPMT[j];
                                histogramCountPMT[j] = temphistogramCountPMT[j];
                                histogramAllPMT[j] = histogramCoolPMT[j] + histogramCountPMT[j];
                            }

                            // Update size of list (could use temphistogramSizePMT, but recalculate just in case)
                            histogramSizePMT = temphistogramSizePMT;//histogramCoolPMT.Count();
                        }
                        else
                        {
                            for (int j = 0; j < temphistogramSizePMT; j++)
                            {
                                // Sum the data from each spectrum into the full list
                                histogramCoolPMT[j] += temphistogramCoolPMT[j];
                                histogramCountPMT[j] += temphistogramCountPMT[j];

                                histogramAllPMT[j] = histogramCoolPMT[j] + histogramCountPMT[j];
                            }
                        }
                    }
                }       // End of loop which goes through spectra and creates histogram

                //********************************
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

                for (int i = 0; i < histogramSizePMT; i++)
                {
                    DataRow myRow = histogramTable.NewRow();
                    myRow["Bin"] = i;
                    myRow["Cool period"] = histogramCoolPMT[i];
                    myRow["Count period"] = histogramCountPMT[i];
                    myRow["All"] = histogramAllPMT[i];
                    histogramTable.Rows.Add(myRow);
                }

                //********************************
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





        private void updateHistogramButtonCAM_Click(object sender, EventArgs e)
        {
            // Do not attempt to do anything if no spectra have been created
            if (myCAMSpectrum != null)
            {
                if (myCAMSpectrum[cameraSpecNum].Count == 0) MessageBox.Show("No data loaded");
                else
                {
                    // Calculating data for histogram
                    //********************************
                    // Initialise variables every time we re-create the histogram
                    histogramSizeCAM = new int();

                    // Local variables used within this method
                    int[] temphistogramCoolCAM;
                    int[] temphistogramCountCAM;
                    int temphistogramSizeCAM = new int();

                    // For each spectrum
                    for (int i = 0; i < numberOfSpectra; i++)
                    {
                        // Temporarily store histograms for this spectrum
                        temphistogramCoolCAM = myCAMSpectrum[cameraSpecNum][i].getHistogramCool();
                        temphistogramCountCAM = myCAMSpectrum[cameraSpecNum][i].getHistogramCount();

                        // Find size of histograms for this spectrum
                        temphistogramSizeCAM = temphistogramCoolCAM.Length;

                        // For the first spectrum only
                        if (i == 0)
                        {
                            // Store size of lists
                            histogramSizeCAM = temphistogramSizeCAM;

                            // Create arrays of the right size
                            histogramCoolCAM = new int[histogramSizeCAM];
                            histogramCountCAM = new int[histogramSizeCAM];
                            histogramAllCAM = new int[histogramSizeCAM];


                            // Loop through each histogram bin and populate arrays
                            for (int j = 0; j < histogramSizeCAM; j++)
                            {
                                // Populate arrays from temp histograms
                                // NB cannot just use e.g. histogramCoolCAM = tempHistogram, this will cause errors
                                // since arrays are a reference type. Need to manipulate each element individually
                                histogramCoolCAM[j] = temphistogramCoolCAM[j];
                                histogramCountCAM[j] = temphistogramCountCAM[j];

                                // Calculate total data and store in another array (cool + count)
                                histogramAllCAM[j] = histogramCoolCAM[j] + histogramCountCAM[j];
                            }
                        }
                        else
                        {   // For subsequent spectra, go through and add the data to existing lists


                            // If the histogram for the current spectrum is larger than the existing histogram
                            if (temphistogramSizeCAM > histogramSizeCAM)
                            {
                                Array.Resize(ref histogramCoolCAM, temphistogramSizeCAM);
                                Array.Resize(ref histogramCountCAM, temphistogramSizeCAM);
                                Array.Resize(ref histogramAllCAM, temphistogramSizeCAM);

                                // Fill in the data into the new bins
                                for (int j = histogramSizeCAM; j < temphistogramSizeCAM; j++)
                                {
                                    histogramCoolCAM[j] = temphistogramCoolCAM[j];
                                    histogramCountCAM[j] = temphistogramCountCAM[j];
                                    histogramAllCAM[j] = histogramCoolCAM[j] + histogramCountCAM[j];
                                }

                                // Update size of list (could use temphistogramSizeCAM, but recalculate just in case)
                                histogramSizeCAM = temphistogramSizeCAM;//histogramCoolCAM.Count();
                            }
                            else
                            {
                                for (int j = 0; j < temphistogramSizeCAM; j++)
                                {
                                    // Sum the data from each spectrum into the full list
                                    histogramCoolCAM[j] += temphistogramCoolCAM[j];
                                    histogramCountCAM[j] += temphistogramCountCAM[j];

                                    histogramAllCAM[j] = histogramCoolCAM[j] + histogramCountCAM[j];
                                }
                            }
                        }
                    }       // End of loop which goes through spectra and creates histogram

                    //********************************
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

                    for (int i = 0; i < histogramSizeCAM; i++)
                    {
                        DataRow myRow = histogramTable.NewRow();
                        myRow["Bin"] = i;
                        myRow["Cool period"] = histogramCoolCAM[i];
                        myRow["Count period"] = histogramCountCAM[i];
                        myRow["All"] = histogramAllCAM[i];
                        histogramTable.Rows.Add(myRow);
                    }

                    //********************************
                    // Plotting histogram data on graph
                    // Need to convert to an enumerable type to get it to dataBind properly
                    // Clear the chart first so that when we re-create the histogram it doesn't cause an error
                    this.histogramChartCAM.DataBindings.Clear();
                    this.histogramChartCAM.Series.Clear();

                    var enumerableTable = (histogramTable as System.ComponentModel.IListSource).GetList();
                    this.histogramChartCAM.DataBindTable(enumerableTable, "Bin");

                    // This line throws an error when chart already exists & update button is pressed

                    // Turn off ticks on x axis
                    histogramChartCAM.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

                    // Enable radio buttons to select display
                    histogramDisplayAllCAM.Enabled = true;
                    histogramDisplayCoolCAM.Enabled = true;
                    histogramDisplayCountCAM.Enabled = true;

                    // Set interval to 1 so that the number will be displayed for each bin
                    histogramChartCAM.ChartAreas[0].AxisX.Interval = 1;

                    // Check which radio button is checked & plot correct series
                    this.histogramDisplayCoolCAM_CheckedChanged(sender, e);


                }   // End of if statement checking that data has been loaded
            }

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
                this.histogramAutoScale(histogramAllPMT);              // Auto scale graph
            }
            else this.histogramChart.Series["All"].Enabled = false; // Disable series


            // For "Cooling period only" radio button
            if (histogramDisplayCool.Checked)
            {
                this.histogramChart.Series["Cool period"].Enabled = true;   // Enable series
                this.histogramAutoScale(histogramCoolPMT);                     // Auto scale graph
            }
            else this.histogramChart.Series["Cool period"].Enabled = false; // Disable series


            // For "Count period only" radio button
            if (histogramDisplayCount.Checked)
            {
                this.histogramChart.Series["Count period"].Enabled = true;      // Enable series
                this.histogramAutoScale(histogramCountPMT);                        // Auto scale graph
            }
            else this.histogramChart.Series["Count period"].Enabled = false;    // Disable series
        }
        private void histogramDisplayCoolCAM_CheckedChanged(object sender, EventArgs e)
        {
            // For each radio button (All, Cool, Count)
            // If the button is checked, display the corresponding series
            // If the button is unchecked, hide the corresponding series
            if (myCAMSpectrum != null)
            {
                // For "All" radio button
                if (histogramDisplayAllCAM.Checked)
                {
                    this.histogramChartCAM.Series["All"].Enabled = true;   // Enable series
                    this.histogramAutoScaleCAM(histogramAllCAM);              // Auto scale graph
                }
                else this.histogramChartCAM.Series["All"].Enabled = false; // Disable series


                // For "Cooling period only" radio button
                if (histogramDisplayCoolCAM.Checked)
                {
                    this.histogramChartCAM.Series["Cool period"].Enabled = true;   // Enable series

                    this.histogramAutoScaleCAM(histogramCoolCAM);                     // Auto scale graph
                }
                else this.histogramChartCAM.Series["Cool period"].Enabled = false; // Disable series


                // For "Count period only" radio button
                if (histogramDisplayCountCAM.Checked)
                {
                    this.histogramChartCAM.Series["Count period"].Enabled = true;      // Enable series
                    this.histogramAutoScaleCAM(histogramCountCAM);                        // Auto scale graph
                }
                else this.histogramChartCAM.Series["Count period"].Enabled = false;    // Disable series
            }
        }








        // Method to scale the axes based on the data being plotted (All, Cool or Counts)
        private void histogramAutoScale(int[] data)
        {
            // Specify an interval to round to based on size of data

            int maxData = data.DefaultIfEmpty().Max();
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
            int x = data.DefaultIfEmpty().Max() / interval;

            // Set the max to one interval greater
            histogramChart.ChartAreas[0].AxisY.Maximum = interval * (x + 1);

        }

        private void histogramAutoScaleCAM(int[] data)
        {
            // Specify an interval to round to based on size of data

            int maxData = data.DefaultIfEmpty().Max();
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
            int x = data.DefaultIfEmpty().Max() / interval;

            // Set the max to one interval greater
            histogramChartCAM.ChartAreas[0].AxisY.Maximum = interval * (x + 1);

        }




        // Method to respond to "Auto" checkbox (under Histogram tab, Maximum bin group) changing
        private void histogramCheckBoxAuto_CheckedChanged(object sender, EventArgs e)
        {
            // If selecting auto, then disable user maxBinSelect
            if (histogramCheckBoxAuto.Checked)
            {
                histogramMaxBinSelect.Enabled = false;
                this.histogramChart.ChartAreas[0].AxisX.Maximum = histogramSizePMT;
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


        private void histogramCheckBoxAutoCAM_CheckedChanged_1(object sender, EventArgs e)
        {
            // If selecting auto, then disable user maxBinSelect
            if (histogramCheckBoxAutoCAM.Checked)
            {
                histogramMaxBinSelectCAM.Enabled = false;
                this.histogramChartCAM.ChartAreas[0].AxisX.Maximum = histogramSizeCAM;
            }
            else
            // If not on auto, scale according to user max bin select
            {
                // Enable user select for max bin
                histogramMaxBinSelectCAM.Enabled = true;
                // NB no code in place to create a ">= N" bin, all this does is change the display
                this.histogramChartCAM.ChartAreas[0].AxisX.Maximum = (double)histogramMaxBinSelectCAM.Value;
            }
        }






        // Method to respond to user changing value in the histogram max bin select
        private void histogramMaxBinSelect_ValueChanged(object sender, EventArgs e)
        {
            // NB nothing clever, we don't change the data, just the display

            // Set maximum bin to user input
            this.histogramChart.ChartAreas[0].AxisX.Maximum = (double)histogramMaxBinSelect.Value;
        }
        private void histogramMaxBinSelect_ValueChangedCAM(object sender, EventArgs e)
        {
            // NB nothing clever, we don't change the data, just the display

            // Set maximum bin to user input
            this.histogramChartCAM.ChartAreas[0].AxisX.Maximum = (double)histogramMaxBinSelectCAM.Value;
        }





        // Method to respond to user clicking "Export histogram..." button
        // Opens a dialogue to save histogram data independently for each displayed spectrum
        private void histogramExportDataButton_Click(object sender, EventArgs e)
        {
            // Do not attempt to do anything if no spectra have been created
            if (myPMTSpectrum.Count == 0) MessageBox.Show("No data loaded");
            else
            {
                // Configuring dialog to save file
                saveFileDialog.InitialDirectory = "C:\\Users\\IonTrap\\Dropbox\\Current Data";      // Initialise to share drive
                saveFileDialog.RestoreDirectory = true;           // Open to last viewed directory
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                // Show new dialogue for each spectrum
                for (int i = 0; i < numberOfSpectra; i++)
                {
                    saveFileDialog.Title = "Save histogram data for spectrum" + (i + 1);
                    saveFileDialog.FileName = myPMTSpectrum[i].getName() + " histogram data.txt";

                    // Show dialog to save file
                    // Check that user has not pressed cancel before continuing to save file
                    if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        // Create streamwriter object to write to file
                        // With filename given from user input
                        TextWriter histogramFile = new StreamWriter(saveFileDialog.FileName);

                        // Call method in the spectrum class to write data to the file
                        myPMTSpectrum[i].writeHistogramData(ref histogramFile);
                    }
                }
            }

        }
        private void histogramExportDataButtonCAM_Click(object sender, EventArgs e)
        {
            // Do not attempt to do anything if no spectra have been created
            if (myCAMSpectrum != null) {
                if (myCAMSpectrum[cameraSpecNum].Count == 0) MessageBox.Show("No data loaded");
                else
                {
                    // Configuring dialog to save file
                    saveFileDialog.InitialDirectory = "C:\\Users\\IonTrap\\Dropbox\\Current Data";      // Initialise to share drive
                    saveFileDialog.RestoreDirectory = true;           // Open to last viewed directory
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                    // Show new dialogue for each spectrum
                    for (int i = 0; i < numberOfSpectra; i++)
                    {
                        saveFileDialog.Title = "Save histogram data for spectrum" + (i + 1);
                        saveFileDialog.FileName = myCAMSpectrum[cameraSpecNum][i].getName() + " histogram data.txt";

                        // Show dialog to save file
                        // Check that user has not pressed cancel before continuing to save file
                        if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
                        {
                            // Create streamwriter object to write to file
                            // With filename given from user input
                            TextWriter histogramFile = new StreamWriter(saveFileDialog.FileName);

                            // Call method in the spectrum class to write data to the file
                            myCAMSpectrum[cameraSpecNum][i].writeHistogramData(ref histogramFile);
                        }
                    }
                }
            }

        }






        #endregion                                                           

        #region Code relating to formatting & plotting graph

        // Build the Chart - before any data has been added
        private void createGraph(ZedGraphControl zgcSpectrum)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgcSpectrum.GraphPane;

            // Clear the Titles
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "";

            // Hide legend
            myPane.Legend.IsVisible = false;

            // Show Y2 (bad counts) axis
            myPane.Y2Axis.IsVisible = true;

            // Disable vertical zoom/pan on spectrum graph
            zgcSpectrum.IsEnableVZoom = false;
            zgcSpectrum.IsEnableVPan = false;
        }

        // Method to create the controls for each spectrum on the graph. For each spectrum, a groupbox is generated
        // containing a checkbox & radio buttons to control what is shown on the graph.
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
                    this.graphControlContextMenu[i] = new ContextMenu();
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
                    this.graphControlGroup[i].ContextMenu = graphControlContextMenu[i];
                    //
                    // Configure group box
                    this.graphControlGroup[i].BackColor = myColoursBadCounts[i];
                    this.graphControlGroup[i].ForeColor = myColoursData[i];
                    this.graphControlGroup[i].Location = new System.Drawing.Point(ClientRectangle.Width - 210, (6 + 115 * i));
                    this.graphControlGroup[i].Size = new System.Drawing.Size(176, 109);
                    this.graphControlGroup[i].TabIndex = 10 + i;
                    this.graphControlGroup[i].TabStop = false;
                    this.graphControlGroup[i].Text = myPMTSpectrum[i].getName();
                    //
                    // Configure check box
                    this.graphControlCheckBox[i].AutoSize = false;
                    this.graphControlCheckBox[i].Checked = true;
                    this.graphControlCheckBox[i].ForeColor = Color.Black;
                    this.graphControlCheckBox[i].Location = new System.Drawing.Point(6, 17);
                    this.graphControlCheckBox[i].Size = new System.Drawing.Size(150, 20);
                    this.graphControlCheckBox[i].TabIndex = 0;
                    this.graphControlCheckBox[i].Text = "Show spectrum " + (i + 1);
                    this.graphControlCheckBox[i].CheckedChanged +=
                        new System.EventHandler(this.updateGraph_Event);
                    //
                    // Configure label to display text "Show bad counts:"
                    this.graphControlLabel[i].AutoSize = true;
                    this.graphControlLabel[i].ForeColor = Color.Black;
                    this.graphControlLabel[i].Location = new System.Drawing.Point(6, 45);
                    this.graphControlLabel[i].Size = new System.Drawing.Size(61, 13);
                    this.graphControlLabel[i].TabIndex = 1;
                    this.graphControlLabel[i].Text = "Show bad counts:";
                    //
                    // Configure radio button to display no bad counts
                    this.graphControlBadCountsNone[i].AutoSize = true;
                    this.graphControlBadCountsNone[i].ForeColor = Color.Black;
                    this.graphControlBadCountsNone[i].Checked = true;
                    this.graphControlBadCountsNone[i].Location = new System.Drawing.Point(6, 62);
                    this.graphControlBadCountsNone[i].Size = new System.Drawing.Size(85, 17);
                    this.graphControlBadCountsNone[i].TabIndex = 2;
                    this.graphControlBadCountsNone[i].Text = "None";
                    this.graphControlBadCountsNone[i].UseVisualStyleBackColor = true;
                    this.graphControlBadCountsNone[i].CheckedChanged +=
                        new System.EventHandler(this.updateGraph_Event);
                    //
                    // Configure radio button to display all bad counts
                    this.graphControlBadCountsAll[i].AutoSize = true;
                    this.graphControlBadCountsAll[i].ForeColor = Color.Black;
                    this.graphControlBadCountsAll[i].Location = new System.Drawing.Point(6, 85);
                    this.graphControlBadCountsAll[i].Size = new System.Drawing.Size(85, 17);
                    this.graphControlBadCountsAll[i].TabIndex = 3;
                    this.graphControlBadCountsAll[i].Text = "All";
                    this.graphControlBadCountsAll[i].UseVisualStyleBackColor = true;
                    this.graphControlBadCountsAll[i].CheckedChanged +=
                        new System.EventHandler(this.updateGraph_Event);
                    //
                    // Configure radio button to display bad counts due to error flags only
                    this.graphControlBadCountsLaser[i].AutoSize = true;
                    this.graphControlBadCountsLaser[i].ForeColor = Color.Black;
                    this.graphControlBadCountsLaser[i].Location = new System.Drawing.Point(76, 62);
                    this.graphControlBadCountsLaser[i].Size = new System.Drawing.Size(85, 17);
                    this.graphControlBadCountsLaser[i].TabIndex = 4;
                    this.graphControlBadCountsLaser[i].Text = "Laser error";
                    this.graphControlBadCountsLaser[i].UseVisualStyleBackColor = true;
                    this.graphControlBadCountsLaser[i].CheckedChanged +=
                        new System.EventHandler(this.updateGraph_Event);
                    //
                    // Configure radio button to display bad counts due to threshold only
                    this.graphControlBadCountsThreshold[i].AutoSize = true;
                    this.graphControlBadCountsThreshold[i].ForeColor = Color.Black;
                    this.graphControlBadCountsThreshold[i].Location = new System.Drawing.Point(76, 85);
                    this.graphControlBadCountsThreshold[i].Size = new System.Drawing.Size(85, 17);
                    this.graphControlBadCountsThreshold[i].TabIndex = 5;
                    this.graphControlBadCountsThreshold[i].Text = "Threshold error";
                    this.graphControlBadCountsThreshold[i].UseVisualStyleBackColor = true;
                    this.graphControlBadCountsThreshold[i].CheckedChanged +=
                        new System.EventHandler(this.updateGraph_Event);
                    //
                    // Configure context menu
                    //
                    // Rename
                    MenuItem contextMenuRename = new MenuItem();
                    contextMenuRename.Name = "Rename";
                    contextMenuRename.Text = "Rename spectrum...";
                    contextMenuRename.Click += new EventHandler(graphControlContextMenu_Rename_Click);
                    // View metadata
                    MenuItem contextMenuViewMetadata = new MenuItem();
                    contextMenuViewMetadata.Text = "View metadata";
                    contextMenuViewMetadata.Click += new EventHandler(graphControlContextMenu_ViewMetadata_Click);
                    // Change colour
                    MenuItem contextMenuChangeColour = new MenuItem();
                    contextMenuChangeColour.Text = "Change colour...";
                    contextMenuChangeColour.Click += new EventHandler(graphControlContextMenu_ChangeColour_Click);
                    // Add frequency offset
                    MenuItem contextMenuAddOffset = new MenuItem();
                    contextMenuAddOffset.Text = "Add frequency offset...";
                    contextMenuAddOffset.Click += new EventHandler(graphControlContextMenu_AddOffset_Click);


                    this.graphControlContextMenu[i].MenuItems.Add(contextMenuRename);
                    this.graphControlContextMenu[i].MenuItems.Add(contextMenuViewMetadata);
                    this.graphControlContextMenu[i].MenuItems.Add(contextMenuChangeColour);
                    this.graphControlContextMenu[i].MenuItems.Add(contextMenuAddOffset);

                }


            }

        }

        private void createGraphControlsCAM()
        {

            // Create a set of controls for each spectrum displayed on the graph
            for (int i = 0; i < numberOfSpectra; i++)
            {
                // Can only fit in controls for up to 5 graphs
                if (i < 5)
                {
                    // Remove the existing controls
                    this.removeGraphControlsCAM(i);
                    // Create new controls
                    this.graphControlBadCountsAllCAM[i] = new RadioButton();
                    this.graphControlBadCountsLaserCAM[i] = new RadioButton();
                    this.graphControlBadCountsNoneCAM[i] = new RadioButton();
                    this.graphControlBadCountsThresholdCAM[i] = new RadioButton();
                    this.graphControlCheckBoxCAM[i] = new CheckBox();
                    this.graphControlGroupCAM[i] = new GroupBox();
                    this.graphControlLabelCAM[i] = new System.Windows.Forms.Label();
                    this.graphControlContextMenuCAM[i] = new ContextMenu();
                    //
                    // Add group box to the spectrum tab page
                    this.spectrumCamTab.Controls.Add(graphControlGroupCAM[i]);
                    // Add controls to the groupbox - checkBox, label and radio buttons
                    this.graphControlGroupCAM[i].Controls.Add(graphControlBadCountsAllCAM[i]);
                    this.graphControlGroupCAM[i].Controls.Add(graphControlBadCountsLaserCAM[i]);
                    this.graphControlGroupCAM[i].Controls.Add(graphControlBadCountsNoneCAM[i]);
                    this.graphControlGroupCAM[i].Controls.Add(graphControlBadCountsThresholdCAM[i]);
                    this.graphControlGroupCAM[i].Controls.Add(graphControlCheckBoxCAM[i]);
                    this.graphControlGroupCAM[i].Controls.Add(graphControlLabelCAM[i]);
                    this.graphControlGroupCAM[i].ContextMenu = graphControlContextMenuCAM[i];
                    //
                    // Configure group box
                    this.graphControlGroupCAM[i].BackColor = myColoursBadCounts[i];
                    this.graphControlGroupCAM[i].ForeColor = myColoursData[i];
                    this.graphControlGroupCAM[i].Location = new System.Drawing.Point(ClientRectangle.Width - 210, (6 + 115 * i));
                    this.graphControlGroupCAM[i].Size = new System.Drawing.Size(176, 109);
                    this.graphControlGroupCAM[i].TabIndex = 10 + i;
                    this.graphControlGroupCAM[i].TabStop = false;
                    this.graphControlGroupCAM[i].Text = myCAMSpectrum[cameraSpecNum][i].getName();
                    //
                    // Configure check box
                    this.graphControlCheckBoxCAM[i].AutoSize = false;
                    this.graphControlCheckBoxCAM[i].Checked = true;
                    this.graphControlCheckBoxCAM[i].ForeColor = Color.Black;
                    this.graphControlCheckBoxCAM[i].Location = new System.Drawing.Point(6, 17);
                    this.graphControlCheckBoxCAM[i].Size = new System.Drawing.Size(150, 20);
                    this.graphControlCheckBoxCAM[i].TabIndex = 0;
                    this.graphControlCheckBoxCAM[i].Text = "Show spectrum " + (i + 1);
                    this.graphControlCheckBoxCAM[i].CheckedChanged +=
                        new System.EventHandler(this.updateGraph_EventCAM);
                    //
                    // Configure label to display text "Show bad counts:"
                    this.graphControlLabelCAM[i].AutoSize = true;
                    this.graphControlLabelCAM[i].ForeColor = Color.Black;
                    this.graphControlLabelCAM[i].Location = new System.Drawing.Point(6, 45);
                    this.graphControlLabelCAM[i].Size = new System.Drawing.Size(61, 13);
                    this.graphControlLabelCAM[i].TabIndex = 1;
                    this.graphControlLabelCAM[i].Text = "Show bad counts:";
                    //
                    // Configure radio button to display no bad counts
                    this.graphControlBadCountsNoneCAM[i].AutoSize = true;
                    this.graphControlBadCountsNoneCAM[i].ForeColor = Color.Black;
                    this.graphControlBadCountsNoneCAM[i].Checked = true;
                    this.graphControlBadCountsNoneCAM[i].Location = new System.Drawing.Point(6, 62);
                    this.graphControlBadCountsNoneCAM[i].Size = new System.Drawing.Size(85, 17);
                    this.graphControlBadCountsNoneCAM[i].TabIndex = 2;
                    this.graphControlBadCountsNoneCAM[i].Text = "None";
                    this.graphControlBadCountsNoneCAM[i].UseVisualStyleBackColor = true;
                    this.graphControlBadCountsNoneCAM[i].CheckedChanged +=
                        new System.EventHandler(this.updateGraph_EventCAM);
                    //
                    // Configure radio button to display all bad counts
                    this.graphControlBadCountsAllCAM[i].AutoSize = true;
                    this.graphControlBadCountsAllCAM[i].ForeColor = Color.Black;
                    this.graphControlBadCountsAllCAM[i].Location = new System.Drawing.Point(6, 85);
                    this.graphControlBadCountsAllCAM[i].Size = new System.Drawing.Size(85, 17);
                    this.graphControlBadCountsAllCAM[i].TabIndex = 3;
                    this.graphControlBadCountsAllCAM[i].Text = "All";
                    this.graphControlBadCountsAllCAM[i].UseVisualStyleBackColor = true;
                    this.graphControlBadCountsAllCAM[i].CheckedChanged +=
                        new System.EventHandler(this.updateGraph_EventCAM);
                    //
                    // Configure radio button to display bad counts due to error flags only
                    this.graphControlBadCountsLaserCAM[i].AutoSize = true;
                    this.graphControlBadCountsLaserCAM[i].ForeColor = Color.Black;
                    this.graphControlBadCountsLaserCAM[i].Location = new System.Drawing.Point(76, 62);
                    this.graphControlBadCountsLaserCAM[i].Size = new System.Drawing.Size(85, 17);
                    this.graphControlBadCountsLaserCAM[i].TabIndex = 4;
                    this.graphControlBadCountsLaserCAM[i].Text = "Laser error";
                    this.graphControlBadCountsLaserCAM[i].UseVisualStyleBackColor = true;
                    this.graphControlBadCountsLaserCAM[i].CheckedChanged +=
                        new System.EventHandler(this.updateGraph_EventCAM);
                    //
                    // Configure radio button to display bad counts due to threshold only
                    this.graphControlBadCountsThresholdCAM[i].AutoSize = true;
                    this.graphControlBadCountsThresholdCAM[i].ForeColor = Color.Black;
                    this.graphControlBadCountsThresholdCAM[i].Location = new System.Drawing.Point(76, 85);
                    this.graphControlBadCountsThresholdCAM[i].Size = new System.Drawing.Size(85, 17);
                    this.graphControlBadCountsThresholdCAM[i].TabIndex = 5;
                    this.graphControlBadCountsThresholdCAM[i].Text = "Threshold error";
                    this.graphControlBadCountsThresholdCAM[i].UseVisualStyleBackColor = true;
                    this.graphControlBadCountsThresholdCAM[i].CheckedChanged +=
                        new System.EventHandler(this.updateGraph_EventCAM);
                    //
                    // Configure context menu
                    //
                    // Rename
                    MenuItem contextMenuRename = new MenuItem();
                    contextMenuRename.Name = "Rename";
                    contextMenuRename.Text = "Rename spectrum...";
                    contextMenuRename.Click += new EventHandler(graphControlContextMenuCAM_Rename_Click);
                    // View metadata
                    MenuItem contextMenuViewMetadata = new MenuItem();
                    contextMenuViewMetadata.Text = "View metadata";
                    contextMenuViewMetadata.Click += new EventHandler(graphControlContextMenuCAM_ViewMetadata_Click);
                    // Change colour
                    MenuItem contextMenuChangeColour = new MenuItem();
                    contextMenuChangeColour.Text = "Change colour...";
                    contextMenuChangeColour.Click += new EventHandler(graphControlContextMenuCAM_ChangeColour_Click);
                    // Add frequency offset
                    MenuItem contextMenuAddOffset = new MenuItem();
                    contextMenuAddOffset.Text = "Add frequency offset...";
                    contextMenuAddOffset.Click += new EventHandler(graphControlContextMenuCAM_AddOffset_Click);


                    this.graphControlContextMenuCAM[i].MenuItems.Add(contextMenuRename);
                    this.graphControlContextMenuCAM[i].MenuItems.Add(contextMenuViewMetadata);
                    this.graphControlContextMenuCAM[i].MenuItems.Add(contextMenuChangeColour);
                    this.graphControlContextMenuCAM[i].MenuItems.Add(contextMenuAddOffset);

                }


            }

        }

        private void createGraphControlsDER()
        {

            // Create a set of controls for each spectrum displayed on the graph
            for (int i = 0; i < numberOfSpectra; i++)
            {
                // Can only fit in controls for up to 5 graphs
                if (i < 5)
                {
                    // Remove the existing controls
                    this.removeGraphControlsDER(i);
                    this.graphControlCheckBoxDER[i] = new CheckBox();
                    // Create new controls
                    this.graphControlAverage[i] = new CheckBox();
                    this.graphControlEE[i] = new CheckBox();
                    this.graphControlEGGE[i] = new CheckBox();
                    this.graphControlGG[i] = new CheckBox();
                    //this.graphControlParity[i] = new CheckBox();
                    this.graphControlGroupDER[i] = new GroupBox();
                    this.graphControlLabelDER[i] = new System.Windows.Forms.Label();

                    // Add group box to the spectrum tab page
                    this.derivedCamTab.Controls.Add(graphControlGroupDER[i]);
                    // Add controls to the groupbox - checkBox, label and radio buttons
                    this.graphControlGroupDER[i].Controls.Add(graphControlCheckBoxDER[i]);
                    this.graphControlGroupDER[i].Controls.Add(graphControlAverage[i]);
                    this.graphControlGroupDER[i].Controls.Add(graphControlEE[i]);
                    this.graphControlGroupDER[i].Controls.Add(graphControlEGGE[i]);
                    this.graphControlGroupDER[i].Controls.Add(graphControlGG[i]);
                    //this.graphControlGroupDER[i].Controls.Add(graphControlParity[i]);
                    
                    this.graphControlGroupDER[i].Controls.Add(graphControlLabelDER[i]);
                    //
                    // Configure group box
                    this.graphControlGroupDER[i].BackColor = myColoursBadCounts[i];
                    this.graphControlGroupDER[i].ForeColor = myColoursData[i];
                    this.graphControlGroupDER[i].Location = new System.Drawing.Point(ClientRectangle.Width - 210, (6 + 115 * i));
                    this.graphControlGroupDER[i].Size = new System.Drawing.Size(176, 109);
                    this.graphControlGroupDER[i].TabIndex = 10 + i;
                    this.graphControlGroupDER[i].TabStop = false;
                    this.graphControlGroupDER[i].Text = "blob";// myCAMSpectrum[cameraSpecNum][i].getName();
                    
                    //
                    
                    //
                    // Configure label to display text "Show bad counts:"
                    this.graphControlLabelDER[i].AutoSize = true;
                    this.graphControlLabelDER[i].ForeColor = Color.Black;
                    this.graphControlLabelDER[i].Location = new System.Drawing.Point(6, 45);
                    this.graphControlLabelDER[i].Size = new System.Drawing.Size(61, 13);
                    this.graphControlLabelDER[i].TabIndex = 1;
                    this.graphControlLabelDER[i].Text = "Show graphs:";

                    // Configure check box
                    this.graphControlCheckBoxDER[i].AutoSize = true;
                    this.graphControlCheckBoxDER[i].Checked = true;
                    this.graphControlCheckBoxDER[i].ForeColor = Color.Black;
                    this.graphControlCheckBoxDER[i].Location = new System.Drawing.Point(6, 17);
                    this.graphControlCheckBoxDER[i].Size = new System.Drawing.Size(150, 20);
                    this.graphControlCheckBoxDER[i].TabIndex = 0;
                    this.graphControlCheckBoxDER[i].Text = "Show spectrum " + (i + 1);
                    this.graphControlCheckBoxDER[i].CheckedChanged +=
                        new System.EventHandler(this.updateGraph_EventDER);


                    //
                    // Configure radio button to display no bad counts
                    this.graphControlAverage[i].AutoSize = true;
                    this.graphControlAverage[i].ForeColor = Color.Black;
                    this.graphControlAverage[i].Checked = true;
                    this.graphControlAverage[i].Location = new System.Drawing.Point(6, 62);
                    this.graphControlAverage[i].Size = new System.Drawing.Size(85, 17);
                    this.graphControlAverage[i].TabIndex = 2;
                    this.graphControlAverage[i].Text = "AVG";
                    this.graphControlAverage[i].UseVisualStyleBackColor = true;
                    this.graphControlAverage[i].CheckedChanged +=
                        new System.EventHandler(this.updateGraph_EventDER);
                    //
                    // Configure radio button to display all bad counts
                    this.graphControlEE[i].AutoSize = true;
                    this.graphControlEE[i].ForeColor = Color.Black;
                    this.graphControlEE[i].Location = new System.Drawing.Point(6, 85);
                    this.graphControlEE[i].Size = new System.Drawing.Size(85, 17);
                    this.graphControlEE[i].TabIndex = 3;
                    this.graphControlEE[i].Checked = true;
                    this.graphControlEE[i].Text = "EE";
                    this.graphControlEE[i].UseVisualStyleBackColor = true;
                    this.graphControlEE[i].CheckedChanged +=
                        new System.EventHandler(this.updateGraph_EventDER);
                    //
                    // Configure radio button to display bad counts due to error flags only
                    this.graphControlEGGE[i].AutoSize = true;
                    this.graphControlEGGE[i].ForeColor = Color.Black;
                    this.graphControlEGGE[i].Location = new System.Drawing.Point(76, 62);
                    this.graphControlEGGE[i].Size = new System.Drawing.Size(85, 17);
                    this.graphControlEGGE[i].TabIndex = 4;
                    this.graphControlEGGE[i].Text = "EG + GE";
                    this.graphControlEGGE[i].UseVisualStyleBackColor = true;
                    this.graphControlEGGE[i].CheckedChanged +=
                        new System.EventHandler(this.updateGraph_EventDER);
                    //
                    // Configure radio button to display bad counts due to threshold only
                    this.graphControlGG[i].AutoSize = true;
                    this.graphControlGG[i].ForeColor = Color.Black;
                    this.graphControlGG[i].Location = new System.Drawing.Point(76, 85);
                    this.graphControlGG[i].Size = new System.Drawing.Size(85, 17);
                    this.graphControlGG[i].TabIndex = 5;
                    this.graphControlGG[i].Text = "GG";
                    this.graphControlGG[i].UseVisualStyleBackColor = true;
                    this.graphControlGG[i].CheckedChanged +=
                        new System.EventHandler(this.updateGraph_EventDER);

                }
            }




        }



        // Method to remove graph controls from the form
        // Required so that we don't get an error when recreating controls
        private void removeGraphControls(int i)
        {
            if (this.tabPageSpectra.Controls.Contains(graphControlGroup[i]))
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

        private void removeGraphControlsCAM(int i)
        {
            if (this.spectrumCamTab.Controls.Contains(graphControlGroupCAM[i]))
            {
                // Remove objects from list of controls
                graphControlGroupCAM[i].Controls.Clear();
                spectrumCamTab.Controls.Remove(graphControlGroupCAM[i]);
                // Dispose of objects
                graphControlLabelCAM[i].Dispose();
                graphControlCheckBoxCAM[i].Dispose();
                graphControlBadCountsAllCAM[i].Dispose();
                graphControlBadCountsNoneCAM[i].Dispose();
                graphControlBadCountsLaserCAM[i].Dispose();
                graphControlBadCountsThresholdCAM[i].Dispose();
                graphControlGroupCAM[i].Dispose();
            }
        }
        private void removeGraphControlsDER(int i)
        {
            if (this.spectrumCamTab.Controls.Contains(graphControlGroupDER[i]))
            {
                // Remove objects from list of controls
                graphControlGroupDER[i].Controls.Clear();
                derivedCamTab.Controls.Remove(graphControlGroupDER[i]);
                // Dispose of objects
                graphControlLabelDER[i].Dispose();
                graphControlCheckBoxDER[i].Dispose();
                graphControlAverage[i].Dispose();
                graphControlEE[i].Dispose();
                graphControlEGGE[i].Dispose();
                graphControlGG[i].Dispose();
                graphControlParity[i].Dispose();
                graphControlGroupDER[i].Dispose();
            }
        }





        // Method to handle renaming spectrum (from context menu click)
        private void graphControlContextMenu_Rename_Click(object sender, EventArgs e)
        {
            // Find which spectrum was clicked ("Rename" is the menu item at index 0)
            int spectrumToRename = whichSpectrumClicked(sender, 0);
            // Go through each spectrum
            for (int i = 0; i < numberOfSpectra; i++)
            {
                // Check whether it was the context menu from this spectrum that fired the event
                // NB "Rename" is the menu item at index 0
                if (sender.Equals(this.graphControlContextMenu[i].MenuItems[0]))
                {
                    spectrumToRename = i;
                }
            }
            // Call method to rename the spectrum
            renameSpectrum(spectrumToRename);
        }
        private void graphControlContextMenuCAM_Rename_Click(object sender, EventArgs e)
        {
            // Find which spectrum was clicked ("Rename" is the menu item at index 0)
            int spectrumToRename = whichSpectrumClicked(sender, 0);
            // Go through each spectrum
            for (int i = 0; i < numberOfSpectra; i++)
            {
                // Check whether it was the context menu from this spectrum that fired the event
                // NB "Rename" is the menu item at index 0
                if (sender.Equals(this.graphControlContextMenuCAM[i].MenuItems[0]))
                {
                    spectrumToRename = i;
                }
            }
            // Call method to rename the spectrum
            renameSpectrumCAM(spectrumToRename);
        }


        // Method to rename spectrum
        private void renameSpectrum(int spectrumNumber)
        {
            renameSpectrumDialog myRenameDialog = new renameSpectrumDialog();
            myRenameDialog.ShowDialog();

            // Only perform rename if user clicked OK (not cancel)
            if (myRenameDialog.DialogResult == DialogResult.OK)
            {
                // Get name from dialog box
                string newName = myRenameDialog.newNameBox.Text;
                // Rename appropriate spectrum
                myPMTSpectrum[spectrumNumber].setName(newName);

                // Re-label graph control group box
                this.graphControlGroup[spectrumNumber].Text = newName;
            }

        }
        private void renameSpectrumCAM(int spectrumNumber)
        {
            renameSpectrumDialog myRenameDialog = new renameSpectrumDialog();
            myRenameDialog.ShowDialog();

            // Only perform rename if user clicked OK (not cancel)
            if (myRenameDialog.DialogResult == DialogResult.OK)
            {
                // Get name from dialog box
                string newName = myRenameDialog.newNameBox.Text;
                // Rename appropriate spectrum
                myCAMSpectrum[cameraSpecNum][spectrumNumber].setName(newName);

                // Re-label graph control group box
                this.graphControlGroupCAM[spectrumNumber].Text = newName;
            }

        }

        // Method to handle viewing metadata (from context menu click)
        private void graphControlContextMenu_ViewMetadata_Click(object sender, EventArgs e)
        {
            // Find which spectrum was clicked ("View metadata" is the menu item at index 1)
            int spectrumToView = whichSpectrumClicked(sender, 1);
            // Show metadataViewer for that spectrum
            metadataViewer myMetadataViewer = new metadataViewer(ref myPMTSpectrum, spectrumToView, numberOfSpectra);
            myMetadataViewer.Show();

        }
        private void graphControlContextMenuCAM_ViewMetadata_Click(object sender, EventArgs e)
        {
            // Find which spectrum was clicked ("View metadata" is the menu item at index 1)
            int spectrumToView = whichSpectrumClicked(sender, 1);
            // Show metadataViewer for that spectrum
            metadataViewer myMetadataViewer = new metadataViewer(ref myCAMSpectrum[cameraSpecNum], spectrumToView, numberOfSpectra);
            myMetadataViewer.Show();

        }

        // Method to handle changing spectrum colour (from context menu click)
        private void graphControlContextMenu_ChangeColour_Click(object sender, EventArgs e)
        {
            // Find which spectrum was clicked ("Change colour" is the menu item at index 2)
            int spectrumToChange = whichSpectrumClicked(sender, 2);

            // Create & open dialog box to select colour
            changeColour myChangeColour = new changeColour();
            myChangeColour.ShowDialog();

            // Make sure user has clicked OK
            if (myChangeColour.DialogResult != DialogResult.OK) return;

            // Store index of which colours to change to
            int newColour = myChangeColour.colourSelectBox.SelectedIndex;
            // Update colours in list
            myColoursData[spectrumToChange] = colourListData[newColour];
            myColoursBadCounts[spectrumToChange] = colourListBadCounts[newColour];

            // Change background colour/title colour of groupBox control
            this.graphControlGroup[spectrumToChange].BackColor = myColoursBadCounts[spectrumToChange];
            this.graphControlGroup[spectrumToChange].ForeColor = myColoursData[spectrumToChange];
            // Refresh graph to reflect new colours
            updateGraph();
        }

        private void graphControlContextMenuCAM_ChangeColour_Click(object sender, EventArgs e)
        {
            // Find which spectrum was clicked ("Change colour" is the menu item at index 2)
            int spectrumToChange = whichSpectrumClicked(sender, 2);

            // Create & open dialog box to select colour
            changeColour myChangeColour = new changeColour();
            myChangeColour.ShowDialog();

            // Make sure user has clicked OK
            if (myChangeColour.DialogResult != DialogResult.OK) return;

            // Store index of which colours to change to
            int newColour = myChangeColour.colourSelectBox.SelectedIndex;
            // Update colours in list
            myColoursData[spectrumToChange] = colourListData[newColour];
            myColoursBadCounts[spectrumToChange] = colourListBadCounts[newColour];

            // Change background colour/title colour of groupBox control
            this.graphControlGroupCAM[spectrumToChange].BackColor = myColoursBadCounts[spectrumToChange];
            this.graphControlGroupCAM[spectrumToChange].ForeColor = myColoursData[spectrumToChange];
            // Refresh graph to reflect new colours
            updateGraphCAM();
        }


        // Method to handle adding a frequency offset (from context menu click)
        private void graphControlContextMenu_AddOffset_Click(object sender, EventArgs e)
        {
            // Find which spectrum was clicked ("Add frequency offset" is the menu item at index 3)
            int spectrumToChange = whichSpectrumClicked(sender, 3);
            int offset = getOffset();
            if (offset != 0)
            {
                myPMTSpectrum[spectrumToChange].addOffset(offset);

                dataPMTPlot[spectrumToChange] = myPMTSpectrum[spectrumToChange].getDataPlot();
                this.updateGraph();
            }
        }

        private void graphControlContextMenuCAM_AddOffset_Click(object sender, EventArgs e)
        {
            // Find which spectrum was clicked ("Add frequency offset" is the menu item at index 3)
            int spectrumToChange = whichSpectrumClickedCAM(sender, 3);
            int offset = getOffset();
            if (offset != 0)
            {
                myCAMSpectrum[cameraSpecNum][spectrumToChange].addOffset(offset);

                dataCAMPlot[cameraSpecNum][spectrumToChange] = myCAMSpectrum[cameraSpecNum][spectrumToChange].getDataPlot();
                this.updateGraphCAM();
            }





        }

        // Method to get an offset from user input
        private int getOffset()
        {
            addOffset myOffsetDialog = new addOffset();
            myOffsetDialog.ShowDialog();

            if (myOffsetDialog.DialogResult != DialogResult.OK) return 0;

            float offsetMHz = new float();
            if (float.TryParse(myOffsetDialog.offsetBox.Text, out offsetMHz))
            {
                int offset = (int)(offsetMHz * 1000000);
                return offset;
            }
            else
            {
                MessageBox.Show("Error: Offset entered was not a valid number");
                return 0;
            }
        }

        // Method to find which spectrum's context menu was clicked (given a sender and the index for a context menu item)
        private int whichSpectrumClicked(object sender, int contextMenuIndex)
        {
            int x = new int();

            for (int i = 0; i < numberOfSpectra; i++)
            {
                // Check whether it was the context menu from this spectrum that fired the event
                // NB "Change colour" is the menu item at index 2
                if (sender.Equals(this.graphControlContextMenu[i].MenuItems[contextMenuIndex]))
                {
                    x = i;
                }
            }

            return x;
        }

        private int whichSpectrumClickedCAM(object sender, int contextMenuIndex)
        {
            int x = new int();

            for (int i = 0; i < numberOfSpectra; i++)
            {
                // Check whether it was the context menu from this spectrum that fired the event
                // NB "Change colour" is the menu item at index 2
                if (sender.Equals(this.graphControlContextMenuCAM[i].MenuItems[contextMenuIndex]))
                {
                    x = i;
                }
            }

            return x;
        }


        // Method to update graph from an event
        private void updateGraph_Event(object sender, EventArgs e)
        {
            updateGraph();
        }

        private void updateGraph_EventCAM(object sender, EventArgs e)
        {
            updateGraphCAM();
        }
        private void updateGraph_EventDER(object sender, EventArgs e)
        {

            Console.WriteLine(this.graphControlCheckBoxDER[0].Checked.ToString());
            updateGraphDER();
        }

        // Method to respond to user changing radio buttons in graph controls
        private void updateGraph()
        {
            // Only try to update graph if some spectra have been loaded
            if (numberOfSpectra != 0)
            {

                // get a reference to the GraphPane
                GraphPane myPane = this.zedGraphSpectra.GraphPane;
                // Clear data
                zedGraphSpectra.GraphPane.CurveList.Clear();
                LineItem myCurve;

                // Array of bad counts data for each spectrum
                // This array will be filled with the appropriate data (laser errors, threshold errors or all)
                // depending on the radio buttons
                PointPairList[] badCountsData = new PointPairList[numberOfSpectra];


                for (int i = 0; i < numberOfSpectra; i++)
                {
                    // If the "show spectrum" checkBox is checked
                    if (graphControlCheckBox[i].Checked)
                    {
                        // Sort the data by x co-ordinate (frequency)
                        // this ensures that the curve looks sensible
                        dataPMTPlot[i].Sort();

                        myCurve = myPane.AddCurve(myPMTSpectrum[i].getName(),
                            dataPMTPlot[i], myColoursData[i % 5], SymbolType.None);
                    }
                    // NB if it is not checked, do nothing


                    // These if statements find which of the radio buttons are checked, and add
                    // the appropriate data to badCountsData array
                    if (graphControlBadCountsAll[i].Checked)            // All bad counts
                    {
                        // Add all bad counts to the list of data
                        badCountsData[i] = myPMTSpectrum[i].getBadCountsAll();
                    }
                    //
                    else if (graphControlBadCountsLaser[i].Checked)     // Just laser errors
                    {
                        // Add bad counts from laser errors to the list of data
                        badCountsData[i] = myPMTSpectrum[i].getBadCountsErrors();
                    }
                    //
                    else if (graphControlBadCountsThreshold[i].Checked) // Just threshold errors
                    {
                        // Add bad counts from threshold to the list of data
                        badCountsData[i] = myPMTSpectrum[i].getBadCountsThreshold();
                    }
                    // If "None" is checked, don't need to put anything in the array. There will just be a blank space at index i

                    // So long as "None" is not checked, plot curve to the graph
                    // badCountsData[i] will contain bad counts from laser errors, threshold errors or both
                    if (!graphControlBadCountsNone[i].Checked)
                    {
                        // Sort the data by x co-ordinate (frequency)
                        // this ensures that the curve looks sensible
                        badCountsData[i].Sort();

                        myCurve = myPane.AddCurve(myPMTSpectrum[i].getName() + " bad counts",
                            badCountsData[i], myColoursBadCounts[i % 5], SymbolType.Circle);
                        myCurve.IsY2Axis = true;
                    }


                }

                // Rescale bad counts axis
                this.badCountsAxisRescale(badCountsData);

                // Tell ZedGraph to refigure the
                // axes since the data have changed
                zedGraphSpectra.AxisChange();
                zedGraphSpectra.Invalidate();
                // Force redraw of control
            }

        }

        private void updateGraphCAM()
        {
            // Only try to update graph if some spectra have been loaded
            if (numberOfSpectra != 0 && useCamera == true)
            {

                // get a reference to the GraphPane
                GraphPane myPane = this.zedGraphSpectraCAM.GraphPane;
                // Clear data
                zedGraphSpectraCAM.GraphPane.CurveList.Clear();
                LineItem myCurve;

                // Array of bad counts data for each spectrum
                // This array will be filled with the appropriate data (laser errors, threshold errors or all)
                // depending on the radio buttons
                PointPairList[] badCountsData = new PointPairList[numberOfSpectra];


                for (int i = 0; i < numberOfSpectra; i++)
                {
                    // If the "show spectrum" checkBox is checked
                    if (graphControlCheckBoxCAM[i].Checked)
                    {
                        // Sort the data by x co-ordinate (frequency)
                        // this ensures that the curve looks sensible
                        dataCAMPlot[cameraSpecNum][i].Sort();

                        myCurve = myPane.AddCurve(myCAMSpectrum[cameraSpecNum][i].getName(),
                            dataCAMPlot[cameraSpecNum][i], myColoursData[i % 5], SymbolType.None);
                    }
                    // NB if it is not checked, do nothing


                    // These if statements find which of the radio buttons are checked, and add
                    // the appropriate data to badCountsData array
                    if (graphControlBadCountsAllCAM[i].Checked)            // All bad counts
                    {
                        // Add all bad counts to the list of data
                        badCountsData[i] = myCAMSpectrum[cameraSpecNum][i].getBadCountsAll();
                    }
                    //
                    else if (graphControlBadCountsLaserCAM[i].Checked)     // Just laser errors
                    {
                        // Add bad counts from laser errors to the list of data
                        badCountsData[i] = myCAMSpectrum[cameraSpecNum][i].getBadCountsErrors();
                    }
                    //
                    else if (graphControlBadCountsThresholdCAM[i].Checked) // Just threshold errors
                    {
                        // Add bad counts from threshold to the list of data
                        badCountsData[i] = myCAMSpectrum[cameraSpecNum][i].getBadCountsThreshold();
                    }
                    // If "None" is checked, don't need to put anything in the array. There will just be a blank space at index i

                    // So long as "None" is not checked, plot curve to the graph
                    // badCountsData[i] will contain bad counts from laser errors, threshold errors or both
                    if (!graphControlBadCountsNoneCAM[i].Checked)
                    {
                        // Sort the data by x co-ordinate (frequency)
                        // this ensures that the curve looks sensible
                        badCountsData[i].Sort();

                        myCurve = myPane.AddCurve(myCAMSpectrum[cameraSpecNum][i].getName() + " bad counts",
                            badCountsData[i], myColoursBadCounts[i % 5], SymbolType.Circle);
                        myCurve.IsY2Axis = true;
                    }


                }

                // Rescale bad counts axis
                this.badCountsAxisRescaleCAM(badCountsData);

                // Tell ZedGraph to refigure the
                // axes since the data have changed
                zedGraphSpectraCAM.AxisChange();
                zedGraphSpectraCAM.Invalidate();
                // Force redraw of control
            }

        }

        private void updateGraphDER()
        {
            // Only try to update graph if some spectra have been loaded
            if (numberOfSpectra != 0 && useDerivedPlots != 0)
            {

                // get a reference to the GraphPane
                GraphPane myPane = this.zedGraphSpectraDER.GraphPane; 
                // Clear data
                zedGraphSpectraDER.GraphPane.CurveList.Clear();
                LineItem myCurve;
             


                for (int i = 0; i < numberOfSpectra; i++)
                {
                    // If the "show spectrum" checkBox is checked
                    if (graphControlCheckBoxDER[i].Checked)
                    {
                       
                            // These if statements find which of the radio buttons are checked, and add
                            // the appropriate data to badCountsData array
                            if (graphControlAverage[i].Checked)            // All bad counts
                            {
                                myCurve = myPane.AddCurve("Average",
                                  derivedCAMPlot[0][i], myColoursData[i % 5], SymbolType.Square);
                            }
                            //
                            if (graphControlEE[i].Checked)     // Just laser errors
                            {
                                myCurve = myPane.AddCurve("EE",
                                  derivedCAMPlot[1][i], myColoursData[i % 5], SymbolType.Triangle);
                            }
                            //
                            if (graphControlEGGE[i].Checked) // Just threshold errors
                            {
                                myCurve = myPane.AddCurve("EG+GE",
                                  derivedCAMPlot[2][i], myColoursData[i % 5], SymbolType.Star);
                            }

                            if (graphControlGG[i].Checked) // Just threshold errors
                            {
                                myCurve = myPane.AddCurve("GG",
                                  derivedCAMPlot[3][i], myColoursData[i % 5], SymbolType.Circle);
                            }

                            /*
                            // If "None" is checked, don't need to put anything in the array. There will just be a blank space at index i

                            // So long as "None" is not checked, plot curve to the graph
                            // badCountsData[i] will contain bad counts from laser errors, threshold errors or both
                            if (!graphControlBadCountsNoneCAM[i].Checked)
                            {
                                // Sort the data by x co-ordinate (frequency)
                                // this ensures that the curve looks sensible
                                badCountsData[i].Sort();

                                myCurve = myPane.AddCurve(myCAMSpectrum[cameraSpecNum][i].getName() + " bad counts",
                                    badCountsData[i], myColoursBadCounts[i % 5], SymbolType.Circle);
                                myCurve.IsY2Axis = true;
                            }
                            */
                        
                    }


                }

                // Rescale bad counts axis
                //this.badCountsAxisRescaleCAM(badCountsData);

                // Tell ZedGraph to refigure the
                // axes since the data have changed
                zedGraphSpectraDER.AxisChange();
                zedGraphSpectraDER.Invalidate();
                // Force redraw of control
            }

        }





        // Method to rescale the bad counts axis on graph
        private void badCountsAxisRescale(PointPairList[] badCountsData)
        {
            int maxData = 0;

            for (int i = 0; i < numberOfSpectra; i++)
            {
                // Only look at bad counts data if it is being displayed
                if (!graphControlBadCountsNone[i].Checked)
                {
                    // Get array of y values only
                    double[] yvalues = badCountsData[i].Select(PointPair => PointPair.Y).ToArray();
                    // Save maximum y value
                    int maxData_Spectrum = (int)yvalues.Max();
                    if (maxData_Spectrum > maxData)
                    {
                        maxData = maxData_Spectrum;
                    }
                }
            }

            // Always set minimum to zero
            zedGraphSpectra.GraphPane.Y2Axis.Scale.Min = 0;

            // Set maximum depending on data
            if (maxData < 20)
            {
                zedGraphSpectra.GraphPane.Y2Axis.Scale.Max = 20;
            }
            else if (maxData < 40)
            {
                zedGraphSpectra.GraphPane.Y2Axis.Scale.Max = 40;
            }
            else if (maxData < 60)
            {
                zedGraphSpectra.GraphPane.Y2Axis.Scale.Max = 60;
            }
            else if (maxData < 80)
            {
                zedGraphSpectra.GraphPane.Y2Axis.Scale.Max = 80;
            }
            else if (maxData < 100)
            {
                zedGraphSpectra.GraphPane.Y2Axis.Scale.Max = 100;
            }
            else if (maxData < 200)
            {
                zedGraphSpectra.GraphPane.Y2Axis.Scale.Max = 200;
            }
            else if (maxData < 400)
            {
                zedGraphSpectra.GraphPane.Y2Axis.Scale.Max = 400;
            }
            else
            {
                zedGraphSpectra.GraphPane.Y2Axis.Scale.Max = 800;
            }
        }
        private void badCountsAxisRescaleCAM(PointPairList[] badCountsData)
        {
            int maxData = 0;

            for (int i = 0; i < numberOfSpectra; i++)
            {
                // Only look at bad counts data if it is being displayed
                if (!graphControlBadCountsNoneCAM[i].Checked)
                {
                    // Get array of y values only
                    double[] yvalues = badCountsData[i].Select(PointPair => PointPair.Y).ToArray();
                    // Save maximum y value
                    int maxData_Spectrum = (int)yvalues.Max();
                    if (maxData_Spectrum > maxData)
                    {
                        maxData = maxData_Spectrum;
                    }
                }
            }

            // Always set minimum to zero
            zedGraphSpectraCAM.GraphPane.Y2Axis.Scale.Min = 0;

            // Set maximum depending on data
            if (maxData < 20)
            {
                zedGraphSpectraCAM.GraphPane.Y2Axis.Scale.Max = 20;
            }
            else if (maxData < 40)
            {
                zedGraphSpectraCAM.GraphPane.Y2Axis.Scale.Max = 40;
            }
            else if (maxData < 60)
            {
                zedGraphSpectraCAM.GraphPane.Y2Axis.Scale.Max = 60;
            }
            else if (maxData < 80)
            {
                zedGraphSpectraCAM.GraphPane.Y2Axis.Scale.Max = 80;
            }
            else if (maxData < 100)
            {
                zedGraphSpectraCAM.GraphPane.Y2Axis.Scale.Max = 100;
            }
            else if (maxData < 200)
            {
                zedGraphSpectraCAM.GraphPane.Y2Axis.Scale.Max = 200;
            }
            else if (maxData < 400)
            {
                zedGraphSpectraCAM.GraphPane.Y2Axis.Scale.Max = 400;
            }
            else
            {
                zedGraphSpectraCAM.GraphPane.Y2Axis.Scale.Max = 800;
            }
        }


        #endregion


        // This code creates a new public event (PauseEvent) which can be detected by the CoreForm
        // Used to trigger the pause button on CoreForm from the pause button on the viewer
        public delegate void PauseEventHandler(object sender, EventArgs e);
        public event PauseEventHandler PauseEvent;
        private void pauseButton_Click(object sender, EventArgs e)
        {
            PauseEvent(this, e);
        }


        // To detect a key press from (hopefully) anywhere on the form. This is linked to as many different controls as possible
        private void viewerForm_KeyDown(object sender, KeyEventArgs e)
        {
            // If F12 has been pressed
            if (e.KeyCode == Keys.F12)
            {
                // Press generate pause event to trigger pause button on CoreForm
                PauseEvent(this, e);
            }
        }

        private void ionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIons;
            int.TryParse(ionBox.SelectedItem.ToString(), out nIons);
            cameraSpecNum = nIons - 1;
        }

        private void ionBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nIons;
            int.TryParse(ionBox1.SelectedItem.ToString(), out nIons);
            cameraSpecNum = nIons - 1;
        }

        private void tabPageSpectra_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            zedGraphSpectra.GraphPane.YAxis.Scale.Max = (double)trackBar1.Value / 100;
            updateGraph();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            zedGraphSpectraCAM.GraphPane.YAxis.Scale.Max = (double)trackBar2.Value / 100;
            updateGraphCAM();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            zedGraphSpectraDER.GraphPane.YAxis.Scale.Max = (double)trackBar2.Value / 100;
            updateGraphDER();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("isSpecRunning" + IsExperimentRunning);
            if (IsExperimentRunning==true) e.Cancel=true;

        }

        private PointPairList populateDerivedCAMPlot(int nPlots, int nSpectra)
        {
            PointPairList derivedPointPairList = new PointPairList();
           
                switch (nPlots)
                {

                    //average

                    case 0:

                        for (int k = 0; k < myCAMSpectrum[0][nSpectra].getDataSize(); k++)
                        {
                            double tempDarkProb = 0;
                            for (int i = 0; i < numOfIons - 1; i++)
                            {
                                tempDarkProb += myCAMSpectrum[i][nSpectra].getDarkProb(k);
                            }
                            double averageDarkProb = (double)tempDarkProb / (numOfIons - 1);
                            derivedPointPairList.Add(myCAMSpectrum[0][nSpectra].getFrequency(k), averageDarkProb);

                        }
                        break;
                    //double excitation
                    case 1:

                        for (int k = 0; k < myCAMSpectrum[0][nSpectra].getDataSize(); k++)
                        {
                            int eeCount = 0;
                            // bool[][] darkBoolArray=new bool[numOfIons-1][]; 
                            int reps = myCAMSpectrum[0][nSpectra].getReps();
                            for (int j = 0; j < reps; j++)
                            {

                                if (myCAMSpectrum[0][nSpectra].getReadingsDark(k, j) == true && myCAMSpectrum[1][nSpectra].getReadingsDark(k, j) == true) eeCount++;

                            }

                            double averageEEProb = (double)eeCount / reps;
                            float freq = myCAMSpectrum[0][nSpectra].getFrequency(k);
                            derivedPointPairList.Add(freq, averageEEProb);

                        }
                        break;
                    case 2:

                        for (int k = 0; k < myCAMSpectrum[0][nSpectra].getDataSize(); k++)
                        {
                            int egCount = 0;
                            // bool[][] darkBoolArray=new bool[numOfIons-1][]; 
                            int reps = myCAMSpectrum[0][nSpectra].getReps();
                            for (int j = 0; j < reps; j++)
                            {

                                if ((myCAMSpectrum[0][nSpectra].getReadingsDark(k, j) == true && myCAMSpectrum[1][nSpectra].getReadingsDark(k, j) == false) || (myCAMSpectrum[0][nSpectra].getReadingsDark(k, j) == false && myCAMSpectrum[1][nSpectra].getReadingsDark(k, j) == true)) egCount++;

                            }

                            double averageEGProb = (double)egCount / reps;
                            derivedPointPairList.Add(myCAMSpectrum[0][nSpectra].getFrequency(k), averageEGProb);

                        }
                        break;


                    case 3:

                        for (int k = 0; k < myCAMSpectrum[0][nSpectra].getDataSize(); k++)
                        {
                            int ggCount = 0;
                            // bool[][] darkBoolArray=new bool[numOfIons-1][]; 
                            int reps = myCAMSpectrum[0][nSpectra].getReps();
                            for (int j = 0; j < reps; j++)
                            {

                                if (myCAMSpectrum[0][nSpectra].getReadingsDark(k, j) == false && myCAMSpectrum[1][nSpectra].getReadingsDark(k, j) == false) ggCount++;

                            }

                            double averageGGProb = (double)ggCount / reps;
                            derivedPointPairList.Add(myCAMSpectrum[0][nSpectra].getFrequency(k), averageGGProb);

                        }
                        break;

                    case 4:

                        for (int k = 0; k < myCAMSpectrum[0][nSpectra].getDataSize(); k++)
                        {
                            int ggeeCount = 0;
                            // bool[][] darkBoolArray=new bool[numOfIons-1][]; 
                            int reps = myCAMSpectrum[0][nSpectra].getReps();
                            for (int j = 0; j < reps; j++)
                            {

                                if ((myCAMSpectrum[0][nSpectra].getReadingsDark(k, j) == false && myCAMSpectrum[1][nSpectra].getReadingsDark(k, j) == false) ||
                                    (myCAMSpectrum[0][nSpectra].getReadingsDark(k, j) == true && myCAMSpectrum[1][nSpectra].getReadingsDark(k, j) == true))
                                    ggeeCount++;

                            }

                            double averageGGEEProb = (double)ggeeCount / reps;
                            derivedPointPairList.Add(myCAMSpectrum[0][nSpectra].getFrequency(k), averageGGEEProb);

                        }
                        break;


                }
                return derivedPointPairList;
            

        }


        private PointPairList populateDerivedPlot(int nPlots, int nSpectra)
        {
            PointPairList derivedPointPairList = new PointPairList();

            switch (nPlots)
            {

                //average

                case 0:

                    for (int k = 0; k < myPMTSpectrum[nSpectra].getDataSize(); k++)
                    {
                        double tempDarkProb = 0;                      
                      
                        tempDarkProb+= myPMTSpectrum[nSpectra].getDarkProb(k);
                       
                        double averageDarkProb = (double)tempDarkProb;
                        derivedPointPairList.Add(myPMTSpectrum[nSpectra].getFrequency(k), myPMTSpectrum[nSpectra].getDarkProb(k));

                    }
                    break;
                //double excitation
                case 1:

                    for (int k = 0; k < myPMTSpectrum[nSpectra].getDataSize(); k++)
                    {
                        double tempDarkProb = 0;
                        tempDarkProb += myPMTSpectrum[nSpectra].getDarkProb(k);
                        double averageDarkProb = (double)tempDarkProb;
                        derivedPointPairList.Add(myPMTSpectrum[nSpectra].getFrequency(k), myPMTSpectrum[nSpectra].getDarkProb(k));
                    }
                    break;
                case 2:

                    for (int k = 0; k < myPMTSpectrum[nSpectra].getDataSize(); k++)
                    {
                      
                        derivedPointPairList.Add(myPMTSpectrum[nSpectra].getFrequency(k), myPMTSpectrum[nSpectra].getEGGEProb(k));
                    }
                    break;


                case 3:

                    for (int k = 0; k < myPMTSpectrum[nSpectra].getDataSize(); k++)
                    {

                        derivedPointPairList.Add(myPMTSpectrum[nSpectra].getFrequency(k), myPMTSpectrum[nSpectra].getGGProb(k));
                    }
                    break;

                case 4:

                    for (int k = 0; k < myPMTSpectrum[nSpectra].getDataSize(); k++)
                    {

                        derivedPointPairList.Add(myPMTSpectrum[nSpectra].getFrequency(k), myPMTSpectrum[nSpectra].getGGProb(k)+ myPMTSpectrum[nSpectra].getDarkProb(k));
                    }
                    break;


            }
            return derivedPointPairList;


        }





    }
        
    }

