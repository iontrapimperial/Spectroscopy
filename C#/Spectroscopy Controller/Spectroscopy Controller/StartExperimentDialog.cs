﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spectroscopy_Controller
{
    // This dialog appears when the user clicks start on the core form
    // Gets required data from the user to put into metadata of the file/pass to viewer
    public partial class StartExperimentDialog : Form
    {
        public TextBox[] SpectrumNames = new TextBox[5];

        private string FilePath;

        public StartExperimentDialog()
        {
            InitializeComponent();

            // Create text boxes for spectrum names
            // Create 5 boxes, then disable them for unused spectra
            for (int i = 0; i < 5; i++)
            {
                SpectrumNames[i] = new TextBox();
                SpectrumNames[i].Location = new System.Drawing.Point(7, (22 + i * 39));
                SpectrumNames[i].Size = new System.Drawing.Size(204, 22);
                SpectrumNames[i].TabIndex = i;
            }
        }

        // Respond to user clicking OK
        private void OKbutton_Click(object sender, EventArgs e)
        {
            // Configure 'Choose folder' dialog for saving readings files
            ChooseFolderDialog.SelectedPath = "Z:/Data";      // Initialise to share drive
            if (ChooseFolderDialog.ShowDialog() != DialogResult.Cancel)
            {
                FilePath = ChooseFolderDialog.SelectedPath;
            }
        }

        // Method to return the file path selected from the Choose Folder dialog
        public string getFilePath()
        {
            return FilePath;
        }

        // Enables the right number of name boxes for the number of spectra selected
        private void SpectrumNameBoxEnable()
        {
            for (int i = 0; i < 5; i++)
            {
                if (i < this.NumberOfSpectra.Value)
                {
                    SpectrumNames[i].Enabled = true;
                }
                else
                {
                    SpectrumNames[i].Enabled = false;
                }
            }
            
        }

        // Method to respond to number of spectra changing
        private void NumberOfSpectra_ValueChanged(object sender, EventArgs e)
        {
            this.SpectrumNameBoxEnable();
        }
    }
}