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
        private List<string> myList = new List<string>();
        // Store the number of existing spectra
        private int mySpectrumLength = new int();

        // Public variables to
        public int selectedIndex = new int();
        public string newSpectrumName;

        // Constructor given a list of existing spectra
        public spectrumSelect(List<spectrum> mySpectrum)
        {
            InitializeComponent();

            // Store number of existing spectra
            mySpectrumLength = mySpectrum.Count();

            string existingSpectrumName;                // String to contain the name of each spectrum

            // Create new item in list for each existing spectrum
            for (int i = 0; i < mySpectrum.Count; i++)
            {
                existingSpectrumName = mySpectrum[i].getName();                     // Retrieve name of spectrum
                myList.Add("Spectrum " + i + " (" + existingSpectrumName + ")");    // Concatenate string with name & number
            }

            // Option to create new spectrum
            // NB put this last, then we can tell if a new or existing spectrum has been selected
            myList.Add("Create new spectrum...");

            // Populate list box from this list
            spectrumSelectList.DataSource = myList;

            // Set default text for box
            newSpectrumNameBox.Text = "Spectrum name";
            // Highlight text by default
            newSpectrumNameBox.SelectionStart = 0;
            newSpectrumNameBox.SelectionLength = newSpectrumNameBox.Text.Length;
            newSpectrumNameBox.MaxLength = 100;          // Set a sensible maximum length for spectrum name

        }

        private void addToSpectrumButton_Click(object sender, EventArgs e)
        {
            // Check which item was selected, set public value
            selectedIndex = spectrumSelectList.SelectedIndex;

            // If creating new spectrum, set public string from user input
            if (selectedIndex == mySpectrumLength)
            {
                newSpectrumName = newSpectrumNameBox.Text;
            }

            this.Close();       // Close form
        }

    }
}
