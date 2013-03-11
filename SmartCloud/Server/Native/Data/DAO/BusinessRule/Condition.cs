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

    public class Condition
    {
        #region Public Properties
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region Get
        public DataObject.Condition Get(int Id)
        {
            DataObject.Condition dataObjectCondition = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [BusinessRule].[GetCondition] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataObjectCondition = new DataObject.Condition();
                            dataObjectCondition.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectCondition.Value = reader.GetValue(1).ToString();
                            dataObjectCondition.Description = reader.GetValue(2).ToString();
                        }
                    }
                }
            }

            return dataObjectCondition;
        }
        #endregion

        #region List
        public List<DataObject.Condition> List()
        {
            List<DataObject.Condition> conditionList = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [BusinessRule].[ListCondition]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.Condition dataObjectCondition = new DataObject.Condition();
                            dataObjectCondition.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectCondition.Value = reader.GetValue(1).ToString();
                            dataObjectCondition.Description = reader.GetValue(2).ToString();

                            conditionList.Add(dataObjectCondition);
                        }
                    }
                }
            }

            return conditionList;
        }
        #endregion
    }
}
