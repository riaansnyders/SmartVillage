namespace lfa.pmgmt.data.DAO.Logging
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    using DataObject = lfa.pmgmt.data.DTO.Logging;
    #endregion

    public class Log
    {
        #region Public Properties 
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region Insert
        public void Insert(int Id_LogType, string originator, string fault, DateTime DateAdded)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO [Logging].[Log] VALUES ({0},'{1}','{2}','{3}')";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id_LogType, originator, 
                                                                         fault, DateAdded.ToString("yyyy/MM/dd hh:mm:ss")), connection))
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

                string sqlQuery = "DELETE FROM [Logging].[Log] WHERE Id = {0}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Truncate()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "TRUNCATE TABLE [Logging].[Log]";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region List
        public List<DataObject.Log> List()
        {
            List<DataObject.Log> list = new List<DataObject.Log>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT Id, Originator, Fault, DateTimeAdded FROM [Logging].[Log] WHERE Id_LogType = 1 ORDER By Id DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.Log dataObject = new DataObject.Log();
                            dataObject.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObject.Originator = reader.GetValue(1).ToString();
                            dataObject.Fault = reader.GetValue(2).ToString();
                            dataObject.DateAdded = Convert.ToDateTime(reader.GetValue(3).ToString());

                            list.Add(dataObject);
                        }
                    }
                }
            }

            return list;
        }
        #endregion
    }
}
