using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spectroscopy_Controller
{
    /// <summary>
    /// Base Class for Pulses. We need a base class so that LoopStates and LaserStates can be in the same array.
    /// </summary>
    abstract class Pulse 
    {
        /// <summary>
        /// The name of the Pulse. Defualt is "Undefined Name".
        /// </summary>
        public String Name = "Undefined Name";        
    }

    /// <summary>
    /// DataType indicating that sub-nodes should be looped by a set number of times.
    /// </summary>
    class LoopState : Pulse
    {
        /// <summary>
        /// Number of times this loop should execute.
        /// </summary>
        public int LoopCount = 1;

        /// <summary>
        /// True for a loop that the FPGA iterates over, false for one that gets unrolled into a long loop by this program.
        /// </summary>
        public bool bIsFPGALoop = false;

        public bool toSweep = false;

    }

    /// <summary>
    /// DataType describing an instruction that is run on the FPGA.
    /// </summary>
    class LaserState : Pulse
    {
        /// <summary>
        /// Different Instruction Types that can be used. Other should not be used and is left here for debugging.
        /// These should be in the same order as in the form ComboBox and the values must be the same as those defined when programming the FPGA.
        /// </summary>
        public enum PulseType
        {
            /// <summary>
            /// Should not be used. Remains here for debugging and shouldn't be removed. Binary 000.
            /// 20/06/2012: Changed to startloop
            /// </summary>
            STARTLOOP = 0,

            /// <summary>
            /// FPGA waits for labview input to go high. Binary 001.
            /// </summary>
            WAIT_LABVIEW = 1,

            /// <summary>
            /// Waits for rising edge of mains trigger. Binary 010.
            /// </summary>
            WAIT_MAINSPHASE = 2,

            /// <summary>
            /// State that lasts for specified number of Clock Cycles before moving to next instruction. Binary 011.
            /// </summary>
            NORMAL = 3,

            /// <summary>
            /// State that lasts for specified number of Clock Cycles before moving to next instruction. During state, FPGA will cound pulses from 
            /// PMT and then send the result to the PC (via USB) once the state finishes.
            /// </summary>
            COUNT = 4, //binary 100

            /// <summary>
            /// Stops FPGA from continuing. Should be last instruction sent.
            /// </summary>
            STOP = 5, //binary 101

            /// <summary>
            /// State tells FPGA to send signal to PC telling it to read data from SRam.
            /// </summary>
            SENDDATA = 6, //binary 110

            /// <summary>
            /// State tells FPGA to send signal to PC telling it to read data from SRam.
            /// </summary>
            ENDLOOP = 7, //binary 111
        }

        /// <summary>.
        /// Number of clock cycles this state should last for before moving to the next.
        /// </summary>
        public int Ticks = 0;
        public float TargetLength = 0; //Int to float 08/08/17

        /// <summary>
        /// True/False for a particular laser being on/off. Default is all are off. Profile 0 selected (all true)
        /// </summary>
        public bool Laser397B1 = false, Laser397B2 = false, Laser729 = false, Laser854 = false, Laser729P0 = true, Laser729P1 = false, Laser854POWER = false, Laser854FREQ = false,
        LaserAux1 = false, Laser729P2 = false;

        /// <summary>
        /// Indicates whether this pulse length should be swept for Rabi-type sequence
        /// </summary>
        public bool toSweep = false;        // Default is not swept

        /// <summary>
        /// Default pulse type is normal.
        /// </summary>
        public PulseType StateType = PulseType.NORMAL;
    }
}
