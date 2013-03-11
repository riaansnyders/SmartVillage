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

    public class Rule
    {
        #region Public Properties
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region Insert
        public void Insert(int Id_RuleSet, string Condition, string Result)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [BusinessRule].[InsertRule] {0},'{1}','{2}' ";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id_RuleSet, Condition, Result), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Update
        public void Update(int Id, int Id_RuleSet, string Condition, string Result)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [BusinessRule].[UpdateRule] {0}, {1},'{2}','{3}' ";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id, Id_RuleSet, Condition, Result), connection))
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

                string sqlQuery = "Exec [BusinessRule].[DeleteRule] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Get
        public DataObject.Rule Get(int Id)
        {
            DataObject.Rule dataObjectRule = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [BusinessRule].[GetActiveRule] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataObjectRule = new DataObject.Rule();
                            dataObjectRule.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectRule.Result = reader.GetValue(2).ToString();
                        }
                    }
                }
            }

            return dataObjectRule;
        }
        #endregion

        #region List
        public List<DataObject.Rule> List(int Id_RuleSet)
        {
            List<DataObject.Rule> ruleList = new List<DataObject.Rule>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [BusinessRule].[ListActiveRule] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query,Id_RuleSet), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.Rule dataObjectRule = new DataObject.Rule();
                            dataObjectRule.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectRule.Condition = reader.GetValue(1).ToString();
                            dataObjectRule.Result = reader.GetValue(2).ToString();

                            ruleList.Add(dataObjectRule);
                        }
                    }
                }
            }

            return ruleList;
        }
        #endregion
    }
}
