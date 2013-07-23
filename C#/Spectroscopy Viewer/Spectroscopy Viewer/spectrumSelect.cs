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
            InitializeComponent();


            int numberInterleaved = numberInterleavedPassed;    // Store number of spectra in the file
            existingSpectra = mySpectrum.Count();               // Store number of existing spectra
            selectedSpectrum = new int[numberInterleaved];      // Initialise array
            myComboBox = new ComboBox[numberInterleaved];       // Create combo boxes

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
            detectedSpectraText.Text = "Valid file " + myFileName + " opened \nFile contains "
                                        + numberInterleaved + " interleaved spectra";


            // Create combo boxes and set data source
            for (int i = 0; i < numberInterleaved; i++)
            {
                myComboBox[i] = new ComboBox();
                myComboBox[i].DataSource = myListOfSpectra;
            }



            // Set text on button to singular/plural depending on number of spectra (just being fancy really)
            if (numberInterleaved == 1)
            {
                buttonOK.Text = "Load spectrum";
            }
            else buttonOK.Text = "Load spectra";

 
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

    }
}
