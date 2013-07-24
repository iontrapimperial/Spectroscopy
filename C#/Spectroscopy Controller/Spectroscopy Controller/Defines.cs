using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spectroscopy_Controller
{
    partial class FPGA
    {
        //////////////////	Command Action	/////////////////////
        const byte	SETUP   = 	0x61;
        const byte	ERASE   = 	0x72;
        const byte	WRITE   =  	0x83;
        const byte	READ    =  	0x94;
        const byte	LCD_DAT	=	0x83;
        const byte	LCD_CMD = 	0x94;
        const byte	LASER_SETUP = 0xA3;
        //////////////////	Command Target	/////////////////////
        const byte	LED	  	=	0xF0;
        const byte	SEG7	=	   0xE1;
        const byte	PS2	  	=	0xD2;
        const byte	FLASH   = 	0xC3;
        const byte	SDRAM   = 	0xB4;
        const byte	SRAM	=	   0xA5;
        const byte	LCD   	=	0x96;
        const byte  VGA    =     0x87;
        const byte	SDRSEL  = 	0x1F;
        const byte	FLSEL	=   	0x2E;
        const byte	EXTIO	=   	0x3D;
        const byte	SET_REG =	   0x4C;
        const byte  SRSEL   =    0x5B;
        const byte	SETUPFINISH = 0xB7;
        const byte	READINGFINISH = 0xC6;
        const byte	INFOREQUEST = 0xF2;
        const byte  FINISHREQUEST = 0xD4;
        const byte  FREQFINISH = 0xE4;
        const byte  LASER_CMD = 0xD7;
        const byte  RESETFPGA = 0xE2;
        //////////////////	Command Mode	/////////////////////
        const byte	OUTSEL   = 	0x33;
        const byte	NORMAL   =   0xAA;
        const byte  DISPLAY  =   0xCC;
        const byte	BURST     =  0xFF;
        const byte  FILEUPLOAD = 0x4B;
    }
}

