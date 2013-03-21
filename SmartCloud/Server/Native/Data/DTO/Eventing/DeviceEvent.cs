namespace lfa.pmgmt.data.DTO.Eventing
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    #endregion

    public class DeviceEvent
    {
        #region Public Properties
        public int Id
        {
            get;
            set;
        }

        public string Serial
        {
            get;
            set;
        }

        public string Event
        {
            get;
            set;
        }
        #endregion
    }
}
