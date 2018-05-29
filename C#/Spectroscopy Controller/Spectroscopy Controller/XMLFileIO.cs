using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Spectroscopy_Controller
{
    public partial class CoreForm : Form
    {
        /// <summary>
        /// Called after SaveXMLFileDialog has closed successfully. Saves XML file based on what is currently in PulseTree.
        /// </summary>
        void SaveXMLFile()
        {
            if (PulseTree.Nodes.Count == 0)
            {
                WriteMessage("Can't Save XML file: No laser states have been set", true);
                return;
            }

            XmlWriterSettings WriterSettings = new XmlWriterSettings();
            WriterSettings.Indent = true;
            WriterSettings.IndentChars = "\t";
            
            using (XmlWriter Writer = XmlWriter.Create(saveXMLFileDialog.FileName, WriterSettings))
            {
                Writer.WriteStartDocument();
                Writer.WriteStartElement("Experiment"); //XML requires only 1 root node so just use this. The actual name here doesn't matter

                ParsePulses(PulseTree.Nodes, Writer);

                Writer.WriteEndElement();
                Writer.WriteEndDocument();
            }            
        }

        /// <summary>
        /// Recursive method to parse PulseTree and write to specified XMLFile.
        /// </summary>
        /// <param name="Pulses">Collection of Tree Nodes to parse.</param>
        /// <param name="Writer">Open XmlWriter representing XML File to write to.</param>
        void ParsePulses(TreeNodeCollection Pulses, XmlWriter Writer)
        {
            for (int i = 0; i < Pulses.Count; i++)
            {
                if (Pulses[i].Tag is LaserState) //if this Pulse is a normal Laserstate output it.
                {
                    WriteLaserStateToFile((LaserState)Pulses[i].Tag, Writer);
                }
                else //it is a loop type
                {
                    Writer.WriteStartElement("Loop");
                    Writer.WriteAttributeString("LoopCount", ((LoopState)Pulses[i].Tag).LoopCount.ToString());
                    Writer.WriteAttributeString("Name", ((LoopState)Pulses[i].Tag).Name);

                    if (((LoopState)Pulses[i].Tag).bIsFPGALoop)
                    {
                        Writer.WriteAttributeString("FPGALoop", "True");
                    }
                    else
                    {
                        Writer.WriteAttributeString("FPGALoop", "False");
                    }

                    ParsePulses(Pulses[i].Nodes, Writer);

                    Writer.WriteEndElement();
                }
            }
        }

        /// <summary>
        /// Writes a LaserState XML element to file.
        /// </summary>
        /// <param name="State">LaserState to write.</param>
        /// <param name="Writer">Open XmlWriter representing XML File to write to.</param>
        void WriteLaserStateToFile(LaserState State, XmlWriter Writer)
        {
            Writer.WriteStartElement("Pulse");

            Writer.WriteAttributeString("Laser397B1", GetStringFromBool(State.Laser397B1));
            Writer.WriteAttributeString("Laser397B2", GetStringFromBool(State.Laser397B2));
            Writer.WriteAttributeString("Laser729", GetStringFromBool(State.Laser729));
            Writer.WriteAttributeString("Laser854", GetStringFromBool(State.Laser854));
            Writer.WriteAttributeString("Laser729RF1", GetStringFromBool(State.Laser729P0));
            Writer.WriteAttributeString("Laser729RF2", GetStringFromBool(State.Laser729P1));
            Writer.WriteAttributeString("Laser854POWER", GetStringFromBool(State.Laser854POWER));
            Writer.WriteAttributeString("Laser854FREQ", GetStringFromBool(State.Laser854FREQ));
            Writer.WriteAttributeString("LaserAux1", GetStringFromBool(State.LaserAux1));
            Writer.WriteAttributeString("LaserAux2", GetStringFromBool(State.Laser729P2));


            if (State.StateType == LaserState.PulseType.STARTLOOP)
            {
                Writer.WriteAttributeString("Type", "Other");
            }
            else if (State.StateType == LaserState.PulseType.NORMAL)
            {
                Writer.WriteAttributeString("Type", "Normal");
            }
            else if (State.StateType == LaserState.PulseType.WAIT_LABVIEW)
            {
                Writer.WriteAttributeString("Type", "Wait_Labview");
            }
            else if (State.StateType == LaserState.PulseType.WAIT_MAINSPHASE)
            {
                Writer.WriteAttributeString("Type", "Wait_MainsPhase");
            }
            else if (State.StateType == LaserState.PulseType.COUNT)
            {
                Writer.WriteAttributeString("Type", "Count");
            }
            else if (State.StateType == LaserState.PulseType.STOP)
            {
                Writer.WriteAttributeString("Type", "Stop");
            }
            else if (State.StateType == LaserState.PulseType.SENDDATA)
            {
                Writer.WriteAttributeString("Type", "SendData");
            }

            Writer.WriteAttributeString("Ticks", State.Ticks.ToString());
            Writer.WriteAttributeString("TargetLength", State.TargetLength.ToString());
            Writer.WriteAttributeString("Name", State.Name);
            Writer.WriteEndElement();
        }

        /// <summary>
        /// Returns "on"/"off" for true/false.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        String GetStringFromBool(bool b)
        {
            if (b)
            {
                return "on";
            }
            else
            {
                return "off";
            }
        }

        /// <summary>
        /// Called after OpenXMLFileDialog has closed successfully. Clears then populates PulseTree based on contents of chosen XML File.
        /// </summary>
        void OpenXMLFile()
        {
            XmlTextReader XMLFile = new XmlTextReader(openXMLFileDialog.FileName);

            List<TreeNode> NodeList = new List<TreeNode>();

            PulseTree.BeginUpdate();
            PulseTree.Nodes.Clear();
                       
            while (XMLFile.Read())
            {
                if (XMLFile.NodeType == XmlNodeType.Element)
                {
                    if (XMLFile.Name.ToUpper() == "Pulse".ToUpper())
                    {                        
                        LaserState State = CreateStateFromXMLLine(XMLFile);
                        TreeNode Node = new TreeNode();
                        Node.Text = State.Name;
                        Node.Tag = State;
                        NodeList.Add(Node);
                    }
                    else if (XMLFile.Name.ToUpper() == "Loop".ToUpper())
                    {
                        LoopState Loop = new LoopState();
                        while (XMLFile.MoveToNextAttribute())
                        {
                            if (XMLFile.Name.ToUpper() == "LoopCount".ToUpper())
                            {
                                Loop.LoopCount = System.Int32.Parse(XMLFile.Value);
                            }
                            else if (XMLFile.Name.ToUpper() == "Name".ToUpper())
                            {
                                Loop.Name = XMLFile.Value;
                            }
                            else if (XMLFile.Name.ToUpper() == "FPGALoop".ToUpper())
                            {
                                Loop.bIsFPGALoop = System.Boolean.Parse(XMLFile.Value);
                            }
                        }
                        TreeNode Node = ReadLoopIntoNode(new TreeNode(), XMLFile);

                        Node.Text = Loop.Name;
                        Node.Text += " (Loop x" + Loop.LoopCount + ")";
                        Node.Tag = Loop;
                        NodeList.Add(Node);    
                    }
                }
            }
            PulseTree.Nodes.AddRange(NodeList.ToArray());
            PulseTree.CollapseAll();
            PulseTree.EndUpdate();
            XMLFile.Close();
        }

        /// <summary>
        /// Recursive method to read nodes from XML File. Should be called after reading Loop opening element.
        /// </summary>
        /// <param name="Node">Node that childen are added to.</param>
        /// <param name="XMLFile">Open XmlTextReader representing XML File to read from.</param>
        /// <returns></returns>
        TreeNode ReadLoopIntoNode(TreeNode Node, XmlTextReader XMLFile)
        {
            while (XMLFile.Read())
            {
                if (XMLFile.NodeType == XmlNodeType.Element)
                {
                    if (XMLFile.Name.ToUpper() == "Pulse".ToUpper())
                    {
                        LaserState State = CreateStateFromXMLLine(XMLFile);
                        TreeNode T = Node.Nodes.Add(State.Name);
                        T.Tag = State;
                    }
                    else if (XMLFile.Name.ToUpper() == "Loop".ToUpper())
                    {
                        LoopState Loop = new LoopState();
                        while (XMLFile.MoveToNextAttribute())
                        {
                            if (XMLFile.Name.ToUpper() == "LoopCount".ToUpper())
                            {
                                Loop.LoopCount = System.Int32.Parse(XMLFile.Value);
                            }
                            else if (XMLFile.Name.ToUpper() == "Name".ToUpper())
                            {
                                Loop.Name = XMLFile.Value;
                            }
                        }
                        TreeNode T = ReadLoopIntoNode(new TreeNode(), XMLFile);
                        T.Text = Loop.Name;
                        T.Text += " (Loop x" + Loop.LoopCount + ")";
                        T.Tag = Loop;
                        Node.Nodes.Add(T);                       
                    }
                }
                else if (XMLFile.NodeType == XmlNodeType.EndElement)
                {
                    if (XMLFile.Name.ToUpper() == "Loop".ToUpper())
                    {
                        break;
                    }
                }
            }
            return Node;
        }

        /// <summary>
        /// Returns a LaserState from XML Line. Should be called after reading Pulse opening element.
        /// </summary>
        /// <param name="XMLFile">Open XmlTextReader representing XML File to read from.</param>
        /// <returns></returns>
        LaserState CreateStateFromXMLLine(XmlTextReader XMLFile)
        {
            LaserState State = new LaserState();
            bool bNameDefined = false; //If no name defined in the file then create one based on the pulse type
            #region XMLParseLine
            while (XMLFile.MoveToNextAttribute()) // Read every attribute
            {
                if (XMLFile.Name.ToUpper() == "Ticks".ToUpper())
                {
                    State.Ticks = System.Int32.Parse(XMLFile.Value);
                }
                else if (XMLFile.Name.ToUpper() == "TargetLength".ToUpper())
                {
                    State.TargetLength = float.Parse(XMLFile.Value); // int to float 08/08/17
                }
                else if (XMLFile.Name.ToUpper() == "Laser397B1".ToUpper())
                {
                    if (XMLFile.Value.ToUpper() == "on".ToUpper())
                    {
                        State.Laser397B1 = true;
                    }
                    else
                    {
                        State.Laser397B1 = false;
                    }
                }
                else if (XMLFile.Name.ToUpper() == "Laser397B2".ToUpper())
                {
                    if (XMLFile.Value.ToUpper() == "on".ToUpper())
                    {
                        State.Laser397B2 = true;
                    }
                    else
                    {
                        State.Laser397B2 = false;
                    }
                }
                else if (XMLFile.Name.ToUpper() == "Laser729".ToUpper())
                {
                    if (XMLFile.Value.ToUpper() == "on".ToUpper())
                    {
                        State.Laser729 = true;
                    }
                    else
                    {
                        State.Laser729 = false;
                    }
                }
                else if (XMLFile.Name.ToUpper() == "Laser854".ToUpper())
                {
                    if (XMLFile.Value.ToUpper() == "on".ToUpper())
                    {
                        State.Laser854 = true;
                    }
                    else
                    {
                        State.Laser854 = false;
                    }
                }
                else if (XMLFile.Name.ToUpper() == "Laser729RF1".ToUpper())
                {
                    if (XMLFile.Value.ToUpper() == "on".ToUpper())
                    {
                        State.Laser729P0 = true;
                    }
                    else
                    {
                        State.Laser729P0 = false;
                    }
                }
                else if (XMLFile.Name.ToUpper() == "Laser729RF2".ToUpper())
                {
                    if (XMLFile.Value.ToUpper() == "on".ToUpper())
                    {
                        State.Laser729P1 = true;
                    }
                    else
                    {
                        State.Laser729P1 = false;
                    }
                }
                else if (XMLFile.Name.ToUpper() == "Laser854POWER".ToUpper())
                {
                    if (XMLFile.Value.ToUpper() == "on".ToUpper())
                    {
                        State.Laser854POWER = true;
                    }
                    else
                    {
                        State.Laser854POWER = false;
                    }
                }
                else if (XMLFile.Name.ToUpper() == "Laser854FREQ".ToUpper())
                {
                    if (XMLFile.Value.ToUpper() == "on".ToUpper())
                    {
                        State.Laser854FREQ = true;
                    }
                    else
                    {
                        State.Laser854FREQ = false;
                    }
                }
                else if (XMLFile.Name.ToUpper() == "LaserAux1".ToUpper())
                {
                    if (XMLFile.Value.ToUpper() == "on".ToUpper())
                    {
                        State.LaserAux1 = true;
                    }
                    else
                    {
                        State.LaserAux1 = false;
                    }
                }
                else if (XMLFile.Name.ToUpper() == "LaserAux2".ToUpper())
                {
                    if (XMLFile.Value.ToUpper() == "on".ToUpper())
                    {
                        State.Laser729P2 = true;
                    }
                    else
                    {
                        State.Laser729P2 = false;
                    }
                }
                else if (XMLFile.Name.ToUpper() == "Type".ToUpper())
                {
                    if (XMLFile.Value.ToUpper() == "wait_labview".ToUpper())
                    {
                        State.StateType = LaserState.PulseType.WAIT_LABVIEW;
                        if (!bNameDefined)
                        {
                            State.Name = "Wait_Labview";
                        }
                    }
                    else if (XMLFile.Value.ToUpper() == "wait_mainsphase".ToUpper())
                    {
                        State.StateType = LaserState.PulseType.WAIT_MAINSPHASE;
                        if (!bNameDefined)
                        {
                            State.Name = "Wait_MainsPhase";
                        }
                    }
                    else if (XMLFile.Value.ToUpper() == "normal".ToUpper())
                    {
                        State.StateType = LaserState.PulseType.NORMAL;
                        if (!bNameDefined)
                        {
                            State.Name = "Normal";
                        }
                    }
                    else if (XMLFile.Value.ToUpper() == "count".ToUpper())
                    {
                        State.StateType = LaserState.PulseType.COUNT;
                        if (!bNameDefined)
                        {
                            State.Name = "Count";
                        }
                    }
                    else if (XMLFile.Value.ToUpper() == "stop".ToUpper())
                    {
                        State.StateType = LaserState.PulseType.STOP;
                        if (!bNameDefined)
                        {
                            State.Name = "Stop";
                        }
                    }
                    else if (XMLFile.Value.ToUpper() == "other".ToUpper())
                    {
                        State.StateType = LaserState.PulseType.STARTLOOP;
                        if (!bNameDefined)
                        {
                            State.Name = "Other";
                        }
                    }
                    else if (XMLFile.Value.ToUpper() == "senddata".ToUpper())
                    {
                        State.StateType = LaserState.PulseType.SENDDATA;
                        if (!bNameDefined)
                        {
                            State.Name = "SendData";
                        }
                    }
                }
                else if (XMLFile.Name.ToUpper() == "Name".ToUpper())
                {
                    State.Name = XMLFile.Value;
                    bNameDefined = true;
                }
            }
            #endregion

            return State;
        }

    }
}