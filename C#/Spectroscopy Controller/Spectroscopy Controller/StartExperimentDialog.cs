using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spectroscopy_Controller
{
    public partial class StartExperimentDialog : Form
    {
        public StartExperimentDialog()
        {
            InitializeComponent();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {


            // Configure 'Choose folder' dialog for saving readings files
            ChooseFolderDialog.SelectedPath = "Z:/Data";      // Initialise to share drive
            ChooseFolderDialog.ShowDialog();

        }

    }
}
