namespace lfa.pmgmt.data.DTO.Logging
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    #endregion

    public class Log
    {
        #region Public Properties
        public int Id
        {
            get;
            set;
        }

        public string Originator
        {
            get;
            set;
        }

        public string Fault
        {
            get;
            set;
        }


        public DateTime DateAdded
        {
            get;
            set;
        }
        #endregion
    }
}
