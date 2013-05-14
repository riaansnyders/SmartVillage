namespace lfa.pmgmt.data.DTO.Security
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    #endregion

    public class Device
    {
        #region Public Properties
        public int Id
        {
            get;
            set;
        }

        public string SmartCloudSerial
        {
            get;
            set;
        }

        public string SessionToken
        {
            get;
            set;
        }
        #endregion
    }
}
