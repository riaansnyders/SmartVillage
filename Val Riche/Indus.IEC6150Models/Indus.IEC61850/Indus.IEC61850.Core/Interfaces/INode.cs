using System;
using System.Collections.Generic;
using System.Text;
using Indus.IEC61850.Core.Enums;

namespace Indus.IEC61850.Core.Interfaces
{
    public interface  INode
    {
        string Name
        {
            get;
        }
        NodeTypeEnum NodeType
        {
            get;
        }
        //INode[] GetChildNodes();
        object Tag
        {
            get;
            set;
        }
    }
}
