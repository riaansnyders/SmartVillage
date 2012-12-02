using System;
using System.Collections.Generic;
using System.Text;
//using Indus.IEC61850.Core.BaseClasses;
using Indus.ACSI.Core;
namespace Indus.IEC61850.LogicalModel.ACSI
{
    public class IECDataAttribute : Indus.ACSI.Core.DataAttribute
    {
        public IECDataAttribute(string Name, string Value)
            : base(Name,Value)
        {
        }
    }
}
