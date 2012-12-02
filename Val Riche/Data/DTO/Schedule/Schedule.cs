namespace lfa.pmgmt.data.DTO.Schedule
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    #endregion

    public class Schedule
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

        public string StartTime
        {
            get;
            set;
        }

        public string EndTime
        {
            get;
            set;
        }

        public int ElapsedTime
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
