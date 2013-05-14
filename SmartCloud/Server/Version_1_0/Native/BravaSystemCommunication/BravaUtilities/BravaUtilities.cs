using System;
using System.Collections.Generic;
using System.Text;
using BravaSystem.Communication;

namespace BravaSystem.Communication
{
    /// <summary>
    /// Collection of useful utility functions.
    /// </summary>
    public class BravaUtilities
    {
        /// <summary>
        /// Generate Standard UTC time value.
        /// </summary>
        /// <returns></returns>
        public static int GetUTCTimeStamp()
        {
            DateTime TimeBase = DateTime.Parse("01 January 2000");
            DateTime UTCTime = DateTime.UtcNow;

            // TimeSpan UTCOffset = (TimeSpan)(UTCTime - TimeBase);
            TimeSpan UTCOffset = UTCTime.Subtract(TimeBase);

            return (int)UTCOffset.TotalSeconds;
        }

        /// <summary>
        /// Generate UTC Time from seconds offset value.
        /// </summary>
        /// <param name="UTCTimeStampValue"></param>
        /// <returns></returns>
        public static DateTime GetUTCTime(UInt32 UTCTimeStampValue)
        {
            DateTime UTCTime = DateTime.Parse("01 January 2000");
            UTCTime = UTCTime.AddSeconds(UTCTimeStampValue);

            return UTCTime;
        }

        /// <summary>
        /// Generate checksum for byte array between startPos and stopPos. 
        /// Generates int32 value... must truncate to required bit length.
        /// </summary>
        /// <param name="inputByteArray"></param>
        /// <returns></returns>
        public static int GetCheckSum(byte[] inputByteArray, int startPos, int stopPos)
        {
            int returnVal = 0;
            for (int b = startPos; b <= stopPos; b++)
            {
                returnVal += inputByteArray[b];
            }

            return returnVal;
        }

        /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
        /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
        /// <returns> Returns an array of bytes. </returns>
        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary>
        /// Convert a string of hex digits (ex: E4 CA B2) to a byte array.
        /// </summary>
        /// <param name="chrs">The char[] containing the hex digits (with or without spaces). </param>
        /// <returns> Returns an array of bytes. </returns>
        public static byte[] HexStringToByteArray(char[] chrs)
        {
            string s = new string(chrs);
            return HexStringToByteArray(s);
        }

        /// <summary>
        /// Convert an array of HEX digits in a byte[] to it's binary representation.
        /// </summary>
        /// <param name="hexBytes"></param>
        /// <param name="startPos"></param>
        /// <param name="returnByteAmount"></param>
        /// <returns></returns>
        public static byte[] HexBytesToByteArray(byte[] hexBytes, int startPos, int returnByteAmount)
        {
            // boundary check
            if (hexBytes.Length >= startPos + (returnByteAmount * 2))
            {
                char[] tempchars = new char[returnByteAmount * 2];
                Array.Copy(hexBytes, startPos, tempchars, 0, tempchars.Length);
                //string tempString = new string(tempchars);
                return HexStringToByteArray(new string(tempchars));
            }
            else
            {
                return null;
            }
        }

        public static byte[] HexBytesToByteArray(byte[] hexBytes)
        {
            return HexBytesToByteArray(hexBytes, 0, hexBytes.Length / 2);
        }


        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 2);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();
        }

    }

}

