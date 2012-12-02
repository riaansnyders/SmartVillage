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
        public void Insert(int Id_Unit, string Name, DateTime DateAdded, string deviceSwitch)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Configuration].[InsertDevice] {0},'{1}','{2}','{3}' ";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id_Unit, Name, 
                                                                         deviceSwitch, DateAdded.ToString("yyyy/MM/dd")), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Update
        public void Update(int Id, int Id_Unit, string Name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Configuration].[UpdateDevice] {0},{1},'{2}' ";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery,Id, Id_Unit, Name), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateLoadShedDeviceStatus(int Id_Device, int Id_Status)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Configuration].[UpdateLoadShedDeviceStatus] {0},{1}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id_Device, Id_Status), connection))
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

                string sqlQuery = "Exec [Configuration].[DeleteDevice] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region EnableDisable
        public void EnableDisable(int Id, bool EnableDisable)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Configuration].[EnableDisableDevice] {0},{1}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id, EnableDisable), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Get
        public DataObject.Device Get(int Id)
        {
            DataObject.Device dataObjectDevice = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [Configuration].[GetActiveDevice] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataObjectDevice = new DataObject.Device();
                            dataObjectDevice.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectDevice.Id_Unit = int.Parse(reader.GetValue(1).ToString());
                            dataObjectDevice.Name = reader.GetValue(2).ToString();
                            dataObjectDevice.DateAdded = Convert.ToDateTime(reader.GetValue(3).ToString());
                            dataObjectDevice.IsActive = Convert.ToBoolean(reader.GetValue(4).ToString());
                        }
                    }
                }
            }

            return dataObjectDevice;
        }
        #endregion

        #region List
        public List<DataObject.Device> List(int Id_Unit)
        {
            List<DataObject.Device> deviceList = new List<DataObject.Device>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [Configuration].[ListActiveDevice] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id_Unit), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.Device  dataObjectDevice = new DataObject.Device();
                            dataObjectDevice.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectDevice.Id_Unit = Id_Unit;
                            dataObjectDevice.Name = reader.GetValue(1).ToString();
                            dataObjectDevice.DateAdded = Convert.ToDateTime(reader.GetValue(2).ToString());
                            dataObjectDevice.IsActive = Convert.ToBoolean(reader.GetValue(3).ToString());
                            dataObjectDevice.Switch = reader.GetValue(4).ToString();

                            deviceList.Add(dataObjectDevice);
                        }
                    }
                }
            }

            return deviceList;
        }

        public string GetDeviceSwitch(int Id)
        {
            string deviceSwitch = string.Empty;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT Switch FROM [Configuration].[Device] WHERE Id = {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query,Id), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            deviceSwitch = reader.GetValue(0).ToString();
                        }
                    }
                }
            }

            return deviceSwitch;
        }

        public int GetDeviceConfigId(int Id, int id_device)
        {
            int deviceId = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT Id_Device FROM [Schedule].[Device] WHERE Id_ScheduleUnit = {0} and Id = {1}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id, id_device), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            deviceId = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
            }

            return deviceId;
        }

        public string GetDeviceAddress(int Id)
        {
            string deviceAddress = string.Empty;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT b.Address FROM [Configuration].[Device] a ";
                query += "INNER JOIN [Configuration].[Unit] b on b.Id = a.Id_Unit ";
                query += "WHERE a.Id = {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            deviceAddress = reader.GetValue(0).ToString();
                        }
                    }
                }
            }

            return deviceAddress;
        }

        public string GetDeviceName(int Id)
        {
            string name = string.Empty;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT Name FROM [Configuration].[Device] WHERE Id = {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            name = reader.GetValue(0).ToString();
                        }
                    }
                }
            }

            return name;
        }

        public List<DataObject.LoadShedDevice> ListLoadShed(int Id_Unit)
        {
            List<DataObject.LoadShedDevice> deviceList = new List<DataObject.LoadShedDevice>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [Configuration].[ListLoadShedDevices] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id_Unit), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.LoadShedDevice dataObjectDevice = new DataObject.LoadShedDevice();
                            dataObjectDevice.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectDevice.Name = reader.GetValue(1).ToString();
                            dataObjectDevice.DateAdded = Convert.ToDateTime(reader.GetValue(2).ToString());
                            dataObjectDevice.IsActive = Convert.ToBoolean(reader.GetValue(3).ToString());

                            if (reader.GetValue(4).ToString().Trim() == "2")
                            {
                                dataObjectDevice.Status = "Off";
                            }
                            else
                            {
                                dataObjectDevice.Status = "On";
                            }

                            deviceList.Add(dataObjectDevice);
                        }
                    }
                }
            }

            return deviceList;
        }
        #endregion
    }
}
