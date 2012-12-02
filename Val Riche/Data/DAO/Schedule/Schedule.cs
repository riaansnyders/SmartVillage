namespace lfa.pmgmt.data.DAO.Schedule
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    using DataObject = lfa.pmgmt.data.DTO.Schedule;
    #endregion

    public class Schedule
    {
       #region Public Properties
       public string ConnectionString
       {
            get;
            set;
       }
       #endregion

       #region Insert
       public void Insert(string Name, string StartTime, string EndTime, int ElapsedTime, DateTime DateAdded)
       {
           using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               connection.Open();

               string sqlQuery = "Exec [Schedule].[InsertSchedule] '{0}','{1}','{2}', {3}, '{4}'";

               using (SqlCommand command = new SqlCommand(string.Format(sqlQuery,Name,StartTime,EndTime,
                                                                        ElapsedTime,DateAdded.ToString("yyyy/MM/dd")), connection))
               {
                   command.ExecuteNonQuery();
               }
           }
       }
       #endregion

       #region Update
       public void Update(int Id, string Name, string StartTime, string EndTime, int ElapsedTime)
       {
           using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               connection.Open();

               string sqlQuery = "Exec [Schedule].[UpdateSchedule] {0},'{1}','{2}', '{3}', {4}";

               using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id, Name, StartTime, EndTime,
                                                                        ElapsedTime), connection))
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

               string sqlQuery = "Exec [Schedule].[DeleteSchedule] {0}";

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

               string sqlQuery = "Exec [Schedule].[EnableDisableSchedule] {0}, {1}";

               using (SqlCommand command = new SqlCommand(string.Format(sqlQuery, Id, EnableDisable), connection))
               {
                   command.ExecuteNonQuery();
               }
           }
       }

       public void DisableAll()
       {
           using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               connection.Open();

               string sqlQuery = "UPDATE [Schedule].[Schedule] SET IsActive = 0";

               using (SqlCommand command = new SqlCommand(sqlQuery, connection))
               {
                   command.ExecuteNonQuery();
               }
           }
       }

       #endregion

       #region Get
       public DataObject.Schedule Get(int Id)
       {
           DataObject.Schedule dataObjectSchedule = null;

           using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               connection.Open();

               string query = "Exec [Schedule].[GetActiveSchedule] {0}";

               using (SqlCommand command = new SqlCommand(string.Format(query, Id), connection))
               {
                   SqlDataReader reader = command.ExecuteReader();

                   if (reader.HasRows)
                   {
                       while (reader.Read())
                       {
                           dataObjectSchedule = new DataObject.Schedule();
                           dataObjectSchedule.Id = int.Parse(reader.GetValue(0).ToString());
                           dataObjectSchedule.Name = reader.GetValue(1).ToString();
                           dataObjectSchedule.StartTime = reader.GetValue(2).ToString();
                           dataObjectSchedule.EndTime = reader.GetValue(3).ToString();
                           dataObjectSchedule.ElapsedTime = int.Parse(reader.GetValue(4).ToString());
                           dataObjectSchedule.DateAdded = Convert.ToDateTime(reader.GetValue(5).ToString());
                           dataObjectSchedule.IsActive = true;
                       }
                   }
               }
           }

           return dataObjectSchedule;
       }
       #endregion

       #region List
       public List<DataObject.Schedule> List()
       {
           List<DataObject.Schedule> scheduleList = new List<DataObject.Schedule>();

           using (SqlConnection connection = new SqlConnection(ConnectionString))
           {
               connection.Open();

               string query = "Exec [Schedule].[ListActiveSchedule]";

               using (SqlCommand command = new SqlCommand(query, connection))
               {
                   SqlDataReader reader = command.ExecuteReader();

                   if (reader.HasRows)
                   {
                       while (reader.Read())
                       {
                           DataObject.Schedule dataObjectSchedule = new DataObject.Schedule();
                           dataObjectSchedule.Id = int.Parse(reader.GetValue(0).ToString());
                           dataObjectSchedule.Name = reader.GetValue(1).ToString();
                           dataObjectSchedule.StartTime = reader.GetValue(2).ToString().Substring(0, 5);
                           dataObjectSchedule.EndTime = reader.GetValue(3).ToString().Substring(0, 5);
                           dataObjectSchedule.ElapsedTime = int.Parse(reader.GetValue(4).ToString());
                           dataObjectSchedule.DateAdded = Convert.ToDateTime(reader.GetValue(5).ToString());
                           dataObjectSchedule.IsActive = Convert.ToBoolean(reader.GetValue(6).ToString());

                           scheduleList.Add(dataObjectSchedule);
                       }
                   }
               }
           }

           return scheduleList;
       }
       #endregion
    }
}
