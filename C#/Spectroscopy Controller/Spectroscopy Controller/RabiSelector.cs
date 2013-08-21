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
    // Takes a template pulse sequence
    public partial class RabiSelector : Form
    {
        private TreeView newPulseTree;

        private BindingList<string> pulseNameList = new BindingList<string>();

        public RabiSelector(TreeNodeCollection pulseTemplate)
        {
            InitializeComponent();

            LaserState state = new LaserState();

            // Loop through each pulse
            for (int i = 0; i < pulseTemplate.Count; i++)
            {
                state = (LaserState)pulseTemplate[i].Tag;
                // If the state type is NORMAL or COUNT
                if (state.StateType == LaserState.PulseType.NORMAL || state.StateType == LaserState.PulseType.COUNT)
                {
                    // Add the name of the pulse to a list, for displaying on the form
                    pulseNameList.Add(state.Name);
                }
            }

            // Make list of pulse names the data source for checkbox list on form
            // This may not work....
            this.pulseListBox.DataSource = pulseNameList;


        }

    }
}
