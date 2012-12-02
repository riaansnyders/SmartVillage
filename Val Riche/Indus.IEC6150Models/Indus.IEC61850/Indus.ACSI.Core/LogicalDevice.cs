using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Indus.ACSI.Core
{
    public abstract class LogicalDevice
    {
        private ArrayList _logicalNodes = new ArrayList();
        private string _ldName;
        private string _ldRef;
        public LogicalDevice(string LDName,string LDRef)
        {
            _ldName = LDName;
            _ldRef = LDRef;
        }
        #region Public Methods
        public void AddLogicalNode(LogicalNode node)
        {
            _logicalNodes.Add(node);
        }

        public virtual string[] GetLogicalDeviceDirectory(string LDReference)
        {
            //LNReference 3-n (LLN0 and LPHD always there)
            string[] strArray = new string[1];
            strArray[0]="LLN0";
            return strArray ;
        }
        #endregion

        #region Public Properties
        public string LDName
        {
            get
            {
                return _ldName;
            }
        }
        public string LDRef
        {
            get
            {
                return _ldRef;
            }
        }
        public LogicalNode[] LogicalNodes
        {
            get
            {
                return (LogicalNode [])_logicalNodes.ToArray(typeof(LogicalNode ));
            }
        }
        #endregion
    }
}
