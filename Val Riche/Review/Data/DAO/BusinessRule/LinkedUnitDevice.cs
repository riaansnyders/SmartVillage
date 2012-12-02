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

    public class LinkedUnitDevice
    {
        #region Public Properties
        public string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region Get
        public DataObject.LinkedRuleUnitDevice Get(int unitId)
        {
            DataObject.LinkedRuleUnitDevice dataObject = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [BusinessRule].[GetRuleUnitAndDevice] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, unitId), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataObject = new DataObject.LinkedRuleUnitDevice();
                            dataObject.UnitId = int.Parse(reader.GetValue(1).ToString());
                            dataObject.UnitAddress = reader.GetValue(2).ToString();
                            dataObject.DeviceId = int.Parse(reader.GetValue(4).ToString());
                        }
                    }
                }
            }

            return dataObject;
        }
        #endregion

        #region List
        public List<DataObject.LinkedRuleUnitDevice> List(int Id_Rule)
        {
            List<DataObject.LinkedRuleUnitDevice> list = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "Exec [BusinessRule].[ListRuleUnitAndDevice] {0}";

                using (SqlCommand command = new SqlCommand(string.Format(query, Id_Rule), connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataObject.LinkedRuleUnitDevice dataObject = new DataObject.LinkedRuleUnitDevice();
                            dataObject.UnitId = int.Parse(reader.GetValue(1).ToString());
                            dataObject.UnitAddress = reader.GetValue(2).ToString();
                            dataObject.DeviceId = int.Parse(reader.GetValue(4).ToString());

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
