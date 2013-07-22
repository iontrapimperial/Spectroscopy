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
        private List<spectrum> mySpectrum = new List<spectrum>();
        public int selectedIndex = new int();

        // Constructor given a list of existing spectra
        public spectrumSelect(List<spectrum> mySpectrumPassed)
        {
            InitializeComponent();

            mySpectrum = mySpectrumPassed;      // Save the passed list as a private member
            string spectrumName;                // String to contain the name of each spectrum

            // Create new item in list for each existing spectrum
            for (int i = 0; i < mySpectrum.Count; i++)
            {
                spectrumName = mySpectrum[i].getName();                     // Retrieve name of spectrum
                myList.Add("Spectrum " + i + " (" + spectrumName + ")");    // Concatenate string with name & number
            }

            // Option to create new spectrum
            // NB put this last, then we can tell if a new or existing spectrum has been selected
            myList.Add("Create new spectrum...");

            // Populate list box from this list
            spectrumSelectList.DataSource = myList;

        }

        private void addToSpectrumButton_Click(object sender, EventArgs e)
        {
            // Check which item was selected, set public value
            selectedIndex = spectrumSelectList.SelectedIndex;
            this.Close();       // Close form
        }


    }
}
