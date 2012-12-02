using System;
using System.Collections.Generic;
using System.Text;
//using Indus.IEC61850.Core.BaseClasses;
using Indus.ACSI.Core;
namespace Indus.IEC61850.LogicalModel.ACSI
{
    public class IECLogicalDevice : Indus.ACSI.Core.LogicalDevice  
    {
        public IECLogicalDevice(string LDName, string LDRef)
            : base(LDName, LDRef)
        {
        }
    }
}
