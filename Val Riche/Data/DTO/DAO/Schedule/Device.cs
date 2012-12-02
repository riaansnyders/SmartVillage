namespace lfa.pmgmt.data.DAO.Schedule
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    using DataObject = lfa.pmgmt.data.DTO.Schedule;
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
        public void Insert(int Id_Device, int Id_ScheduleUnit, bool on, int Id_Schedule)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Schedule].[InsertDevice] {0}, {1}, {3}, '{2}'";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id_Device, Id_ScheduleUnit, on.ToString(), Id_Schedule), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Update
        public void Update(int Id, int Id_Device, int Id_ScheduleUnit, bool on)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Schedule].[UpdateDevice] {0}, '{1}'";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery,Id,on.ToString()), connection))
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

                string sqlQuery = "Exec [Schedule].[DeleteDevice] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id), connection))
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

                string query = "Exec [Schedule].[GetActiveDevice] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataObjectDevice = new DataObject.Device();
                            dataObjectDevice.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectDevice.Name = reader.GetValue(1).ToString();
                            dataObjectDevice.DateAdded = Convert.ToDateTime(reader.GetValue(2).ToString());
                        }
                    }
                }
            }

            return dataObjectDevice;
        }

        public int GetUnitId(int Id_ScheduleUnit)
        {
            int unitId = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT Id_Unit FROM [Schedule].[Unit] WHERE Id = {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id_ScheduleUnit), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            unitId = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
            
            return unitId;
        }
        #endregion

        #region List
        public List<DataObject.Device> List(int Id_Unit,int selectedSchedule)
        {
            List<DataObject.Device> deviceList = new List<DataObject.Device>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [Schedule].[ListActiveDevice] {0}, {1}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id_Unit, selectedSchedule), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.Device dataObjectDevice = new DataObject.Device();
                            dataObjectDevice.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectDevice.Name = reader.GetValue(1).ToString();
                            dataObjectDevice.DateAdded = Convert.ToDateTime(reader.GetValue(2).ToString());
                            dataObjectDevice.DeviceOn = Convert.ToBoolean(reader.GetValue(3).ToString());
                            deviceList.Add(dataObjectDevice);
                        }
                    }
                }
            }

            return deviceList;
        }

        public List<DataObject.Device> ListById(int Id_Unit, int selectedSchedule)
        {
            List<DataObject.Device> deviceList = new List<DataObject.Device>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [Schedule].[ListActiveDeviceById] {0}, {1}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id_Unit, selectedSchedule), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.Device dataObjectDevice = new DataObject.Device();
                            dataObjectDevice.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectDevice.Name = reader.GetValue(1).ToString();
                            dataObjectDevice.DateAdded = Convert.ToDateTime(reader.GetValue(2).ToString());
                            dataObjectDevice.DeviceOn = Convert.ToBoolean(reader.GetValue(3).ToString());
                            deviceList.Add(dataObjectDevice);
                        }
                    }
                }
            }

            return deviceList;
        }

        public List<DataObject.Device> ListWithDeviceId(int Id_Unit, int selectedSchedule)
        {
            List<DataObject.Device> deviceList = new List<DataObject.Device>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = @"DECLARE @ScheduleUnitId int
    
                                SELECT @ScheduleUnitId = Id FROM [Schedule].[Unit]
                                WHERE Id_Schedule = {1} and Id_Unit = {0}
    
	                            SELECT device.Id, cfdevice.Name, cfdevice.DateAdded,device.DeviceOn, ID_Device FROM [Schedule].[Device] device
	                            INNER JOIN [Configuration].[Device] cfdevice on cfdevice.Id = device.Id_Device
	                            WHERE device.Id_ScheduleUnit =@ScheduleUnitId";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id_Unit, selectedSchedule), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.Device dataObjectDevice = new DataObject.Device();
                            dataObjectDevice.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectDevice.Name = reader.GetValue(1).ToString();
                            dataObjectDevice.DateAdded = Convert.ToDateTime(reader.GetValue(2).ToString());
                            dataObjectDevice.DeviceOn = Convert.ToBoolean(reader.GetValue(3).ToString());
                            dataObjectDevice.DeviceId = int.Parse(reader.GetValue(4).ToString());
                            deviceList.Add(dataObjectDevice);
                        }
                    }
                }
            }

            return deviceList;
        }

        public List<DataObject.Device> ListWithSwitch(int Id_Unit, int selectedSchedule)
        {
            List<DataObject.Device> deviceList = new List<DataObject.Device>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = @"DECLARE @ScheduleUnitId int
    
                                SELECT @ScheduleUnitId = Id FROM [Schedule].[Unit]
                                WHERE Id_Schedule = {1} and Id_Unit = {0}
    
	                            SELECT device.Id, cfdevice.Name, cfdevice.DateAdded,device.DeviceOn, ID_Device, cfdevice.Switch FROM [Schedule].[Device] device
	                            INNER JOIN [Configuration].[Device] cfdevice on cfdevice.Id = device.Id_Device
	                            WHERE device.Id_ScheduleUnit =@ScheduleUnitId Order By cfdevice.Switch asc";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id_Unit, selectedSchedule), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.Device dataObjectDevice = new DataObject.Device();
                            dataObjectDevice.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectDevice.Name = reader.GetValue(1).ToString();
                            dataObjectDevice.Switch = reader.GetValue(5).ToString();
                            dataObjectDevice.DateAdded = Convert.ToDateTime(reader.GetValue(2).ToString());
                            dataObjectDevice.DeviceOn = Convert.ToBoolean(reader.GetValue(3).ToString());
                            dataObjectDevice.DeviceId = int.Parse(reader.GetValue(4).ToString());
                            dataObjectDevice.Switch = reader.GetValue(5).ToString();
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
