using System;
using System.Collections.Generic;
using System.Text;
//using Indus.IEC61850.Core.BaseClasses;
using Indus.ACSI.Core;
namespace Indus.IEC61850.LogicalModel.ACSI
{
    public class IECLogicalNode : Indus.ACSI.Core.LogicalNode  
    {
        public IECLogicalNode(string LNName, string LnRef)
            : base(LNName , LnRef )
        {
        }
    }
}
