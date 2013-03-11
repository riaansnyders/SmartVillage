namespace lfa.pmgmt.data.DAO.BusinessRule
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    using DataObject = lfa.pmgmt.data.DTO.BusinessRule;
    #endregion

    public class Result
    {
        #region Public Properties
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region Get
        public DataObject.Result Get(int Id)
        {
            DataObject.Result dataObjectResult = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [BusinessRule].[GetResult] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataObjectResult = new DataObject.Result();
                            dataObjectResult.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectResult.Value = reader.GetValue(1).ToString();
                        }
                    }
                }
            }

            return dataObjectResult;
        }
        #endregion

        #region List
        public List<DataObject.Result> List()
        {
            List<DataObject.Result> resultList = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [BusinessRule].[ListResult]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.Result dataObjectResult = new DataObject.Result();
                            dataObjectResult.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectResult.Value = reader.GetValue(1).ToString();

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
