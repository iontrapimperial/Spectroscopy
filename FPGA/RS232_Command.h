//////////////////	Command Action	/////////////////////

// We mostly send the SETUP byte.  But sometimes it's handy to manualy control the RAM.  We can do that by sending erase, write etc.
parameter	SETUP	=	8'h61;
parameter	ERASE	=	8'h72;
parameter	WRITE	=	8'h83;
parameter	READ	=	8'h94;
parameter	LCD_DAT	=	8'h83;
parameter	LCD_CMD	=	8'h94;
parameter	LASER_SETUP = 8'hA3;



//////////////////	Command Target	/////////////////////
// Read and write to the SDRAM
parameter	SDRAM	=	8'hB4;	

// Read and write to the SRAM
parameter	SRAM	=	8'hA5;	

// Not used
parameter	LED		=	8'hF0;
parameter	SEG7	=	8'hE1;
parameter	PS2		=	8'hD2;
parameter	FLASH	=	8'hC3;
parameter	LCD		=	8'h96;
parameter	VGA		=	8'h87;
parameter	SDRSEL	=	8'h1F;
parameter	FLSEL	=	8'h2E;
parameter	EXTIO	=	8'h3D;
parameter	SET_REG	=	8'h4C;
parameter	SRSEL	=	8'h5B;
// // //

// Signal to tell the FPGA to start the experiment
parameter	SETUPFINISH = 8'hB7;

// This tells the FPGA that it has recieved all the PMT counts
parameter	READINGFINISH = 8'hC6;

// Ask the FPGA to re-send the request
parameter	INFOREQUEST = 8'hF2;

// PC confirms that a request has been recieved
parameter	FINISHREQUEST = 8'hD4;

// PC confirms that the AOM frequency has been changed
parameter   FREQFINISH = 8'hE4;

// Live control of the lasers
parameter	LASER_CMD = 8'hD7;

// Soft reset the FPGA
parameter	RESETFPGA = 8'hE2;



//////////////////	Command Mode	/////////////////////
// Not used
parameter	OUTSEL	=	8'h33;

// What is normal??  Good question.
parameter	NORMAL	= 	8'hAA;

// Not used
parameter	DISPLAY	=	8'hCC;

// Not used
parameter	BURST	= 	8'hFF; 

// We are about to upload data
parameter	FILEUPLOAD = 8'h4B;
