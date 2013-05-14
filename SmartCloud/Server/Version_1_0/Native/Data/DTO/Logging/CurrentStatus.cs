namespace lfa.pmgmt.data.DTO.Logging
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    #endregion

    public class CurrentStatus
    {
        #region Public Properties
        public int Id
        {
            get;
            set;
        }

        public string UnitName
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }
        #endregion
    }
}
