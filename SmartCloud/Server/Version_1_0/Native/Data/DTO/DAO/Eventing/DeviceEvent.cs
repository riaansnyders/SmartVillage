namespace lfa.pmgmt.data.DAO.Eventing
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    using DataObject = lfa.pmgmt.data.DTO.Eventing;
    #endregion

    public class DeviceEvent
    {
        #region Public Properties
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region Insert
        public void Insert(string Serial, string Event)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Eventing].[InsertEvent] '{0}','{1}'";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Serial, Event), connection))
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

                string sqlQuery = "Exec [Eventing].[DeleteEvents] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Get Event
        public DataObject.DeviceEvent GetEvent(string Serial)
        {
            DataObject.DeviceEvent deviceEvent = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "[Security].[ListEvents] '{0}'";

                using (SqlCommand command = new SqlCommand(string.Format(query, Serial), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        deviceEvent = new DataObject.DeviceEvent();

                        while (reader.Read())
                        {
                            deviceEvent.Id = int.Parse(reader.GetValue(0).ToString());
                            deviceEvent.Serial = Serial;
                            deviceEvent.Event = reader.GetValue(1).ToString();
                        }
                    }
                }
            }

            return deviceEvent;
        }
        #endregion
    }
}