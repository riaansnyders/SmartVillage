namespace lfa.pmgmt.data.DTO.Security
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    #endregion

    public class Role
    {
        #region Public Properties
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string SmartCloudSerial
        {
            get;
            set;
        }
        #endregion
    }
}
