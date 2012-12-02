using System;
using System.Collections.Generic;
using System.Text;

namespace BravaSystem.Communication
{
    /// <summary>
    /// Holds constant values such as frame lengths and such.
    /// </summary>
    public class BravaConstants
    {
        public const int INFOMESSAGERECORDLENGTH = 12; // Information frame is 12 bytes long.
        public const int STATEBLOCKRECORDLENGTH = 16;    // Data Frame Records are 16 bytes long.
        public const byte AllRecords = 0;
    }

    /// <summary>
    /// Constants for Customer ZIRODE
    /// </summary>
    public class ZIRODEConstants
    {
        public const string ZIRODECODE1 = "ZD01";
    }

    /// <summary>
    /// Maps the "magic" / code numbers used in Brava System to meaningful names and enums.
    /// </summary>
    /// <remarks>This would ordinarily be a bunch of #define compiler macros but it might be neater like this.</remarks>
    public class BravaCodes
    {
        // enums for BRAVA Protocol Signalling control
        // ACK: Send an ACK frame: Control or Configure Parse successful.
        // VALID: Request Frame parsed OK. Response frame is being sent as reply. No further ACK required.
        // ERROR: Send an ERROR frame: Parse error or Parameter error encountered 
        // NACK: Send NACK Frame: Brava Protocol validation failed or Protocol header error.

        public enum ProtocolStatus
        {
	        NONE = 0,
	        VALID,
            NACK,
	        ERROR,
            ACK
        }

        /// <remarks>All BRAVA Bus frames can be are identified by four fields in the following order: Task, Function, Dataset, Index.</remarks>
        /// 
        // List of possible tasks: 
        public enum Tasks
        {
            Status = 1,
            Request,
            Response,
            Control,
            Configure
        }

        // This is the list of possible functions supported by BRAVA system. 
        // Some Functions may not be implemented yet.
        public enum Functions
        {
            ElectricityMeter = 1,
            WaterMeter,
            LoadSwitch,
            Display,
            Gateway,
            Server,
            GenericIO
        }

        // The different Datasets available from the Electricity metering function.
        // These datasets can be likened to set of Request / Response commands for each function.
        public enum ElectricityMeterRecords
        {
            CurrentConsumptionDelivered = 1,
            ReservedValues
        }

        // The different Record Types available from the Gateway Function for the REQUEST Task.
        public enum GatewayRecords
        {
            TypeString = 1,
            MeterReadings,
            StateBlock

        }
        // The different Record Types available from the Gateway Function for the CONFIGURE Task.
        public enum GatewayConfiguration
        {
            SetMessageRoute = 1,
            ClearMessageRoute
        }

        // The different types of communication channels from the Gateway. Affects the addressing scheme decoding.
        public enum RouteAddressType
        {
            EthernetIP = 1,
            ZigBeeMAC,
            EthernetMAC
        }

        // The Different Record Types available for the Display function
        public enum DisplayRecords
        {
            DisplayText = 1
        }

        public enum GenericIORecords
        {
            DigitalInput = 1,
            DigitalOutput
        }

        // The Different Record Types available for the Load Switch function
        public enum LoadSwitchRecords
        {
            ConnectLoad = 2,
            DisconnectLoad,
            CancelConnectLoad,
            CancelDisconnectLoad,
            SwitchBankUpdate
        }

        public enum LoadSwitchCircuits
        {
            Circuit1 = 128,
            Circuit2 = 64,
            Circuit3 = 32,
            Circuit4 = 16
        }

        // A "Dataset" is essentially a single frame of data appearing on the BRAVA System BUS.
        public enum DataSets
        {
            ElecMeter = 0x31,
            LoadSwitch = 0x32,
            WaterMeter = 0x41
        }

        public enum StateBlockRecords
        {
            NetworkAddress = 1,
            SerialNumber,
            UTCTime,
            UserString,
            Unused5,
            Unused6,
            Unused7,
            SwitchBankLS8
        }

        public enum SwitchState
        {
            NoChange = 0x01,
            SwitchOn = 0x02,
            SwitchOff = 0x03
        }

    }

}
