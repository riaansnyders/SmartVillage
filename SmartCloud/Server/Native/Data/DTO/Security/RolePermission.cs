namespace lfa.pmgmt.data.DTO.Security
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    #endregion

    public class RolePermission
    {
        #region Public Properties
        public int Id
        {
            get;
            set;
        }

        public string Id_Role
        {
            get;
            set;
        }

        public bool CanManageSchedule
        {
            get;
            set;
        }
  
        public bool CanManageZones
        {
          get;
          set;
        }
  
        public bool CanManageSwitches
        {
          get;
          set;
        }
  
        public bool CanManageUnits
        {
          get;
          set;
        }
  
        public bool CanSwitchOnOff
        {
          get;
          set;
        }

        public bool CanManageUsers
        {
          get;
          set;
        }
        #endregion
    }
}
