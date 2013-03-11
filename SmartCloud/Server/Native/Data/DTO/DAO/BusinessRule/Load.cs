namespace lfa.pmgmt.data.DAO.BusinessRule
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    using DataObject = lfa.pmgmt.data.DTO.BusinessRule;
    #endregion

    public class Load
    {
        #region Public Properties
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region Insert
        public void Insert(int currentLoad, int maximumLoad)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [BusinessRule].[InsertLoad] {0}, {1}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery,currentLoad,maximumLoad),connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertManual(int manualLoad, int maximumLoad)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = @"DECLARE @CURRENTLOAD INT

                                    SELECT @CURRENTLOAD = CurrentLoad FROM [BusinessRule].[Load]

                                    DELETE FROM [BusinessRule].[Load]
                                    
                                    INSERT INTO [BusinessRule].[Load] VALUES (@CurrentLoad,'{1}','{0}')";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, manualLoad, maximumLoad), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Update
        public void Update(int currentLoad, int maximumLoad)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [BusinessRule].[UpdateLoad] {0}, {1}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery,currentLoad,maximumLoad), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region List
        public List<DataObject.Load> List()
        {
            List<DataObject.Load> resultList = new List<DataObject.Load>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [BusinessRule].[ListLoad]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.Load dataObjectResult = new DataObject.Load();
                            dataObjectResult.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectResult.CurrentLoad = int.Parse(reader.GetValue(1).ToString());
                            dataObjectResult.MaximumLoad = int.Parse(reader.GetValue(2).ToString());
                            dataObjectResult.ManualLoad = int.Parse(reader.GetValue(3).ToString());

                            resultList.Add(dataObjectResult);
                        }
                    }
                }
            }

            return resultList;
        }
        #endregion
    }
}
