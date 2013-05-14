namespace lfa.pmgmt.data.DTO.Security
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    #endregion

    public class User
    {
        #region Public Properties
        public int Id
        {
            get;
            set;
        }

        public int Id_Role
        {
            get;
            set;
        }

        public string Firstname
        {
            get;
            set;
        }

        public string Surname
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public DateTime DateRegistered
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

        public string SessionToken
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
