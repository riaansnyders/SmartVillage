using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Indus.IEC61850.Core.Interfaces;
using Indus.IEC61850.Core.Enums;
namespace Indus.IEC61850.Core.BaseClasses
{
    public class BaseNode :INode 
    {
        private string _name;
        private NodeTypeEnum _nodeType;
        private object _tag;
        private ArrayList _childNodes;
        public BaseNode(string Name, NodeTypeEnum NodeType)
        {
            _name = Name;
            _nodeType = NodeType;
            _childNodes = new ArrayList();
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public NodeTypeEnum  NodeType
        {
            get
            {
                return _nodeType;
            }
        }

        public object Tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        }

        public BaseNode[] GetChildNodes()
        {
            return (BaseNode[])_childNodes.ToArray(typeof(BaseNode));
        }

        public void AddChildNode(BaseNode Node)
        {
            _childNodes.Add(Node);
        }
        public void RemoveChildNode(BaseNode Node)
        {
            _childNodes.Remove(Node);
        }
    }
}
