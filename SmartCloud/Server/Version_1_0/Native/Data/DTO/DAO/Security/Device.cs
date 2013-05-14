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

        #region Login
        public string Login(string Serial)
        {
            string sessionToken = string.Empty;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "[Security].[LoginDevice] '{0}'";

                using (SqlCommand command = new SqlCommand(string.Format(query, Serial), connection))
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
        #endregion
    }
}
