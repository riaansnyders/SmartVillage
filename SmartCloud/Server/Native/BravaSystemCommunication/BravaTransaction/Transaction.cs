using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections;

namespace BravaSystem.Communication
{
    /// <summary>
    /// Abstract Class for Transactions
    /// </summary>
    public abstract class BravaTransaction
    {
        #region Constants Enums
        public enum TransactionState
        { 
            Open = 1,
            Pending,
            Failed,
            Completed,
            Closed        
        }
        #endregion

        #region Data Members
        public BravaTransaction.TransactionState State;

        protected Stream m_reqStrm;
		protected Stream m_resStrm;

        #endregion

        #region Properties
        public abstract Stream RequestStream { get; }
		public abstract Stream ResponseStream { set; }

        //public virtual bool DoReadBackVerify
        //{
        //    get { m_ReadBackFlag = false; return m_ReadBackFlag; }
        //    set {}
        //}
        #endregion
    }

    /// <summary>
    /// Represents the transaction which updates the state of an 8-way switch bank
    /// </summary>
    public class SwitchbankUpdate : BravaTransaction
    {
        // Public data access
        public override Stream RequestStream
        {
            get { return (m_reqStrm); }
        }

        public override Stream ResponseStream
        {
            set { m_resStrm = value; }
        }

        // Constructors
        /// <summary>
        /// Update 8 Switches at once. Selectable Verify.
        /// </summary>
        /// <param name="SwitchState1"></param>
        /// <param name="SwitchState2"></param>
        /// <param name="SwitchState3"></param>
        /// <param name="SwitchState4"></param>
        /// <param name="SwitchState5"></param>
        /// <param name="SwitchState6"></param>
        /// <param name="SwitchState7"></param>
        /// <param name="SwitchState8"></param>
        public SwitchbankUpdate(
            BravaCodes.SwitchState SwitchState1,
            BravaCodes.SwitchState SwitchState2,
            BravaCodes.SwitchState SwitchState3, 
            BravaCodes.SwitchState SwitchState4,
            BravaCodes.SwitchState SwitchState5,
            BravaCodes.SwitchState SwitchState6,
            BravaCodes.SwitchState SwitchState7, 
            BravaCodes.SwitchState SwitchState8)
        {
            byte[] buffer = {   (byte)BravaCodes.Tasks.Control,
                                (byte)BravaCodes.Functions.LoadSwitch,
                                (byte)BravaCodes.LoadSwitchRecords.SwitchBankUpdate,
                                (byte)8                                                 // Number of switches being updated by this command.
                            };
            #region RequestStream for Controlling the 8 Switches.
            m_reqStrm = new MemoryStream(16);
            // Write Header
            m_reqStrm.Write(buffer, 0, 4);

            // Add in the 8 switch states.
            // 
            // TODO: Likely change this entire thing to some form of collection with a foreach loop instead and limits check in front.
            //  for now it'll do pig... it'll do.
            m_reqStrm.WriteByte((byte)SwitchState1);
            m_reqStrm.WriteByte((byte)SwitchState2);
            m_reqStrm.WriteByte((byte)SwitchState3);
            m_reqStrm.WriteByte((byte)SwitchState4);
            m_reqStrm.WriteByte((byte)SwitchState5);
            m_reqStrm.WriteByte((byte)SwitchState6);
            m_reqStrm.WriteByte((byte)SwitchState7);
            m_reqStrm.WriteByte((byte)SwitchState8);
            
            // ReSynce UTC Time Base
            DateTime TimeBase = DateTime.Parse("01 January 2000");
            DateTime UTCTime = DateTime.UtcNow;

            TimeSpan UTCOffset = (TimeSpan)(UTCTime - TimeBase);

            int reqTimeStamp = (int)UTCOffset.TotalSeconds;

            System.Diagnostics.Debug.WriteLine("UTC Seconds is" + reqTimeStamp.ToString());

            buffer = BitConverter.GetBytes(reqTimeStamp);
            m_reqStrm.Write(buffer, 0, 4);
            // 16 bytes long
            #endregion

            this.State = TransactionState.Open;
        }
    }

    /// <summary>
    /// Represents the transaction that opens (disconnects) a specific load switch.
    /// </summary>
    public class DisconnectSwitch : BravaTransaction
    {
        // Public data access
        public override Stream RequestStream
        {
            get { return (m_reqStrm); }
        }

        public override Stream ResponseStream
        {
            set { m_resStrm = value; }
        }

        // Constructors
        public DisconnectSwitch(byte bCircuitNumber, byte bTimeDuration, byte bTimeOffset)
        {
            byte[] buffer = {   (byte)BravaCodes.Tasks.Control,
                                (byte)BravaCodes.Functions.LoadSwitch,
                                (byte)BravaCodes.LoadSwitchRecords.DisconnectLoad,
                                (byte)bCircuitNumber
                            };
            // Header
            m_reqStrm = new MemoryStream(10);
            m_reqStrm.Write(buffer, 0, 4);

            // Write Filler
            m_reqStrm.WriteByte(bTimeDuration);
            m_reqStrm.WriteByte(bTimeOffset);             // Offset from Time base.

            // ReSynce UTC Time Base
            DateTime TimeBase = DateTime.Parse("01 January 2000");
            DateTime UTCTime = DateTime.UtcNow;

            TimeSpan UTCOffset = (TimeSpan)(UTCTime - TimeBase);

            int reqTimeStamp = (int)UTCOffset.TotalSeconds;

            System.Diagnostics.Debug.WriteLine("UTC Seconds is" + reqTimeStamp.ToString());

            buffer = BitConverter.GetBytes(reqTimeStamp);
            m_reqStrm.Write(buffer, 0, 4);
        }
    }

    /// <summary>
    /// Represents the transaction that closes (connects) a specific load switch.
    /// </summary>
    public class ConnectSwitch : BravaTransaction
    {
        // Public data access
        public override Stream RequestStream
        {
            get { return (m_reqStrm); }
        }

        public override Stream ResponseStream
        {
            set { m_resStrm = value; }
        }

        // Constructors
        public ConnectSwitch(byte bCircuitNumber, byte bTimeDuration, byte bTimeOffset)
        {
            byte[] buffer = {   (byte)BravaCodes.Tasks.Control,
                                (byte)BravaCodes.Functions.LoadSwitch,
                                (byte)BravaCodes.LoadSwitchRecords.ConnectLoad,
                                bCircuitNumber
                            };
            // Header
            m_reqStrm = new MemoryStream(10);
            m_reqStrm.Write(buffer, 0, 4);

            // Write Filler
            m_reqStrm.WriteByte(bTimeDuration);
            m_reqStrm.WriteByte(bTimeOffset);             // Offset from Time base.

            // ReSynce UTC Time Base
            DateTime TimeBase = DateTime.Parse("01 January 2000");
            DateTime UTCTime = DateTime.UtcNow;

            TimeSpan UTCOffset = (TimeSpan)(UTCTime - TimeBase);

            int reqTimeStamp = (int)UTCOffset.TotalSeconds;

            System.Diagnostics.Debug.WriteLine("UTC Seconds is" + reqTimeStamp.ToString());

            buffer = BitConverter.GetBytes(reqTimeStamp);
            m_reqStrm.Write(buffer, 0, 4);
        }
    }

    /// <summary>
    /// Represents the Transaction required to cause a text message to display on the BRAVA LCD display.
    /// </summary>
    public class DisplayText : BravaTransaction
    {
        // Public data access
        public override Stream RequestStream
        {
            get { return (m_reqStrm); }
        }

        public override Stream ResponseStream
        {
            set { m_resStrm = value; }
        }

        // Constructors
        public DisplayText(string strMessage, byte bMsgNumber)
        {
            byte[] buffer = {   (byte)BravaCodes.Tasks.Response,
                                (byte)BravaCodes.Functions.Display,
                                (byte)BravaCodes.DisplayRecords.DisplayText,
                                bMsgNumber
                            };
            // Header
            m_reqStrm = new MemoryStream(10);
            m_reqStrm.Write(buffer, 0, 4);

            // Write Filler
            m_reqStrm.WriteByte(0x30);
            m_reqStrm.WriteByte(0x30);

            //
            DateTime TimeBase = DateTime.Parse("01 January 2000");
            DateTime UTCTime = DateTime.UtcNow;

            TimeSpan UTCOffset = (TimeSpan)(UTCTime - TimeBase);

            int reqTimeStamp = (int)UTCOffset.TotalSeconds;

            System.Diagnostics.Debug.WriteLine("UTC Seconds is" + reqTimeStamp.ToString());

            buffer = BitConverter.GetBytes(reqTimeStamp);
            m_reqStrm.Write(buffer, 0, 4);

            // Only write the first 20 bytes of the message string to the BRAVA
            if (strMessage.Length < 20)
                strMessage = strMessage.PadRight(20, ' ');

            ;
            m_reqStrm.Write(System.Text.ASCIIEncoding.ASCII.GetBytes(strMessage.ToCharArray()), 0, 20);

            // 30 bytes long 
        }
    }

    /// <summary>
	/// Represents the Request / Response sequence to get the BRAVA Type number
	/// </summary>
	public class RequestType : BravaTransaction
	{
		// Public data access
		public override Stream RequestStream
		{
			get { return(m_reqStrm); }
		}

		public override Stream ResponseStream
		{
			set { m_resStrm = value; }
		}

		public System.Xml.XmlDocument ResultXML;

		// Constructors
		public RequestType()
		{
			byte[] buffer = {   (byte)BravaCodes.Tasks.Request, 
								(byte)BravaCodes.Functions.Gateway, 
								(byte)BravaCodes.GatewayRecords.TypeString, 
							    (byte)BravaConstants.AllRecords }; // 
			m_reqStrm = new MemoryStream(10);
			// Write Header()
			m_reqStrm.Write(buffer, 0, 4);

			// Write Filler
			m_reqStrm.WriteByte(0x30);
			m_reqStrm.WriteByte(0x30);

			DateTime TimeBase = DateTime.Parse("01 January 2000");
			DateTime UTCTime = DateTime.UtcNow;

			TimeSpan UTCOffset = (TimeSpan)(UTCTime - TimeBase);

			int reqTimeStamp = (int)UTCOffset.TotalSeconds;

            System.Diagnostics.Debug.WriteLine("UTC Seconds is"+reqTimeStamp.ToString());
			
			buffer = BitConverter.GetBytes(reqTimeStamp);
			m_reqStrm.Write(buffer, 0, 4);
		}

		public void ParseResultStream()
		{
			// Copy response stream into a more versatile memory stream.
			byte[] bufferBytes = new byte[m_resStrm.Length];

            m_resStrm.Seek(0, SeekOrigin.Begin);

			m_resStrm.Read(bufferBytes, 0, (int)m_resStrm.Length);
			
			MemoryStream resMemStr = new MemoryStream();
            if ((m_resStrm.Length == (BravaConstants.INFOMESSAGERECORDLENGTH + 5)) &&
                 (bufferBytes[4] == 0x01)) // First byte must always be '0x01': Number Of Records
            {
                if ((bufferBytes[0] == (byte)BravaCodes.Tasks.Response) &&
                    (bufferBytes[1] == (byte)BravaCodes.Functions.Gateway) &&
                    (bufferBytes[2] == (byte)BravaCodes.GatewayRecords.TypeString) &&
                    (bufferBytes[3] == (byte)BravaConstants.AllRecords))
                {
                    // Response Header Correlates with Request info
                    XmlTextWriter writer = new XmlTextWriter(resMemStr, Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("Transaction", "BravaSystem.Communication");
                    writer.WriteStartElement("Response");
                    writer.WriteStartElement("Header");
                    writer.WriteAttributeString("Task", XmlConvert.ToString(bufferBytes[0]));
                    writer.WriteAttributeString("Function", XmlConvert.ToString(bufferBytes[1]));
                    writer.WriteAttributeString("RecordType", XmlConvert.ToString(bufferBytes[2]));
                    writer.WriteAttributeString("RecordIndex", XmlConvert.ToString(bufferBytes[3]));
                    writer.WriteEndElement();  // End "Header"

                    writer.WriteStartElement("Data");
                    writer.WriteAttributeString("RecordCount", XmlConvert.ToString(bufferBytes[4]));

                    writer.WriteStartElement("Record");
                    writer.WriteAttributeString("BravaType", BitConverter.ToString(bufferBytes, 5, 6));
                    writer.WriteAttributeString("MACAddress", BitConverter.ToString(bufferBytes, 11, 6));
                    writer.WriteEndElement(); // End "Record"

                    writer.WriteEndElement(); // End "Data"

                    writer.WriteEndElement(); // End "Response"

                    writer.WriteEndElement(); // End "Transaction"

                    writer.WriteEndDocument();

                    writer.Flush();

                    this.ResultXML = new XmlDocument();
                    resMemStr.Seek(0, SeekOrigin.Begin);
                    this.ResultXML.Load(resMemStr);

                    // DEBUG:
                    System.Diagnostics.Debug.WriteLine(this.ResultXML.OuterXml);

                    writer.Close();

                    this.State = TransactionState.Closed;
                }
                else { this.State = TransactionState.Failed; }  // Failed Header Validation.
            }
            else { this.State = TransactionState.Failed; }      // Failed frame length validation.

		}

	}

	/// <summary>
	/// Represents the request / response sequence needed to get measurement readings.
    /// For BRAVA System 1. 
	/// </summary>
	public class RequestReadings : BravaTransaction
	{
		// Public data access
		public override Stream RequestStream
		{
			get { return(m_reqStrm); }
		}

		public override Stream ResponseStream
		{
			set { m_resStrm = value; }
		}

		public System.Xml.XmlDocument ResultXML;

		// Constructors
		public RequestReadings()
		{
			byte[] buffer = {   (byte)BravaCodes.Tasks.Request,
								(byte)BravaCodes.Functions.Gateway, 
								(byte)BravaCodes.GatewayRecords.MeterReadings, 
								(byte)BravaConstants.AllRecords};
			m_reqStrm = new MemoryStream(10);

			//Write Header
			m_reqStrm.Write(buffer, 0, 4);

			// Write Filler
			m_reqStrm.WriteByte(0x30);
			m_reqStrm.WriteByte(0x30);

			DateTime TimeBase = DateTime.Parse("01 January 2000");
			DateTime UTCTime = DateTime.UtcNow;

			TimeSpan UTCOffset = (TimeSpan)(UTCTime - TimeBase);

			int reqTimeStamp = (int)UTCOffset.TotalSeconds;

			buffer = BitConverter.GetBytes(reqTimeStamp);
			m_reqStrm.Write(buffer, 0, 4);
		}

		// Methods

		/// <summary>
		/// Parses the stream returned from the BRAVA System.
		/// This is in the format:
        /// [Number of records(1 byte)][Record 00(12 bytes)][Record nn(12 bytes)]
		/// </summary>
		public void ParseResultStream()  
		{
			// Copy response stream into a more versatile memory stream.
			byte[] bufferBytes = new byte[m_resStrm.Length];

            m_resStrm.Seek(0, SeekOrigin.Begin);

            m_resStrm.Read(bufferBytes, 0, (int)m_resStrm.Length);

			MemoryStream resMemStr = new MemoryStream();

            // First Byte: Last Record available index = Number of Records - 1.
            byte b_numRecords = bufferBytes[4];

            // b_numRecords++;
			
			// Check that input frame length matches the number of records.

            if (m_resStrm.Length == ((b_numRecords * BravaConstants.INFOMESSAGERECORDLENGTH) + 5))
			{ 
				// Frame length matches
				if ((bufferBytes[0] == (byte)BravaCodes.Tasks.Response) &&
					(bufferBytes[1] == (byte)BravaCodes.Functions.Gateway) &&
					(bufferBytes[2] == (byte)BravaCodes.GatewayRecords.MeterReadings) &&
                    (bufferBytes[3] == (byte)BravaConstants.AllRecords))
				{ 
					// Response Header Correlates with Request header.
					XmlTextWriter writer = new XmlTextWriter(resMemStr, Encoding.UTF8);
					writer.Formatting = Formatting.Indented;

					writer.WriteStartDocument();
					writer.WriteStartElement("Transaction", "BravaSystem.Communication");
					writer.WriteStartElement("Response");
					writer.WriteStartElement("Header");
					writer.WriteAttributeString("Task", XmlConvert.ToString(bufferBytes[0]));
					writer.WriteAttributeString("Function", XmlConvert.ToString(bufferBytes[1]));
					writer.WriteAttributeString("RecordType", XmlConvert.ToString(bufferBytes[2]));
					writer.WriteAttributeString("RecordIndex", XmlConvert.ToString(bufferBytes[3]));
					writer.WriteEndElement();  // End "Header"

					writer.WriteStartElement("Data");
					writer.WriteAttributeString("RecordCount", XmlConvert.ToString(bufferBytes[4]));

					// Loop through all the records.
					for (int recnum = 0; recnum < b_numRecords; recnum++)
					{
                        Int16 iCanSid = BitConverter.ToInt16(bufferBytes, ((recnum * BravaConstants.INFOMESSAGERECORDLENGTH) + 5)); // +5+0: CAN SID (2 bytes)

                        iCanSid >>= 3;

                        writer.WriteStartElement("Record");
                        switch (iCanSid)
                        {
                            case (Int16)BravaCodes.DataSets.ElecMeter:
                                writer.WriteAttributeString("MeterType", "Electricity");
                                writer.WriteAttributeString("UnitScale", "1");
                                writer.WriteAttributeString("Unit", "wH");
                                writer.WriteAttributeString("MeterValue", XmlConvert.ToString(BitConverter.ToUInt32(bufferBytes, (recnum * BravaConstants.INFOMESSAGERECORDLENGTH) + 9)));  // +5+4: Wh reading 
                                writer.WriteAttributeString("TimeStamp", XmlConvert.ToString(BitConverter.ToUInt32(bufferBytes, (recnum * BravaConstants.INFOMESSAGERECORDLENGTH) + 13)));   // +5+8: Time Stamp in 1 second intervals.
                                break;

                            case (Int16)BravaCodes.DataSets.WaterMeter:
                                writer.WriteAttributeString("MeterType", "Water");
                                writer.WriteAttributeString("UnitScale", "0.5");
                                writer.WriteAttributeString("Unit", "L");
                                writer.WriteAttributeString("MeterValue", XmlConvert.ToString(BitConverter.ToUInt32(bufferBytes, (recnum * BravaConstants.INFOMESSAGERECORDLENGTH) + 9)));  // +5+4: Water Meter Reading
                                writer.WriteAttributeString("TimeStamp", XmlConvert.ToString(BitConverter.ToUInt32(bufferBytes, (recnum * BravaConstants.INFOMESSAGERECORDLENGTH) + 13)));   // +5+8: Time Stamp in 1 second intervals.
                                break;

                            case (Int16)BravaCodes.DataSets.LoadSwitch:
                                writer.WriteAttributeString("MeterType", "LoadSwitch");
                                writer.WriteAttributeString("UnitScale", "0.1");
                                writer.WriteAttributeString("Unit", "kW");
                                // +5+3: Load Switch Status Bit flags.                     
                                byte bSwitchState = bufferBytes[(recnum * BravaConstants.INFOMESSAGERECORDLENGTH) + 8];

                                writer.WriteAttributeString("Circuit1State", (bSwitchState & (byte)BravaCodes.LoadSwitchCircuits.Circuit1) != 0 ? "Connect" : "Disconnect");  // Bit 0: Switch1 State
                                writer.WriteAttributeString("Circuit2State", (bSwitchState & (byte)BravaCodes.LoadSwitchCircuits.Circuit2) != 0 ? "Connect" : "Disconnect");  // Bit 1: Switch1 State
                                writer.WriteAttributeString("Circuit3State", (bSwitchState & (byte)BravaCodes.LoadSwitchCircuits.Circuit3) != 0 ? "Connect" : "Disconnect");  // Bit 2: Switch1 State
                                writer.WriteAttributeString("Circuit4State", (bSwitchState & (byte)BravaCodes.LoadSwitchCircuits.Circuit4) != 0 ? "Connect" : "Disconnect");  // Bit 3: Switch1 State


                                writer.WriteAttributeString("PowerValue1", (bufferBytes[(recnum * BravaConstants.INFOMESSAGERECORDLENGTH) + 9]).ToString());  // +5+4:  Power Meter Reading
                                writer.WriteAttributeString("PowerValue2", (bufferBytes[(recnum * BravaConstants.INFOMESSAGERECORDLENGTH) + 10]).ToString());  // +5+5: Power Meter Reading
                                writer.WriteAttributeString("PowerValue3", (bufferBytes[(recnum * BravaConstants.INFOMESSAGERECORDLENGTH) + 11]).ToString());  // +5+6: Power Meter Reading
                                writer.WriteAttributeString("PowerValue4", (bufferBytes[(recnum * BravaConstants.INFOMESSAGERECORDLENGTH) + 12]).ToString());  // +5+7: Power Meter Reading

                                writer.WriteAttributeString("TimeStamp", XmlConvert.ToString(BitConverter.ToUInt32(bufferBytes, (recnum * BravaConstants.INFOMESSAGERECORDLENGTH) + 13)));   // +5+8: Time Stamp in 1 second intervals.
                                break;

                        }

                        writer.WriteEndElement(); // End "Record"
                    }

					writer.WriteEndElement(); // End "Data"

					writer.WriteEndElement(); // End "Response"

					writer.WriteEndElement(); // End "Transaction"

					writer.WriteEndDocument();

					writer.Flush();

					this.ResultXML = new XmlDocument();
					resMemStr.Seek(0, SeekOrigin.Begin);
					this.ResultXML.Load(resMemStr);

					// DEBUG:
					System.Diagnostics.Debug.WriteLine(this.ResultXML.OuterXml);

					writer.Close();

                    this.State = TransactionState.Closed;

				}
			}	
		}

	}

    /// <summary>
    /// Represents the request / response sequence needed to get measurement readings.
    /// LSV1 and LS8 based load switch system.
    /// </summary>
    public class RequestStateBlock : BravaTransaction
    {
        // Public data access
        public override Stream RequestStream
        {
            get { return (m_reqStrm); }
        }

        public override Stream ResponseStream
        {
            set { m_resStrm = value; }
        }

        public System.Xml.XmlDocument ResultXML;

        // Constructors
        public RequestStateBlock() : this((byte)BravaConstants.AllRecords)
        {

        }

        public RequestStateBlock(byte recIndex)
        {
            byte[] buffer = {   (byte)BravaCodes.Tasks.Request,
								(byte)BravaCodes.Functions.Gateway, 
								(byte)BravaCodes.GatewayRecords.StateBlock, 
								(byte)recIndex};
            m_reqStrm = new MemoryStream(10);

            //Write Header
            m_reqStrm.Write(buffer, 0, 4);

            // Write Filler
            m_reqStrm.WriteByte(0x30);
            m_reqStrm.WriteByte(0x30);

            DateTime TimeBase = DateTime.Parse("01 January 2000");
            DateTime UTCTime = DateTime.UtcNow;

            TimeSpan UTCOffset = (TimeSpan)(UTCTime - TimeBase);

            int reqTimeStamp = (int)UTCOffset.TotalSeconds;

            buffer = BitConverter.GetBytes(reqTimeStamp);
            m_reqStrm.Write(buffer, 0, 4);
        }

        // Methods
        public BravaCodes.SwitchState[] ParseSwitchStates(int numSwitches)
        {
            BravaCodes.SwitchState[] resultStates = new BravaCodes.SwitchState[numSwitches];
            // Copy response stream into a more versatile memory stream.
            byte[] bufferBytes = new byte[m_resStrm.Length];

            m_resStrm.Seek(0, SeekOrigin.Begin);

            m_resStrm.Read(bufferBytes, 0, (int)m_resStrm.Length);

            MemoryStream resMemStr = new MemoryStream();

            // First Byte: Last Record available index = Number of Records - 1.
            byte b_numRecords = bufferBytes[4];

            // Check that input frame length matches the number of records.

            if (m_resStrm.Length == ((b_numRecords * BravaConstants.STATEBLOCKRECORDLENGTH) + 5))
            {
                // Frame length matches
                if ((bufferBytes[0] == (byte)BravaCodes.Tasks.Response) &&
                    (bufferBytes[1] == (byte)BravaCodes.Functions.Gateway) &&
                    (bufferBytes[2] == (byte)BravaCodes.GatewayRecords.StateBlock) &&
                    (bufferBytes[3] == (byte)BravaCodes.StateBlockRecords.SwitchBankLS8))
                {
                    // Header validation OK
                    if (numSwitches > 32) numSwitches = 32;

                    for (int n = 0; n < numSwitches; n++)
                    {
                        resultStates[n] = (bufferBytes[0xc + n] == 0x03 ? BravaCodes.SwitchState.SwitchOff : BravaCodes.SwitchState.SwitchOn);
                    }

                    this.State = TransactionState.Closed;
                }
            }

            return resultStates;
        }
        /// <summary>
        /// Parses the stream returned from the BRAVA System.
        /// This is in the format:
        /// [Number of records(1 byte)][Record 00(12 bytes)][Record nn(12 bytes)]
        /// </summary>
        public void ParseResultStream()
        {
            // Copy response stream into a more versatile memory stream.
            byte[] bufferBytes = new byte[m_resStrm.Length];

            m_resStrm.Seek(0, SeekOrigin.Begin);

            m_resStrm.Read(bufferBytes, 0, (int)m_resStrm.Length);

            MemoryStream resMemStr = new MemoryStream();

            // First Byte: Last Record available index = Number of Records - 1.
            byte b_numRecords = bufferBytes[4];
            m_reqStrm.Seek(3, SeekOrigin.Begin);
            byte b_recIndexReq = (byte)m_reqStrm.ReadByte();

            // b_numRecords++;

            // Check that input frame length matches the number of records.

            if (m_resStrm.Length == ((b_numRecords * BravaConstants.STATEBLOCKRECORDLENGTH) + 5))
            {
                // Frame length matches
                if ((bufferBytes[0] == (byte)BravaCodes.Tasks.Response) &&
                    (bufferBytes[1] == (byte)BravaCodes.Functions.Gateway) &&
                    (bufferBytes[2] == (byte)BravaCodes.GatewayRecords.StateBlock) &&
                    (bufferBytes[3] == b_recIndexReq))
                {
                    // Response Header Correlates with Request header.
                    XmlTextWriter writer = new XmlTextWriter(resMemStr, Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("Transaction", "BravaSystem.Communication");
                    writer.WriteStartElement("Response");
                    writer.WriteStartElement("Header");
                    writer.WriteAttributeString("Task", XmlConvert.ToString(bufferBytes[0]));
                    writer.WriteAttributeString("Function", XmlConvert.ToString(bufferBytes[1]));
                    writer.WriteAttributeString("RecordType", XmlConvert.ToString(bufferBytes[2]));
                    writer.WriteAttributeString("RecordIndex", XmlConvert.ToString(bufferBytes[3]));
                    writer.WriteEndElement();  // End "Header"

                    writer.WriteStartElement("Data");
                    writer.WriteAttributeString("RecordCount", XmlConvert.ToString(bufferBytes[4]));

                    // Loop through all the records.
                    for (int recnum = 0; recnum < b_numRecords; recnum++)
                    {
                        int iBufferOffset = 5 + (recnum * (int)BravaConstants.STATEBLOCKRECORDLENGTH);
                        
                        writer.WriteStartElement("Record");

                        byte cRecordIndex = bufferBytes[iBufferOffset];   // First Byte is a form of Record Type.
                        writer.WriteAttributeString("RecordID", XmlConvert.ToString(cRecordIndex));

                        switch (cRecordIndex)
                        {
                            case (byte)BravaCodes.StateBlockRecords.NetworkAddress:
                                writer.WriteAttributeString("MACAddress", BitConverter.ToString(bufferBytes, 5 + (recnum * BravaConstants.STATEBLOCKRECORDLENGTH) + 1  , 6));
                                writer.WriteAttributeString("IPAddress",  BitConverter.ToString(bufferBytes, 5 + (recnum * BravaConstants.STATEBLOCKRECORDLENGTH) + 1 + 6, 4));
                                writer.WriteAttributeString("TimeStamp", XmlConvert.ToString(BitConverter.ToUInt32(bufferBytes, (recnum * BravaConstants.STATEBLOCKRECORDLENGTH) + 1 + 6 +4)));   // Time Stamp in 1 second intervals from date 01 Jan 2000
                                break;

                            case (byte)BravaCodes.StateBlockRecords.SerialNumber:
                                writer.WriteAttributeString("SerialNumber", BitConverter.ToString(bufferBytes, 5 + (recnum * BravaConstants.STATEBLOCKRECORDLENGTH) + 1 , 10)); 
                                break;

                            case (byte)BravaCodes.StateBlockRecords.UTCTime:
                                writer.WriteAttributeString("UTCTime", BitConverter.ToString(bufferBytes, 5 + (recnum * BravaConstants.STATEBLOCKRECORDLENGTH) + 1, 4)); 
                                break;

                            case (byte)BravaCodes.StateBlockRecords.UserString:
                                writer.WriteAttributeString("UserString", BitConverter.ToString(bufferBytes, 5 + (recnum * BravaConstants.STATEBLOCKRECORDLENGTH) + 1, 16));
                                break;

                            case (byte)BravaCodes.StateBlockRecords.SwitchBankLS8:
                                // BRAVA System 1:
                                // writer.WriteAttributeString("Circuit1State", (bSwitchState & (byte)BravaCodes.LoadSwitchCircuits.Circuit1) != 0 ? "Connect" : "Disconnect");  // Bit 0: Switch1 State
                                // BRAVA Multi LS8.
                                //writer.WriteAttributeString("Circuit1State", (bufferBytes[5 + (recnum * BravaConstants.STATEBLOCKRECORDLENGTH) + 1 + 6]) == 0x12 ? "Connected":"Disconnected");
                                writer.WriteAttributeString("Circuit1State", (bufferBytes[5 + (recnum * BravaConstants.STATEBLOCKRECORDLENGTH) + 1 + 6]) == 0x03 ? "Disconnected":"Connected");
                                writer.WriteAttributeString("Circuit2State", (bufferBytes[5 + (recnum * BravaConstants.STATEBLOCKRECORDLENGTH) + 1 + 7]) == 0x03 ? "Disconnected":"Connected");
                                writer.WriteAttributeString("Circuit3State", (bufferBytes[5 + (recnum * BravaConstants.STATEBLOCKRECORDLENGTH) + 1 + 8]) == 0x03 ? "Disconnected":"Connected");
                                writer.WriteAttributeString("Circuit4State", (bufferBytes[5 + (recnum * BravaConstants.STATEBLOCKRECORDLENGTH) + 1 + 9]) == 0x03 ? "Disconnected":"Connected");
                                writer.WriteAttributeString("Circuit5State", (bufferBytes[5 + (recnum * BravaConstants.STATEBLOCKRECORDLENGTH) + 1 + 10]) == 0x03 ? "Disconnected":"Connected");
                                writer.WriteAttributeString("Circuit6State", (bufferBytes[5 + (recnum * BravaConstants.STATEBLOCKRECORDLENGTH) + 1 + 11]) == 0x03 ? "Disconnected":"Connected");
                                writer.WriteAttributeString("Circuit7State", (bufferBytes[5 + (recnum * BravaConstants.STATEBLOCKRECORDLENGTH) + 1 + 12]) == 0x03 ? "Disconnected":"Connected");
                                writer.WriteAttributeString("Circuit8State", (bufferBytes[5 + (recnum * BravaConstants.STATEBLOCKRECORDLENGTH) + 1 + 13]) == 0x03 ? "Disconnected":"Connected");
                                break;
                        }

                        writer.WriteEndElement(); // End "Record"
                    }

                    writer.WriteEndElement(); // End "Data"

                    writer.WriteEndElement(); // End "Response"

                    writer.WriteEndElement(); // End "Transaction"

                    writer.WriteEndDocument();

                    writer.Flush();

                    this.ResultXML = new XmlDocument();
                    resMemStr.Seek(0, SeekOrigin.Begin);
                    this.ResultXML.Load(resMemStr);

                    // DEBUG:
                    System.Diagnostics.Debug.WriteLine(this.ResultXML.OuterXml);

                    writer.Close();

                    this.State = TransactionState.Closed;

                }
            }
        }

    }

    /// <summary>
    /// Represents the Transaction required to set a message routing rule for the Gateway.
    /// </summary>
    public class ConfigureAlertMessageRoute : BravaTransaction
    {
        // Public data access
        public override Stream RequestStream
        {
            get { return (m_reqStrm); }
        }

        public override Stream ResponseStream
        {
            set { m_resStrm = value; }
        }

        // Constructors
        public ConfigureAlertMessageRoute(byte bRouteNumber, System.Net.IPAddress destIPAddress, int destPortNum)
        {
            byte[] buffer = {   (byte)BravaCodes.Tasks.Configure,
                                (byte)BravaCodes.Functions.Gateway,
                                (byte)BravaCodes.GatewayConfiguration.SetMessageRoute,
                                bRouteNumber                                // This number is application specific. This route is stored and referenced by this number.
                            };
            // Header
            m_reqStrm = new MemoryStream(16);
            m_reqStrm.Write(buffer, 0, 4);

            // Write Route Address Record.
            // Layout [bytes]{Array}
            // [RouteNumber][RouteAddressType=EthernetIP(1)][TASK][FUNCTION][DATASET][RECORDINDEX]{IPADR0..4}{PORT0..1}{UTC_TIME0..4}
            m_reqStrm.WriteByte(bRouteNumber);
            m_reqStrm.WriteByte((byte)BravaCodes.RouteAddressType.EthernetIP);
            
            // Write the Message ID that must be routed.
            byte[] buffer1 = {  (byte)BravaCodes.Tasks.Status,
                                (byte)BravaCodes.Functions.GenericIO,
                                (byte)BravaCodes.GenericIORecords.DigitalInput,
                                (byte)BravaConstants.AllRecords
                            };

            m_reqStrm.Write(buffer1, 0, 4);

            // Write the destination Address for the specified Message ID.
            // In this case it's IP address and Port Address.
            m_reqStrm.Write(destIPAddress.GetAddressBytes(), 0, 4);
            m_reqStrm.Write(BitConverter.GetBytes(destPortNum), 0, 2);

            // Write the UTC Time Stamp.
            DateTime TimeBase = DateTime.Parse("01 January 2000");
            DateTime UTCTime = DateTime.UtcNow;

            TimeSpan UTCOffset = (TimeSpan)(UTCTime - TimeBase);

            int reqTimeStamp = (int)UTCOffset.TotalSeconds;

            System.Diagnostics.Debug.WriteLine("UTC Seconds is" + reqTimeStamp.ToString());

            buffer = BitConverter.GetBytes(reqTimeStamp);
            m_reqStrm.Write(buffer, 0, 4);

            // 20 bytes long
        }
    }

    /// <summary>
    /// Represents the request / response sequence needed to get measurement readings.
    /// For PM9. 9 channel Power Meter Reader via Serial/Modem interface.
    /// </summary>
    public class RequestElectricityMeter : BravaTransaction
    {
        // Public data access
        public override Stream RequestStream
        {
            get { return (m_reqStrm); }
        }

        public override Stream ResponseStream
        {
            set { m_resStrm = value; }
        }

        public System.Xml.XmlDocument ResultXML;

        // Constructors
        public RequestElectricityMeter()
        {
            byte[] data = new byte[30];
            int checksum = 0;
            m_reqStrm = new MemoryStream();

            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();

            byte[] dataHeaderBin = {
                                (byte)BravaCodes.Tasks.Request,
                                (byte)BravaCodes.Functions.ElectricityMeter,
                                (byte)BravaCodes.ElectricityMeterRecords.CurrentConsumptionDelivered,
                                (byte)BravaConstants.AllRecords
                                };

            checksum += BravaUtilities.GetCheckSum(dataHeaderBin, 0, dataHeaderBin.Length - 1);

            byte[] dataHeaderAsc = enc.GetBytes(BravaUtilities.ByteArrayToHexString(dataHeaderBin));

            byte[] dataPayloadBin = new byte[8];

            Array.Copy(enc.GetBytes(ZIRODEConstants.ZIRODECODE1), dataPayloadBin, 4);
            Array.Copy(BitConverter.GetBytes(BravaUtilities.GetUTCTimeStamp()), 0, dataPayloadBin, 4, 4);

            checksum += BravaUtilities.GetCheckSum(dataPayloadBin, 0, dataPayloadBin.Length - 1);

            byte[] dataPayloadAsc = enc.GetBytes(BravaUtilities.ByteArrayToHexString(dataPayloadBin));

            byte[] checksumAsc = enc.GetBytes(BravaUtilities.ByteArrayToHexString(BitConverter.GetBytes((byte)checksum)));

            // Concatenate all blocks to output buffer.
            System.Buffer.BlockCopy(dataHeaderAsc, 0, data, 1, 8);
            System.Buffer.BlockCopy(dataPayloadAsc, 0, data, 10, 16);
            System.Buffer.BlockCopy(checksumAsc, 0, data, 27, 2);
            data[0] = 0x01;
            data[9] = 0x02;
            data[26] = 0x03;
            data[29] = 0x04;

            m_reqStrm.Write(data, 0, data.Length);
        }

        // Methods

        /// <summary>
        /// Parses Result Stream from PM9 system.
        /// </summary>
        public void ParseResultStream()
        {
            // Copy response stream into a more versatile memory stream.
            byte[] bufferBytes = new byte[m_resStrm.Length];

            m_resStrm.Seek(0, SeekOrigin.Begin);

            m_resStrm.Read(bufferBytes, 0, (int)m_resStrm.Length);

            MemoryStream resMemStr = new MemoryStream();

            int bytesRead;

            byte[] headerbytes = null;
            byte[] recordSetHeaderBytes = null;

            ArrayList recordSetBytes = new ArrayList();

            #region Test Debug Code
            //MemoryStream resMemStr = new MemoryStream();
            //System.Xml.XmlDocument ResultXML;

            //FileStream fs = File.Open(@"C:\Buffer\Reply_PM9_1.bin", FileMode.Open, FileAccess.Read);

            //bufferBytes = new byte[fs.Length];

            //fs.Seek(0, SeekOrigin.Begin);

            //bytesRead = fs.Read(bufferBytes, 0, (int)fs.Length);
            //fs.Close();
            #endregion

            #region Deserialise
            // Now we have a byte array of the stream with tranmission markers and data in ASCII hex.
            // Now validate transmission Markers are all there.
            // quick and simple method... not optimal ram usage ...
            int indexSOH = Array.IndexOf(bufferBytes, (byte)0x01);
            int indexSTX = Array.IndexOf(bufferBytes, (byte)0x02);
            int indexEOT = Array.IndexOf(bufferBytes, (byte)0x04);
            int indexCR1 = Array.IndexOf(bufferBytes, (byte)0x0d);

            // check existence and relative position.
            if ((indexSOH >= 0) && (indexSTX == indexSOH + 9) && (indexCR1 > indexSTX) && (indexEOT > indexCR1))
            {
                // markers exist and are correct in relation to each other.
                // Remove markers and de-serialise into seperate binary arrays.

                // get different sections in binary;
                headerbytes = BravaUtilities.HexBytesToByteArray(bufferBytes, indexSOH + 1, 4);
                recordSetHeaderBytes = BravaUtilities.HexBytesToByteArray(bufferBytes, indexSTX + 1, (indexCR1 - 1 - indexSTX) / 2);

                // Check if correct transaction.
                if (headerbytes[0] == 0x03 && headerbytes[1] == 0x01 && headerbytes[2] == 0x01)
                {
                    int numRecords = headerbytes[3];
                    int recordStart = indexCR1 + 1;
                    // find next record end marker
                    int recordEnd;

                    for (int n = 0; n < numRecords; n++)
                    {
                        recordEnd = Array.IndexOf(bufferBytes, (byte)0x0d, recordStart);
                        byte[] recordBytes = BravaUtilities.HexBytesToByteArray(bufferBytes, recordStart, (recordEnd - recordStart) / 2);
                        recordSetBytes.Add(recordBytes);
                        recordStart = recordEnd + 1;
                    }
                }
            }
            #endregion

            #region Parse To XML
            // Now parse the different byte sections into an XML document.

            XmlTextWriter writer = new XmlTextWriter(resMemStr, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;

            writer.WriteStartDocument();
            writer.WriteStartElement("Transaction", "BravaSystem.Communication");
            writer.WriteStartElement("Response");
            writer.WriteStartElement("Header");
            writer.WriteAttributeString("Task", XmlConvert.ToString(headerbytes[0]));
            writer.WriteAttributeString("Function", XmlConvert.ToString(headerbytes[1]));
            writer.WriteAttributeString("RecordType", XmlConvert.ToString(headerbytes[2]));
            writer.WriteAttributeString("RecordCount", XmlConvert.ToString(headerbytes[3]));
            writer.WriteEndElement();  // End "Header"

            writer.WriteStartElement("Data");
            writer.WriteAttributeString("RecordCount", XmlConvert.ToString(headerbytes[3]));
            writer.WriteAttributeString("UTCTime", BravaUtilities.GetUTCTime(BitConverter.ToUInt32(recordSetHeaderBytes, 4)).ToString());

            // Now Loop through all the records.
            foreach (byte[] recordBytes in recordSetBytes)
            {
                writer.WriteStartElement("Record");
                writer.WriteAttributeString("RecordType", XmlConvert.ToString(recordBytes[0]));
                writer.WriteAttributeString("ZBNode", XmlConvert.ToString(recordBytes[1]));
                writer.WriteAttributeString("RSSI", XmlConvert.ToString(recordBytes[2]));
                writer.WriteAttributeString("DeviceID", XmlConvert.ToString(recordBytes[3]));
                
                writer.WriteAttributeString("UnitSerialNumber", XmlConvert.ToString(BitConverter.ToUInt32(recordBytes, 4)));

                writer.WriteAttributeString("Reading1", XmlConvert.ToString(BitConverter.ToUInt32(recordBytes, 8)));
                writer.WriteAttributeString("TimeStamp1", XmlConvert.ToString(BitConverter.ToUInt16(recordBytes, 12)));

                writer.WriteAttributeString("Reading2", XmlConvert.ToString(BitConverter.ToUInt32(recordBytes, 14)));
                writer.WriteAttributeString("TimeStamp2", XmlConvert.ToString(BitConverter.ToUInt16(recordBytes, 18)));

                writer.WriteAttributeString("Reading3", XmlConvert.ToString(BitConverter.ToUInt32(recordBytes, 20)));
                writer.WriteAttributeString("TimeStamp3", XmlConvert.ToString(BitConverter.ToUInt16(recordBytes, 24)));

                writer.WriteAttributeString("Reading4", XmlConvert.ToString(BitConverter.ToUInt32(recordBytes, 26)));
                writer.WriteAttributeString("TimeStamp4", XmlConvert.ToString(BitConverter.ToUInt16(recordBytes, 30)));
                
                writer.WriteEndElement(); // End "Record"
            }
            writer.WriteEndElement(); // End "Data"

            writer.WriteEndElement(); // End "Response"

            writer.WriteEndElement(); // End "Transaction"

            writer.WriteEndDocument();

            writer.Flush();


            #endregion

            ResultXML = new XmlDocument();
            resMemStr.Seek(0, SeekOrigin.Begin);
            ResultXML.Load(resMemStr);

            writer.Close();
            // DEBUG:
            System.Diagnostics.Debug.WriteLine(ResultXML.OuterXml);
        }       
    }










}
