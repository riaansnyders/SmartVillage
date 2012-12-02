using System;
using System.Collections.Generic;
using System.Text;

namespace Indus.ASN_1.Services.Builders
{
    public class ResponseBuilder
    {
        const string RESPONSE_STRING = "GetServerDirectory_Response+ ::= SEQUENCE {ObjectClass VisibleString ";
        private string _value;
        public ResponseBuilder(string value)
        {
            _value=value;
        }
        public string ResponseString()
        {
            return RESPONSE_STRING + "{"+ _value +"}}";
        }
    }
}
