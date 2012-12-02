using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using lfa.pmgmt.data.DTO.Schedule;
using lfa.pmgmt.data.DTO.Configuration;
using lfa.pmgmt.data.DAO.Schedule;
using lfa.pmgmt.data.DAO.Configuration;

using lfa.pmgmt.schedule;

namespace lfa.pmgmt.ut
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                decimal currentLoad = GetHigestVoltage();

                Console.WriteLine(currentLoad.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("done...");
            Console.ReadKey();
        }

        #region Unit Test Methods
        private static void StartSchedule()

        {
            string connectionString = @"Data Source=DLMHS10V\BTS2;Initial Catalog=lfa_PowerMgmt;user id=sa;password=Orgaleon12;";

            lfa.pmgmt.schedule.Scheduling schedule = new Scheduling(connectionString);
            schedule.Execute(9000);


        }

        private static decimal GetHigestVoltage()
        {
            ArrayList voltageList = new ArrayList();
            voltageList.Add(123.445);
            voltageList.Add(12.00);
            voltageList.Add(34567.89);

            voltageList.Sort();

            int voltageListLen = voltageList.Count - 1;
            decimal hightestVoltage = Convert.ToDecimal(voltageList[voltageListLen].ToString());

            return hightestVoltage;
        }
        #endregion
    }
}
