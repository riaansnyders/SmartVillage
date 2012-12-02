using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Indus.ACSI.Core
{
    public abstract class Data
    {
        private string _dataName;
        private string _dataRef;
        private ArrayList _dataAttributes=new ArrayList();
        public Data(string DataName,string DataRef)
        {
            _dataName = DataName;
            _dataRef = DataRef;
        }

        public void AddDataAttribues(DataAttribute dataAttrib)
        {
            _dataAttributes.Add(dataAttrib );
        }
        public string DataName
        {
            get
            {
                return _dataName;
            }
        }
        public string DataRef
        {
            get
            {
                return _dataRef;
            }
        }
        public Boolean Presence
        {
            get
            {
                //harcoding that the data is present
                return true;
            }
        }

        public DataAttribute[] DataAttributes
        {
            get
            {
                return (DataAttribute[]) _dataAttributes.ToArray(typeof(DataAttribute));
            }
        }

    }
}
