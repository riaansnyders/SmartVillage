using System;
using System.Collections.Generic;
using System.Text;
using Indus.ACSI.Core;

namespace Indus.IEC61850.LogicalModel.ACSI
{
    public class IECData : Indus.ACSI.Core.Data  
    {
        public IECData(string DataName, string DataRef)
            : base(DataName, DataRef)
        {
        }
    }
}
