namespace lfa.pmgmt.data.DTO.Configuration
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        public int Id_Unit
        {
            get;
            set;
        }

        public string Name
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

        public string Switch
        {
            get;
            set;
        }
        #endregion
    }
}
