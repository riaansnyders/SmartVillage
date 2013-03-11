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
        public void Insert(int Id_Zone, string Name, DateTime DateAdded, string Address)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Configuration].[InsertUnit] {0},'{1}','{2}', '{3}'";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id_Zone, Name, 
                                                                         DateAdded.ToString("yyyy/MM/dd"),Address), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Update
        public void Update(int Id, int Id_Zone, string Name, string Address)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [Configuration].[UpdateUnit] {0}, {1},'{2}','{3}'";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id, Id_Zone, Name, Address), connection))
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

                string sqlQuery = "Exec [Configuration].[DeleteUnit] {0}";

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

                string sqlQuery = "Exec [Configuration].[EnableDisableUnit] {0},{1}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id, EnableDisable), connection))
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

                string query = "Exec [Configuration].[GetActiveUnit] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataObjectUnit = new DataObject.Unit();
                            dataObjectUnit.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectUnit.Id_Zone = 0;
                            dataObjectUnit.Name = reader.GetValue(1).ToString();
                            dataObjectUnit.Address = reader.GetValue(3).ToString();
                            dataObjectUnit.DateAdded = Convert.ToDateTime(reader.GetValue(2).ToString());
                            dataObjectUnit.IsActive = true;
                        }
                    }
                }
            }

            return dataObjectUnit;
        }

        public string GetName(int Id)
        {
            string name = string.Empty;
               
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [Configuration].[GetActiveUnit] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            name = reader.GetValue(1).ToString();
                        }
                    }
                }
            }

            return name;
        }

        public int GetLastInsertedUnit(int zoneId)
        {
            int lastInsertedId = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Select Id from Configuration.Unit where Id_zone = {0} order by Id asc";

                using (SqlCommand command = new SqlCommand(string.Format(query, zoneId), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            lastInsertedId = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
            }

            return lastInsertedId;
        }
        #endregion

        #region List
        public List<DataObject.Unit> List(int Id_Zone)
        {
            List<DataObject.Unit> unitList = new List<DataObject.Unit>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [Configuration].[ListActiveUnit] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id_Zone), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.Unit dataObjectUnit = new DataObject.Unit();
                            dataObjectUnit.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectUnit.Id_Zone = Id_Zone;
                            dataObjectUnit.Name = reader.GetValue(1).ToString();
                            dataObjectUnit.Address = reader.GetValue(3).ToString();
                            dataObjectUnit.DateAdded = Convert.ToDateTime(reader.GetValue(2).ToString());
                            dataObjectUnit.IsActive = Convert.ToBoolean(reader.GetValue(4).ToString());

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
