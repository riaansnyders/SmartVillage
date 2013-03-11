namespace lfa.pmgmt.data.DTO.Schedule
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    #endregion

    public class Unit
    {
        #region Public Properties
        public int Id
        {
            get;
            set;
        }

        public int Id_ScheduleUnit
        {
            get;
            set;
        }

        public int Id_Zone
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public DateTime DateAdded
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }
        #endregion
    }
}
