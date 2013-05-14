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

    public class Zone
    {
        #region Public Properties
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region Insert
        public void Insert(string Name, DateTime DateAdded, string serial)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Configuration].[InsertZone] '{0}','{1}','{2}'";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Name, DateAdded.ToString("yyyy/MM/dd"),serial), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Update
        public void Update(int Id, string Name)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Configuration].[UpdateZone] {0},'{1}'";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id, Name), connection))
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

                string sqlQuery = "Exec [Configuration].[DeleteZone] {0}";

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

                string sqlQuery = "Exec [Configuration].[EnableDisableZone] {0},{1}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id, EnableDisable), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Get
        public DataObject.Zone Get(int Id)
        {
            DataObject.Zone dataObjectZone = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [Configuration].[GetActiveZone] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataObjectZone = new DataObject.Zone();
                            dataObjectZone.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectZone.Name = reader.GetValue(1).ToString();
                            dataObjectZone.DateAdded = Convert.ToDateTime(reader.GetValue(2).ToString());
                            dataObjectZone.IsActive = Convert.ToBoolean(reader.GetValue(3).ToString());
                        }
                    }
                }
            }

            return dataObjectZone;
        }
        #endregion

        #region List
        public List<DataObject.Zone> List()
        {
            List<DataObject.Zone> zoneList = new List<DataObject.Zone>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [Configuration].[ListActiveZone]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            DataObject.Zone dataObjectZone = new DataObject.Zone();
                            dataObjectZone.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectZone.Name = reader.GetValue(1).ToString();
                            dataObjectZone.DateAdded = Convert.ToDateTime(reader.GetValue(2).ToString());
                            dataObjectZone.IsActive = Convert.ToBoolean(reader.GetValue(3).ToString());

                            zoneList.Add(dataObjectZone);
                        }
                    }
                }
            }

            return zoneList;
        }
        #endregion
    }
}
