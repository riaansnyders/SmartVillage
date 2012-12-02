using System;
using System.Collections.Generic;
using System.Text;

namespace Indus.ASN_1.Services.BER
{
    public class Decoder
    {
        byte[] _dataToDecode;
        StringBuilder builder;
        public Decoder(byte[] dataToDecode)
        {
            _dataToDecode = dataToDecode;
        }
        public string Decode()
        {
            builder = new StringBuilder();
            if (_dataToDecode[0] == 0x04) builder.Append("Visible String");
            if (_dataToDecode[1] == 0x07) builder.Append("Length");
            builder.Append( System.Text.Encoding.ASCII.GetString(_dataToDecode));
            
            return builder.ToString();
        }
    }
}
