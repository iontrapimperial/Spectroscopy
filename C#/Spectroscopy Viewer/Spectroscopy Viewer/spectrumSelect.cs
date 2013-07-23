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

        // To store names of the new spectra to be created
        private List<string> newSpectra = new List<string>();

        // Public variables to be accessed by main form
        public List<int> selectedSpectrum = new List<int>();        // Which option selected for each data set
        public List<string> spectrumNames = new List<string>();     // List of names

        // Constructor given a list of existing spectra
        public spectrumSelect(List<spectrum> mySpectrum, int numberInterleavedPassed)
        {
            InitializeComponent();

            // Store number of spectra in the file
            int numberInterleaved = numberInterleavedPassed;

            // Store number of existing spectra
            existingSpectra = mySpectrum.Count();

            // Create new item in list for each existing spectrum
            for (int i = 0; i < mySpectrum.Count; i++)
            {
                spectrumNames[i] = mySpectrum[i].getName();                     // Retrieve name of spectrum
                myListOfSpectra.Add("Spectrum " + i + " (" + spectrumNames[i] + ")");    // Concatenate string with name & number
            }


            // Set defaults for text box
            newSpectrumNameBox.MaxLength = 100;          // Set a sensible maximum length for spectrum name
            
            // Set data source for combo box 
            DestinationColumn.DataSource = myListOfSpectra;


            for (int i = 0; i < numberInterleaved; i++)
            {
                // Add rows to data grid view
                spectrumSelectDataGrid.Rows.Add();
                spectrumSelectDataGrid.Rows[i].Cells[0].Value = i;
            }


 
        }


        private void addNewSpectrumButton_Click(object sender, EventArgs e)
        {
            // Add name to temporary list of new spectra to be created
            newSpectra.Add(newSpectrumNameBox.Text);

            // Add spectra to list
            myListOfSpectra.Add(newSpectrumNameBox.Text + " (New)");
            
            // Trying to get this to update.. but it doesn't seem to be working
            // Wait for new form design before worrying too much
            this.Refresh();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Temp variables for debugging
            selectedSpectrum[0] = 0;
            selectedSpectrum[1] = 1;

            // For each of the interleaved spectra
            for (int i = 0; i < numberInterleaved; i++)
            {

                // Check which spectrum each data set should belong to - from user input on form
                // (Waiting for form design)




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
