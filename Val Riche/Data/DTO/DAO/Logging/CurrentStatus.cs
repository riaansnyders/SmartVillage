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

    public class CurrentStatus
    {
        #region Public Properties 
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region Insert
        public void Insert(string unitName, string status)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = @"IF (SELECT COUNT(1) FROM [Logging].[CurrentStatus] WHERE UnitName = '{0}') > 0
                                        BEGIN
                                            UPDATE [Logging].[CurrentStatus] SET Status = '{1}' WHERE UnitName = '{0}'
                                        END
                                        ELSE
                                        BEGIN
                                          INSERT INTO [Logging].[CurrentStatus] VALUES ('{0}','{1}')
                                        END";

                using (SqlCommand command = new SqlCommand(string.Format(sqlQuery,unitName,status),connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region List
        public List<DataObject.CurrentStatus> List(int Id_Zone)
        {
            List<DataObject.CurrentStatus> list = new List<DataObject.CurrentStatus>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = @"Select c.Id,c.UnitName,c.[Status]
                                    FROM [Configuration].[Zone] a
                                    INNER JOIN [Configuration].[Unit] b on b.Id_Zone = a.Id
                                    INNER JOIN [Logging].[CurrentStatus] c on c.UnitName = b.Name
                                    WHERE a.Id = {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query,Id_Zone), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.CurrentStatus dataObject = new DataObject.CurrentStatus();
                            dataObject.Id = int.Parse(reader.GetValue(0).ToString());
                            dataObject.UnitName = reader.GetValue(1).ToString();
                            dataObject.Status = reader.GetValue(2).ToString();

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
