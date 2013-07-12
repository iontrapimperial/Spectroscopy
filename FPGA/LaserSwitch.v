module LaserSwitch ( 
							iExperimentRunning,
							iLasersExperiment,
							iLasersIdle,
							oLasers);
input iExperimentRunning;
input [9:0] iLasersExperiment;			
input [9:0] iLasersIdle;
output [9:0] oLasers;

assign oLasers = (iExperimentRunning) ? iLasersExperiment:
													iLasersIdle;

//could probably just use a multiplexer for this...							
							
endmodule
