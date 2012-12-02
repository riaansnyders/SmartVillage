using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


namespace Indus.ACSI.Core
{
    public abstract class LogicalNode
    {

        private ArrayList _data = new ArrayList();
        private string _lnName;
        private string _lnRef;
        public LogicalNode(string LNName,string LnRef)
        {
            _lnName = LNName;
            _lnRef = LnRef;
        }
        #region Public Methods

        public void AddData(Data data)
        {
            _data.Add(data);
        }
        #endregion

        #region Public Properties

        public string LNName
        {
            get
            {
                return _lnName;
            }
        }

        public string LNRef
        {
            get
            {
                return _lnRef;
            }
        }

        public Data[] Data
        {
            get
            {
                return (Indus.ACSI.Core.Data[])_data.ToArray(typeof(Data));
            }
        }
        #endregion
    }
}
