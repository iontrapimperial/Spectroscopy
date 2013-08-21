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
        private BindingList<string> pulseNameList = new BindingList<string>();
        private TreeNodeCollection pulseTemplate;

        public RabiSelector()
        {
            InitializeComponent();
        }

        public RabiSelector(TreeNodeCollection pulseTemplatePassed)
        {
            InitializeComponent();
            pulseTemplate = pulseTemplatePassed;
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
            this.pulseSelectBox.DataSource = pulseNameList;
        }

        private void generateSequenceButton_Click(object sender, EventArgs e)
        {
            LaserState state = new LaserState();
            // Loop through each pulse
            for (int i = 0; i < pulseTemplate.Count; i++)
            {
                state = (LaserState)pulseTemplate[i].Tag;
                if (state.StateType == LaserState.PulseType.NORMAL || state.StateType == LaserState.PulseType.COUNT)
                {
                    // Call method to find out if that item is checked in pulseSelectBox
                    if ( isItemChecked(state.Name) )
                    {
                        // Set property in the state to say we should sweep this
                        state.toSweep = true;
                    }
                }
            }
        }


        // Method to find out whether the desired item is in the list of checked items in pulseSelectBox
        private bool isItemChecked(string item)
        {
            // Retrieve list of checked items in pulseSelectBox
            CheckedListBox.CheckedItemCollection myCheckedItems = this.pulseSelectBox.CheckedItems;

            // Loop through each checked item
            for (int i = 0; i < myCheckedItems.Count; i++)
            {
                // Compare the item in the list to the desired item (both strings)
                if (myCheckedItems[i].ToString() == item)
                {
                    // If they match, item is in the list
                    return true;
                }
            }
            // If we get here, desired item does not match anything in the list
            return false;
        }

        private void startExperimentButton_Click(object sender, EventArgs e)
        {

        }

    }
}
