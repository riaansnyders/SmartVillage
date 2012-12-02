namespace lfa.pmgmt.reader.service
{
    #region Using Directives
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Sockets;
    using System.ServiceProcess;
    using System.Text.RegularExpressions;
    using System.Text;
    using System.Xml;

    using System.Runtime.InteropServices;
    #endregion

    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();

            tmrManager = new System.Timers.Timer();
            tmrManager.Enabled = true;
            tmrManager.Interval = 2000;
            tmrManager.Elapsed += new System.Timers.ElapsedEventHandler(tmrManager_Elapsed);
        }

        protected override void OnStart(string[] args)
        {
            tmrManager.Start();
        }

        protected override void OnStop()
        {
            tmrManager.Stop();
        }

        #region Timer Ticked Methods
        private void tmrManager_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            tmrManager.Stop();
            tmrManager.Enabled = false;

            int interval = int.Parse(ConfigurationManager.AppSettings["Interval"].ToString());

            Socket socket = null;

            try
            {
                string requestResult = string.Empty;

                ArrayList meterReadings = new ArrayList();

                byte[] byteReadingRequest = null;

                bool writeToLog = Convert.ToBoolean(ConfigurationManager.AppSettings["Logging"].ToString());
                string connectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
                string meterAddressList = ConfigurationManager.AppSettings["MeterAddressList"].ToString();
                string meterPassword = ConfigurationManager.AppSettings["MeterPassword"].ToString();
                string maxAmps = ConfigurationManager.AppSettings["MaxAmps"].ToString();
                string[] meterPasswords = meterPassword.Split(",".ToCharArray());

                string[] meterAddressArray = meterAddressList.Split(",".ToCharArray());

                int meterAddressArrayLen = meterAddressArray.Length - 1;

                for (int i = 0; i <= meterAddressArrayLen; i++)
                {
                    meterPassword = meterPasswords[i].ToString();
                    string[] fullAddressArray = meterAddressArray[i].Split(":".ToCharArray());
                    string ipAddress = fullAddressArray[0].ToString();
                    int port = int.Parse(fullAddressArray[1].ToString());
                    string outBuildingNumber = fullAddressArray[2].ToString();

                    LogEvent("Session started for meter with ip: " + ipAddress, writeToLog);

                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    socket.LingerState.Enabled = false;
                    socket.SendTimeout = 5000;
                    socket.ReceiveTimeout = 5000;

                    IPAddress address = IPAddress.Parse(ipAddress);

                    socket.Connect(address, port);

                    if (socket.Connected)
                    {
                        LogEvent("Connection made to meter with ip: " + ipAddress, writeToLog);

                        string loginRequest = "/?" + outBuildingNumber + "!\r\n";

                        byte[] bufferToSend = Encoding.ASCII.GetBytes(loginRequest);

                        socket.Send(bufferToSend);

                        byte[] byteHandShake = new byte[23];

                        System.Threading.Thread.Sleep(1000);

                        socket.Receive(byteHandShake);

                        string handShake = Encoding.ASCII.GetString(byteHandShake);

                        if (handShake.Contains("/GEC"))
                        {
                            LogEvent("Handshake received", writeToLog);

                            byte[] byteAckCommand = Encoding.ASCII.GetBytes("051\r");

                            socket.Send(Encoding.ASCII.GetBytes("\x06"));
                            socket.Send(byteAckCommand);
                            socket.Send(Encoding.ASCII.GetBytes("\n"));

                            byte[] byteAckResponse = new byte[24];

                            System.Threading.Thread.Sleep(1000);

                            socket.Receive(byteAckResponse);

                            string stringAckResponse = Encoding.ASCII.GetString(byteAckResponse);

                            socket.Send(Encoding.ASCII.GetBytes("\x01P2\x02(0000000000000000)\x03b"));

                            //Must get ACK
                            byteReadingRequest = new byte[256];

                            System.Threading.Thread.Sleep(1000);

                            socket.Receive(byteReadingRequest);

                            requestResult = Encoding.ASCII.GetString(byteReadingRequest);

                            LogEvent("Ack Received", writeToLog);

                            socket.Send(Encoding.ASCII.GetBytes("\x01"));
                            socket.Send(Encoding.ASCII.GetBytes("R1"));
                            socket.Send(Encoding.ASCII.GetBytes("\x02"));
                            socket.Send(Encoding.ASCII.GetBytes("798001(10)"));
                            socket.Send(Encoding.ASCII.GetBytes("\x03"));
                            socket.Send(Encoding.ASCII.GetBytes("e"));

                            byteReadingRequest = new byte[36];

                            System.Threading.Thread.Sleep(1000);

                            socket.Receive(byteReadingRequest);

                            string stringBufferReg10 = Encoding.ASCII.GetString(byteReadingRequest);

                            socket.Send(Encoding.ASCII.GetBytes("\x01"));
                            socket.Send(Encoding.ASCII.GetBytes("R1"));
                            socket.Send(Encoding.ASCII.GetBytes("\x02"));
                            socket.Send(Encoding.ASCII.GetBytes("795001(08)"));
                            socket.Send(Encoding.ASCII.GetBytes("\x03"));
                            socket.Send(Encoding.ASCII.GetBytes("a"));

                            byteReadingRequest = new byte[25];

                            System.Threading.Thread.Sleep(1000);

                            socket.Receive(byteReadingRequest);

                            requestResult = Encoding.ASCII.GetString(byteReadingRequest);

                            string[] keyArrayPreFix = stringAckResponse.Split("(".ToCharArray());
                            string[] keyArrayPostFix = keyArrayPreFix[1].ToString().Split(")".ToCharArray());

                            //Send password
                            string seed = keyArrayPostFix[0].ToString();

                            LogEvent("Seed Received" + ipAddress, writeToLog);

                            byte[] pwdByte = System.Text.Encoding.Unicode.GetBytes(meterPassword);
                            byte[] seedByte = System.Text.Encoding.Unicode.GetBytes(seed);
                            byte[] encoded = new byte[16];

                            string encodingString = ElsterMeteringSystems.EncryptDotNet.EncryptUtility.Encrypt(meterPassword, seed);

                            byte ckB = CheckSum.GetBCC(Encoding.ASCII.GetBytes("\x01P2\x02(" + encodingString + ")\x03"));
                            byte[] ckBS = new byte[1];
                            ckBS[0] = ckB;

                            string ckS = Encoding.ASCII.GetString(ckBS);

                            socket.Send(Encoding.ASCII.GetBytes("\x01"));
                            socket.Send(Encoding.ASCII.GetBytes("P2"));
                            socket.Send(Encoding.ASCII.GetBytes("\x02"));
                            socket.Send(Encoding.ASCII.GetBytes("(" + encodingString + ")"));
                            socket.Send(Encoding.ASCII.GetBytes("\x03"));
                            socket.Send(ckBS);

                            byteReadingRequest = new byte[300];

                            System.Threading.Thread.Sleep(1000);

                            socket.Receive(byteReadingRequest);

                            requestResult = Encoding.ASCII.GetString(byteReadingRequest);

                            //Send A, B, C for different meter phases
                            socket.Send(Encoding.ASCII.GetBytes("\x01"));
                            socket.Send(Encoding.ASCII.GetBytes("W1"));
                            socket.Send(Encoding.ASCII.GetBytes("\x02"));
                            socket.Send(Encoding.ASCII.GetBytes("605001(1A2A4A00)"));
                            socket.Send(Encoding.ASCII.GetBytes("\x03"));
                            socket.Send(Encoding.ASCII.GetBytes("\x12"));

                            LogEvent("Password send with Ack received", writeToLog);

                            byteReadingRequest = new byte[1];

                            System.Threading.Thread.Sleep(1000);

                            socket.Receive(byteReadingRequest);

                            requestResult = Encoding.ASCII.GetString(byteReadingRequest);

                            requestResult = Encoding.ASCII.GetString(byteReadingRequest);

                            //Meter Reading Request
                            //SAMPLE REQUEST: <SOH>R1<STX>605001(04)<ETX>e
                            socket.Send(Encoding.ASCII.GetBytes("\x01"));
                            socket.Send(Encoding.ASCII.GetBytes("R1"));
                            socket.Send(Encoding.ASCII.GetBytes("\x02"));
                            socket.Send(Encoding.ASCII.GetBytes("605001(01)"));
                            socket.Send(Encoding.ASCII.GetBytes("\x03"));
                            socket.Send(Encoding.ASCII.GetBytes("e"));

                            byte[] bytePhaseTwoRequest = new byte[256];

                            System.Threading.Thread.Sleep(1000);

                            socket.Receive(bytePhaseTwoRequest);

                            string phaseTwoResult = Encoding.ASCII.GetString(bytePhaseTwoRequest);

                            //Reading
                            //<SOH>R1<STX>606001(1C)<ETX><DLE>
                            socket.Send(Encoding.ASCII.GetBytes("\x01"));
                            socket.Send(Encoding.ASCII.GetBytes("R1"));
                            socket.Send(Encoding.ASCII.GetBytes("\x02"));
                            socket.Send(Encoding.ASCII.GetBytes("606001(1C)"));
                            socket.Send(Encoding.ASCII.GetBytes("\x03"));
                            socket.Send(Encoding.ASCII.GetBytes("\x10"));


                            byte[] byteMeterReading = new byte[256];

                            System.Threading.Thread.Sleep(500);

                            socket.Receive(byteMeterReading);

                            string readingResult = Encoding.ASCII.GetString(byteMeterReading);

                            if (!readingResult.Contains("ERR"))
                            {
                                LogEvent("Meter Reading Received", writeToLog);

                                //SAMPLE RESULT: <STX>(9DAD4D0D)<ETX>~
                                string[] voltageArray = readingResult.Split("(".ToCharArray());
                                string voltage = voltageArray[1].ToString();
                                string[] cleanVoltageArr = voltage.Split(")".ToCharArray());
                                string volts = cleanVoltageArr[0].ToString();

                                string currentUsage = volts.Replace("0", "").Replace("FF", "");

                                if (!string.IsNullOrEmpty(currentUsage))
                                {
                                    if (currentUsage.Length == 6)
                                    {
                                        currentUsage = currentUsage.Substring(0, 2);
                                    }
                                    else
                                    {
                                        currentUsage = currentUsage.Substring(0, 1);
                                    }

                                    LogEvent("Meter Reading Phase 1: " + currentUsage, writeToLog);

                                    meterReadings.Add(currentUsage);
                                }
                            }
                            else
                            {
                                HandleNackReceivedException();
                            }

                            //socket.Send(Encoding.ASCII.GetBytes("\x01"));
                            //socket.Send(Encoding.ASCII.GetBytes("W1"));
                            //socket.Send(Encoding.ASCII.GetBytes("\x02"));
                            //socket.Send(Encoding.ASCII.GetBytes("605001(1B2B4B00)"));
                            //socket.Send(Encoding.ASCII.GetBytes("\x03"));
                            //socket.Send(Encoding.ASCII.GetBytes("\x11"));

                            //System.Threading.Thread.Sleep(1000);

                            socket.Send(Encoding.ASCII.GetBytes("\x01"));
                            socket.Send(Encoding.ASCII.GetBytes("R1"));
                            socket.Send(Encoding.ASCII.GetBytes("\x02"));
                            socket.Send(Encoding.ASCII.GetBytes("605010(01)"));
                            socket.Send(Encoding.ASCII.GetBytes("\x03"));
                            socket.Send(Encoding.ASCII.GetBytes("e"));

                            System.Threading.Thread.Sleep(1000);

                            socket.Send(Encoding.ASCII.GetBytes("\x01"));
                            socket.Send(Encoding.ASCII.GetBytes("R1"));
                            socket.Send(Encoding.ASCII.GetBytes("\x02"));
                            socket.Send(Encoding.ASCII.GetBytes("606001(1C)"));
                            socket.Send(Encoding.ASCII.GetBytes("\x03"));
                            socket.Send(Encoding.ASCII.GetBytes("\x10"));


                            byte[] byteMeterReadingPhase2 = new byte[256];

                            System.Threading.Thread.Sleep(1000);

                            socket.Receive(byteMeterReadingPhase2);

                            string readingResultPhase2 = Encoding.ASCII.GetString(byteMeterReadingPhase2);

                            if (!readingResultPhase2.Contains("ERR"))
                            {
                                LogEvent("Meter Reading Received", writeToLog);

                                //SAMPLE RESULT: <STX>(9DAD4D0D)<ETX>~
                                string[] voltageArray = readingResultPhase2.Split("(".ToCharArray());
                                string voltage = voltageArray[1].ToString();
                                string[] cleanVoltageArr = voltage.Split(")".ToCharArray());
                                string volts = cleanVoltageArr[0].ToString();

                                string currentUsage = volts.Replace("0", "").Replace("FF", "");

                                if (!string.IsNullOrEmpty(currentUsage))
                                {
                                    if (currentUsage.Length == 6)
                                    {
                                        currentUsage = currentUsage.Substring(0, 2);
                                    }
                                    else
                                    {
                                        currentUsage = currentUsage.Substring(0, 1);
                                    }

                                    LogEvent("Meter Reading Phase 2: " + currentUsage, writeToLog);

                                    //meterReadings.Add(currentUsage);
                                }
                            }
                            else
                            {
                                HandleNackReceivedException();
                            }

                            //socket.Send(Encoding.ASCII.GetBytes("\x01"));
                            //socket.Send(Encoding.ASCII.GetBytes("W1"));
                            //socket.Send(Encoding.ASCII.GetBytes("\x02"));
                            //socket.Send(Encoding.ASCII.GetBytes("605001(1C2C4C0C)"));
                            //socket.Send(Encoding.ASCII.GetBytes("\x03"));
                            //socket.Send(Encoding.ASCII.GetBytes("c"));

                            //System.Threading.Thread.Sleep(500);


                            socket.Send(Encoding.ASCII.GetBytes("\x01"));
                            socket.Send(Encoding.ASCII.GetBytes("R1"));
                            socket.Send(Encoding.ASCII.GetBytes("\x02"));
                            socket.Send(Encoding.ASCII.GetBytes("605100(01)"));
                            socket.Send(Encoding.ASCII.GetBytes("\x03"));
                            socket.Send(Encoding.ASCII.GetBytes("e"));

                            System.Threading.Thread.Sleep(1000);

                            socket.Send(Encoding.ASCII.GetBytes("\x01"));
                            socket.Send(Encoding.ASCII.GetBytes("R1"));
                            socket.Send(Encoding.ASCII.GetBytes("\x02"));
                            socket.Send(Encoding.ASCII.GetBytes("606001(1C)"));
                            socket.Send(Encoding.ASCII.GetBytes("\x03"));
                            socket.Send(Encoding.ASCII.GetBytes("\x10"));

                            byte[] byteMeterReadingPhase3 = new byte[256];

                            System.Threading.Thread.Sleep(500);

                            socket.Receive(byteMeterReadingPhase3);

                            string readingResultPhase3 = Encoding.ASCII.GetString(byteMeterReadingPhase3);

                            if (!readingResultPhase3.Contains("ERR"))
                            {
                                LogEvent("Meter Reading Received Phase 3", writeToLog);

                                //SAMPLE RESULT: <STX>(9DAD4D0D)<ETX>~
                                string[] voltageArray = readingResultPhase3.Split("(".ToCharArray());
                                string voltage = voltageArray[1].ToString();
                                string[] cleanVoltageArr = voltage.Split(")".ToCharArray());
                                string volts = cleanVoltageArr[0].ToString();

                                string currentUsage = volts.Replace("0", "").Replace("FF", "");

                                if (!string.IsNullOrEmpty(currentUsage))
                                {
                                    if (currentUsage.Length == 6)
                                    {
                                        currentUsage = currentUsage.Substring(0, 2);
                                    }
                                    else
                                    {
                                        currentUsage = currentUsage.Substring(0, 1);
                                    }

                                    LogEvent("Meter Reading 3: " + currentUsage, writeToLog);

                                    //meterReadings.Add(currentUsage);
                                }
                            }
                            else
                            {
                                HandleNackReceivedException();
                            }

                            //Got to end the session!
                            socket.Send(Encoding.ASCII.GetBytes("\x01"));
                            socket.Send(Encoding.ASCII.GetBytes("B0"));
                            socket.Send(Encoding.ASCII.GetBytes("\x03"));
                            socket.Send(Encoding.ASCII.GetBytes("q"));

                            LogEvent("Session ended for meter with ip: " + ipAddress, writeToLog);
                        }
                        else
                        {
                            //Got to end the session!
                            socket.Send(Encoding.ASCII.GetBytes("\x01"));
                            socket.Send(Encoding.ASCII.GetBytes("B0"));
                            socket.Send(Encoding.ASCII.GetBytes("\x03"));
                            socket.Send(Encoding.ASCII.GetBytes("q"));

                            HandleInvalidHandShakeException();
                        }
                    }
                }

                if (socket != null)
                {
                    if (socket.Connected)
                    {
                        socket.Disconnect(false);
                    }
                }

                CalculateAndUpdateCurrentUsage(meterReadings, maxAmps, connectionString);

                LogEvent("Usage Updated. Ending reading...", writeToLog);
            }
            catch
            {
                 try
                 {
                        if (socket != null)
                        {
                   
                                //Got to end the session!
                                socket.Send(Encoding.ASCII.GetBytes("\x01"));
                                socket.Send(Encoding.ASCII.GetBytes("B0"));
                                socket.Send(Encoding.ASCII.GetBytes("\x03"));
                                socket.Send(Encoding.ASCII.GetBytes("q"));
                   
                        }
                 }
                 catch
                 {
                     HandleNackReceivedException();
                 }

                HandleNackReceivedException();
            }
            finally
            {

                try
                {
                    if (socket != null)
                    {
                        if (socket.Connected)
                        {
                            socket.Disconnect(false);
                            socket.Close();
                            socket.Dispose();
                        }
                    }
                }
                catch
                {
                    HandleNackReceivedException();
                }

                tmrManager = new System.Timers.Timer();
                tmrManager.Interval = interval;
                tmrManager.Enabled = true;
                tmrManager.Elapsed += new System.Timers.ElapsedEventHandler(tmrManager_Elapsed);
                tmrManager.Start();
            }
        }
        #endregion

        #region Conversion Methods
        private static int DecimalToU_Int32(decimal argument)
        {
            object Int32Value;

            try
            {
                Int32Value = (int)argument;
            }
            catch (Exception ex)
            {
                Int32Value = GetExceptionType(ex);
            }

            return (int)Int32Value;
        }

        private static string GetExceptionType(Exception ex)
        {
            string exceptionType = ex.GetType().ToString();

            return exceptionType.Substring(
                exceptionType.LastIndexOf('.') + 1);
        }

        private static string ConvertHexToString(string HexValue)
        {
            string StrValue = "";
            while (HexValue.Length > 0)
            {
                StrValue += System.Convert.ToChar(System.Convert.ToUInt32(HexValue.Substring(0, 2), 16)).ToString();
                HexValue = HexValue.Substring(2, HexValue.Length - 2);
            }

            return StrValue;
        }

        public static byte[] ConvertToBinaryCodedDecimal(bool isLittleEndian, string bcdString)
        {
            bool isValid = true;
            isValid = isValid && !String.IsNullOrEmpty(bcdString);
            // Check that the string is made up of sets of two numbers (e.g. "01" or "3456")
            isValid = isValid && Regex.IsMatch(bcdString, "^([0-9]{2})+$");
            byte[] bytes;
            if (isValid)
            {
                char[] chars = bcdString.ToCharArray();
                int len = chars.Length / 2;
                bytes = new byte[len];
                if (isLittleEndian)
                {
                    for (int i = 0; i < len; i++)
                    {
                        byte highNibble = byte.Parse(chars[2 * (len - 1) - 2 * i].ToString());
                        byte lowNibble = byte.Parse(chars[2 * (len - 1) - 2 * i + 1].ToString());
                        bytes[i] = (byte)((byte)(highNibble << 4) | lowNibble);
                    }
                }
                else
                {
                    for (int i = 0; i < len; i++)
                    {
                        byte highNibble = byte.Parse(chars[2 * i].ToString());
                        byte lowNibble = byte.Parse(chars[2 * i + 1].ToString());
                        bytes[i] = (byte)((byte)(highNibble << 4) | lowNibble);
                    }
                }
            }
            else
            {
                throw new ArgumentException(String.Format(
                    "Input string ({0}) was invalid.", bcdString));
            }
            return bytes;
        }

        static string BytesToString(byte[] data)
        {
            // Minimum length 1. 
            if (data.Length == 0) return "0";

            // length <= digits.Length. 
            var digits = new byte[(data.Length * 0x00026882/* (int)(Math.Log(2, 10) * 0x80000) */ + 0xFFFF) >> 16];
            int length = 1;

            // For each byte: 
            for (int j = 0; j != data.Length; ++j)
            {
                // digits = digits * 256 + data[j]. 
                int i, carry = data[j];
                for (i = 0; i < length || carry != 0; ++i)
                {
                    int value = digits[i] * 256 + carry;
                    carry = Math.DivRem(value, 10, out value);
                    digits[i] = (byte)value;
                }
                // digits got longer. 
                if (i > length) length = i;
            }

            // Return string. 
            var result = new StringBuilder(length);
            while (0 != length) result.Append((char)('0' + digits[--length]));
            return result.ToString();
        }
        #endregion

        #region Data Methods
        private static void CalculateAndUpdateCurrentUsage(ArrayList meterReadings, string maxAmps, string connectionString)
        {
            int meterReadingsLen = meterReadings.Count;

            if (meterReadingsLen > 0)
            {
                meterReadings.Sort();

                long sumOfReadings = 0;

                for (int i = 0; i <= meterReadingsLen - 1; i++)
                {
                    sumOfReadings += Convert.ToInt64(meterReadings[i]);
                }

                //int currentVoltage = ((int)sumOfReadings / meterReadingsLen);
                int currentVoltage = (((int)sumOfReadings * 100) / int.Parse(maxAmps));

                if (!string.IsNullOrEmpty(currentVoltage.ToString()))
                {
                    if (int.Parse(currentVoltage.ToString().Replace("-", "")) > 0)
                    {
                        UpdateMeterReading(connectionString, currentVoltage.ToString().Replace("-", ""));
                    }
                }
            }
        }

        private static void UpdateMeterReading(string connectionString, string meterReading)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = string.Format(@"UPDATE [BusinessRule].[Load] SET CurrentLoad = '{0}'",
                                                 meterReading);

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                HandleLoadUpdateException();
            }
        }
        #endregion

        #region Exception Handling Methods
        private static void HandleLoadUpdateException()
        {
            System.Diagnostics.EventLog.WriteEntry("Power Management Meter Reader",
                                                    @"Could not update current load indicator. Possible reason could 
                                                        be no load entered in database.",
                                                    System.Diagnostics.EventLogEntryType.Warning);
        }

        private static void HandleInvalidHandShakeException()
        {
            System.Diagnostics.EventLog.WriteEntry("Power Management Meter Reader",
                                                    @"No valid communication handshake received from Meter.",
                                                    System.Diagnostics.EventLogEntryType.Warning);
        }

        private static void HandleNackReceivedException()
        {
            System.Diagnostics.EventLog.WriteEntry("Power Management Meter Reader",
                                                    @"Nack (Negative acknoledgement) received from Meter.",
                                                    System.Diagnostics.EventLogEntryType.Warning);
        }
        #endregion

        #region Logging Methods
        private static void LogEvent(string logMessage, bool writeLog)
        {
            if (writeLog)
                System.Diagnostics.EventLog.WriteEntry("DEBUG: (Metering Service)", "Log: Event: " + logMessage,
                                                      System.Diagnostics.EventLogEntryType.Warning);
        }
        #endregion
    }

    #region CheckSum Class
    public static class CheckSum
    {
        public static byte GetBCC(this byte[] inputStream)
        {
            byte bcc = 0;

            if (inputStream != null && inputStream.Length > 0)
            {
                // Exclude SOH during BCC calculation
                for (int i = 1; i < inputStream.Length; i++)
                {
                    bcc ^= inputStream[i];
                }
            }

            return bcc;
        }
    }
    #endregion
}
