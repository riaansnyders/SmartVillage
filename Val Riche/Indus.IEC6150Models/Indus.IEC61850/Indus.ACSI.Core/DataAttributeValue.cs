using System;
using System.Collections.Generic;
using System.Text;

namespace Indus.ACSI.Core
{
    public abstract class DataAttributeValue
    {
       private string _value;
       public string Value
       {
          get
          {

              return _value;
          }
       }
    }
}
