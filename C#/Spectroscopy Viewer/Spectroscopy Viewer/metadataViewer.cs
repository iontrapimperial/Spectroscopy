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


            

            this.metadataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            string[] metadata = mySpectrum[spectrumNumber].getMetadata();
            string[] metadataTitle = new string[metadata.Length];


            for (int i = 0; i < metadata.Length; i++)
            {
                Console.WriteLine("{0}", metadata[i]);
            }


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
            // Fill in spectrum name depending on which spectrum in the array we are looking at
            this.metadataGrid.Rows.Add(metadataTitle[15], metadata[16 + spectrumNumber]);
            // Fill in notes depending on how many spectra there are in the array
            this.metadataGrid.Rows.Add(metadataTitle[16], metadata[16 + int.Parse(metadata[14])]);
        }
            


    }
}
