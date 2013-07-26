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

            // Set default text
            startFreqBox.Text = "1000";
            stepSizeBox.Text = "20";
            repeatsBox.Text = "100";
            numberInterleavedBox.Text = "1";
        }

        // Respond to change in any of the values
        private void inputBox_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Changing input {0}", int.TryParse(startFreqBox.Text, out startFreq));


            // Try to convert all strings to integers
            if (int.TryParse(startFreqBox.Text, out startFreq) && int.TryParse(stepSizeBox.Text, out stepSize)
                && int.TryParse(repeatsBox.Text, out repeats) && int.TryParse(numberInterleavedBox.Text, out numberInterleaved) )
            {
                Console.WriteLine("Start freq {0}", startFreq);
                Console.WriteLine("repeats {0}", repeats);
                Console.WriteLine("step size {0}", stepSize);
                Console.WriteLine("Interleaved {0}", numberInterleaved);
                // If they succeed, make sure they are not zero (apart from start freq which can be)
                if (numberInterleaved != 0 && repeats != 0 && stepSize != 0)
                {
                    buttonOK.Enabled = true;
                }
                else buttonOK.Enabled = false;
            }
            else buttonOK.Enabled = false;

        }



    }
}
