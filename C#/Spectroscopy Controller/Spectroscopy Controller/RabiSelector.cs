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
            LoopState loopState = new LoopState();

            // Loop through each pulse
            for (int i = 0; i < pulseTemplate.Count; i++)
            {

                if (typeof(LaserState).IsAssignableFrom(pulseTemplate[i].Tag.GetType())) {
                    state = (LaserState)pulseTemplate[i].Tag;
                    // If the state type is NORMAL or COUNT
                    if (state.StateType == LaserState.PulseType.NORMAL || state.StateType == LaserState.PulseType.COUNT)
                    {
                        // Add the name of the pulse to a list, for displaying on the form
                        for (int k = 0; k < pulseNameList.Count; k++)
                        {
                            // Compare the item in the list to the desired item (both strings)
                            if (pulseNameList[k] == state.Name)
                            {
                                MessageBox.Show("Sequence creation failed. Template contains multiple pulses with same name. Please fix and try again.");
                                return;
                            }
                        }
                        pulseNameList.Add(state.Name);
                    }
                }
                if (typeof(LoopState).IsAssignableFrom(pulseTemplate[i].Tag.GetType()))
                {
                    
                    loopState = (LoopState)pulseTemplate[i].Tag;
                    for (int k = 0; k < pulseNameList.Count; k++)
                    {
                        // Compare the item in the list to the desired item (both strings)
                        if (pulseNameList[k] == loopState.Name)
                        {
                            MessageBox.Show("Sequence creation failed. Template contains multiple pulses with same name. Please fix and try again.");
                            return;
                        }
                    }

                    pulseNameList.Add(loopState.Name);
                    for (int j=0;j< pulseTemplate[i].Nodes.Count;j++)
                    {
                        if (typeof(LaserState).IsAssignableFrom(pulseTemplate[i].Nodes[j].Tag.GetType()))
                        {
                            state = (LaserState)pulseTemplate[i].Nodes[j].Tag;
                            // If the state type is NORMAL or COUNT
                            if (state.StateType == LaserState.PulseType.NORMAL || state.StateType == LaserState.PulseType.COUNT)
                            {
                                // Add the name of the pulse to a list, for displaying on the form
                                for (int k = 0; k< pulseNameList.Count; k++)
                                {
                                    // Compare the item in the list to the desired item (both strings)
                                    if (pulseNameList[k] == state.Name)
                                    {
                                        MessageBox.Show("Sequence creation failed. Template contains multiple pulses with same name. Please fix and try again.");
                                        return;
                                    }
                                }
                                pulseNameList.Add(state.Name);
                            }
                        }
                    }                   

                }

            }

            // Make list of pulse names the data source for checkbox list on form
            // This may not work....
        
            this.pulseSelectBox.DataSource = pulseNameList;
            this.ShowDialog();
        }

        private void generateSequenceButton_Click(object sender, EventArgs e)
        {
            /*
            LaserState state = new LaserState();
            // Loop through each pulse
           
                for (int i = 0; i < pulseTemplate.Count; i++)
                {
                if (typeof(LaserState).IsAssignableFrom(pulseTemplate[i].Tag.GetType()))
                {
                    state = (LaserState)pulseTemplate[i].Tag;
                    if (state.StateType == LaserState.PulseType.NORMAL || state.StateType == LaserState.PulseType.COUNT)
                    {
                        // Call method to find out if that item is checked in pulseSelectBox
                        if (isItemChecked(state.Name))
                        {
                            // Set property in the state to say we should sweep this
                            state.toSweep = true;
                        }
                    }
                }
            }*/

            LaserState state = new LaserState();
            LoopState loopState = new LoopState();

            // Loop through each pulse
            for (int i = 0; i < pulseTemplate.Count; i++)
            {

                if (typeof(LaserState).IsAssignableFrom(pulseTemplate[i].Tag.GetType()))
                {
                    state = (LaserState)pulseTemplate[i].Tag;
                    // If the state type is NORMAL or COUNT
                    if (state.StateType == LaserState.PulseType.NORMAL || state.StateType == LaserState.PulseType.COUNT)
                    {
                        if (isItemChecked(state.Name))
                        {
                            // Set property in the state to say we should sweep this
                            state.toSweep = true;
                        }
                    }
                }
                if (typeof(LoopState).IsAssignableFrom(pulseTemplate[i].Tag.GetType()))
                {

                    loopState = (LoopState)pulseTemplate[i].Tag;
                    if (isItemChecked(loopState.Name))
                    {
                        // Set property in the state to say we should sweep this
                        loopState.toSweep = true;
                    }
                    for (int j = 0; j < pulseTemplate[i].Nodes.Count; j++)
                    {
                        if (typeof(LaserState).IsAssignableFrom(pulseTemplate[i].Nodes[j].Tag.GetType()))
                        {
                            state = (LaserState)pulseTemplate[i].Nodes[j].Tag;
                            // If the state type is NORMAL or COUNT
                            if (state.StateType == LaserState.PulseType.NORMAL || state.StateType == LaserState.PulseType.COUNT)
                            {
                                if (isItemChecked(state.Name))
                                {
                                    // Set property in the state to say we should sweep this
                                    state.toSweep = true;
                                }
                            }
                        }
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

        private void repeatsSelect_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
