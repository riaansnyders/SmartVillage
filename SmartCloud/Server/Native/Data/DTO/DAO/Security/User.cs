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

    public class Device
    {
        #region Public Properties
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region Insert
        public void Insert(string Name, string Surname, string Username, string Password, string Serial)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Security].[RegisterUser] '{0}','{1}','{2}','{3}','{4}' ";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery,Name,Surname,Username,Password,Serial), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Update
        //N/A
        #endregion

        #region Delete
        //NA
        #endregion

        #region EnableDisable
        public void Enable(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Security].[EnableUser] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Disable(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Security].[DisableUser] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region LoginLogout
        public string LoginUser(string Username, string Password)
        {
            string sessionToken = string.Empty;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                
                string query = "[Security].[LoginUser] '{0}','{1}'";

                using (SqlCommand command = new SqlCommand(string.Format(query, Username, Password), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            sessionToken = reader.GetValue(0).ToString();
                        }
                    }
                }
            }

            return sessionToken;
        }

        public void LogoutUser(string SessionToken)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Security].[LogoutUser] '{0}'";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, SessionToken), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}
