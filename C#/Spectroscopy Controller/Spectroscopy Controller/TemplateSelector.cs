using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Spectroscopy_Controller
{
    public partial class TemplateSelector : Form
    {
        TreeView PulseTree;
        public TemplateSelector( TreeView PulseTree )
        {
            InitializeComponent();
            this.PulseTree = PulseTree;
            this.Shown +=new EventHandler(TemplateSelector_Shown);
        }

        private void TemplateSelector_Shown(object sender, EventArgs e)
        {
            RabiMinLength_ValueChanged(null, null);
            RabiMaxLength_ValueChanged(null, null);
            RabiPulseStep_ValueChanged(null, null);
        }

        private void SideBandsAcceptButton_Click(object sender, EventArgs e)
        {
            PulseTree.BeginUpdate();
            PulseTree.Nodes.Clear();

            TreeNode ExperimentLoopNode = PulseTree.Nodes.Add("Experiment Loop (Loop x" + NumFrequencies.Value + ")");
            LoopState Loop = new LoopState();
            Loop.Name = "Experiment Loop";
            Loop.LoopCount = (int)NumFrequencies.Value;
            ExperimentLoopNode.Tag = Loop;



            TreeNode MeasureLoopNode = ExperimentLoopNode.Nodes.Add("Measure Loop (Loop x" + SidebandNumRepeats.Value + ")");
            LoopState MeasureLoop = new LoopState();
            MeasureLoop.Name = "Measure Loop";
            MeasureLoop.LoopCount = (int)SidebandNumRepeats.Value;
            MeasureLoopNode.Tag = MeasureLoop;

            TreeNode Node = MeasureLoopNode.Nodes.Add("MainsPhase Wait");
            LaserState State = new LaserState();
            State.Name = "MainsPhase Wait";
            State.StateType = LaserState.PulseType.WAIT_MAINSPHASE;
            State.Laser397a = true;
            State.Laser397b = true;
            State.Laser866 = true;
            State.Laser854 = true;
            State.Laser729 = false;
            Node.Tag = State;

            Node = MeasureLoopNode.Nodes.Add("Cooling");
            State = new LaserState();
            State.Name = "Cooling";
            State.StateType = LaserState.PulseType.COUNT;
            State.Ticks = 250000;
            State.Laser397a = true;
            State.Laser397b = true;
            State.Laser866 = true;
            State.Laser854 = true;
            State.Laser729 = false;
            Node.Tag = State;

            Node = MeasureLoopNode.Nodes.Add("State Prepare");
            State = new LaserState();
            State.Name = "State Prepare";
            State.StateType = LaserState.PulseType.NORMAL;
            State.Ticks = 2000;
            State.Laser397a = true;
            State.Laser397b = false;
            State.Laser866 = true;
            State.Laser854 = true;
            State.Laser729 = false;
            Node.Tag = State;

            Node = MeasureLoopNode.Nodes.Add("729 Pulse");
            State = new LaserState();
            State.Name = "729 Pulse";
            State.StateType = LaserState.PulseType.NORMAL;
            State.Ticks = 250000;
            State.Laser397a = false;
            State.Laser397b = false;
            State.Laser866 = true;
            State.Laser854 = false;
            State.Laser729 = true;
            Node.Tag = State;

            Node = MeasureLoopNode.Nodes.Add("Count");
            State = new LaserState();
            State.Name = "Count";
            State.StateType = LaserState.PulseType.COUNT;
            State.Ticks = 250000;
            State.Laser397a = true;
            State.Laser397b = true;
            State.Laser866 = false;
            State.Laser854 = false;
            State.Laser729 = false;
            Node.Tag = State;

 
            Node = ExperimentLoopNode.Nodes.Add("Send Data");
            LaserState SendDataState = new LaserState();
            SendDataState.Name = "Send Data";
            SendDataState.StateType = LaserState.PulseType.SENDDATA;
            SendDataState.Laser397a = true;
            SendDataState.Laser397b = true;
            SendDataState.Laser866 = true;
            SendDataState.Laser854 = true;
            SendDataState.Laser729 = false;
            Node.Tag = SendDataState;

            Node = ExperimentLoopNode.Nodes.Add("Labview Wait");
            LaserState LabviewState = new LaserState();
            LabviewState.Name = "Labview Wait";
            LabviewState.StateType = LaserState.PulseType.WAIT_LABVIEW;
            LabviewState.Laser397a = true;
            LabviewState.Laser397b = true;
            LabviewState.Laser866 = true;
            LabviewState.Laser854 = true;
            LabviewState.Laser729 = false;
            Node.Tag = LabviewState;

            
            TreeNode StopNode = PulseTree.Nodes.Add("Stop Experiment");
            LaserState StopState = new LaserState();
            StopState.Name = "Stop Experiment";
            StopState.StateType = LaserState.PulseType.STOP;
            StopNode.Tag = StopState;
            StopState.Laser397a = true;
            StopState.Laser397b = true;
            StopState.Laser866 = true;
            StopState.Laser854 = true;
            StopState.Laser729 = false;
            PulseTree.ExpandAll();
            PulseTree.EndUpdate();

            this.Close();
        }

        private void RabiMinLength_ValueChanged(object sender, EventArgs e)
        {
            MinPulseLength.Text = "(" + ((RabiMinLength.Value * 20) / (1000000)) + " ms)";
        }

        private void RabiMaxLength_ValueChanged(object sender, EventArgs e)
        {
            MaxPulseLength.Text = "(" + ((RabiMaxLength.Value * 20) / (1000000)) + " ms)";
        }
        
        private void RabiPulseStep_ValueChanged(object sender, EventArgs e)
        {
            StepLength.Text = "(" + ((RabiPulseStep.Value * 20) / (1000000)) + " ms)";
        }

        private void RabiAcceptButton_Click(object sender, EventArgs e)
        {
            PulseTree.BeginUpdate();
            PulseTree.Nodes.Clear();

            TreeNode Node;/* = PulseTree.Nodes.Add("Labview Wait");
            LaserState LabviewState = new LaserState();
            LabviewState.Name = "Labview Wait";
            LabviewState.StateType = LaserState.PulseType.WAIT_LABVIEW;
            LabviewState.Laser397a = true;
            LabviewState.Laser397b = true;
            LabviewState.Laser866 = true;
            LabviewState.Laser854 = true;
            LabviewState.Laser729 = false;
            Node.Tag = LabviewState;      */

            for (int PulseLength = (int)RabiMinLength.Value; PulseLength <= (int)RabiMaxLength.Value; PulseLength += (int)RabiPulseStep.Value)
            {                       
                string MeasureLoopName = "Pulse Length: " + ((((float)PulseLength) * 20) / 1000000) + "ms (Loop x" + RabiNumRepeats.Value + ")";
                TreeNode MeasureLoopNode = PulseTree.Nodes.Add(MeasureLoopName);
                LoopState MeasureLoop = new LoopState();
                MeasureLoop.Name = MeasureLoopName;
                MeasureLoop.LoopCount = (int)RabiNumRepeats.Value;
                MeasureLoopNode.Tag = MeasureLoop;

                Node = MeasureLoopNode.Nodes.Add("MainsPhase Wait");
                LaserState State = new LaserState();
                State.Name = "MainsPhase Wait";
                State.StateType = LaserState.PulseType.WAIT_MAINSPHASE;
                State.Ticks = 0;
                State.Laser397a = true;
                State.Laser397b = true;
                State.Laser866 = true;
                State.Laser854 = true;
                State.Laser729 = false;
                Node.Tag = State;

                Node = MeasureLoopNode.Nodes.Add("Cooling");
                State = new LaserState();
                State.Name = "Cooling";
                State.StateType = LaserState.PulseType.COUNT;
                State.Ticks = 250000;
                State.Laser397a = true;
                State.Laser397b = true;
                State.Laser866 = true;
                State.Laser854 = true;
                State.Laser729 = false;
                Node.Tag = State;

                Node = MeasureLoopNode.Nodes.Add("State Prepare");
                State = new LaserState();
                State.Name = "State Prepare";
                State.StateType = LaserState.PulseType.NORMAL;
                State.Ticks = 2000;
                State.Laser397a = true;
                State.Laser397b = false;
                State.Laser866 = true;
                State.Laser854 = true;
                State.Laser729 = false;
                Node.Tag = State;

                Node = MeasureLoopNode.Nodes.Add("729 Pulse");
                State = new LaserState();
                State.Name = "729 Pulse";
                State.StateType = LaserState.PulseType.NORMAL;
                State.Ticks = PulseLength;
                State.Laser397a = false;
                State.Laser397b = false;
                State.Laser866 = false;
                State.Laser854 = false;
                State.Laser729 = true;
                Node.Tag = State;

                Node = MeasureLoopNode.Nodes.Add("Count");
                State = new LaserState();
                State.Name = "Count";
                State.StateType = LaserState.PulseType.COUNT;
                State.Ticks = 250000;
                State.Laser397a = true;
                State.Laser397b = true;
                State.Laser866 = false;
                State.Laser854 = false;
                State.Laser729 = false;
                Node.Tag = State;

                Node = PulseTree.Nodes.Add("Send Data");
                LaserState SendDataState = new LaserState();
                SendDataState.Name = "Send Data";
                SendDataState.StateType = LaserState.PulseType.SENDDATA;
                SendDataState.Laser397a = true;
                SendDataState.Laser397b = true;
                SendDataState.Laser866 = true;
                SendDataState.Laser854 = true;
                SendDataState.Laser729 = false;
                Node.Tag = SendDataState;
            }

            TreeNode StopNode = PulseTree.Nodes.Add("Stop Experiment");
            LaserState StopState = new LaserState();
            StopState.Name = "Stop Experiment";
            StopState.StateType = LaserState.PulseType.STOP;
            StopNode.Tag = StopState;
            StopState.Laser397a = true;
            StopState.Laser397b = true;
            StopState.Laser866 = true;
            StopState.Laser854 = true;
            StopState.Laser729 = false;

            //PulseTree.ExpandAll();
            PulseTree.EndUpdate();
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

    }
}

