namespace lfa.pmgmt.data.DAO.Security
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    using DataObject = lfa.pmgmt.data.DTO.Security;
    #endregion

    public class RolePermission
    {
        #region Public Properties
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region Insert
        public void Insert(int Id_Role, bool CanManageSchedule, bool CanManageZones, bool CanManageSwitches, 
                           bool CanManageUnits, bool CanSwitchOnOff, bool CanManageUsers)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Security].[ManageRolePermissions] {0},'{1}','{2}','{3}','{4}','{5}','{6}'";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id_Role,CanManageSchedule,CanManageZones,
                                                                         CanManageSwitches,CanManageUnits,CanSwitchOnOff,
                                                                         CanManageUsers), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Get Role Permissions
        public DataObject.RolePermission GetUserRole(int Id)
        {
            DataObject.RolePermission role = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "[Security].[GetRolePermissions] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        role = new DataObject.RolePermission();

                        while (reader.Read())
                        {
                            role.Id = int.Parse(reader.GetValue(0).ToString());
                            role.CanManageSchedule = Convert.ToBoolean(reader.GetValue(1).ToString());
                            role.CanManageZones = Convert.ToBoolean(reader.GetValue(2).ToString());
                            role.CanManageSwitches = Convert.ToBoolean(reader.GetValue(3).ToString());
                            role.CanManageUnits = Convert.ToBoolean(reader.GetValue(4).ToString());
                            role.CanSwitchOnOff = Convert.ToBoolean(reader.GetValue(5).ToString());
                            role.CanManageUsers = Convert.ToBoolean(reader.GetValue(6).ToString());
                        }
                    }
                }
            }

            return role;
        }
        #endregion
    }
}