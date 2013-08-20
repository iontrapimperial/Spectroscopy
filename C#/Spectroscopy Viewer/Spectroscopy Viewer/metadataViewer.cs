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
        public metadataViewer(ref List<spectrum> mySpectrum, int spectrumNumber)
        {
            InitializeComponent();

            string[] metadata = mySpectrum[spectrumNumber].getMetadata();


            int i = 0;

            
        }


    }
}
