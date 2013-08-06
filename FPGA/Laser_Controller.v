module Laser_Controller(
										iCLOCK,
										iSD_DATA_FINISHED_UPLOAD, //from CPU, goes high when SETUPFINISH signal has been sent from computer
										
										iSD_DATA, //actual data
										iSD_DATA_READY, //from CPU&SDRAM, tells us when data is ready to be collected
										
										//iLABVIEW_READY, //input from labview
										iMAINS_PHASE, //input from mains phase trigger
										
										oSD_ADDR, //Address to read
										oSD_DATA_REQUEST, //push high when we want to read some data.
										
										oLasers, //output to lasers
										oRedLEDs, //this output is just a way to get debug info out. Not required.
										//iPMTCount, // Input from lpm_counter which counts pulses from PMT
										oPMTGate, //gates the PMT counter (high = count, low = don't)
										oPMTClear, //clears PMT count to zero
										oCountReady, //tells CPU block that we have a reading to store
										oCountData, //actual reading to send
										oSendData, //goes high when SENDDATA instruction occurs
										iFinishedSendingData,
										oExperimentStop,
										oFreqChange,
										iFreqChangeComplete,	
										iPMTCountA,
										iPMTCountB,
										iLaser397aLock,
										iLaser397bLock,
										iLaser854Lock,
										iLaser729Lock,
										oErrorSignal
										
);

input iLaser397aLock;
reg i397aLock;
input iLaser397bLock;
reg i397bLock;
input iLaser854Lock;
reg i854Lock;
input iLaser729Lock;
reg i729Lock;

output reg [15:0] oErrorSignal = 0; //bit 0 for 397a, 1 for 397b, 2 for 854, 3 for 729

input [31:0] iPMTCountA;
input [31:0] iPMTCountB;
output reg oExperimentStop = 0, oFreqChange = 0;
input iFreqChangeComplete;

input iFinishedSendingData;
output reg oSendData = 0;
output reg oCountReady = 0;
output reg [31:0] oCountData = 0;

//input [31:0] iPMTCount; //NB: we only send 20 of these bits to the PC. Left as 32 bits if this needs to be expanded.
input iCLOCK;
input iSD_DATA_FINISHED_UPLOAD;
output reg oPMTGate = 0, oPMTClear = 0;


input iSD_DATA_READY;
input [31:0] iSD_DATA;

//input iLABVIEW_READY;
input	iMAINS_PHASE;

output reg [9:0] oRedLEDs = 10'b0000000000;

`include "LaserInstructions.h"

///////////////////////////////////
///////////////////////////////////
// 		Instruction Definition  //
reg	[18:0] 	TicksToRun = 0; //(19 bits for timing)
reg	[9:0] 	LaserState = 0; //control 10 lasers
reg	[2:0]		ControlBits = 0; //3 bits to determine state type (normal, detection, wait etc)

reg f_ClearErrorSignal = 0; //goes high for one clock cycle to clear latches that store laser lock error signals

output reg [21:0] oSD_ADDR = 0;
output reg oSD_DATA_REQUEST = 0; 

output [9:0] oLasers;

assign oLasers = LaserState;


reg [18:0] Ticks = 19'd0; //Initialise ticks to zero.
reg [3:0] f_State = 0; //state variable for main loop

reg 	[31:0] NextInstruction = 0; //next instruction to use. Buffered so that we can switch between the two quickly
reg 	f_PrepNextInstruction = 0;
reg 	[3:0] f_InstructionState = 0;
reg	f_NextInstructionReady = 0;


//Detect rising edge of mains
//Will miss edge if it is simultaneous with clock edge. Todo: fix this!
/*reg     signal_prev; 
always @(posedge iCLOCK) begin signal_prev <= iMAINS_PHASE; end
 
wire f_MainsPhase;
assign f_MainsPhase = iMAINS_PHASE & ~signal_prev; //if Mains Phase is high and previous signal is low. This line is continuously run.
*/

reg [2:0] Buffer = 0;

reg f_MainsPhase_state = 1;
reg BufferSmoothed = 0;

reg f_MainsPhase = 0;

//Digitally filter serial input across 3 clock cycles
always@(posedge iCLOCK)
begin	
	Buffer <= { iMAINS_PHASE, Buffer[2], Buffer[1]};

	if(Buffer == 3'b111)
	begin
		BufferSmoothed <= 1;
	end
	else if(Buffer == 3'b000)
	begin
		BufferSmoothed <= 0;
	end
	
	if(f_MainsPhase_state == 1'b1)
	begin
		f_MainsPhase <= 0;
		if(BufferSmoothed == 1'b0)
		begin
			f_MainsPhase_state <= 0;		
		end
	end
	else
	begin
		if(BufferSmoothed == 1'b1)
		begin
			f_MainsPhase_state <= 1;
			f_MainsPhase <= 1;
		end	
	end
end



//Laser lock checks
//filter lock inputs across 1 clock cycle (latch on clock edge)
//this synchronises the inputs with our clock signal but we lose 20ns of timing.
always@(posedge iCLOCK)
begin	
	if(iLaser397aLock)
	begin
		oErrorSignal[0] <= 1;
		i397aLock <= 1;
	end
	else
	begin
		i397aLock <= 0;
	end
	
	if(f_ClearErrorSignal)
	begin
		oErrorSignal[0] <= 0;
	end	
end

always@(posedge iCLOCK)
begin	
	if(iLaser397bLock)
	begin
		oErrorSignal[1] <= 1;
		i397bLock <= 1;
	end
	else
	begin
		i397bLock <= 0;
	end
	
	if(f_ClearErrorSignal)
	begin
		oErrorSignal[1] <= 0;
	end
end

always@(posedge iCLOCK)
begin	
	if(iLaser854Lock)
	begin
		oErrorSignal[2] <= 1;
		i854Lock <= 1;
	end
	else
	begin
		i854Lock <= 0;
	end
	
	if(f_ClearErrorSignal)
	begin
		oErrorSignal[2] <= 0;
	end
end

always@(posedge iCLOCK)
begin	
	if(iLaser729Lock)
	begin
		oErrorSignal[3] <= 1;
		i729Lock <= 1;
	end
	else
	begin
		i729Lock <= 0;
	end
	
	if(f_ClearErrorSignal)
	begin
		oErrorSignal[3] <= 0;
	end
end

reg [21:0] f_NextAddress = 0; //the address of the next instruction we need (initially zero)
reg [21:0] f_LoopStartAddress = 0; //Address of the start of the loop (instruction AFTER Startloop command)
reg [18:0] f_LoopCount = 0; //Number of times to loop
reg [23:0] f_NumTimesLooped = 0; //Number of times we've run through a loop

//reg [31:0] x = 0;

//oRedLEDs = 10'b0000000000;

always@(posedge iCLOCK)
begin

//oRedLEDs <= 10'b1111111101;
	f_ClearErrorSignal <=0;
	oCountReady <= 0; //by default this should be zero. This line ensures that it goes high for only one clock cycle.
	oSendData <= 0;
	oFreqChange <= 0;
	
	if(iSD_DATA_FINISHED_UPLOAD == 1'b1) //if we have recieved a SetupFinish signal from the PC->FPGA->This block
	begin //originally we used a big case statement here (switch block in c/c++) but using nested if's is technically more stable (does use a bit more of the FPGA resources)
		if(f_State == 0)
		begin			
				f_NextAddress <= 0; //may not need?
				f_PrepNextInstruction <= 1; //load the next instruction
				f_NextInstructionReady <= 0;
				//oSD_ADDR <= 0;				
				//oSD_DATA_REQUEST <= 1'b1;
				
				f_State <= 1;	
		end			
		else if(f_State == 1)
			begin
				//if( iSD_DATA_READY == 1'b1)
				if(f_NextInstructionReady == 1'b1 && f_PrepNextInstruction == 1'b0)
				begin
						TicksToRun <= NextInstruction[31:13] << 5;		// Convert timing bits to ticks by adding 5 empty bits - ensures correct timing
						LaserState <= NextInstruction[12:3];
						ControlBits <= NextInstruction[2:0];
						f_PrepNextInstruction <= 1;
						f_State <= 2;
						
						// 10/07/13 Commented out code has NOT been changed to reflect new bit assignments (uncommented 6/8/2013, has now been changed)
						oSD_DATA_REQUEST <= 0;										
						Ticks <= 24'd0;
						TicksToRun <= iSD_DATA[31:13] << 5;
						LaserState <= iSD_DATA[12:3];
						ControlBits <= iSD_DATA[2:0];	
						f_PrepNextInstruction <= 1; //load the next instruction
						f_NextAddress <= f_NextAddress + 22'd1;
						f_State <= 2;
				end
			end		
		else if(f_State == 2)
		begin
				if(ControlBits == WAIT_LABVIEW)								
							begin	
									oFreqChange <= 1;
									if(iFreqChangeComplete) //simple test if labview signal is high
									begin											
										if(f_NextInstructionReady == 1'b1 && f_PrepNextInstruction == 1'b0)
										begin
											f_NextInstructionReady <= 0;
											Ticks <= 0;
											oFreqChange <= 0;
											TicksToRun <= NextInstruction[31:13] << 5;	// Convert timing bits to ticks by adding 5 empty bits - ensures correct timing
											LaserState <= NextInstruction[12:3];
											ControlBits <= NextInstruction[2:0];
											f_PrepNextInstruction <= 1;	
										end
										else
										begin
											oRedLEDs[9] <= 1;
										end
									end									
							end
							
				else if(ControlBits == WAIT_MAINSPHASE)
							begin
									if(f_MainsPhase == 1'b1 && 
										i397aLock == 1'b0		&&
										i397bLock == 1'b0		&&
										i854Lock == 1'b0		&&
										i729Lock == 1'b0		) //this goes high on rising edge of mains trigger									
									begin											
										if(f_NextInstructionReady == 1'b1 && f_PrepNextInstruction == 1'b0)
										begin
											f_NextInstructionReady <= 0;
											Ticks <= 0;
											TicksToRun <= NextInstruction[31:13] << 5;	// Convert timing bits to ticks by adding 5 empty bits - ensures correct timing
											LaserState <= NextInstruction[12:3];
											ControlBits <= NextInstruction[2:0];
											f_PrepNextInstruction <= 1;	
										end	
										else
										begin
											oRedLEDs[8] <= 1;
										end
									end									
							end
							
				else if(ControlBits == NORMAL) //normal state that just waits until alotted time has elapsed before moving on
							begin
								if(Ticks < TicksToRun)
								begin
									Ticks <= Ticks + 19'd1;
								end
								else	
								begin
									if(f_NextInstructionReady == 1'b1 && f_PrepNextInstruction == 1'b0)
									begin
										f_NextInstructionReady <= 0;
										Ticks <= 0;
										TicksToRun <= NextInstruction[31:13] << 5;	// Convert timing bits to ticks by adding 5 empty bits - ensures correct timing
										LaserState <= NextInstruction[12:3];
										ControlBits <= NextInstruction[2:0];
										f_PrepNextInstruction <= 1;	
									end
									else
									begin
										oRedLEDs[7] <= 1;
									end
								end
							end
							
				else if(ControlBits == COUNT) //similar to normal as we wait for a time before moving on. PMT counter is gated and then reading is sent after time has elapsed
							begin		// This happens during the count period
								if(Ticks < TicksToRun)
								begin
									oPMTGate <= 1;
									if(Ticks == 0)
									begin
										oPMTClear <= 1;	//make sure we send clear signal only 1 clock cycle (20ns) wide
															//clear at start of count instruction (as opposed to end) so that when we send data it's still there. 
															//Danger of clearing too early if we clear at the end.
									end
									else
									begin
										oPMTClear <= 0;
									end
									Ticks <= Ticks + 19'd1;									
								end
								else		// This is at the end of the count period
								begin	
									oPMTGate <= 0;
									f_ClearErrorSignal <= 1;									
									if(f_NextInstructionReady == 1'b1 && f_PrepNextInstruction == 1'b0)
									begin
										f_NextInstructionReady <= 0;
										Ticks <= 0;
										oCountReady <= 1;										
										oCountData <= iPMTCountA + iPMTCountB;
										//oErrorSignal <= 7;  Automatically taken care of
										//oCountData <= x;
										//x <= x + 1;
									
										TicksToRun <= NextInstruction[31:13] << 5;	// Convert timing bits to ticks by adding 5 empty bits - ensures correct timing
										LaserState <= NextInstruction[12:3];
										ControlBits <= NextInstruction[2:0];
										f_PrepNextInstruction <= 1;	
									end
									else
									begin
										oRedLEDs[6] <= 1;
									end
								end
							end
				else if(ControlBits == SENDDATA) 
							begin	
								oSendData <= 1;
								if(iFinishedSendingData == 1'b1)
								begin									
									if(f_NextInstructionReady == 1'b1 && f_PrepNextInstruction == 1'b0)
									begin		
										f_NextInstructionReady <= 0;
										oSendData <= 0;
										Ticks <= 0;
										TicksToRun <= NextInstruction[31:13] << 5;	// Convert timing bits to ticks by adding 5 empty bits - ensures correct timing
										LaserState <= NextInstruction[12:3];
										ControlBits <= NextInstruction[2:0];
										f_PrepNextInstruction <= 1;	
									end
									else
									begin
										oRedLEDs[5] <= 1;
									end
								end
							end			
							
				else if(ControlBits == STOP) //Just lock out once we get to this stage.
							begin	
								oExperimentStop <= 1;
								
								//TODO: send finish signal to PC (Done)
								//TODO: reset FPGA? (Kind of Done..can send back reset manually)
							end
				else
				begin
						oRedLEDs <= 10'b1010101010; //should never get to this point really...
				end				
		end
		else
		begin
			oRedLEDs <= 10'b1111111111; //should not get here either.
		end //Closes: if(f_State == 0)
		
	if(f_PrepNextInstruction == 1) //if we need to read the next instruction (one after the currently running one)
		begin
			case(f_InstructionState)
				0: begin						
						oSD_ADDR <= f_NextAddress * 22'd2; //instructions live in memory and multiples of two (each memory slot is 16 bits) so multiply by 2 to get the actual address we want. Could just add 2 every time instead				
						oSD_DATA_REQUEST <= 1'b1;
						f_InstructionState <= 1;
						f_NextInstructionReady <= 0;
					end
				1: begin						
						if( iSD_DATA_READY == 1'b1)
						begin							
							oSD_DATA_REQUEST <= 0;
							
							if(iSD_DATA[2:0] == STARTLOOP) //if the next instruction coming in is the start of a loop
							begin
								f_LoopStartAddress <= f_NextAddress + 22'd1; //save loop info
								f_LoopCount <= iSD_DATA[31:13];
								
								f_InstructionState <= 0; //load the next instruction in memory
								f_PrepNextInstruction <= 1;
								f_NextAddress <= f_NextAddress + 22'd1;
								f_NextInstructionReady <= 0;
								
								f_NumTimesLooped <= 0; //reset the number of times we've looped to zero.
								
								oSD_DATA_REQUEST <= 1;								
							end
							else if(iSD_DATA[2:0] == ENDLOOP)
							begin
								if(f_NumTimesLooped < (f_LoopCount - 1))
								begin
										//loop again
										f_NumTimesLooped <= f_NumTimesLooped + 24'd1;
										f_NextAddress <= f_LoopStartAddress;
										
										f_InstructionState <= 0; //load the next instruction in memory
										f_PrepNextInstruction <= 1;										
										f_NextInstructionReady <= 0;

										oSD_DATA_REQUEST <= 1;	
								end
								else
								begin
										//don't loop again. Treat like a normal command
										f_InstructionState <= 0; //load the next instruction in memory
										f_NextAddress <= f_NextAddress + 22'd1;
										f_PrepNextInstruction <= 1;										
										f_NextInstructionReady <= 0;

										oSD_DATA_REQUEST <= 1;
								end
							end
							else
							begin //normal command.							
								NextInstruction <= iSD_DATA; //buffer the instruction
								f_InstructionState <= 0;									
								f_PrepNextInstruction <= 0;
								f_NextAddress <= f_NextAddress + 22'd1;
								f_NextInstructionReady <= 1'b1;
							end
						end						
					end
			endcase	
		end		
		
	end //Closes: if(iSD_DATA_FINISHED_UPLOAD == 1'b1)
	else
	begin //this resets some variables so the FPGA is ready to go again.
		f_State <= 0;	
		f_NextAddress <= 0;
		oExperimentStop <= 0;
		f_LoopStartAddress <= 0; 
		f_LoopCount <= 0;
	end
	
	
	
end

                                                                                  
endmodule
