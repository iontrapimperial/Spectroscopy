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


    public partial class requestMetadata : Form
    {
        public int startFreq = new int();
        public int stepSize = new int();
        public int repeats = new int();
        public int numberInterleaved = new int();

        public requestMetadata()
        {
            InitializeComponent();
        }

        // Respond to user pressing 'OK'
        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Get data from form
            startFreq = int.Parse(startFreqBox.Text);
            stepSize = int.Parse(stepSizeBox.Text);
            repeats = int.Parse(repeatsBox.Text);
            numberInterleaved = int.Parse(numberInterleavedBox.Text);
        }


    }
}
