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
    public partial class displayMetadata : Form
    {
        // Constructor given a particular spectrum
        public displayMetadata(ref spectrum mySpectrum)
        {
            InitializeComponent();
        }
    }
}
