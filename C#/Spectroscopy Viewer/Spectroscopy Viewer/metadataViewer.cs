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
    public partial class metadataViewer : Form
    {
        public metadataViewer(ref List<spectrum> mySpectrum, int spectrumNumber, int numberOfSpectra)
        {
            InitializeComponent();
            // Set the text to wrap automatically
            this.metadataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // Set the form title to the spectrum name
            this.Text = mySpectrum[spectrumNumber].getName();

            // Retrieve array of metadata from spectrum
            string[] metadata = mySpectrum[spectrumNumber].getMetadata();
            // New string array for printing out "Field" column
            string[] metadataTitle = new string[metadata.Length];
            
            metadataTitle[0] = "Date";
            metadataTitle[1] = "Spectrum Type";
            metadataTitle[2] = "729 Direction";
            metadataTitle[3] = "Trap Voltage (V)";
            metadataTitle[4] = "Axial Frequency (kHz)";
            metadataTitle[5] = "Modified Cyclotron Frequency (kHz)";
            metadataTitle[6] = "Magnetron Frequency (kHz)";
            metadataTitle[7] = "AOM Start Frequency (MHz)";
            metadataTitle[8] = "Carrier Frequency (MHz)";
            metadataTitle[9] = "Step Size (kHz)";
            metadataTitle[10] = "Sidebands to scan / side";
            metadataTitle[11] = "Sideband Width (Steps)";
            metadataTitle[12] = "729 RF Amplitude (dBm)";
            metadataTitle[13] = "Number of Repeats";
            metadataTitle[14] = "Number Interleaved";
            metadataTitle[15] = "Spectrum Name (from file)";
            metadataTitle[16] = "Notes";

            // Fill in the first 14 bits of metadata automatically
            for (int i = 0; i < 15; i++)
            {
                this.metadataGrid.Rows.Add(metadataTitle[i], metadata[i]);
            }
            // Here we skip a field - which sideband (not applicable to entire spectra)
            this.metadataGrid.Rows.Add(metadataTitle[15], metadata[16]);
            this.metadataGrid.Rows.Add(metadataTitle[16], metadata[17]);
        }  
    }
}
