using System;
using System.Collections.Generic;
using System.Text;

namespace Indus.ACSI.Core
{
    public abstract class DataAttribute
    {
        private string _name;
        private string _value;
        public DataAttribute(string Name,string Value)
        {
            _name = Name;
            _value = Value;

        }        
        public string Name
        {
            get
            {

                return _name ;
            }
        }
        public string Value
        {
            get
            {
                return _value;
            }
        }
    }
}
