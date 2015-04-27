using System;

namespace Spectroscopy_Controller
{


    public class AndorCamera
    {
        public AndorCamera()
        {
            // If FTD2XX.DLL is NOT loaded already, load it
            if (atmcDLL == IntPtr.Zero)
            {
                // Load our FTD2XX.DLL library
                atmcDLL = LoadLibrary(@"ATMCD32CS.dll");
                if (atmcDLL == IntPtr.Zero)
                {
                    // Failed to load our FTD2XX.DLL library from System32 or the application directory
                    // Try the same directory that this FTD2XX_NET DLL is in
                    MessageBox.Show("Attempting to load ATMCD32CS.dll from:\n" + Path.GetDirectoryName(GetType().Assembly.Location));
                    atmcDLL = LoadLibrary(@Path.GetDirectoryName(GetType().Assembly.Location) + "\\ATMCD32CS.dll");
                }
            }

            
            /// Return Type: unsigned int
             ///dir: char*
            //[System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="Initialize")]
          //  public static extern  uint Initialize(System.IntPtr dir) ;

            if (atmcDLL != IntPtr.Zero)
            {
                Initialize = GetProcAddress(atmcDLL, "Initialize");
                SetShutter = GetProcAddress(atmcDLL, "SetShutter");
            }
            else
            {
                // Failed to load our DLL - alert the user
                MessageBox.Show("Failed to load FTD2XX.DLL.  Are the FTDI drivers installed?");
            }
        }

        ~AndorCamera()
        {
            // FreeLibrary here - we should only do this if we are completely finished
            FreeLibrary(atmcDLL);
            atmcDLL = IntPtr.Zero;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate FT_STATUS Initialize(IntPtr ftHandle, ref UInt32 lpdwAmountInRxQueue);









        }
    }
}


/*
// Warning: <unknown> 603: Encountered an empty #define

public partial class NativeConstants {
    
    /// __atmcd32d_h -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    public const string @__atmcd32d_h = "";
    
    /// at_32 -> long
    /// Error generating expression: Value long is not resolved
    public const string at_32 = "long";
    
    /// at_u32 -> unsigned long
    /// Error generating expression: Expression is not parsable.  Treating value as a raw string
    public const string at_u32 = "unsigned long";
    
    /// at_64 -> long long
    /// Error generating expression: Expression is not parsable.  Treating value as a raw string
    public const string at_64 = "long long";
    
    /// at_u64 -> unsigned long long
    /// Error generating expression: Expression is not parsable.  Treating value as a raw string
    public const string at_u64 = "unsigned long long";
    
    /// AT_NoOfVersionInfoIds -> 2
    public const int AT_NoOfVersionInfoIds = 2;
    
    /// AT_VERSION_INFO_LEN -> 80
    public const int AT_VERSION_INFO_LEN = 80;
    
    /// AT_CONTROLLER_CARD_MODEL_LEN -> 80
    public const int AT_CONTROLLER_CARD_MODEL_LEN = 80;
    
    /// AT_DDGLite_ControlBit_GlobalEnable -> 0x01
    public const int AT_DDGLite_ControlBit_GlobalEnable = 1;
    
    /// AT_DDGLite_ControlBit_ChannelEnable -> 0x01
    public const int AT_DDGLite_ControlBit_ChannelEnable = 1;
    
    /// AT_DDGLite_ControlBit_FreeRun -> 0x02
    public const int AT_DDGLite_ControlBit_FreeRun = 2;
    
    /// AT_DDGLite_ControlBit_DisableOnFrame -> 0x04
    public const int AT_DDGLite_ControlBit_DisableOnFrame = 4;
    
    /// AT_DDGLite_ControlBit_RestartOnFire -> 0x08
    public const int AT_DDGLite_ControlBit_RestartOnFire = 8;
    
    /// AT_DDGLite_ControlBit_Invert -> 0x10
    public const int AT_DDGLite_ControlBit_Invert = 16;
    
    /// AT_DDGLite_ControlBit_EnableOnFire -> 0x20
    public const int AT_DDGLite_ControlBit_EnableOnFire = 32;
    
    /// AT_DDG_POLARITY_POSITIVE -> 0
    public const int AT_DDG_POLARITY_POSITIVE = 0;
    
    /// AT_DDG_POLARITY_NEGATIVE -> 1
    public const int AT_DDG_POLARITY_NEGATIVE = 1;
    
    /// AT_DDG_TERMINATION_50OHMS -> 0
    public const int AT_DDG_TERMINATION_50OHMS = 0;
    
    /// AT_DDG_TERMINATION_HIGHZ -> 1
    public const int AT_DDG_TERMINATION_HIGHZ = 1;
    
    /// AT_STEPMODE_CONSTANT -> 0
    public const int AT_STEPMODE_CONSTANT = 0;
    
    /// AT_STEPMODE_EXPONENTIAL -> 1
    public const int AT_STEPMODE_EXPONENTIAL = 1;
    
    /// AT_STEPMODE_LOGARITHMIC -> 2
    public const int AT_STEPMODE_LOGARITHMIC = 2;
    
    /// AT_STEPMODE_LINEAR -> 3
    public const int AT_STEPMODE_LINEAR = 3;
    
    /// AT_STEPMODE_OFF -> 100
    public const int AT_STEPMODE_OFF = 100;
    
    /// AT_GATEMODE_FIRE_AND_GATE -> 0
    public const int AT_GATEMODE_FIRE_AND_GATE = 0;
    
    /// AT_GATEMODE_FIRE_ONLY -> 1
    public const int AT_GATEMODE_FIRE_ONLY = 1;
    
    /// AT_GATEMODE_GATE_ONLY -> 2
    public const int AT_GATEMODE_GATE_ONLY = 2;
    
    /// AT_GATEMODE_CW_ON -> 3
    public const int AT_GATEMODE_CW_ON = 3;
    
    /// AT_GATEMODE_CW_OFF -> 4
    public const int AT_GATEMODE_CW_OFF = 4;
    
    /// AT_GATEMODE_DDG -> 5
    public const int AT_GATEMODE_DDG = 5;
    
    /// DRV_ERROR_CODES -> 20001
    public const int DRV_ERROR_CODES = 20001;
    
    /// DRV_SUCCESS -> 20002
    public const int DRV_SUCCESS = 20002;
    
    /// DRV_VXDNOTINSTALLED -> 20003
    public const int DRV_VXDNOTINSTALLED = 20003;
    
    /// DRV_ERROR_SCAN -> 20004
    public const int DRV_ERROR_SCAN = 20004;
    
    /// DRV_ERROR_CHECK_SUM -> 20005
    public const int DRV_ERROR_CHECK_SUM = 20005;
    
    /// DRV_ERROR_FILELOAD -> 20006
    public const int DRV_ERROR_FILELOAD = 20006;
    
    /// DRV_UNKNOWN_FUNCTION -> 20007
    public const int DRV_UNKNOWN_FUNCTION = 20007;
    
    /// DRV_ERROR_VXD_INIT -> 20008
    public const int DRV_ERROR_VXD_INIT = 20008;
    
    /// DRV_ERROR_ADDRESS -> 20009
    public const int DRV_ERROR_ADDRESS = 20009;
    
    /// DRV_ERROR_PAGELOCK -> 20010
    public const int DRV_ERROR_PAGELOCK = 20010;
    
    /// DRV_ERROR_PAGEUNLOCK -> 20011
    public const int DRV_ERROR_PAGEUNLOCK = 20011;
    
    /// DRV_ERROR_BOARDTEST -> 20012
    public const int DRV_ERROR_BOARDTEST = 20012;
    
    /// DRV_ERROR_ACK -> 20013
    public const int DRV_ERROR_ACK = 20013;
    
    /// DRV_ERROR_UP_FIFO -> 20014
    public const int DRV_ERROR_UP_FIFO = 20014;
    
    /// DRV_ERROR_PATTERN -> 20015
    public const int DRV_ERROR_PATTERN = 20015;
    
    /// DRV_ACQUISITION_ERRORS -> 20017
    public const int DRV_ACQUISITION_ERRORS = 20017;
    
    /// DRV_ACQ_BUFFER -> 20018
    public const int DRV_ACQ_BUFFER = 20018;
    
    /// DRV_ACQ_DOWNFIFO_FULL -> 20019
    public const int DRV_ACQ_DOWNFIFO_FULL = 20019;
    
    /// DRV_PROC_UNKONWN_INSTRUCTION -> 20020
    public const int DRV_PROC_UNKONWN_INSTRUCTION = 20020;
    
    /// DRV_ILLEGAL_OP_CODE -> 20021
    public const int DRV_ILLEGAL_OP_CODE = 20021;
    
    /// DRV_KINETIC_TIME_NOT_MET -> 20022
    public const int DRV_KINETIC_TIME_NOT_MET = 20022;
    
    /// DRV_ACCUM_TIME_NOT_MET -> 20023
    public const int DRV_ACCUM_TIME_NOT_MET = 20023;
    
    /// DRV_NO_NEW_DATA -> 20024
    public const int DRV_NO_NEW_DATA = 20024;
    
    /// DRV_PCI_DMA_FAIL -> 20025
    public const int DRV_PCI_DMA_FAIL = 20025;
    
    /// DRV_SPOOLERROR -> 20026
    public const int DRV_SPOOLERROR = 20026;
    
    /// DRV_SPOOLSETUPERROR -> 20027
    public const int DRV_SPOOLSETUPERROR = 20027;
    
    /// DRV_FILESIZELIMITERROR -> 20028
    public const int DRV_FILESIZELIMITERROR = 20028;
    
    /// DRV_ERROR_FILESAVE -> 20029
    public const int DRV_ERROR_FILESAVE = 20029;
    
    /// DRV_TEMPERATURE_CODES -> 20033
    public const int DRV_TEMPERATURE_CODES = 20033;
    
    /// DRV_TEMPERATURE_OFF -> 20034
    public const int DRV_TEMPERATURE_OFF = 20034;
    
    /// DRV_TEMPERATURE_NOT_STABILIZED -> 20035
    public const int DRV_TEMPERATURE_NOT_STABILIZED = 20035;
    
    /// DRV_TEMPERATURE_STABILIZED -> 20036
    public const int DRV_TEMPERATURE_STABILIZED = 20036;
    
    /// DRV_TEMPERATURE_NOT_REACHED -> 20037
    public const int DRV_TEMPERATURE_NOT_REACHED = 20037;
    
    /// DRV_TEMPERATURE_OUT_RANGE -> 20038
    public const int DRV_TEMPERATURE_OUT_RANGE = 20038;
    
    /// DRV_TEMPERATURE_NOT_SUPPORTED -> 20039
    public const int DRV_TEMPERATURE_NOT_SUPPORTED = 20039;
    
    /// DRV_TEMPERATURE_DRIFT -> 20040
    public const int DRV_TEMPERATURE_DRIFT = 20040;
    
    /// DRV_TEMP_CODES -> 20033
    public const int DRV_TEMP_CODES = 20033;
    
    /// DRV_TEMP_OFF -> 20034
    public const int DRV_TEMP_OFF = 20034;
    
    /// DRV_TEMP_NOT_STABILIZED -> 20035
    public const int DRV_TEMP_NOT_STABILIZED = 20035;
    
    /// DRV_TEMP_STABILIZED -> 20036
    public const int DRV_TEMP_STABILIZED = 20036;
    
    /// DRV_TEMP_NOT_REACHED -> 20037
    public const int DRV_TEMP_NOT_REACHED = 20037;
    
    /// DRV_TEMP_OUT_RANGE -> 20038
    public const int DRV_TEMP_OUT_RANGE = 20038;
    
    /// DRV_TEMP_NOT_SUPPORTED -> 20039
    public const int DRV_TEMP_NOT_SUPPORTED = 20039;
    
    /// DRV_TEMP_DRIFT -> 20040
    public const int DRV_TEMP_DRIFT = 20040;
    
    /// DRV_GENERAL_ERRORS -> 20049
    public const int DRV_GENERAL_ERRORS = 20049;
    
    /// DRV_INVALID_AUX -> 20050
    public const int DRV_INVALID_AUX = 20050;
    
    /// DRV_COF_NOTLOADED -> 20051
    public const int DRV_COF_NOTLOADED = 20051;
    
    /// DRV_FPGAPROG -> 20052
    public const int DRV_FPGAPROG = 20052;
    
    /// DRV_FLEXERROR -> 20053
    public const int DRV_FLEXERROR = 20053;
    
    /// DRV_GPIBERROR -> 20054
    public const int DRV_GPIBERROR = 20054;
    
    /// DRV_EEPROMVERSIONERROR -> 20055
    public const int DRV_EEPROMVERSIONERROR = 20055;
    
    /// DRV_DATATYPE -> 20064
    public const int DRV_DATATYPE = 20064;
    
    /// DRV_DRIVER_ERRORS -> 20065
    public const int DRV_DRIVER_ERRORS = 20065;
    
    /// DRV_P1INVALID -> 20066
    public const int DRV_P1INVALID = 20066;
    
    /// DRV_P2INVALID -> 20067
    public const int DRV_P2INVALID = 20067;
    
    /// DRV_P3INVALID -> 20068
    public const int DRV_P3INVALID = 20068;
    
    /// DRV_P4INVALID -> 20069
    public const int DRV_P4INVALID = 20069;
    
    /// DRV_INIERROR -> 20070
    public const int DRV_INIERROR = 20070;
    
    /// DRV_COFERROR -> 20071
    public const int DRV_COFERROR = 20071;
    
    /// DRV_ACQUIRING -> 20072
    public const int DRV_ACQUIRING = 20072;
    
    /// DRV_IDLE -> 20073
    public const int DRV_IDLE = 20073;
    
    /// DRV_TEMPCYCLE -> 20074
    public const int DRV_TEMPCYCLE = 20074;
    
    /// DRV_NOT_INITIALIZED -> 20075
    public const int DRV_NOT_INITIALIZED = 20075;
    
    /// DRV_P5INVALID -> 20076
    public const int DRV_P5INVALID = 20076;
    
    /// DRV_P6INVALID -> 20077
    public const int DRV_P6INVALID = 20077;
    
    /// DRV_INVALID_MODE -> 20078
    public const int DRV_INVALID_MODE = 20078;
    
    /// DRV_INVALID_FILTER -> 20079
    public const int DRV_INVALID_FILTER = 20079;
    
    /// DRV_I2CERRORS -> 20080
    public const int DRV_I2CERRORS = 20080;
    
    /// DRV_I2CDEVNOTFOUND -> 20081
    public const int DRV_I2CDEVNOTFOUND = 20081;
    
    /// DRV_I2CTIMEOUT -> 20082
    public const int DRV_I2CTIMEOUT = 20082;
    
    /// DRV_P7INVALID -> 20083
    public const int DRV_P7INVALID = 20083;
    
    /// DRV_P8INVALID -> 20084
    public const int DRV_P8INVALID = 20084;
    
    /// DRV_P9INVALID -> 20085
    public const int DRV_P9INVALID = 20085;
    
    /// DRV_P10INVALID -> 20086
    public const int DRV_P10INVALID = 20086;
    
    /// DRV_P11INVALID -> 20087
    public const int DRV_P11INVALID = 20087;
}

public enum AT_VersionInfoId {
    
    /// AT_SDKVersion -> 0x40000000
    AT_SDKVersion = 1073741824,
    
    /// AT_DeviceDriverVersion -> 0x40000001
    AT_DeviceDriverVersion = 1073741825,
}

public enum AT_DDGLiteChannelId {
    
    /// AT_DDGLite_ChannelA -> 0x40000000
    AT_DDGLite_ChannelA = 1073741824,
    
    /// AT_DDGLite_ChannelB -> 0x40000001
    AT_DDGLite_ChannelB = 1073741825,
    
    /// AT_DDGLite_ChannelC -> 0x40000002
    AT_DDGLite_ChannelC = 1073741826,
}

[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct ANDORCAPS {
    
    /// ULONG->unsigned int
    public uint ulSize;
    
    /// ULONG->unsigned int
    public uint ulAcqModes;
    
    /// ULONG->unsigned int
    public uint ulReadModes;
    
    /// ULONG->unsigned int
    public uint ulTriggerModes;
    
    /// ULONG->unsigned int
    public uint ulCameraType;
    
    /// ULONG->unsigned int
    public uint ulPixelMode;
    
    /// ULONG->unsigned int
    public uint ulSetFunctions;
    
    /// ULONG->unsigned int
    public uint ulGetFunctions;
    
    /// ULONG->unsigned int
    public uint ulFeatures;
    
    /// ULONG->unsigned int
    public uint ulPCICard;
    
    /// ULONG->unsigned int
    public uint ulEMGainCapability;
    
    /// ULONG->unsigned int
    public uint ulFTReadModes;
}

[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct COLORDEMOSAICINFO {
    
    /// int
    public int iX;
    
    /// int
    public int iY;
    
    /// int
    public int iAlgorithm;
    
    /// int
    public int iXPhase;
    
    /// int
    public int iYPhase;
    
    /// int
    public int iBackground;
}

[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct WHITEBALANCEINFO {
    
    /// int
    public int iSize;
    
    /// int
    public int iX;
    
    /// int
    public int iY;
    
    /// int
    public int iAlgorithm;
    
    /// int
    public int iROI_left;
    
    /// int
    public int iROI_right;
    
    /// int
    public int iROI_top;
    
    /// int
    public int iROI_bottom;
    
    /// int
    public int iOperation;
}

[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct SYSTEMTIME {
    
    /// WORD->unsigned short
    public ushort wYear;
    
    /// WORD->unsigned short
    public ushort wMonth;
    
    /// WORD->unsigned short
    public ushort wDayOfWeek;
    
    /// WORD->unsigned short
    public ushort wDay;
    
    /// WORD->unsigned short
    public ushort wHour;
    
    /// WORD->unsigned short
    public ushort wMinute;
    
    /// WORD->unsigned short
    public ushort wSecond;
    
    /// WORD->unsigned short
    public ushort wMilliseconds;
}

[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct HWND__ {
    
    /// int
    public int unused;
}

public partial class NativeMethods {
    
    /// Return Type: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="AbortAcquisition")]
public static extern  uint AbortAcquisition() ;

    
    /// Return Type: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="CancelWait")]
public static extern  uint CancelWait() ;

    
    /// Return Type: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="CoolerOFF")]
public static extern  uint CoolerOFF() ;

    
    /// Return Type: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="CoolerON")]
public static extern  uint CoolerON() ;

    
    /// Return Type: unsigned int
    ///grey: WORD*
    ///red: WORD*
    ///green: WORD*
    ///blue: WORD*
    ///info: ColorDemosaicInfo*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="DemosaicImage")]
public static extern  uint DemosaicImage(ref ushort grey, ref ushort red, ref ushort green, ref ushort blue, ref COLORDEMOSAICINFO info) ;

    
    /// Return Type: unsigned int
    ///iMode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="EnableKeepCleans")]
public static extern  uint EnableKeepCleans(int iMode) ;

    
    /// Return Type: unsigned int
    ///iMode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="EnableSensorCompensation")]
public static extern  uint EnableSensorCompensation(int iMode) ;

    
    /// Return Type: unsigned int
    ///mode: char
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetIRIGModulation")]
public static extern  uint SetIRIGModulation(byte mode) ;

    
    /// Return Type: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="FreeInternalMemory")]
public static extern  uint FreeInternalMemory() ;

    
    /// Return Type: unsigned int
    ///arr: int*
    ///size: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetAcquiredData")]
public static extern  uint GetAcquiredData(ref int arr, uint size) ;

    
    /// Return Type: unsigned int
    ///arr: WORD*
    ///size: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetAcquiredData16")]
public static extern  uint GetAcquiredData16(ref ushort arr, uint size) ;

    
    /// Return Type: unsigned int
    ///arr: float*
    ///size: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetAcquiredFloatData")]
public static extern  uint GetAcquiredFloatData(ref float arr, uint size) ;

    
    /// Return Type: unsigned int
    ///acc: int*
    ///series: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetAcquisitionProgress")]
public static extern  uint GetAcquisitionProgress(ref int acc, ref int series) ;

    
    /// Return Type: unsigned int
    ///exposure: float*
    ///accumulate: float*
    ///kinetic: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetAcquisitionTimings")]
public static extern  uint GetAcquisitionTimings(ref float exposure, ref float accumulate, ref float kinetic) ;

    
    /// Return Type: unsigned int
    ///inumTimes: int
    ///fptimes: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetAdjustedRingExposureTimes")]
public static extern  uint GetAdjustedRingExposureTimes(int inumTimes, ref float fptimes) ;

    
    /// Return Type: unsigned int
    ///arr: int*
    ///size: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetAllDMAData")]
public static extern  uint GetAllDMAData(ref int arr, uint size) ;

    
    /// Return Type: unsigned int
    ///index: int
    ///name: char*
    ///length: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetAmpDesc")]
public static extern  uint GetAmpDesc(int index, System.IntPtr name, int length) ;

    
    /// Return Type: unsigned int
    ///index: int
    ///speed: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetAmpMaxSpeed")]
public static extern  uint GetAmpMaxSpeed(int index, ref float speed) ;

    
    /// Return Type: unsigned int
    ///totalCameras: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetAvailableCameras")]
public static extern  uint GetAvailableCameras(ref int totalCameras) ;

    
    /// Return Type: unsigned int
    ///arr: int*
    ///size: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetBackground")]
public static extern  uint GetBackground(ref int arr, uint size) ;

    
    /// Return Type: unsigned int
    ///state: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetBaselineClamp")]
public static extern  uint GetBaselineClamp(ref int state) ;

    
    /// Return Type: unsigned int
    ///channel: int
    ///depth: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetBitDepth")]
public static extern  uint GetBitDepth(int channel, ref int depth) ;

    
    /// Return Type: unsigned int
    ///camStatus: DWORD*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetCameraEventStatus")]
public static extern  uint GetCameraEventStatus(ref uint camStatus) ;

    
    /// Return Type: unsigned int
    ///cameraIndex: int
    ///cameraHandle: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetCameraHandle")]
public static extern  uint GetCameraHandle(int cameraIndex, ref int cameraHandle) ;

    
    /// Return Type: unsigned int
    ///index: int
    ///information: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetCameraInformation")]
public static extern  uint GetCameraInformation(int index, ref int information) ;

    
    /// Return Type: unsigned int
    ///number: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetCameraSerialNumber")]
public static extern  uint GetCameraSerialNumber(ref int number) ;

    
    /// Return Type: unsigned int
    ///caps: AndorCapabilities*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetCapabilities")]
public static extern  uint GetCapabilities(ref ANDORCAPS caps) ;

    
    /// Return Type: unsigned int
    ///controllerCardModel: char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetControllerCardModel")]
public static extern  uint GetControllerCardModel(System.IntPtr controllerCardModel) ;

    
    /// Return Type: unsigned int
    ///minval: float*
    ///maxval: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetCountConvertWavelengthRange")]
public static extern  uint GetCountConvertWavelengthRange(ref float minval, ref float maxval) ;

    
    /// Return Type: unsigned int
    ///cameraHandle: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetCurrentCamera")]
public static extern  uint GetCurrentCamera(ref int cameraHandle) ;

    
    /// Return Type: unsigned int
    ///iXshift: int*
    ///iYShift: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetCYMGShift")]
public static extern  uint GetCYMGShift(ref int iXshift, ref int iYShift) ;

    
    /// Return Type: unsigned int
    ///uiIndex: unsigned int
    ///puiEnabled: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGExternalOutputEnabled")]
public static extern  uint GetDDGExternalOutputEnabled(uint uiIndex, ref uint puiEnabled) ;

    
    /// Return Type: unsigned int
    ///uiIndex: unsigned int
    ///puiPolarity: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGExternalOutputPolarity")]
public static extern  uint GetDDGExternalOutputPolarity(uint uiIndex, ref uint puiPolarity) ;

    
    /// Return Type: unsigned int
    ///uiIndex: unsigned int
    ///puiEnabled: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGExternalOutputStepEnabled")]
public static extern  uint GetDDGExternalOutputStepEnabled(uint uiIndex, ref uint puiEnabled) ;

    
    /// Return Type: unsigned int
    ///uiIndex: unsigned int
    ///param1: unsigned int
    ///puiDelay: int*
    ///param3: unsigned int
    ///puiWidth: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGExternalOutputTime")]
public static extern  uint GetDDGExternalOutputTime(uint uiIndex, uint param1, ref int puiDelay, uint param3, ref int puiWidth) ;

    
    /// Return Type: unsigned int
    ///param0: unsigned int
    ///opticalWidth: int
    ///param2: unsigned int
    ///ttlWidth: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGTTLGateWidth")]
public static extern  uint GetDDGTTLGateWidth(uint param0, int opticalWidth, uint param2, ref int ttlWidth) ;

    
    /// Return Type: unsigned int
    ///param0: unsigned int
    ///puiDelay: int*
    ///param2: unsigned int
    ///puiWidth: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGGateTime")]
public static extern  uint GetDDGGateTime(uint param0, ref int puiDelay, uint param2, ref int puiWidth) ;

    
    /// Return Type: unsigned int
    ///piState: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGInsertionDelay")]
public static extern  uint GetDDGInsertionDelay(ref int piState) ;

    
    /// Return Type: unsigned int
    ///piState: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGIntelligate")]
public static extern  uint GetDDGIntelligate(ref int piState) ;

    
    /// Return Type: unsigned int
    ///state: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGIOC")]
public static extern  uint GetDDGIOC(ref int state) ;

    
    /// Return Type: unsigned int
    ///frequency: double*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGIOCFrequency")]
public static extern  uint GetDDGIOCFrequency(ref double frequency) ;

    
    /// Return Type: unsigned int
    ///numberPulses: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGIOCNumber")]
public static extern  uint GetDDGIOCNumber(ref uint numberPulses) ;

    
    /// Return Type: unsigned int
    ///pulses: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGIOCNumberRequested")]
public static extern  uint GetDDGIOCNumberRequested(ref uint pulses) ;

    
    /// Return Type: unsigned int
    ///param0: unsigned int
    ///period: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGIOCPeriod")]
public static extern  uint GetDDGIOCPeriod(uint param0, ref int period) ;

    
    /// Return Type: unsigned int
    ///pulses: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGIOCPulses")]
public static extern  uint GetDDGIOCPulses(ref int pulses) ;

    
    /// Return Type: unsigned int
    ///trigger: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGIOCTrigger")]
public static extern  uint GetDDGIOCTrigger(ref uint trigger) ;

    
    /// Return Type: unsigned int
    ///puiEnabled: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGOpticalWidthEnabled")]
public static extern  uint GetDDGOpticalWidthEnabled(ref uint puiEnabled) ;

    
    /// Return Type: unsigned int
    ///control: unsigned char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGLiteGlobalControlByte")]
public static extern  uint GetDDGLiteGlobalControlByte(System.IntPtr control) ;

    
    /// Return Type: unsigned int
    ///channel: AT_DDGLiteChannelId->Anonymous_1c96db6c_1962_4028_8710_c3ee5a0433cc
    ///control: unsigned char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGLiteControlByte")]
public static extern  uint GetDDGLiteControlByte(AT_DDGLiteChannelId channel, System.IntPtr control) ;

    
    /// Return Type: unsigned int
    ///channel: AT_DDGLiteChannelId->Anonymous_1c96db6c_1962_4028_8710_c3ee5a0433cc
    ///fDelay: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGLiteInitialDelay")]
public static extern  uint GetDDGLiteInitialDelay(AT_DDGLiteChannelId channel, ref float fDelay) ;

    
    /// Return Type: unsigned int
    ///channel: AT_DDGLiteChannelId->Anonymous_1c96db6c_1962_4028_8710_c3ee5a0433cc
    ///fWidth: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGLitePulseWidth")]
public static extern  uint GetDDGLitePulseWidth(AT_DDGLiteChannelId channel, ref float fWidth) ;

    
    /// Return Type: unsigned int
    ///channel: AT_DDGLiteChannelId->Anonymous_1c96db6c_1962_4028_8710_c3ee5a0433cc
    ///fDelay: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGLiteInterPulseDelay")]
public static extern  uint GetDDGLiteInterPulseDelay(AT_DDGLiteChannelId channel, ref float fDelay) ;

    
    /// Return Type: unsigned int
    ///channel: AT_DDGLiteChannelId->Anonymous_1c96db6c_1962_4028_8710_c3ee5a0433cc
    ///ui32Pulses: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGLitePulsesPerExposure")]
public static extern  uint GetDDGLitePulsesPerExposure(AT_DDGLiteChannelId channel, ref uint ui32Pulses) ;

    
    /// Return Type: unsigned int
    ///wid: double
    ///resolution: double
    ///Delay: double*
    ///Width: double*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGPulse")]
public static extern  uint GetDDGPulse(double wid, double resolution, ref double Delay, ref double Width) ;

    
    /// Return Type: unsigned int
    ///mode: unsigned int
    ///p1: double*
    ///p2: double*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGStepCoefficients")]
public static extern  uint GetDDGStepCoefficients(uint mode, ref double p1, ref double p2) ;

    
    /// Return Type: unsigned int
    ///mode: unsigned int
    ///p1: double*
    ///p2: double*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGWidthStepCoefficients")]
public static extern  uint GetDDGWidthStepCoefficients(uint mode, ref double p1, ref double p2) ;

    
    /// Return Type: unsigned int
    ///mode: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGStepMode")]
public static extern  uint GetDDGStepMode(ref uint mode) ;

    
    /// Return Type: unsigned int
    ///mode: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDDGWidthStepMode")]
public static extern  uint GetDDGWidthStepMode(ref uint mode) ;

    
    /// Return Type: unsigned int
    ///xpixels: int*
    ///ypixels: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDetector")]
public static extern  uint GetDetector(ref int xpixels, ref int ypixels) ;

    
    /// Return Type: unsigned int
    ///info: void*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDICameraInfo")]
public static extern  uint GetDICameraInfo(System.IntPtr info) ;

    
    /// Return Type: unsigned int
    ///state: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetEMAdvanced")]
public static extern  uint GetEMAdvanced(ref int state) ;

    
    /// Return Type: unsigned int
    ///gain: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetEMCCDGain")]
public static extern  uint GetEMCCDGain(ref int gain) ;

    
    /// Return Type: unsigned int
    ///low: int*
    ///high: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetEMGainRange")]
public static extern  uint GetEMGainRange(ref int low, ref int high) ;

    
    /// Return Type: unsigned int
    ///puiTermination: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetExternalTriggerTermination")]
public static extern  uint GetExternalTriggerTermination(ref uint puiTermination) ;

    
    /// Return Type: unsigned int
    ///index: int*
    ///speed: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetFastestRecommendedVSSpeed")]
public static extern  uint GetFastestRecommendedVSSpeed(ref int index, ref float speed) ;

    
    /// Return Type: unsigned int
    ///FIFOusage: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetFIFOUsage")]
public static extern  uint GetFIFOUsage(ref int FIFOusage) ;

    
    /// Return Type: unsigned int
    ///mode: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetFilterMode")]
public static extern  uint GetFilterMode(ref int mode) ;

    
    /// Return Type: unsigned int
    ///time: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetFKExposureTime")]
public static extern  uint GetFKExposureTime(ref float time) ;

    
    /// Return Type: unsigned int
    ///index: int
    ///speed: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetFKVShiftSpeed")]
public static extern  uint GetFKVShiftSpeed(int index, ref int speed) ;

    
    /// Return Type: unsigned int
    ///index: int
    ///speed: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetFKVShiftSpeedF")]
public static extern  uint GetFKVShiftSpeedF(int index, ref float speed) ;

    
    /// Return Type: unsigned int
    ///piFlag: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetFrontEndStatus")]
public static extern  uint GetFrontEndStatus(ref int piFlag) ;

    
    /// Return Type: unsigned int
    ///piGatemode: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetGateMode")]
public static extern  uint GetGateMode(ref int piGatemode) ;

    
    /// Return Type: unsigned int
    ///PCB: unsigned int*
    ///Decode: unsigned int*
    ///dummy1: unsigned int*
    ///dummy2: unsigned int*
    ///CameraFirmwareVersion: unsigned int*
    ///CameraFirmwareBuild: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetHardwareVersion")]
public static extern  uint GetHardwareVersion(ref uint PCB, ref uint Decode, ref uint dummy1, ref uint dummy2, ref uint CameraFirmwareVersion, ref uint CameraFirmwareBuild) ;

    
    /// Return Type: unsigned int
    ///name: char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetHeadModel")]
public static extern  uint GetHeadModel(System.IntPtr name) ;

    
    /// Return Type: unsigned int
    ///index: int
    ///speed: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetHorizontalSpeed")]
public static extern  uint GetHorizontalSpeed(int index, ref int speed) ;

    
    /// Return Type: unsigned int
    ///channel: int
    ///typ: int
    ///index: int
    ///speed: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetHSSpeed")]
public static extern  uint GetHSSpeed(int channel, int typ, int index, ref float speed) ;

    
    /// Return Type: unsigned int
    ///bFlag: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetHVflag")]
public static extern  uint GetHVflag(ref int bFlag) ;

    
    /// Return Type: unsigned int
    ///devNum: int
    ///id: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetID")]
public static extern  uint GetID(int devNum, ref int id) ;

    
    /// Return Type: unsigned int
    ///iHFlip: int*
    ///iVFlip: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetImageFlip")]
public static extern  uint GetImageFlip(ref int iHFlip, ref int iVFlip) ;

    
    /// Return Type: unsigned int
    ///iRotate: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetImageRotate")]
public static extern  uint GetImageRotate(ref int iRotate) ;

    
    /// Return Type: unsigned int
    ///first: int
    ///last: int
    ///arr: int*
    ///size: unsigned int
    ///validfirst: int*
    ///validlast: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetImages")]
public static extern  uint GetImages(int first, int last, ref int arr, uint size, ref int validfirst, ref int validlast) ;

    
    /// Return Type: unsigned int
    ///first: int
    ///last: int
    ///arr: WORD*
    ///size: unsigned int
    ///validfirst: int*
    ///validlast: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetImages16")]
public static extern  uint GetImages16(int first, int last, ref ushort arr, uint size, ref int validfirst, ref int validlast) ;

    
    /// Return Type: unsigned int
    ///images: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetImagesPerDMA")]
public static extern  uint GetImagesPerDMA(ref uint images) ;

    
    /// Return Type: unsigned int
    ///IRQ: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetIRQ")]
public static extern  uint GetIRQ(ref int IRQ) ;

    
    /// Return Type: unsigned int
    ///KeepCleanTime: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetKeepCleanTime")]
public static extern  uint GetKeepCleanTime(ref float KeepCleanTime) ;

    
    /// Return Type: unsigned int
    ///ReadMode: int
    ///HorzVert: int
    ///MaxBinning: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetMaximumBinning")]
public static extern  uint GetMaximumBinning(int ReadMode, int HorzVert, ref int MaxBinning) ;

    
    /// Return Type: unsigned int
    ///MaxExp: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetMaximumExposure")]
public static extern  uint GetMaximumExposure(ref float MaxExp) ;

    
    /// Return Type: unsigned int
    ///number: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetMaximumNumberRingExposureTimes")]
public static extern  uint GetMaximumNumberRingExposureTimes(ref int number) ;

    
    /// Return Type: unsigned int
    ///piGain: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetMCPGain")]
public static extern  uint GetMCPGain(ref int piGain) ;

    
    /// Return Type: unsigned int
    ///iLow: int*
    ///iHigh: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetMCPGainRange")]
public static extern  uint GetMCPGainRange(ref int iLow, ref int iHigh) ;

    
    /// Return Type: unsigned int
    ///iNum: int
    ///piGain: int*
    ///pfPhotoepc: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetMCPGainTable")]
public static extern  uint GetMCPGainTable(int iNum, ref int piGain, ref float pfPhotoepc) ;

    
    /// Return Type: unsigned int
    ///iVoltage: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetMCPVoltage")]
public static extern  uint GetMCPVoltage(ref int iVoltage) ;

    
    /// Return Type: unsigned int
    ///MinImageLength: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetMinimumImageLength")]
public static extern  uint GetMinimumImageLength(ref int MinImageLength) ;

    
    /// Return Type: unsigned int
    ///number: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetMinimumNumberInSeries")]
public static extern  uint GetMinimumNumberInSeries(ref int number) ;

    
    /// Return Type: unsigned int
    ///size: unsigned int
    ///algorithm: int
    ///red: WORD*
    ///green: WORD*
    ///blue: WORD*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetMostRecentColorImage16")]
public static extern  uint GetMostRecentColorImage16(uint size, int algorithm, ref ushort red, ref ushort green, ref ushort blue) ;

    
    /// Return Type: unsigned int
    ///arr: int*
    ///size: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetMostRecentImage")]
public static extern  uint GetMostRecentImage(ref int arr, uint size) ;

    
    /// Return Type: unsigned int
    ///arr: WORD*
    ///size: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetMostRecentImage16")]
public static extern  uint GetMostRecentImage16(ref ushort arr, uint size) ;

    
    /// Return Type: unsigned int
    ///TimeOfStart: SYSTEMTIME*
    ///pfDifferences: float*
    ///inoOfImages: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetMSTimingsData")]
public static extern  uint GetMSTimingsData(ref SYSTEMTIME TimeOfStart, ref float pfDifferences, int inoOfImages) ;

    
    /// Return Type: unsigned int
    ///TimeOfStart: SYSTEMTIME*
    ///pfTimeFromStart: float*
    ///index: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetMetaDataInfo")]
public static extern  uint GetMetaDataInfo(ref SYSTEMTIME TimeOfStart, ref float pfTimeFromStart, uint index) ;

    
    /// Return Type: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetMSTimingsEnabled")]
public static extern  uint GetMSTimingsEnabled() ;

    
    /// Return Type: unsigned int
    ///arr: int*
    ///size: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNewData")]
public static extern  uint GetNewData(ref int arr, uint size) ;

    
    /// Return Type: unsigned int
    ///arr: WORD*
    ///size: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNewData16")]
public static extern  uint GetNewData16(ref ushort arr, uint size) ;

    
    /// Return Type: unsigned int
    ///arr: unsigned char*
    ///size: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNewData8")]
public static extern  uint GetNewData8(System.IntPtr arr, uint size) ;

    
    /// Return Type: unsigned int
    ///arr: float*
    ///size: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNewFloatData")]
public static extern  uint GetNewFloatData(ref float arr, uint size) ;

    
    /// Return Type: unsigned int
    ///channels: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberADChannels")]
public static extern  uint GetNumberADChannels(ref int channels) ;

    
    /// Return Type: unsigned int
    ///amp: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberAmp")]
public static extern  uint GetNumberAmp(ref int amp) ;

    
    /// Return Type: unsigned int
    ///first: int*
    ///last: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberAvailableImages")]
public static extern  uint GetNumberAvailableImages(ref int first, ref int last) ;

    
    /// Return Type: unsigned int
    ///puiCount: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberDDGExternalOutputs")]
public static extern  uint GetNumberDDGExternalOutputs(ref uint puiCount) ;

    
    /// Return Type: unsigned int
    ///numDevs: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberDevices")]
public static extern  uint GetNumberDevices(ref int numDevs) ;

    
    /// Return Type: unsigned int
    ///number: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberFKVShiftSpeeds")]
public static extern  uint GetNumberFKVShiftSpeeds(ref int number) ;

    
    /// Return Type: unsigned int
    ///number: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberHorizontalSpeeds")]
public static extern  uint GetNumberHorizontalSpeeds(ref int number) ;

    
    /// Return Type: unsigned int
    ///channel: int
    ///typ: int
    ///speeds: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberHSSpeeds")]
public static extern  uint GetNumberHSSpeeds(int channel, int typ, ref int speeds) ;

    
    /// Return Type: unsigned int
    ///first: unsigned int
    ///last: unsigned int
    ///arr: WORD*
    ///size: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberMissedExternalTriggers")]
public static extern  uint GetNumberMissedExternalTriggers(uint first, uint last, ref ushort arr, uint size) ;

    
    /// Return Type: unsigned int
    ///_uc_irigData: unsigned char*
    ///_ui_index: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetIRIGData")]
public static extern  uint GetIRIGData(System.IntPtr _uc_irigData, uint _ui_index) ;

    
    /// Return Type: unsigned int
    ///first: int*
    ///last: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberNewImages")]
public static extern  uint GetNumberNewImages(ref int first, ref int last) ;

    
    /// Return Type: unsigned int
    ///noOfDivisions: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberPhotonCountingDivisions")]
public static extern  uint GetNumberPhotonCountingDivisions(ref uint noOfDivisions) ;

    
    /// Return Type: unsigned int
    ///noGains: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberPreAmpGains")]
public static extern  uint GetNumberPreAmpGains(ref int noGains) ;

    
    /// Return Type: unsigned int
    ///ipnumTimes: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberRingExposureTimes")]
public static extern  uint GetNumberRingExposureTimes(ref int ipnumTimes) ;

    
    /// Return Type: unsigned int
    ///iNumber: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberIO")]
public static extern  uint GetNumberIO(ref int iNumber) ;

    
    /// Return Type: unsigned int
    ///number: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberVerticalSpeeds")]
public static extern  uint GetNumberVerticalSpeeds(ref int number) ;

    
    /// Return Type: unsigned int
    ///number: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberVSAmplitudes")]
public static extern  uint GetNumberVSAmplitudes(ref int number) ;

    
    /// Return Type: unsigned int
    ///speeds: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetNumberVSSpeeds")]
public static extern  uint GetNumberVSSpeeds(ref int speeds) ;

    
    /// Return Type: unsigned int
    ///arr: int*
    ///size: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetOldestImage")]
public static extern  uint GetOldestImage(ref int arr, uint size) ;

    
    /// Return Type: unsigned int
    ///arr: WORD*
    ///size: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetOldestImage16")]
public static extern  uint GetOldestImage16(ref ushort arr, uint size) ;

    
    /// Return Type: unsigned int
    ///piFlag: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetPhosphorStatus")]
public static extern  uint GetPhosphorStatus(ref int piFlag) ;

    
    /// Return Type: unsigned int
    ///Address1: unsigned int*
    ///Address2: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetPhysicalDMAAddress")]
public static extern  uint GetPhysicalDMAAddress(ref uint Address1, ref uint Address2) ;

    
    /// Return Type: unsigned int
    ///xSize: float*
    ///ySize: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetPixelSize")]
public static extern  uint GetPixelSize(ref float xSize, ref float ySize) ;

    
    /// Return Type: unsigned int
    ///index: int
    ///gain: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetPreAmpGain")]
public static extern  uint GetPreAmpGain(int index, ref float gain) ;

    
    /// Return Type: unsigned int
    ///index: int
    ///name: char*
    ///length: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetPreAmpGainText")]
public static extern  uint GetPreAmpGainText(int index, System.IntPtr name, int length) ;

    
    /// Return Type: unsigned int
    ///exposure1: float*
    ///exposure2: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetDualExposureTimes")]
public static extern  uint GetDualExposureTimes(ref float exposure1, ref float exposure2) ;

    
    /// Return Type: unsigned int
    ///sensor: char*
    ///wavelength: float
    ///mode: unsigned int
    ///QE: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetQE")]
public static extern  uint GetQE(System.IntPtr sensor, float wavelength, uint mode, ref float QE) ;

    
    /// Return Type: unsigned int
    ///ReadOutTime: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetReadOutTime")]
public static extern  uint GetReadOutTime(ref float ReadOutTime) ;

    
    /// Return Type: unsigned int
    ///mode: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetRegisterDump")]
public static extern  uint GetRegisterDump(ref int mode) ;

    
    /// Return Type: unsigned int
    ///first: unsigned int
    ///last: unsigned int
    ///param2: unsigned int
    ///arr: int*
    ///size: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetRelativeImageTimes")]
public static extern  uint GetRelativeImageTimes(uint first, uint last, uint param2, ref int arr, uint size) ;

    
    /// Return Type: unsigned int
    ///fpMin: float*
    ///fpMax: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetRingExposureRange")]
public static extern  uint GetRingExposureRange(ref float fpMin, ref float fpMax) ;

    
    /// Return Type: unsigned int
    ///Handle: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetSDK3Handle")]
public static extern  uint GetSDK3Handle(ref int Handle) ;

    
    /// Return Type: unsigned int
    ///channel: int
    ///horzShift: int
    ///amplifier: int
    ///pa: int
    ///sensitivity: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetSensitivity")]
public static extern  uint GetSensitivity(int channel, int horzShift, int amplifier, int pa, ref float sensitivity) ;

    
    /// Return Type: unsigned int
    ///minclosingtime: int*
    ///minopeningtime: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetShutterMinTimes")]
public static extern  uint GetShutterMinTimes(ref int minclosingtime, ref int minopeningtime) ;

    
    /// Return Type: unsigned int
    ///index: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetSizeOfCircularBuffer")]
public static extern  uint GetSizeOfCircularBuffer(ref int index) ;

    
    /// Return Type: unsigned int
    ///dwslot: DWORD*
    ///dwBus: DWORD*
    ///dwDevice: DWORD*
    ///dwFunction: DWORD*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetSlotBusDeviceFunction")]
public static extern  uint GetSlotBusDeviceFunction(ref uint dwslot, ref uint dwBus, ref uint dwDevice, ref uint dwFunction) ;

    
    /// Return Type: unsigned int
    ///eprom: unsigned int*
    ///coffile: unsigned int*
    ///vxdrev: unsigned int*
    ///vxdver: unsigned int*
    ///dllrev: unsigned int*
    ///dllver: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetSoftwareVersion")]
public static extern  uint GetSoftwareVersion(ref uint eprom, ref uint coffile, ref uint vxdrev, ref uint vxdver, ref uint dllrev, ref uint dllver) ;

    
    /// Return Type: unsigned int
    ///index: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetSpoolProgress")]
public static extern  uint GetSpoolProgress(ref int index) ;

    
    /// Return Type: unsigned int
    ///time: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetStartUpTime")]
public static extern  uint GetStartUpTime(ref float time) ;

    
    /// Return Type: unsigned int
    ///status: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetStatus")]
public static extern  uint GetStatus(ref int status) ;

    
    /// Return Type: unsigned int
    ///piFlag: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetTECStatus")]
public static extern  uint GetTECStatus(ref int piFlag) ;

    
    /// Return Type: unsigned int
    ///temperature: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetTemperature")]
public static extern  uint GetTemperature(ref int temperature) ;

    
    /// Return Type: unsigned int
    ///temperature: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetTemperatureF")]
public static extern  uint GetTemperatureF(ref float temperature) ;

    
    /// Return Type: unsigned int
    ///mintemp: int*
    ///maxtemp: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetTemperatureRange")]
public static extern  uint GetTemperatureRange(ref int mintemp, ref int maxtemp) ;

    
    /// Return Type: unsigned int
    ///precision: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetTemperaturePrecision")]
public static extern  uint GetTemperaturePrecision(ref int precision) ;

    
    /// Return Type: unsigned int
    ///SensorTemp: float*
    ///TargetTemp: float*
    ///AmbientTemp: float*
    ///CoolerVolts: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetTemperatureStatus")]
public static extern  uint GetTemperatureStatus(ref float SensorTemp, ref float TargetTemp, ref float AmbientTemp, ref float CoolerVolts) ;

    
    /// Return Type: unsigned int
    ///index: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetTotalNumberImagesAcquired")]
public static extern  uint GetTotalNumberImagesAcquired(ref int index) ;

    
    /// Return Type: unsigned int
    ///index: int
    ///iDirection: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetIODirection")]
public static extern  uint GetIODirection(int index, ref int iDirection) ;

    
    /// Return Type: unsigned int
    ///index: int
    ///iLevel: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetIOLevel")]
public static extern  uint GetIOLevel(int index, ref int iLevel) ;

    
    /// Return Type: unsigned int
    ///VendorID: WORD*
    ///ProductID: WORD*
    ///FirmwareVersion: WORD*
    ///SpecificationNumber: WORD*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetUSBDeviceDetails")]
public static extern  uint GetUSBDeviceDetails(ref ushort VendorID, ref ushort ProductID, ref ushort FirmwareVersion, ref ushort SpecificationNumber) ;

    
    /// Return Type: unsigned int
    ///arr: AT_VersionInfoId->Anonymous_e4fff422_a20a_4a8f_9918_17c6073f8195
    ///szVersionInfo: char*
    ///ui32BufferLen: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetVersionInfo")]
public static extern  uint GetVersionInfo(AT_VersionInfoId arr, System.IntPtr szVersionInfo, uint ui32BufferLen) ;

    
    /// Return Type: unsigned int
    ///index: int
    ///speed: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetVerticalSpeed")]
public static extern  uint GetVerticalSpeed(int index, ref int speed) ;

    
    /// Return Type: unsigned int
    ///Address1: void**
    ///Address2: void**
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetVirtualDMAAddress")]
public static extern  uint GetVirtualDMAAddress(ref System.IntPtr Address1, ref System.IntPtr Address2) ;

    
    /// Return Type: unsigned int
    ///index: int
    ///text: char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetVSAmplitudeString")]
public static extern  uint GetVSAmplitudeString(int index, System.IntPtr text) ;

    
    /// Return Type: unsigned int
    ///text: char*
    ///index: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetVSAmplitudeFromString")]
public static extern  uint GetVSAmplitudeFromString(System.IntPtr text, ref int index) ;

    
    /// Return Type: unsigned int
    ///index: int
    ///value: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetVSAmplitudeValue")]
public static extern  uint GetVSAmplitudeValue(int index, ref int value) ;

    
    /// Return Type: unsigned int
    ///index: int
    ///speed: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetVSSpeed")]
public static extern  uint GetVSSpeed(int index, ref float speed) ;

    
    /// Return Type: unsigned int
    ///id: int
    ///address: short
    ///text: char*
    ///size: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GPIBReceive")]
public static extern  uint GPIBReceive(int id, short address, System.IntPtr text, int size) ;

    
    /// Return Type: unsigned int
    ///id: int
    ///address: short
    ///text: char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GPIBSend")]
public static extern  uint GPIBSend(int id, short address, System.IntPtr text) ;

    
    /// Return Type: unsigned int
    ///i2cAddress: BYTE->unsigned char
    ///nBytes: int
    ///data: BYTE*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="I2CBurstRead")]
public static extern  uint I2CBurstRead(byte i2cAddress, int nBytes, ref byte data) ;

    
    /// Return Type: unsigned int
    ///i2cAddress: BYTE->unsigned char
    ///nBytes: int
    ///data: BYTE*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="I2CBurstWrite")]
public static extern  uint I2CBurstWrite(byte i2cAddress, int nBytes, ref byte data) ;

    
    /// Return Type: unsigned int
    ///deviceID: BYTE->unsigned char
    ///intAddress: BYTE->unsigned char
    ///pdata: BYTE*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="I2CRead")]
public static extern  uint I2CRead(byte deviceID, byte intAddress, ref byte pdata) ;

    
    /// Return Type: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="I2CReset")]
public static extern  uint I2CReset() ;

    
    /// Return Type: unsigned int
    ///deviceID: BYTE->unsigned char
    ///intAddress: BYTE->unsigned char
    ///data: BYTE->unsigned char
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="I2CWrite")]
public static extern  uint I2CWrite(byte deviceID, byte intAddress, byte data) ;

    
    /// Return Type: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="IdAndorDll")]
public static extern  uint IdAndorDll() ;

    
    /// Return Type: unsigned int
    ///port: int
    ///state: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="InAuxPort")]
public static extern  uint InAuxPort(int port, ref int state) ;

    
    /// Return Type: unsigned int
    ///dir: char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="Initialize")]
public static extern  uint Initialize(System.IntPtr dir) ;

    
    /// Return Type: unsigned int
    ///dir: char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="InitializeDevice")]
public static extern  uint InitializeDevice(System.IntPtr dir) ;

    
    /// Return Type: unsigned int
    ///iamp: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="IsAmplifierAvailable")]
public static extern  uint IsAmplifierAvailable(int iamp) ;

    
    /// Return Type: unsigned int
    ///iCoolerStatus: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="IsCoolerOn")]
public static extern  uint IsCoolerOn(ref int iCoolerStatus) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="IsCountConvertModeAvailable")]
public static extern  uint IsCountConvertModeAvailable(int mode) ;

    
    /// Return Type: unsigned int
    ///InternalShutter: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="IsInternalMechanicalShutter")]
public static extern  uint IsInternalMechanicalShutter(ref int InternalShutter) ;

    
    /// Return Type: unsigned int
    ///channel: int
    ///amplifier: int
    ///index: int
    ///pa: int
    ///status: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="IsPreAmpGainAvailable")]
public static extern  uint IsPreAmpGainAvailable(int channel, int amplifier, int index, int pa, ref int status) ;

    
    /// Return Type: unsigned int
    ///iAmplifier: int
    ///iFlipped: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="IsReadoutFlippedByAmplifier")]
public static extern  uint IsReadoutFlippedByAmplifier(int iAmplifier, ref int iFlipped) ;

    
    /// Return Type: unsigned int
    ///iTriggerMode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="IsTriggerModeAvailable")]
public static extern  uint IsTriggerModeAvailable(int iTriggerMode) ;

    
    /// Return Type: unsigned int
    ///arr: int*
    ///nOrder: int
    ///nPoint: int
    ///nPixel: int
    ///coeff: float*
    ///fit: int
    ///hbin: int
    ///output: int*
    ///start: float*
    ///step_Renamed: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="Merge")]
public static extern  uint Merge(ref int arr, int nOrder, int nPoint, int nPixel, ref float coeff, int fit, int hbin, ref int output, ref float start, ref float step_Renamed) ;

    
    /// Return Type: unsigned int
    ///port: int
    ///state: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OutAuxPort")]
public static extern  uint OutAuxPort(int port, int state) ;

    
    /// Return Type: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="PrepareAcquisition")]
public static extern  uint PrepareAcquisition() ;

    
    /// Return Type: unsigned int
    ///path: char*
    ///palette: char*
    ///ymin: int
    ///ymax: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SaveAsBmp")]
public static extern  uint SaveAsBmp([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string path, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string palette, int ymin, int ymax) ;

    
    /// Return Type: unsigned int
    ///path: char*
    ///comment: char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SaveAsCommentedSif")]
public static extern  uint SaveAsCommentedSif(System.IntPtr path, System.IntPtr comment) ;

    
    /// Return Type: unsigned int
    ///szPath: char*
    ///iMode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SaveAsEDF")]
public static extern  uint SaveAsEDF(System.IntPtr szPath, int iMode) ;

    
    /// Return Type: unsigned int
    ///szFileTitle: char*
    ///typ: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SaveAsFITS")]
public static extern  uint SaveAsFITS(System.IntPtr szFileTitle, int typ) ;

    
    /// Return Type: unsigned int
    ///szFileTitle: char*
    ///typ: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SaveAsRaw")]
public static extern  uint SaveAsRaw(System.IntPtr szFileTitle, int typ) ;

    
    /// Return Type: unsigned int
    ///path: char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SaveAsSif")]
public static extern  uint SaveAsSif(System.IntPtr path) ;

    
    /// Return Type: unsigned int
    ///path: char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SaveAsSPC")]
public static extern  uint SaveAsSPC(System.IntPtr path) ;

    
    /// Return Type: unsigned int
    ///path: char*
    ///palette: char*
    ///position: int
    ///typ: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SaveAsTiff")]
public static extern  uint SaveAsTiff(System.IntPtr path, System.IntPtr palette, int position, int typ) ;

    
    /// Return Type: unsigned int
    ///path: char*
    ///palette: char*
    ///position: int
    ///typ: int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SaveAsTiffEx")]
public static extern  uint SaveAsTiffEx(System.IntPtr path, System.IntPtr palette, int position, int typ, int mode) ;

    
    /// Return Type: unsigned int
    ///cFileName: char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SaveEEPROMToFile")]
public static extern  uint SaveEEPROMToFile(System.IntPtr cFileName) ;

    
    /// Return Type: unsigned int
    ///palette: char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SaveToClipBoard")]
public static extern  uint SaveToClipBoard(System.IntPtr palette) ;

    
    /// Return Type: unsigned int
    ///devNum: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SelectDevice")]
public static extern  uint SelectDevice(int devNum) ;

    
    /// Return Type: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SendSoftwareTrigger")]
public static extern  uint SendSoftwareTrigger() ;

    
    /// Return Type: unsigned int
    ///time: float
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetAccumulationCycleTime")]
public static extern  uint SetAccumulationCycleTime(float time) ;

    
    /// Return Type: unsigned int
    ///statusEvent: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetAcqStatusEvent")]
public static extern  uint SetAcqStatusEvent(System.IntPtr statusEvent) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetAcquisitionMode")]
public static extern  uint SetAcquisitionMode(int mode) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetSensorPortMode")]
public static extern  uint SetSensorPortMode(int mode) ;

    
    /// Return Type: unsigned int
    ///port: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SelectSensorPort")]
public static extern  uint SelectSensorPort(int port) ;

    
    /// Return Type: unsigned int
    ///typ: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetAcquisitionType")]
public static extern  uint SetAcquisitionType(int typ) ;

    
    /// Return Type: unsigned int
    ///channel: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetADChannel")]
public static extern  uint SetADChannel(int channel) ;

    
    /// Return Type: unsigned int
    ///iState: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetAdvancedTriggerModeState")]
public static extern  uint SetAdvancedTriggerModeState(int iState) ;

    
    /// Return Type: unsigned int
    ///arr: int*
    ///size: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetBackground")]
public static extern  uint SetBackground(ref int arr, uint size) ;

    
    /// Return Type: unsigned int
    ///state: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetBaselineClamp")]
public static extern  uint SetBaselineClamp(int state) ;

    
    /// Return Type: unsigned int
    ///offset: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetBaselineOffset")]
public static extern  uint SetBaselineOffset(int offset) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetCameraLinkMode")]
public static extern  uint SetCameraLinkMode(int mode) ;

    
    /// Return Type: unsigned int
    ///Enable: DWORD->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetCameraStatusEnable")]
public static extern  uint SetCameraStatusEnable(uint Enable) ;

    
    /// Return Type: unsigned int
    ///NumberRows: unsigned int
    ///NumberRepeats: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetChargeShifting")]
public static extern  uint SetChargeShifting(uint NumberRows, uint NumberRepeats) ;

    
    /// Return Type: unsigned int
    ///numAreas: int
    ///areas: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetComplexImage")]
public static extern  uint SetComplexImage(int numAreas, ref int areas) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetCoolerMode")]
public static extern  uint SetCoolerMode(int mode) ;

    
    /// Return Type: unsigned int
    ///Mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetCountConvertMode")]
public static extern  uint SetCountConvertMode(int Mode) ;

    
    /// Return Type: unsigned int
    ///wavelength: float
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetCountConvertWavelength")]
public static extern  uint SetCountConvertWavelength(float wavelength) ;

    
    /// Return Type: unsigned int
    ///active: int
    ///cropHeight: int
    ///reserved: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetCropMode")]
public static extern  uint SetCropMode(int active, int cropHeight, int reserved) ;

    
    /// Return Type: unsigned int
    ///cameraHandle: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetCurrentCamera")]
public static extern  uint SetCurrentCamera(int cameraHandle) ;

    
    /// Return Type: unsigned int
    ///bin: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetCustomTrackHBin")]
public static extern  uint SetCustomTrackHBin(int bin) ;

    
    /// Return Type: unsigned int
    ///typ: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDataType")]
public static extern  uint SetDataType(int typ) ;

    
    /// Return Type: unsigned int
    ///iOption: int
    ///iResolution: int
    ///iValue: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDACOutput")]
public static extern  uint SetDACOutput(int iOption, int iResolution, int iValue) ;

    
    /// Return Type: unsigned int
    ///iScale: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDACOutputScale")]
public static extern  uint SetDACOutputScale(int iScale) ;

    
    /// Return Type: unsigned int
    ///t0: BYTE->unsigned char
    ///t1: BYTE->unsigned char
    ///t2: BYTE->unsigned char
    ///t3: BYTE->unsigned char
    ///address: BYTE->unsigned char
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGAddress")]
public static extern  uint SetDDGAddress(byte t0, byte t1, byte t2, byte t3, byte address) ;

    
    /// Return Type: unsigned int
    ///uiIndex: unsigned int
    ///uiEnabled: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGExternalOutputEnabled")]
public static extern  uint SetDDGExternalOutputEnabled(uint uiIndex, uint uiEnabled) ;

    
    /// Return Type: unsigned int
    ///uiIndex: unsigned int
    ///uiPolarity: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGExternalOutputPolarity")]
public static extern  uint SetDDGExternalOutputPolarity(uint uiIndex, uint uiPolarity) ;

    
    /// Return Type: unsigned int
    ///uiIndex: unsigned int
    ///uiEnabled: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGExternalOutputStepEnabled")]
public static extern  uint SetDDGExternalOutputStepEnabled(uint uiIndex, uint uiEnabled) ;

    
    /// Return Type: unsigned int
    ///uiIndex: unsigned int
    ///param1: unsigned int
    ///uiDelay: int
    ///param3: unsigned int
    ///uiWidth: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGExternalOutputTime")]
public static extern  uint SetDDGExternalOutputTime(uint uiIndex, uint param1, int uiDelay, uint param3, int uiWidth) ;

    
    /// Return Type: unsigned int
    ///gain: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGGain")]
public static extern  uint SetDDGGain(int gain) ;

    
    /// Return Type: unsigned int
    ///step_Renamed: double
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGGateStep")]
public static extern  uint SetDDGGateStep(double step_Renamed) ;

    
    /// Return Type: unsigned int
    ///param0: unsigned int
    ///uiDelay: int
    ///param2: unsigned int
    ///uiWidth: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGGateTime")]
public static extern  uint SetDDGGateTime(uint param0, int uiDelay, uint param2, int uiWidth) ;

    
    /// Return Type: unsigned int
    ///state: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGInsertionDelay")]
public static extern  uint SetDDGInsertionDelay(int state) ;

    
    /// Return Type: unsigned int
    ///state: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGIntelligate")]
public static extern  uint SetDDGIntelligate(int state) ;

    
    /// Return Type: unsigned int
    ///state: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGIOC")]
public static extern  uint SetDDGIOC(int state) ;

    
    /// Return Type: unsigned int
    ///frequency: double
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGIOCFrequency")]
public static extern  uint SetDDGIOCFrequency(double frequency) ;

    
    /// Return Type: unsigned int
    ///numberPulses: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGIOCNumber")]
public static extern  uint SetDDGIOCNumber(uint numberPulses) ;

    
    /// Return Type: unsigned int
    ///param0: unsigned int
    ///period: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGIOCPeriod")]
public static extern  uint SetDDGIOCPeriod(uint param0, int period) ;

    
    /// Return Type: unsigned int
    ///trigger: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGIOCTrigger")]
public static extern  uint SetDDGIOCTrigger(uint trigger) ;

    
    /// Return Type: unsigned int
    ///uiEnabled: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGOpticalWidthEnabled")]
public static extern  uint SetDDGOpticalWidthEnabled(uint uiEnabled) ;

    
    /// Return Type: unsigned int
    ///control: unsigned char
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGLiteGlobalControlByte")]
public static extern  uint SetDDGLiteGlobalControlByte(byte control) ;

    
    /// Return Type: unsigned int
    ///channel: AT_DDGLiteChannelId->Anonymous_1c96db6c_1962_4028_8710_c3ee5a0433cc
    ///control: unsigned char
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGLiteControlByte")]
public static extern  uint SetDDGLiteControlByte(AT_DDGLiteChannelId channel, byte control) ;

    
    /// Return Type: unsigned int
    ///channel: AT_DDGLiteChannelId->Anonymous_1c96db6c_1962_4028_8710_c3ee5a0433cc
    ///fDelay: float
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGLiteInitialDelay")]
public static extern  uint SetDDGLiteInitialDelay(AT_DDGLiteChannelId channel, float fDelay) ;

    
    /// Return Type: unsigned int
    ///channel: AT_DDGLiteChannelId->Anonymous_1c96db6c_1962_4028_8710_c3ee5a0433cc
    ///fWidth: float
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGLitePulseWidth")]
public static extern  uint SetDDGLitePulseWidth(AT_DDGLiteChannelId channel, float fWidth) ;

    
    /// Return Type: unsigned int
    ///channel: AT_DDGLiteChannelId->Anonymous_1c96db6c_1962_4028_8710_c3ee5a0433cc
    ///fDelay: float
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGLiteInterPulseDelay")]
public static extern  uint SetDDGLiteInterPulseDelay(AT_DDGLiteChannelId channel, float fDelay) ;

    
    /// Return Type: unsigned int
    ///channel: AT_DDGLiteChannelId->Anonymous_1c96db6c_1962_4028_8710_c3ee5a0433cc
    ///ui32Pulses: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGLitePulsesPerExposure")]
public static extern  uint SetDDGLitePulsesPerExposure(AT_DDGLiteChannelId channel, uint ui32Pulses) ;

    
    /// Return Type: unsigned int
    ///mode: unsigned int
    ///p1: double
    ///p2: double
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGStepCoefficients")]
public static extern  uint SetDDGStepCoefficients(uint mode, double p1, double p2) ;

    
    /// Return Type: unsigned int
    ///mode: unsigned int
    ///p1: double
    ///p2: double
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGWidthStepCoefficients")]
public static extern  uint SetDDGWidthStepCoefficients(uint mode, double p1, double p2) ;

    
    /// Return Type: unsigned int
    ///mode: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGStepMode")]
public static extern  uint SetDDGStepMode(uint mode) ;

    
    /// Return Type: unsigned int
    ///mode: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGWidthStepMode")]
public static extern  uint SetDDGWidthStepMode(uint mode) ;

    
    /// Return Type: unsigned int
    ///t0: double
    ///t1: double
    ///t2: double
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGTimes")]
public static extern  uint SetDDGTimes(double t0, double t1, double t2) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGTriggerMode")]
public static extern  uint SetDDGTriggerMode(int mode) ;

    
    /// Return Type: unsigned int
    ///mode: int
    ///p1: double
    ///p2: double
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDDGVariableGateStep")]
public static extern  uint SetDDGVariableGateStep(int mode, double p1, double p2) ;

    
    /// Return Type: unsigned int
    ///board: int
    ///address: short
    ///typ: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDelayGenerator")]
public static extern  uint SetDelayGenerator(int board, short address, int typ) ;

    
    /// Return Type: unsigned int
    ///MaxImagesPerDMA: int
    ///SecondsPerDMA: float
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDMAParameters")]
public static extern  uint SetDMAParameters(int MaxImagesPerDMA, float SecondsPerDMA) ;

    
    /// Return Type: unsigned int
    ///driverEvent: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDriverEvent")]
public static extern  uint SetDriverEvent(System.IntPtr driverEvent) ;

    
    /// Return Type: unsigned int
    ///state: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetEMAdvanced")]
public static extern  uint SetEMAdvanced(int state) ;

    
    /// Return Type: unsigned int
    ///gain: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetEMCCDGain")]
public static extern  uint SetEMCCDGain(int gain) ;

    
    /// Return Type: unsigned int
    ///EMClockCompensationFlag: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetEMClockCompensation")]
public static extern  uint SetEMClockCompensation(int EMClockCompensationFlag) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetEMGainMode")]
public static extern  uint SetEMGainMode(int mode) ;

    
    /// Return Type: unsigned int
    ///time: float
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetExposureTime")]
public static extern  uint SetExposureTime(float time) ;

    
    /// Return Type: unsigned int
    ///uiTermination: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetExternalTriggerTermination")]
public static extern  uint SetExternalTriggerTermination(uint uiTermination) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetFanMode")]
public static extern  uint SetFanMode(int mode) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetFastExtTrigger")]
public static extern  uint SetFastExtTrigger(int mode) ;

    
    /// Return Type: unsigned int
    ///exposedRows: int
    ///seriesLength: int
    ///time: float
    ///mode: int
    ///hbin: int
    ///vbin: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetFastKinetics")]
public static extern  uint SetFastKinetics(int exposedRows, int seriesLength, float time, int mode, int hbin, int vbin) ;

    
    /// Return Type: unsigned int
    ///exposedRows: int
    ///seriesLength: int
    ///time: float
    ///mode: int
    ///hbin: int
    ///vbin: int
    ///offset: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetFastKineticsEx")]
public static extern  uint SetFastKineticsEx(int exposedRows, int seriesLength, float time, int mode, int hbin, int vbin, int offset) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetFilterMode")]
public static extern  uint SetFilterMode(int mode) ;

    
    /// Return Type: unsigned int
    ///width: int
    ///sensitivity: float
    ///range: int
    ///accept: float
    ///smooth: int
    ///noise: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetFilterParameters")]
public static extern  uint SetFilterParameters(int width, float sensitivity, int range, float accept, int smooth, int noise) ;

    
    /// Return Type: unsigned int
    ///index: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetFKVShiftSpeed")]
public static extern  uint SetFKVShiftSpeed(int index) ;

    
    /// Return Type: unsigned int
    ///state: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetFPDP")]
public static extern  uint SetFPDP(int state) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetFrameTransferMode")]
public static extern  uint SetFrameTransferMode(int mode) ;

    
    /// Return Type: unsigned int
    ///driverEvent: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetFrontEndEvent")]
public static extern  uint SetFrontEndEvent(System.IntPtr driverEvent) ;

    
    /// Return Type: unsigned int
    ///hbin: int
    ///vbin: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetFullImage")]
public static extern  uint SetFullImage(int hbin, int vbin) ;

    
    /// Return Type: unsigned int
    ///bin: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetFVBHBin")]
public static extern  uint SetFVBHBin(int bin) ;

    
    /// Return Type: unsigned int
    ///gain: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetGain")]
public static extern  uint SetGain(int gain) ;

    
    /// Return Type: unsigned int
    ///delay: float
    ///width: float
    ///stepRenamed: float
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetGate")]
public static extern  uint SetGate(float delay, float width, float stepRenamed) ;

    
    /// Return Type: unsigned int
    ///gatemode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetGateMode")]
public static extern  uint SetGateMode(int gatemode) ;

    
    /// Return Type: unsigned int
    ///state: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetHighCapacity")]
public static extern  uint SetHighCapacity(int state) ;

    
    /// Return Type: unsigned int
    ///index: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetHorizontalSpeed")]
public static extern  uint SetHorizontalSpeed(int index) ;

    
    /// Return Type: unsigned int
    ///typ: int
    ///index: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetHSSpeed")]
public static extern  uint SetHSSpeed(int typ, int index) ;

    
    /// Return Type: unsigned int
    ///hbin: int
    ///vbin: int
    ///hstart: int
    ///hend: int
    ///vstart: int
    ///vend: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetImage")]
public static extern  uint SetImage(int hbin, int vbin, int hstart, int hend, int vstart, int vend) ;

    
    /// Return Type: unsigned int
    ///iHFlip: int
    ///iVFlip: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetImageFlip")]
public static extern  uint SetImageFlip(int iHFlip, int iVFlip) ;

    
    /// Return Type: unsigned int
    ///iRotate: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetImageRotate")]
public static extern  uint SetImageRotate(int iRotate) ;

    
    /// Return Type: unsigned int
    ///active: int
    ///cropheight: int
    ///cropwidth: int
    ///vbin: int
    ///hbin: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetIsolatedCropMode")]
public static extern  uint SetIsolatedCropMode(int active, int cropheight, int cropwidth, int vbin, int hbin) ;

    
    /// Return Type: unsigned int
    ///active: int
    ///cropheight: int
    ///cropwidth: int
    ///vbin: int
    ///hbin: int
    ///cropleft: int
    ///cropbottom: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetIsolatedCropModeEx")]
public static extern  uint SetIsolatedCropModeEx(int active, int cropheight, int cropwidth, int vbin, int hbin, int cropleft, int cropbottom) ;

    
    /// Return Type: unsigned int
    ///time: float
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetKineticCycleTime")]
public static extern  uint SetKineticCycleTime(float time) ;

    
    /// Return Type: unsigned int
    ///gain: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetMCPGain")]
public static extern  uint SetMCPGain(int gain) ;

    
    /// Return Type: unsigned int
    ///gating: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetMCPGating")]
public static extern  uint SetMCPGating(int gating) ;

    
    /// Return Type: unsigned int
    ///wnd: HWND->HWND__*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetMessageWindow")]
public static extern  uint SetMessageWindow(System.IntPtr wnd) ;

    
    /// Return Type: unsigned int
    ///state: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetMetaData")]
public static extern  uint SetMetaData(int state) ;

    
    /// Return Type: unsigned int
    ///number: int
    ///height: int
    ///offset: int
    ///bottom: int*
    ///gap: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetMultiTrack")]
public static extern  uint SetMultiTrack(int number, int height, int offset, ref int bottom, ref int gap) ;

    
    /// Return Type: unsigned int
    ///bin: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetMultiTrackHBin")]
public static extern  uint SetMultiTrackHBin(int bin) ;

    
    /// Return Type: unsigned int
    ///iStart: int
    ///iEnd: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetMultiTrackHRange")]
public static extern  uint SetMultiTrackHRange(int iStart, int iEnd) ;

    
    /// Return Type: unsigned int
    ///trackHeight: int
    ///numberTracks: int
    ///iSIHStart: int
    ///iSIHEnd: int
    ///trackHBinning: int
    ///trackVBinning: int
    ///trackGap: int
    ///trackOffset: int
    ///trackSkip: int
    ///numberSubFrames: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetMultiTrackScan")]
public static extern  uint SetMultiTrackScan(int trackHeight, int numberTracks, int iSIHStart, int iSIHEnd, int trackHBinning, int trackVBinning, int trackGap, int trackOffset, int trackSkip, int numberSubFrames) ;

    
    /// Return Type: unsigned int
    ///data: int*
    ///lowAdd: int
    ///highAdd: int
    ///length: int
    ///physical: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetNextAddress")]
public static extern  uint SetNextAddress(ref int data, int lowAdd, int highAdd, int length, int physical) ;

    
    /// Return Type: unsigned int
    ///data: int*
    ///lowAdd: int
    ///highAdd: int
    ///length: int
    ///physical: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetNextAddress16")]
public static extern  uint SetNextAddress16(ref int data, int lowAdd, int highAdd, int length, int physical) ;

    
    /// Return Type: unsigned int
    ///number: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetNumberAccumulations")]
public static extern  uint SetNumberAccumulations(int number) ;

    
    /// Return Type: unsigned int
    ///number: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetNumberKinetics")]
public static extern  uint SetNumberKinetics(int number) ;

    
    /// Return Type: unsigned int
    ///iNumber: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetNumberPrescans")]
public static extern  uint SetNumberPrescans(int iNumber) ;

    
    /// Return Type: unsigned int
    ///typ: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetOutputAmplifier")]
public static extern  uint SetOutputAmplifier(int typ) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetOverlapMode")]
public static extern  uint SetOverlapMode(int mode) ;

    
    /// Return Type: unsigned int
    ///mode: int
    ///value: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetPCIMode")]
public static extern  uint SetPCIMode(int mode, int value) ;

    
    /// Return Type: unsigned int
    ///state: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetPhotonCounting")]
public static extern  uint SetPhotonCounting(int state) ;

    
    /// Return Type: unsigned int
    ///param0: int
    ///param1: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetPhotonCountingThreshold")]
public static extern  uint SetPhotonCountingThreshold(int param0, int param1) ;

    
    /// Return Type: unsigned int
    ///driverEvent: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetPhosphorEvent")]
public static extern  uint SetPhosphorEvent(System.IntPtr driverEvent) ;

    
    /// Return Type: unsigned int
    ///noOfDivisions: unsigned int
    ///divisions: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetPhotonCountingDivisions")]
public static extern  uint SetPhotonCountingDivisions(uint noOfDivisions, ref int divisions) ;

    
    /// Return Type: unsigned int
    ///bitdepth: int
    ///colormode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetPixelMode")]
public static extern  uint SetPixelMode(int bitdepth, int colormode) ;

    
    /// Return Type: unsigned int
    ///index: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetPreAmpGain")]
public static extern  uint SetPreAmpGain(int index) ;

    
    /// Return Type: unsigned int
    ///expTime1: float
    ///expTime2: float
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDualExposureTimes")]
public static extern  uint SetDualExposureTimes(float expTime1, float expTime2) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetDualExposureMode")]
public static extern  uint SetDualExposureMode(int mode) ;

    
    /// Return Type: unsigned int
    ///numTracks: int
    ///areas: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetRandomTracks")]
public static extern  uint SetRandomTracks(int numTracks, ref int areas) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetReadMode")]
public static extern  uint SetReadMode(int mode) ;

    
    /// Return Type: unsigned int
    ///mode: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetReadoutRegisterPacking")]
public static extern  uint SetReadoutRegisterPacking(uint mode) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetRegisterDump")]
public static extern  uint SetRegisterDump(int mode) ;

    
    /// Return Type: unsigned int
    ///numTimes: int
    ///times: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetRingExposureTimes")]
public static extern  uint SetRingExposureTimes(int numTimes, ref float times) ;

    
    /// Return Type: unsigned int
    ///saturationEvent: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetSaturationEvent")]
public static extern  uint SetSaturationEvent(System.IntPtr saturationEvent) ;

    
    /// Return Type: unsigned int
    ///typ: int
    ///mode: int
    ///closingtime: int
    ///openingtime: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetShutter")]
public static extern  uint SetShutter(int typ, int mode, int closingtime, int openingtime) ;

    
    /// Return Type: unsigned int
    ///typ: int
    ///mode: int
    ///closingtime: int
    ///openingtime: int
    ///extmode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetShutterEx")]
public static extern  uint SetShutterEx(int typ, int mode, int closingtime, int openingtime, int extmode) ;

    
    /// Return Type: unsigned int
    ///typ: int
    ///mode: int
    ///closingtime: int
    ///openingtime: int
    ///exttype: int
    ///extmode: int
    ///dummy1: int
    ///dummy2: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetShutters")]
public static extern  uint SetShutters(int typ, int mode, int closingtime, int openingtime, int exttype, int extmode, int dummy1, int dummy2) ;

    
    /// Return Type: unsigned int
    ///comment: char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetSifComment")]
public static extern  uint SetSifComment(System.IntPtr comment) ;

    
    /// Return Type: unsigned int
    ///centre: int
    ///height: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetSingleTrack")]
public static extern  uint SetSingleTrack(int centre, int height) ;

    
    /// Return Type: unsigned int
    ///bin: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetSingleTrackHBin")]
public static extern  uint SetSingleTrackHBin(int bin) ;

    
    /// Return Type: unsigned int
    ///active: int
    ///method: int
    ///path: char*
    ///framebuffersize: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetSpool")]
public static extern  uint SetSpool(int active, int method, System.IntPtr path, int framebuffersize) ;

    
    /// Return Type: unsigned int
    ///count: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetSpoolThreadCount")]
public static extern  uint SetSpoolThreadCount(int count) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetStorageMode")]
public static extern  uint SetStorageMode(int mode) ;

    
    /// Return Type: unsigned int
    ///driverEvent: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetTECEvent")]
public static extern  uint SetTECEvent(System.IntPtr driverEvent) ;

    
    /// Return Type: unsigned int
    ///temperature: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetTemperature")]
public static extern  uint SetTemperature(int temperature) ;

    
    /// Return Type: unsigned int
    ///temperatureEvent: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetTemperatureEvent")]
public static extern  uint SetTemperatureEvent(System.IntPtr temperatureEvent) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetTriggerMode")]
public static extern  uint SetTriggerMode(int mode) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetTriggerInvert")]
public static extern  uint SetTriggerInvert(int mode) ;

    
    /// Return Type: unsigned int
    ///minimum: float*
    ///maximum: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="GetTriggerLevelRange")]
public static extern  uint GetTriggerLevelRange(ref float minimum, ref float maximum) ;

    
    /// Return Type: unsigned int
    ///f_level: float
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetTriggerLevel")]
public static extern  uint SetTriggerLevel(float f_level) ;

    
    /// Return Type: unsigned int
    ///index: int
    ///iDirection: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetIODirection")]
public static extern  uint SetIODirection(int index, int iDirection) ;

    
    /// Return Type: unsigned int
    ///index: int
    ///iLevel: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetIOLevel")]
public static extern  uint SetIOLevel(int index, int iLevel) ;

    
    /// Return Type: unsigned int
    ///userEvent: HANDLE->void*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetUserEvent")]
public static extern  uint SetUserEvent(System.IntPtr userEvent) ;

    
    /// Return Type: unsigned int
    ///width: int
    ///height: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetUSGenomics")]
public static extern  uint SetUSGenomics(int width, int height) ;

    
    /// Return Type: unsigned int
    ///rows: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetVerticalRowBuffer")]
public static extern  uint SetVerticalRowBuffer(int rows) ;

    
    /// Return Type: unsigned int
    ///index: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetVerticalSpeed")]
public static extern  uint SetVerticalSpeed(int index) ;

    
    /// Return Type: unsigned int
    ///state: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetVirtualChip")]
public static extern  uint SetVirtualChip(int state) ;

    
    /// Return Type: unsigned int
    ///index: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetVSAmplitude")]
public static extern  uint SetVSAmplitude(int index) ;

    
    /// Return Type: unsigned int
    ///index: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="SetVSSpeed")]
public static extern  uint SetVSSpeed(int index) ;

    
    /// Return Type: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="ShutDown")]
public static extern  uint ShutDown() ;

    
    /// Return Type: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="StartAcquisition")]
public static extern  uint StartAcquisition() ;

    
    /// Return Type: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="UnMapPhysicalAddress")]
public static extern  uint UnMapPhysicalAddress() ;

    
    /// Return Type: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="UpdateDDGTimings")]
public static extern  uint UpdateDDGTimings() ;

    
    /// Return Type: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="WaitForAcquisition")]
public static extern  uint WaitForAcquisition() ;

    
    /// Return Type: unsigned int
    ///cameraHandle: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="WaitForAcquisitionByHandle")]
public static extern  uint WaitForAcquisitionByHandle(int cameraHandle) ;

    
    /// Return Type: unsigned int
    ///cameraHandle: int
    ///iTimeOutMs: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="WaitForAcquisitionByHandleTimeOut")]
public static extern  uint WaitForAcquisitionByHandleTimeOut(int cameraHandle, int iTimeOutMs) ;

    
    /// Return Type: unsigned int
    ///iTimeOutMs: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="WaitForAcquisitionTimeOut")]
public static extern  uint WaitForAcquisitionTimeOut(int iTimeOutMs) ;

    
    /// Return Type: unsigned int
    ///wRed: WORD*
    ///wGreen: WORD*
    ///wBlue: WORD*
    ///fRelR: float*
    ///fRelB: float*
    ///info: WhiteBalanceInfo*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="WhiteBalance")]
public static extern  uint WhiteBalance(ref ushort wRed, ref ushort wGreen, ref ushort wBlue, ref float fRelR, ref float fRelB, ref WHITEBALANCEINFO info) ;

    
    /// Return Type: unsigned int
    ///pcFilename: char*
    ///uiFileNameLen: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_Initialize")]
public static extern  uint OA_Initialize([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcFilename, uint uiFileNameLen) ;

    
    /// Return Type: unsigned int
    ///pcModeName: char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_EnableMode")]
public static extern  uint OA_EnableMode([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcModeName) ;

    
    /// Return Type: unsigned int
    ///pcModeName: char*
    ///pcListOfParams: char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_GetModeAcqParams")]
public static extern  uint OA_GetModeAcqParams([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcModeName, System.IntPtr pcListOfParams) ;

    
    /// Return Type: unsigned int
    ///pcListOfModes: char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_GetUserModeNames")]
public static extern  uint OA_GetUserModeNames(System.IntPtr pcListOfModes) ;

    
    /// Return Type: unsigned int
    ///pcListOfModes: char*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_GetPreSetModeNames")]
public static extern  uint OA_GetPreSetModeNames(System.IntPtr pcListOfModes) ;

    
    /// Return Type: unsigned int
    ///puiNumberOfModes: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_GetNumberOfUserModes")]
public static extern  uint OA_GetNumberOfUserModes(ref uint puiNumberOfModes) ;

    
    /// Return Type: unsigned int
    ///puiNumberOfModes: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_GetNumberOfPreSetModes")]
public static extern  uint OA_GetNumberOfPreSetModes(ref uint puiNumberOfModes) ;

    
    /// Return Type: unsigned int
    ///pcModeName: char*
    ///puiNumberOfParams: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_GetNumberOfAcqParams")]
public static extern  uint OA_GetNumberOfAcqParams([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcModeName, ref uint puiNumberOfParams) ;

    
    /// Return Type: unsigned int
    ///pcModeName: char*
    ///uiModeNameLen: unsigned int
    ///pcModeDescription: char*
    ///uiModeDescriptionLen: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_AddMode")]
public static extern  uint OA_AddMode(System.IntPtr pcModeName, uint uiModeNameLen, System.IntPtr pcModeDescription, uint uiModeDescriptionLen) ;

    
    /// Return Type: unsigned int
    ///pcFileName: char*
    ///uiFileNameLen: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_WriteToFile")]
public static extern  uint OA_WriteToFile([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcFileName, uint uiFileNameLen) ;

    
    /// Return Type: unsigned int
    ///pcModeName: char*
    ///uiModeNameLen: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_DeleteMode")]
public static extern  uint OA_DeleteMode([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcModeName, uint uiModeNameLen) ;

    
    /// Return Type: unsigned int
    ///pcModeName: char*
    ///pcModeParam: char*
    ///iIntValue: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_SetInt")]
public static extern  uint OA_SetInt([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcModeName, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcModeParam, int iIntValue) ;

    
    /// Return Type: unsigned int
    ///pcModeName: char*
    ///pcModeParam: char*
    ///fFloatValue: float
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_SetFloat")]
public static extern  uint OA_SetFloat([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcModeName, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcModeParam, float fFloatValue) ;

    
    /// Return Type: unsigned int
    ///pcModeName: char*
    ///pcModeParam: char*
    ///pcStringValue: char*
    ///uiStringLen: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_SetString")]
public static extern  uint OA_SetString([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcModeName, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcModeParam, System.IntPtr pcStringValue, uint uiStringLen) ;

    
    /// Return Type: unsigned int
    ///pcModeName: char*
    ///pcModeParam: char*
    ///iIntValue: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_GetInt")]
public static extern  uint OA_GetInt([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcModeName, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcModeParam, ref int iIntValue) ;

    
    /// Return Type: unsigned int
    ///pcModeName: char*
    ///pcModeParam: char*
    ///fFloatValue: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_GetFloat")]
public static extern  uint OA_GetFloat([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcModeName, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcModeParam, ref float fFloatValue) ;

    
    /// Return Type: unsigned int
    ///pcModeName: char*
    ///pcModeParam: char*
    ///pcStringValue: char*
    ///uiStringLen: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="OA_GetString")]
public static extern  uint OA_GetString([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcModeName, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcModeParam, System.IntPtr pcStringValue, uint uiStringLen) ;

    
    /// Return Type: unsigned int
    ///mode: unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="Filter_SetMode")]
public static extern  uint Filter_SetMode(uint mode) ;

    
    /// Return Type: unsigned int
    ///mode: unsigned int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="Filter_GetMode")]
public static extern  uint Filter_GetMode(ref uint mode) ;

    
    /// Return Type: unsigned int
    ///threshold: float
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="Filter_SetThreshold")]
public static extern  uint Filter_SetThreshold(float threshold) ;

    
    /// Return Type: unsigned int
    ///threshold: float*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="Filter_GetThreshold")]
public static extern  uint Filter_GetThreshold(ref float threshold) ;

    
    /// Return Type: unsigned int
    ///mode: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="Filter_SetDataAveragingMode")]
public static extern  uint Filter_SetDataAveragingMode(int mode) ;

    
    /// Return Type: unsigned int
    ///mode: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="Filter_GetDataAveragingMode")]
public static extern  uint Filter_GetDataAveragingMode(ref int mode) ;

    
    /// Return Type: unsigned int
    ///frames: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="Filter_SetAveragingFrameCount")]
public static extern  uint Filter_SetAveragingFrameCount(int frames) ;

    
    /// Return Type: unsigned int
    ///frames: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="Filter_GetAveragingFrameCount")]
public static extern  uint Filter_GetAveragingFrameCount(ref int frames) ;

    
    /// Return Type: unsigned int
    ///averagingFactor: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="Filter_SetAveragingFactor")]
public static extern  uint Filter_SetAveragingFactor(int averagingFactor) ;

    
    /// Return Type: unsigned int
    ///averagingFactor: int*
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="Filter_GetAveragingFactor")]
public static extern  uint Filter_GetAveragingFactor(ref int averagingFactor) ;

    
    /// Return Type: unsigned int
    ///pInputImage: int*
    ///pOutputImage: int*
    ///iOutputBufferSize: int
    ///iBaseline: int
    ///iMode: int
    ///fThreshold: float
    ///iHeight: int
    ///iWidth: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="PostProcessNoiseFilter")]
public static extern  uint PostProcessNoiseFilter(ref int pInputImage, ref int pOutputImage, int iOutputBufferSize, int iBaseline, int iMode, float fThreshold, int iHeight, int iWidth) ;

    
    /// Return Type: unsigned int
    ///pInputImage: int*
    ///pOutputImage: int*
    ///iOutputBufferSize: int
    ///iNumImages: int
    ///iBaseline: int
    ///iMode: int
    ///iEmGain: int
    ///fQE: float
    ///fSensitivity: float
    ///iHeight: int
    ///iWidth: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="PostProcessCountConvert")]
public static extern  uint PostProcessCountConvert(ref int pInputImage, ref int pOutputImage, int iOutputBufferSize, int iNumImages, int iBaseline, int iMode, int iEmGain, float fQE, float fSensitivity, int iHeight, int iWidth) ;

    
    /// Return Type: unsigned int
    ///pInputImage: int*
    ///pOutputImage: int*
    ///iOutputBufferSize: int
    ///iNumImages: int
    ///iNumframes: int
    ///iNumberOfThresholds: int
    ///pfThreshold: float*
    ///iHeight: int
    ///iWidth: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="PostProcessPhotonCounting")]
public static extern  uint PostProcessPhotonCounting(ref int pInputImage, ref int pOutputImage, int iOutputBufferSize, int iNumImages, int iNumframes, int iNumberOfThresholds, ref float pfThreshold, int iHeight, int iWidth) ;

    
    /// Return Type: unsigned int
    ///pInputImage: int*
    ///pOutputImage: int*
    ///iOutputBufferSize: int
    ///iNumImages: int
    ///iAveragingFilterMode: int
    ///iHeight: int
    ///iWidth: int
    ///iFrameCount: int
    ///iAveragingFactor: int
    [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="PostProcessDataAveraging")]
public static extern  uint PostProcessDataAveraging(ref int pInputImage, ref int pOutputImage, int iOutputBufferSize, int iNumImages, int iAveragingFilterMode, int iHeight, int iWidth, int iFrameCount, int iAveragingFactor) ;

}
*/