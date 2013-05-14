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

    public class Unit
    {
        #region Public Properties
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region Insert
        public void Insert(int Id_Unit, int Id_Schedule)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Schedule].[InsertUnit] {0},{1}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id_Unit, Id_Schedule), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Update
        public void Update(int Id, int Id_Unit, int Id_Schedule)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Schedule].[UpdateUnit] {0}, {1}, {2}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id, Id_Unit, Id_Schedule), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Delete
        public void Delete(int Id, int id_Schedule)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Schedule].[DeleteUnit] {0}, {1}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id, id_Schedule), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Get
        public DataObject.Unit Get(int Id)
        {
            DataObject.Unit dataObjectUnit = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [Schedule].[GetActiveUnit] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataObjectUnit = new DataObject.Unit();
                            dataObjectUnit.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectUnit.Name = reader.GetValue(1).ToString();
                            dataObjectUnit.Address = reader.GetValue(2).ToString();
                            dataObjectUnit.DateAdded = Convert.ToDateTime(reader.GetValue(3).ToString());
                        }
                    }
                }
            }

            return dataObjectUnit;

        }
        #endregion

        #region List
        public List<DataObject.Unit> List(int Id_Schedule)
        {
            List<DataObject.Unit> unitList = new List<DataObject.Unit>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [Schedule].[ListActiveUnit] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id_Schedule), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.Unit dataObjectUnit = new DataObject.Unit();
                            dataObjectUnit.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectUnit.Id_ScheduleUnit = int.Parse(reader.GetValue(1).ToString());
                            dataObjectUnit.Name = reader.GetValue(2).ToString();
                            dataObjectUnit.Address = reader.GetValue(3).ToString();
                            dataObjectUnit.DateAdded = Convert.ToDateTime(reader.GetValue(4).ToString());
                            dataObjectUnit.IsActive = Convert.ToBoolean(reader.GetValue(5).ToString());

                            unitList.Add(dataObjectUnit);
                        }
                    }
                }
            }

            return unitList;
        }

        public List<DataObject.Unit> ListWithZone(int Id_Schedule)
        {
            List<DataObject.Unit> unitList = new List<DataObject.Unit>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = @"SELECT cfunit.Id, unit.Id as 'Id_ScheduleUnit', cfunit.Name, cfunit.[Address], 
                                        cfunit.DateAdded, cfunit.IsActive, cfunit.Id_Zone
	                            FROM [Schedule].[Unit] unit
	                            INNER JOIN [Configuration].[Unit] cfunit on cfunit.Id = unit.Id_Unit
	                            WHERE unit.Id_Schedule = {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id_Schedule), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.Unit dataObjectUnit = new DataObject.Unit();
                            dataObjectUnit.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectUnit.Id_ScheduleUnit = int.Parse(reader.GetValue(1).ToString());
                            dataObjectUnit.Name = reader.GetValue(2).ToString();
                            dataObjectUnit.Address = reader.GetValue(3).ToString();
                            dataObjectUnit.DateAdded = Convert.ToDateTime(reader.GetValue(4).ToString());
                            dataObjectUnit.IsActive = Convert.ToBoolean(reader.GetValue(5).ToString());
                            dataObjectUnit.Id_Zone = int.Parse(reader.GetValue(6).ToString());

                            unitList.Add(dataObjectUnit);
                        }
                    }
                }
            }

            return unitList;
        }

        public List<DataObject.Unit> ListConfigurationUnits()
        {
            List<DataObject.Unit> unitList = new List<DataObject.Unit>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [Schedule].[ListConfigurationUnit]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.Unit dataObjectUnit = new DataObject.Unit();
                            dataObjectUnit.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectUnit.Id_ScheduleUnit = 0;
                            dataObjectUnit.Name = reader.GetValue(1).ToString();
                            dataObjectUnit.Address = string.Empty;
                            dataObjectUnit.DateAdded = DateTime.Now;

                            unitList.Add(dataObjectUnit);
                        }
                    }
                }
            }

            return unitList;
        }
        #endregion
    }
}
