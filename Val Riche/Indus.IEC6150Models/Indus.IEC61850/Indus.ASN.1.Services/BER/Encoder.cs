using System;
using System.Collections.Generic;
using System.Text;

namespace Indus.ASN_1.Services.BER
{
    public class Encoder
    {
        private string _dataToEncode;
        public Encoder(string dataToEncode)
        {
            _dataToEncode = dataToEncode;
        }
        //datattype

        //length

        //value

        //0x01 -BOOLEAN
        //0x03 - BIT STRING
        //0x04- OCTET STRING

        //0x01 Octet

        public byte[] Encode()
        {
            //do the processing
            //_dataToEncode
            //Read through from beginning

            //if the VisibleString
            //DataType
            byte[] bytes= new byte[255];
            bytes[0] = 0x04; //VisibleString
            bytes[1] = 0x07;// Length
            int i=2;
            //byte[] bytes2=   System.Text.Encoding.ASCII.GetBytes(_dataToEncode.ToCharArray());
            byte[] bytes2 = System.Text.Encoding.ASCII.GetBytes(_dataToEncode);

            for (int iC = 2; iC <= bytes2.Length; iC++)
            {
                bytes[iC] = bytes2[iC - 2];
            }
            return bytes;
        }
    }
}
