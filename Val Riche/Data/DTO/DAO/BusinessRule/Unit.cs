namespace lfa.pmgmt.data.DAO.BusinessRule
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
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
        public void Insert(int Id_Unit, int Id_Rule)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [BusinessRule].[InsertUnit] {0}, {1}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id_Unit, Id_Rule), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Update
        public void Update(int Id, int Id_Unit, int Id_Rule)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "Exec [BusinessRule].[UpdateUnit] {0}, {1}, {2}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery,Id, Id_Unit, Id_Rule), connection))
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

                string sqlQuery = "Exec [BusinessRule].[DeleteUnit] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}
