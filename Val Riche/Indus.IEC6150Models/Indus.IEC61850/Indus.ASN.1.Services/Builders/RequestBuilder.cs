using System;
using System.Collections.Generic;
using System.Text;

namespace Indus.ASN_1.Services.Builders
{
    public class RequestBuilder
    {

        const string REQUEST_STRING ="GetServerDirectory_Request ::= SEQUENCE {ObjectClass VisibleString ";
        private string _value;
        public RequestBuilder(string value)
        {
            _value = value;
        }

        public string RequestString()
        {
            return REQUEST_STRING + "{"+ _value + "}}";
        }

    }

}
