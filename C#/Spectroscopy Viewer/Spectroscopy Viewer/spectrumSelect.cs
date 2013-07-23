using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spectroscopy_Viewer
{
    public partial class spectrumSelect : Form
    {
        // List to display 
        private List<string> myListOfSpectra = new List<string>();
        // Store the number of existing spectra
        private int existingSpectra = new int();
        // Store the number of interleaved spectra in file
        private int numberInterleaved = new int();
        // Combo boxes for user input
        private ComboBox[] myComboBox;      

        // To store names of the new spectra to be created
        private List<string> newSpectra = new List<string>();

        // Public variables to be accessed by main form
        public int[] selectedSpectrum;        // Which option selected for each data set
        public List<string> spectrumNames = new List<string>();     // List of names

        // Constructor given a list of existing spectra
        public spectrumSelect(List<spectrum> mySpectrum, int numberInterleavedPassed, string myFileName)
        {
            int numberInterleaved = numberInterleavedPassed;    // Store number of spectra in the file

            InitializeComponent();

            existingSpectra = mySpectrum.Count();               // Store number of existing spectra
            selectedSpectrum = new int[numberInterleaved];      // Initialise array
            

            // Create new item in list for each existing spectrum
            for (int i = 0; i < existingSpectra; i++)
            {
                spectrumNames[i] = mySpectrum[i].getName();                     // Retrieve name of spectrum
                myListOfSpectra.Add("Spectrum " + i + " (" + spectrumNames[i] + ")");    // Concatenate string with name & number
            }
            myListOfSpectra.Add("");    // Add a blank option


            // Set defaults for text box
            newSpectrumNameBox.MaxLength = 100;          // Set a sensible maximum length for spectrum name
            
            // Set text telling the user how many spectra have been detected
            detectedSpectraText.Text = "Valid file " + myFileName + " opened\nFile contains "
                                        + numberInterleaved + " interleaved spectra"
                                        + "\nPlease choose destinations:";

            this.addComboBoxes();

            //******************************************//
            // Set text on button to singular/plural depending on number of spectra (just being fancy really) 
                        if (numberInterleaved == 1)
            {
                buttonOK.Text = "Load spectrum";
            }
            else buttonOK.Text = "Load spectra";
            //******************************************//
            

 
        }


        private void addNewSpectrumButton_Click(object sender, EventArgs e)
        {
            // Add name to temporary list of new spectra to be created
            newSpectra.Add(newSpectrumNameBox.Text);

            // Add spectra to list
            myListOfSpectra.Add("(New) " + newSpectrumNameBox.Text);

            // Update drop-down lists
            for (int i = 0; i < numberInterleaved; i++)
            {
                myComboBox[i].DataSource = myListOfSpectra;
            }

            // Trying to get this to update.. but it doesn't seem to be working
            // Wait for new form design before worrying too much
            this.Refresh();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

            // For each of the interleaved spectra
            for (int i = 0; i < numberInterleaved; i++)
            {
                // Assign which spectrum each data set should belong to - from user input on form
                selectedSpectrum[i] = myComboBox[i].SelectedIndex;

                if (selectedSpectrum[i] >= existingSpectra)
                {
                    // Re-order so that the next spectrum to be dealt with is the next in the array
                    // This ensures correct metadata when items are added to list using List.Add
                    spectrumNames.Add(newSpectra[selectedSpectrum[i] - existingSpectra]);
                }
            }

            this.Close();       // Close form
        }



        private void addComboBoxes()
        {
            //******************************************//
            myComboBox = new ComboBox[numberInterleaved];       // Create combo boxes
            Label[] myComboBoxLabel = new Label[numberInterleaved];     // Create labels for combo boxes
            // For each interleaved spectrum
            for (int i = 0; i < numberInterleaved; i++)
            {
                myComboBoxLabel[i] = new Label();                       // Create label
                myComboBoxLabel[i].Text = "Spectrum " + i + ":";        // Set text
                myComboBoxLabel[i].Location = new Point(10, 80 + i * 30); // Set location
                this.Controls.Add(myComboBoxLabel[i]);

                myComboBox[i] = new ComboBox();                         // Create combo box
                myComboBox[i].DataSource = myListOfSpectra;             // Set data source
                myComboBox[i].Location = new Point(110, 80 + i * 30);     // Set location
                this.Controls.Add(myComboBox[i]);
            }
            //******************************************//
        }



    }
}
