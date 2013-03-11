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

    public class Role
    {
        #region Public Properties
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region Insert
        public void Insert(string Name, string Description, string Serial)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Security].[InsertRole] '{0}','{1}','{2}'";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Name, Description, Serial), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Update
        public void Update(string Name, string Description, string Serial)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Security].[UpdateRole] '{0}','{1}','{2}'";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Name, Description, Serial), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Delete
        public void Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Security].[DeleteRole] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Get User Role
        public DataObject.Role GetUserRole(int UserId, string Serial)
        {
            DataObject.Role role = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "[Security].[GetUserRole] '{0}','{1}'";

                using (SqlCommand command = new SqlCommand(string.Format(query, UserId, Serial), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        role = new DataObject.Role();

                        while (reader.Read())
                        {
                            role.Id = int.Parse(reader.GetValue(0).ToString());
                            role.Name = reader.GetValue(1).ToString();
                            role.Description = reader.GetValue(2).ToString();
                            role.SmartCloudSerial = reader.GetValue(3).ToString();
                        }
                    }
                }
            }

            return role;
        }
        #endregion
    }
}