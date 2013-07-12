## Generated SDC file "CII_Starter_USB_API.out.sdc"

## Copyright (C) 1991-2011 Altera Corporation
## Your use of Altera Corporation's design tools, logic functions 
## and other software and tools, and its AMPP partner logic 
## functions, and any output files from any of the foregoing 
## (including device programming or simulation files), and any 
## associated documentation or information are expressly subject 
## to the terms and conditions of the Altera Program License 
## Subscription Agreement, Altera MegaCore Function License 
## Agreement, or other applicable license agreement, including, 
## without limitation, that your use is for the sole purpose of 
## programming logic devices manufactured by Altera and sold by 
## Altera or its authorized distributors.  Please refer to the 
## applicable agreement for further details.


## VENDOR  "Altera"
## PROGRAM "Quartus II"
## VERSION "Version 11.0 Build 208 07/03/2011 Service Pack 1 SJ Web Edition"

## DATE    "Mon Dec 12 10:58:55 2011"

##
## DEVICE  "EP2C20F484C7"
##


#**************************************************************
# Time Information
#**************************************************************

set_time_format -unit ns -decimal_places 3



#**************************************************************
# Create Clock
#**************************************************************

create_clock -name {TCK} -period 2.500 -waveform { 0.000 1.250 } [get_ports {TCK}]
create_clock -name {CLOCK_50} -period 20.000 -waveform { 0.000 10.000 } [get_ports {CLOCK_50}]
create_clock -name {CII_Starter_USB_API:inst|USB_JTAG:u1|mTCK} -period 100.000 -waveform { 0.000 0.500 } [get_registers { CII_Starter_USB_API:inst|USB_JTAG:u1|mTCK }]


#**************************************************************
# Create Generated Clock
#**************************************************************

create_generated_clock -name {CII_Starter_USB_API:inst|Multi_Sdram:u3|Sdram_Controller:u1|PLL1:sdram_pll1|altpll:altpll_component|_clk0} -source [get_pins {inst|u3|u1|sdram_pll1|altpll_component|pll|inclk[0]}] -duty_cycle 50.000 -multiply_by 1 -master_clock {CLOCK_50} [get_pins {inst|u3|u1|sdram_pll1|altpll_component|pll|clk[0]}] 
create_generated_clock -name {CII_Starter_USB_API:inst|Multi_Sdram:u3|Sdram_Controller:u1|PLL1:sdram_pll1|altpll:altpll_component|_clk2} -source [get_pins {inst|u3|u1|sdram_pll1|altpll_component|pll|inclk[0]}] -duty_cycle 50.000 -multiply_by 1 -master_clock {CLOCK_50} [get_pins {inst|u3|u1|sdram_pll1|altpll_component|pll|clk[2]}] 


#**************************************************************
# Set Clock Latency
#**************************************************************



#**************************************************************
# Set Clock Uncertainty
#**************************************************************



#**************************************************************
# Set Input Delay
#**************************************************************



#**************************************************************
# Set Output Delay
#**************************************************************



#**************************************************************
# Set Clock Groups
#**************************************************************

set_clock_groups -asynchronous -group [get_clocks {  CII_Starter_USB_API:inst|Multi_Sdram:u3|Sdram_Controller:u1|PLL1:sdram_pll1|altpll:altpll_component|_clk0  CII_Starter_USB_API:inst|Multi_Sdram:u3|Sdram_Controller:u1|PLL1:sdram_pll1|altpll:altpll_component|_clk2  CLOCK_50  }] -group [get_clocks {  TCK  }] 


#**************************************************************
# Set False Path
#**************************************************************



#**************************************************************
# Set Multicycle Path
#**************************************************************



#**************************************************************
# Set Maximum Delay
#**************************************************************



#**************************************************************
# Set Minimum Delay
#**************************************************************



#**************************************************************
# Set Input Transition
#**************************************************************

