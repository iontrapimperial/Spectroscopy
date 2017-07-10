using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spectroscopy_Controller
{
    public partial class CoreForm : Form
    {
        /// <summary>
        /// Adds an item to the PulseTree based on current form inputs.
        /// </summary>
        /// <param name="bIsRoot">If true adds new node as sibling to currently selected node. If false adds as child to currently selected node.</param>
        void AddNewState(bool bIsRoot)
        {
            bool bIsLoop;
            if (PulseTypeTabs.SelectedTab == LoopTabPage)
            {
                bIsLoop = true;
            }
            else
            {
                bIsLoop = false;
            }

            Pulse P = CreatePulseFromForm(bIsLoop);
            TreeNode T;
            if (PulseTree.SelectedNode != null) //make sure there is a node selected
            {                
                if (!bIsRoot) 
                {
                    if (PulseTree.SelectedNode.Tag is LaserState)
                    {
                        WriteMessage("Can't Create New Pulse: Laser States can't have child nodes", true);
                        return;
                    }
                    T = PulseTree.SelectedNode.Nodes.Add(P.Name);//create a child node of currently selected node
                }
                else //add a sibling to currently selected node.
                {
                    if (PulseTree.SelectedNode.Parent != null) //is node NOT a top-level node?
                    {
                        T = PulseTree.SelectedNode.Parent.Nodes.Add(P.Name); //add as a sibling to selected node                        
                    }
                    else
                    {
                        T = PulseTree.Nodes.Add(P.Name); //if top-level node then just add to the top-level list                        
                    }
                }
            }
            else
            {
                T = PulseTree.Nodes.Add(P.Name); //add as top level node if nothing is selected
            }
            T.Tag = P; //Tag is any object we choose so put in the specific laser data.

            if (bIsLoop)
            {
                if (FPGALoopSelect.Checked == true)
                {
                    T.Text += " (FPGA Loop x" + ((LoopState)P).LoopCount + ")";
                }
                else
                {
                    T.Text += " (Loop x" + ((LoopState)P).LoopCount + ")";
                }
            }

            //PulseTree.Select();
            //PulseTree.SelectedNode = T; //select the new node            
        }

        /// <summary>
        /// Creates a new class of type Pulse based on current form input.
        /// </summary>
        /// <param name="bIsLoop">Set to true to create a Loop, false to create a LaserState.</param>
        /// <returns>Returns newly created Pulse.</returns>
        Pulse CreatePulseFromForm(bool bIsLoop)
        {
            if (bIsLoop)
            {
                LoopState L = new LoopState();
                if (NameBox.Text != "") //don't add a blank slot.
                {
                    L.Name = NameBox.Text;
                }
                L.LoopCount = (int)LoopNumberBox.Value;
                L.bIsFPGALoop = FPGALoopSelect.Checked;
                return L;
            }
            else
            {
                LaserState State = new LaserState();
                if (NameBox.Text != "") //don't add a blank slot.
                {
                    State.Name = NameBox.Text;
                }

                State.Laser397B1 = LaserBox397B1.Checked;
                State.Laser397B2 = LaserBox397B2.Checked;
                State.Laser729 = LaserBox729.Checked;
                State.Laser854 = LaserBox854.Checked;
                State.Laser854POWER = LaserBox854POWER.Checked;
                State.Laser854FREQ = LaserBox854FREQ.Checked;
                State.LaserAux1 = LaserBoxAux1.Checked;                
                
                switch ((int)SourceSelect729.Value)
                {
                    case 0:
                        State.Laser729P0 = true;
                        State.Laser729P1 = true;
                        State.Laser729P2 = true;
                        break;
                    case 1:
                        State.Laser729P0 = false;
                        State.Laser729P1 = true;
                        State.Laser729P2 = true;                        
                        break;
                    case 2:
                        State.Laser729P0 = true;
                        State.Laser729P1 = false;
                        State.Laser729P2 = true;
                        break;
                    case 3:
                        State.Laser729P0 = false;
                        State.Laser729P1 = false;
                        State.Laser729P2 = true;
                        break;
                    case 4:
                        State.Laser729P0 = true;
                        State.Laser729P1 = true;
                        State.Laser729P2 = false;
                        break;
                    case 5:
                        State.Laser729P0 = false;
                        State.Laser729P1 = true;
                        State.Laser729P2 = false;
                        break;
                    case 6:
                        State.Laser729P0 = true;
                        State.Laser729P1 = false;
                        State.Laser729P2 = false;
                        break;
                    case 7:
                        State.Laser729P0 = false;
                        State.Laser729P1 = false;
                        State.Laser729P2 = false;
                        break;
                }

                //Set pulse length to nearest number of ticks
                State.Ticks = tickRounder();
                State.TargetLength = (int)TicksBox.Value;

                if (PulseTypeBox.SelectedIndex == 0)
                {
                    State.StateType = LaserState.PulseType.STARTLOOP;
                }
                else if (PulseTypeBox.SelectedIndex == 1)
                {
                    State.StateType = LaserState.PulseType.WAIT_LABVIEW;
                }
                else if (PulseTypeBox.SelectedIndex == 2)
                {
                    State.StateType = LaserState.PulseType.WAIT_MAINSPHASE;
                }
                else if (PulseTypeBox.SelectedIndex == 3)
                {
                    State.StateType = LaserState.PulseType.NORMAL;
                }
                else if (PulseTypeBox.SelectedIndex == 4)
                {
                    State.StateType = LaserState.PulseType.COUNT;
                }
                else if (PulseTypeBox.SelectedIndex == 5)
                {
                    State.StateType = LaserState.PulseType.STOP;
                }
                else if (PulseTypeBox.SelectedIndex == 6)
                {
                    State.StateType = LaserState.PulseType.SENDDATA;
                }

                return State;
            }
        }

        /// <summary>
        /// Moves a state in the specified direction along the PulseTree.
        /// </summary>
        /// <param name="bMoveUp">Set true to move up, false to move down.</param>
        void MoveState(bool bMoveUp)
        {
            if (PulseTree.SelectedNode != null) //make sure there is a node selected
            {
                int PositionChange;
                if (bMoveUp)
                {
                    PositionChange = -1;
                }
                else
                {
                    PositionChange = 2; //2 as we insert before removal so we need to move 2 positions
                }

                TreeNode Node;
                if (PulseTree.SelectedNode.Parent != null) //make sure there is a parent otherwise just use the main list
                {
                    //first copy the node, insert it then delete the original.
                    Node = (TreeNode)PulseTree.SelectedNode.Clone();
                    PulseTree.SelectedNode.Parent.Nodes.Insert(PulseTree.SelectedNode.Index + PositionChange, Node);
                }
                else
                {
                    Node = (TreeNode)PulseTree.SelectedNode.Clone();
                    PulseTree.Nodes.Insert(PulseTree.SelectedNode.Index + PositionChange, Node);
                }

                PulseTree.SelectedNode.Remove();
                PulseTree.SelectedNode = Node;

            }
            else
            {
                WriteMessage("Can't Re-order Pulse: No Pulse Selected", true);
            }
        }

        /// <summary>
        /// Removes a the currently selected line from the PulseTree.
        /// </summary>
        void RemoveState()
        {
            if (PulseTree.SelectedNode != null) //make sure there is a node selected
            {
                PulseTree.SelectedNode.Remove();
            }
            else
            {
                WriteMessage("Can't Delete Pulse: No Pulse Selected", true);
            }
        }
        
        /// <summary>
        /// Called when an item is selected in the PulseTree. Updates other form elements with the Pulse data at the particular tree node.
        /// </summary>
        void PulseTreeSelect()
        {
            if (PulseTree.SelectedNode != null)
            {
                Pulse P = (Pulse)PulseTree.SelectedNode.Tag;
                NameBox.Text = P.Name;
                if (PulseTree.SelectedNode.Tag is LoopState)
                {
                    PulseTypeTabs.SelectedTab = LoopTabPage;
                    LoopNumberBox.Value = ((LoopState)P).LoopCount;
                    FPGALoopSelect.Checked = ((LoopState)P).bIsFPGALoop;
                }
                else
                {
                    PulseTypeTabs.SelectedTab = PulseTabPage;

                    LaserBox397B1.Checked = ((LaserState)P).Laser397B1;
                    LaserBox397B2.Checked = ((LaserState)P).Laser397B2;
                    LaserBox729.Checked = ((LaserState)P).Laser729;
                    LaserBox854.Checked = ((LaserState)P).Laser854;
                    LaserBox854POWER.Checked = ((LaserState)P).Laser854POWER;
                    LaserBox854FREQ.Checked = ((LaserState)P).Laser854FREQ;
                    LaserBoxAux1.Checked = ((LaserState)P).LaserAux1;

                    if (((LaserState)P).Laser729P0 == true && ((LaserState)P).Laser729P1 == true && ((LaserState)P).Laser729P2 == true)
                    {
                        SourceSelect729.Value = 0;
                    }
                    else if (((LaserState)P).Laser729P0 == false && ((LaserState)P).Laser729P1 == true && ((LaserState)P).Laser729P2 == true)
                    {
                        SourceSelect729.Value = 1;
                    }
                    else if (((LaserState)P).Laser729P0 == true && ((LaserState)P).Laser729P1 == false && ((LaserState)P).Laser729P2 == true)
                    {
                        SourceSelect729.Value = 2;
                    }
                    else if (((LaserState)P).Laser729P0 == false && ((LaserState)P).Laser729P1 == false && ((LaserState)P).Laser729P2 == true)
                    {
                        SourceSelect729.Value = 3;
                    }
                    else if (((LaserState)P).Laser729P0 == true && ((LaserState)P).Laser729P1 == true && ((LaserState)P).Laser729P2 == false)
                    {
                        SourceSelect729.Value = 4;
                    }
                    else if (((LaserState)P).Laser729P0 == false && ((LaserState)P).Laser729P1 == true && ((LaserState)P).Laser729P2 == false)
                    {
                        SourceSelect729.Value = 5;
                    }
                    else if (((LaserState)P).Laser729P0 == true && ((LaserState)P).Laser729P1 == false && ((LaserState)P).Laser729P2 == false)
                    {
                        SourceSelect729.Value = 6;
                    }
                    else if (((LaserState)P).Laser729P0 == false && ((LaserState)P).Laser729P1 == false && ((LaserState)P).Laser729P2 == false)
                    {
                        SourceSelect729.Value = 7;
                    }

                    //Update tick box to target length, and call tickRounder to update rounded length display
                    TicksBox.Value = ((LaserState)P).TargetLength;
                    tickRounder();

                    PulseTypeBox.SelectedIndex = (int)((LaserState)P).StateType;
                }
                PulseTree.Select(); //make sure that focus stays on PulseTree

            }            
        }

        /// <summary>
        /// Copies currently selected form data into currently selected PulseTree item.
        /// </summary>
        void SaveStateFromForm()
        {
            if (PulseTree.SelectedNode == null)
            {
                return;
            }

            Pulse P;
            if (PulseTree.SelectedNode.Tag is LoopState)
            {
                PulseTypeTabs.SelectedTab = LoopTabPage;
                P = CreatePulseFromForm(true);

                if (FPGALoopSelect.Checked == true)
                {
                    PulseTree.SelectedNode.Text = P.Name + " (FPGA Loop x" + ((LoopState)P).LoopCount + ")";
                }
                else
                {
                    PulseTree.SelectedNode.Text = P.Name + " (Loop x" + ((LoopState)P).LoopCount + ")";
                }
            }
            else
            {
                PulseTypeTabs.SelectedTab = PulseTabPage;
                P = CreatePulseFromForm(false);
                PulseTree.SelectedNode.Text = P.Name;
            }
            PulseTree.SelectedNode.Tag = P;
            
        }

        /// <summary>
        /// Creates or destroys preview node in PulseTree.
        /// </summary>
        /// <param name="bIsRoot">True to add at root level, false to add as child.</param>
        /// <param name="bMouseEntering">True to add a node at the correct place, false to remove the previously added node.</param>
        private void ManagePreviewNode(bool bIsRoot, bool bMouseEntering)
        {
            PreviewNode.Remove(); //just to be safe, always remove the node regardless

            if (!bMouseEntering)
            {
                return; //if leaving the button remove the node only then return
            }

            PreviewNode.Text = NameBox.Text;

            if (PulseTree.SelectedNode != null) //make sure there is a node selected
            {
                if (!bIsRoot)
                {
                    if (PulseTree.SelectedNode.Tag is LaserState)
                    {
                        return;
                    }                    
                    PulseTree.SelectedNode.Nodes.Add(PreviewNode);//create a child node of currently selected node
                    PulseTree.SelectedNode.Expand();
                }
                else //add a sibling to currently selected node.
                {
                    if (PulseTree.SelectedNode.Parent != null) //is node NOT a top-level node?
                    {
                        PulseTree.SelectedNode.Parent.Nodes.Add(PreviewNode); //add as a sibling to selected node                        
                    }
                    else
                    {
                        PulseTree.Nodes.Add(PreviewNode); //if top-level node then just add to the top-level list                        
                    }
                }
            }
            else
            {
                PulseTree.Nodes.Add(PreviewNode); //add as top level node if nothing is selected
            }


            if (PulseTypeTabs.SelectedTab == LoopTabPage)
            {
                if (FPGALoopSelect.Checked == true)
                {
                    PreviewNode.Text += " (FPGA Loop x" + LoopNumberBox.Value + ")";
                }
                else
                {
                    PreviewNode.Text += " (Loop x" + LoopNumberBox.Value + ")";
                }                
            }
        }
    }

}
