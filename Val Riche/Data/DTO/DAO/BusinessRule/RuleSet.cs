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

    public class RuleSet
    {
        #region Public Properties
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region Insert
        public void Insert(string Name, string Version, DateTime DateAdded)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [BusinessRule].[InsertRuleSet] '{0}','{1}','{2}' ";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Name, Version, 
                                                                         DateAdded.ToString("yyyy/MM/dd")), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertPriority(int Id_RuleSet, int Id_Rule, string priority)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO [BusinessRule].[PriorityRule] VALUES ({0},'{1}', {2})";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id_RuleSet,priority, Id_Rule), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Update
        public void Update(int Id, string Name, string Version)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [BusinessRule].[UpdateRuleSet] {0},'{1}','{2}' ";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id, Name, Version), connection))
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

                string sqlQuery = "Exec [BusinessRule].[DeleteRuleSet] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery,Id), connection))
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

                string sqlQuery = "Exec [BusinessRule].[EnableRuleSet] {0},{1} ";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id,EnableDisable),connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Get
        public DataObject.RuleSet Get(int Id)
        {
            DataObject.RuleSet dataObjectRuleSet = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [BusinessRule].[GetActiveRuleSet] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataObjectRuleSet = new DataObject.RuleSet();
                            dataObjectRuleSet.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectRuleSet.Name = reader.GetValue(1).ToString();
                            dataObjectRuleSet.Version = reader.GetValue(2).ToString();
                            dataObjectRuleSet.DateAdded = Convert.ToDateTime(reader.GetValue(3).ToString());
                            dataObjectRuleSet.IsActive = true;
                        }
                    }
                }
            }

            return dataObjectRuleSet;
        }
        #endregion

        #region List
        public List<DataObject.RuleSet> List()
        {
            List<DataObject.RuleSet> ruleSetList = new List<DataObject.RuleSet>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [BusinessRule].[ListActiveRuleSet]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.RuleSet dataObjectRuleSet = new DataObject.RuleSet();
                            dataObjectRuleSet.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectRuleSet.Name = reader.GetValue(1).ToString();
                            dataObjectRuleSet.Version = reader.GetValue(2).ToString();
                            dataObjectRuleSet.DateAdded = Convert.ToDateTime(reader.GetValue(3).ToString());
                            dataObjectRuleSet.IsActive = true;

                            ruleSetList.Add(dataObjectRuleSet);
                        }
                    }
                }
            }

            return ruleSetList;
        }

        public List<DataObject.Priority> ListPriority(string priority)
        {
            List<DataObject.Priority> scheduleList = new List<DataObject.Priority>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT a.Id, a.Id_RuleSet, b.Name, a.Priority FROM [BusinessRule].[PriorityRule] a ";
                query += "INNER JOIN [BusinessRule].[Ruleset] b on b.Id = a.Id_RuleSet WHERE Priority = '{0}'";

                using (SqlCommand command = new SqlCommand(string.Format(query, priority), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.Priority dataObjectSchedule = new DataObject.Priority();
                            dataObjectSchedule.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObjectSchedule.Id_RuleSet = int.Parse(reader.GetValue(1).ToString());
                            dataObjectSchedule.Name = reader.GetValue(2).ToString();
                            dataObjectSchedule.PriorityType = reader.GetValue(3).ToString();

                            scheduleList.Add(dataObjectSchedule);
                        }
                    }
                }
            }

            return scheduleList;
        }

        public List<int> ListPrioritySchedules(int Id_Zone, string priority)
        {
            List<int> scheduleIdList = new List<int>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT a.Id_RuleSet FROM [Schedule].[Zone] a ";
                query += "INNER JOIN  [Schedule].[PriorityRule] b on b.Id_Schedule = a.Id_Schedule ";
                query += "WHERE a.Id_Zone = {0} and b.Priority = '{1}'";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id_Zone, priority), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            scheduleIdList.Add(int.Parse(reader.GetValue(0).ToString()));
                        }
                    }
                }
            }

            return scheduleIdList;
        }
        #endregion
    }
}
