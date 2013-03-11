namespace lfa.pmgmt.data.DAO.Configuration
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    using DataObject = lfa.pmgmt.data.DTO.Configuration;
    #endregion

    public class DeviceStatus
    {
        #region Public Properties
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region Insert
        public void Insert(int Id_Device, int Id_Status)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Configuration].[InsertDeviceStatus] {0},{1}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id_Device, Id_Status), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Update
        public void Update(int Id_Device, int Id_Status)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Configuration].[UpdateDeviceStatus] {0},{1}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id_Device, Id_Status), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Get
        public DataObject.Status Get(int Id_Device)
        {
            DataObject.Status dataObjectDeviceStatus = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [Configuration].[GetDeviceStatus] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id_Device), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataObjectDeviceStatus = new DataObject.Status();
                            dataObjectDeviceStatus.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectDeviceStatus.Description = reader.GetValue(1).ToString();
                        }
                    }
                }
            }

            return dataObjectDeviceStatus;
        }
        #endregion
    }
}
