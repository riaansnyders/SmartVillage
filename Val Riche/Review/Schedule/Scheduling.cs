namespace lfa.pmgmt.schedule
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;

    using lfa.pmgmt.data.DAO.Configuration;
    using lfa.pmgmt.data.DAO.Schedule;
    using lfa.pmgmt.data.DTO.Configuration;
    using lfa.pmgmt.data.DTO.Schedule;

    using BravaSystem.Communication;
    #endregion

    public class Scheduling
    {
        private string _connectionString = string.Empty;
        private List<string> _executed = null;
        private Dictionary<string, List<lfa.pmgmt.data.DTO.Schedule.Unit>> _defaultUnits = null;

        #region Constructor
        public Scheduling(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region Schedule Start
        public void Execute(int defaultPort)
        {
            _executed = new List<string>();

            lfa.pmgmt.data.DAO.Schedule.Schedule scheduleDAO = new data.DAO.Schedule.Schedule();
            scheduleDAO.ConnectionString = _connectionString;

            List<lfa.pmgmt.data.DTO.Schedule.Schedule> scheduleList = scheduleDAO.List();

            foreach (lfa.pmgmt.data.DTO.Schedule.Schedule schedule in scheduleList)
            {
                if (schedule.IsActive)
                {
                    string scheduleStartTime = schedule.StartTime;
                    string scheduleEndTime = schedule.EndTime;

                    DateTime currentTime = DateTime.Now;
                    DateTime scheduleStart = Convert.ToDateTime(scheduleStartTime);
                    DateTime scheduleEnd = Convert.ToDateTime(scheduleEndTime);

                    if (currentTime <= scheduleEnd)
                    {
                        if (currentTime >= scheduleStart)
                        {
                            lfa.pmgmt.data.DAO.Schedule.Schedule DAO = new data.DAO.Schedule.Schedule();
                            DAO.ConnectionString = _connectionString;

                            string priorityValue = DAO.GetPriority(schedule.Id);

                            if (string.IsNullOrEmpty(priorityValue))
                            {
                                lfa.pmgmt.data.DAO.Schedule.Unit unitDAO = new data.DAO.Schedule.Unit();
                                unitDAO.ConnectionString = _connectionString;
                                List<lfa.pmgmt.data.DTO.Schedule.Unit> scheduleUnits = unitDAO.List(schedule.Id);

                                GetScheduleUnitDetails(scheduleUnits, schedule.Id, defaultPort);
                            }
                            else
                            {
                                    lfa.pmgmt.data.DAO.Schedule.Unit unitDAO = new data.DAO.Schedule.Unit();
                                    unitDAO.ConnectionString = _connectionString;
                                    List<lfa.pmgmt.data.DTO.Schedule.Unit> scheduleUnits = unitDAO.List(schedule.Id);

                                    if (ExecutePriority(_connectionString, priorityValue))
                                    {
                                        GetScheduleUnitDetails(scheduleUnits, schedule.Id, defaultPort);

                                        _executed.Add("true");
                                    }

                                #region OBSOLETE
                                //if (priorityValue.ToLower().Equals("low"))
                                    //{
                                    //    ExecutePriority(connectionString,priority)
                                    //    {
                                    //      GetScheduleUnitDetails(scheduleUnits, schedule.Id, defaultPort);
                                    //    }
                                    //}

                                    //if (priorityValue.ToLower().Equals("medium"))
                                    //{
                                    //    GetScheduleUnitDetails(scheduleUnits, schedule.Id, defaultPort);

                                    //    lfa.pmgmt.data.DAO.Schedule.Schedule dao = new data.DAO.Schedule.Schedule();

                                    //    dao.ConnectionString = _connectionString;
                                    //    int zoneid = dao.GetLinkedZone(schedule.Id);

                                    //    List<int> scheduleIds = dao.ListPrioritySchedules(zoneid, "Low");

                                    //    foreach (int id in scheduleIds)
                                    //    {
                                    //        List<lfa.pmgmt.data.DTO.Schedule.Unit> i_scheduleUnits = unitDAO.List(id);

                                    //        GetScheduleUnitDetails(i_scheduleUnits, id, defaultPort);
                                    //    }

                                    //}

                                    //if (priorityValue.ToLower().Equals("high"))
                                    //{
                                    //    GetScheduleUnitDetails(scheduleUnits, schedule.Id, defaultPort);

                                    //    lfa.pmgmt.data.DAO.Schedule.Schedule dao = new data.DAO.Schedule.Schedule();

                                    //    dao.ConnectionString = _connectionString;
                                    //    int zoneid = dao.GetLinkedZone(schedule.Id);

                                    //    List<int> scheduleIds = dao.ListPrioritySchedules(zoneid, "Medium");

                                    //    foreach (int id in scheduleIds)
                                    //    {
                                    //        List<lfa.pmgmt.data.DTO.Schedule.Unit> i_scheduleUnits = unitDAO.List(id);

                                    //        GetScheduleUnitDetails(i_scheduleUnits, id, defaultPort);
                                    //    }

                                    //    List<int> lowscheduleIds = dao.ListPrioritySchedules(zoneid, "Low");

                                    //    foreach (int id in lowscheduleIds)
                                    //    {
                                    //        List<lfa.pmgmt.data.DTO.Schedule.Unit> i_scheduleUnits = unitDAO.List(id);

                                    //        GetScheduleUnitDetails(i_scheduleUnits, id, defaultPort);
                                    //    }
                                //}
                                #endregion
                             }
                           }
                        }
                    }
               }
        }

        public List<lfa.pmgmt.data.DTO.Schedule.Schedule> ListSchedules()
        {
            lfa.pmgmt.data.DAO.Schedule.Schedule scheduleDAO = new data.DAO.Schedule.Schedule();
            scheduleDAO.ConnectionString = _connectionString;

            List<lfa.pmgmt.data.DTO.Schedule.Schedule> scheduleList = scheduleDAO.List();
            
            return scheduleList;
        }

        public void ExecuteSchedule(List<lfa.pmgmt.data.DTO.Schedule.Schedule> scheduleList, 
                                    List<int> ruleEnabledUnits, int defaultPort)
        {
            _executed = new List<string>();
            _defaultUnits = new Dictionary<string, List<lfa.pmgmt.data.DTO.Schedule.Unit>>();

            foreach (lfa.pmgmt.data.DTO.Schedule.Schedule schedule in scheduleList)
            {
                if (schedule.IsActive)
                {
                    string scheduleStartTime = schedule.StartTime;
                    string scheduleEndTime = schedule.EndTime;

                    DateTime currentTime = DateTime.Now;
                    DateTime scheduleStart = Convert.ToDateTime(scheduleStartTime);
                    DateTime scheduleEnd = Convert.ToDateTime(scheduleEndTime);

                    if (currentTime <= scheduleEnd)
                    {
                        if (currentTime >= scheduleStart)
                        {
                            lfa.pmgmt.data.DAO.Schedule.Schedule DAO = new data.DAO.Schedule.Schedule();
                            DAO.ConnectionString = _connectionString;

                            string priorityValue = DAO.GetPriority(schedule.Id);

                            if (string.IsNullOrEmpty(priorityValue))
                            {
                                priorityValue = "None";
                            }

                            if (string.IsNullOrEmpty(priorityValue))
                            {
                                lfa.pmgmt.data.DAO.Schedule.Unit unitDAO = new data.DAO.Schedule.Unit();
                                unitDAO.ConnectionString = _connectionString;
                                List<lfa.pmgmt.data.DTO.Schedule.Unit> scheduleUnits = unitDAO.List(schedule.Id);

                                GetScheduleUnitDetailsForId(scheduleUnits, schedule.Id, ruleEnabledUnits, defaultPort);
                            }
                            else
                            {
                                lfa.pmgmt.data.DAO.Schedule.Unit unitDAO = new data.DAO.Schedule.Unit();
                                unitDAO.ConnectionString = _connectionString;
                                List<lfa.pmgmt.data.DTO.Schedule.Unit> scheduleUnits = unitDAO.List(schedule.Id);

                                if (ExecutePriority(_connectionString, priorityValue))
                                {
                                    GetScheduleUnitDetails(scheduleUnits, schedule.Id, defaultPort);

                                    _executed.Add("true");
                                }

                                #region OBSOLETE
                                //if (ExecutePriority(_connectionString))
                                //{
                                //    lfa.pmgmt.data.DAO.Schedule.Unit unitDAO = new data.DAO.Schedule.Unit();
                                //    unitDAO.ConnectionString = _connectionString;
                                //    List<lfa.pmgmt.data.DTO.Schedule.Unit> scheduleUnits = unitDAO.List(schedule.Id);

                                //    if (priorityValue.ToLower().Equals("low"))
                                //    {
                                //        GetScheduleUnitDetails(scheduleUnits, schedule.Id, defaultPort);
                                //    }

                                //    if (priorityValue.ToLower().Equals("medium"))
                                //    {
                                //        GetScheduleUnitDetails(scheduleUnits, schedule.Id, defaultPort);

                                //        lfa.pmgmt.data.DAO.Schedule.Schedule dao = new data.DAO.Schedule.Schedule();
                                        
                                //        dao.ConnectionString = _connectionString;
                                //        int zoneid = dao.GetLinkedZone(schedule.Id);

                                //        List<int> scheduleIds = dao.ListPrioritySchedules(zoneid, "Low");

                                //        foreach (int id in scheduleIds)
                                //        {
                                //            List<lfa.pmgmt.data.DTO.Schedule.Unit> i_scheduleUnits = unitDAO.List(id);

                                //            GetScheduleUnitDetails(i_scheduleUnits, id, defaultPort);
                                //        }

                                //    }

                                //    if (priorityValue.ToLower().Equals("high"))
                                //    {
                                //        GetScheduleUnitDetails(scheduleUnits, schedule.Id, defaultPort);

                                //        lfa.pmgmt.data.DAO.Schedule.Schedule dao = new data.DAO.Schedule.Schedule();

                                //        dao.ConnectionString = _connectionString;
                                //        int zoneid = dao.GetLinkedZone(schedule.Id);

                                //        List<int> scheduleIds = dao.ListPrioritySchedules(zoneid, "Medium");

                                //        foreach (int id in scheduleIds)
                                //        {
                                //            List<lfa.pmgmt.data.DTO.Schedule.Unit> i_scheduleUnits = unitDAO.List(id);

                                //            GetScheduleUnitDetails(i_scheduleUnits, id, defaultPort);
                                //        }

                                //        List<int> lowscheduleIds = dao.ListPrioritySchedules(zoneid, "Low");

                                //        foreach (int id in lowscheduleIds)
                                //        {
                                //            List<lfa.pmgmt.data.DTO.Schedule.Unit> i_scheduleUnits = unitDAO.List(id);

                                //            GetScheduleUnitDetails(i_scheduleUnits,id, defaultPort);
                                //        }
                                //    }
                                //}
                                #endregion
                            }
                        }
                    }

                    if (scheduleEndTime == "00:00" && scheduleStartTime == "00:00")
                    {
                          lfa.pmgmt.data.DAO.Schedule.Schedule DAO = new data.DAO.Schedule.Schedule();
                            DAO.ConnectionString = _connectionString;

                            string priorityValue = DAO.GetPriority(schedule.Id);

                            if (string.IsNullOrEmpty(priorityValue))
                            {
                                priorityValue = "None";
                            }

                            if (string.IsNullOrEmpty(priorityValue))
                            {
                                lfa.pmgmt.data.DAO.Schedule.Unit unitDAO = new data.DAO.Schedule.Unit();
                                unitDAO.ConnectionString = _connectionString;
                                List<lfa.pmgmt.data.DTO.Schedule.Unit> scheduleUnits = unitDAO.List(schedule.Id);

                                GetScheduleUnitDetailsForId(scheduleUnits, schedule.Id, ruleEnabledUnits, defaultPort);
                            }
                            else
                            {
                                lfa.pmgmt.data.DAO.Schedule.Unit unitDAO = new data.DAO.Schedule.Unit();
                                unitDAO.ConnectionString = _connectionString;
                                List<lfa.pmgmt.data.DTO.Schedule.Unit> scheduleUnits = unitDAO.List(schedule.Id);

                                _defaultUnits.Add(schedule.Id.ToString(),scheduleUnits);

                                //if (ExecutePriority(_connectionString, priorityValue))
                                //{
                                    //GetScheduleUnitDetails(scheduleUnits, schedule.Id, defaultPort);
                                //}
                           }
                    }
                }
            }


            if (_defaultUnits.Count > 0)
            {
                if (_executed.Count <= 0)
                {
                    foreach (string id in _defaultUnits.Keys)
                    {
                        List<lfa.pmgmt.data.DTO.Schedule.Unit> units = _defaultUnits[id];

                        GetScheduleUnitDetails(units, int.Parse(id), defaultPort);
                    }
                }
            }

            _defaultUnits.Clear();
            _executed.Clear();
        }
        #endregion
         
        #region Private Methods
        private void GetScheduleUnitDetails(List<lfa.pmgmt.data.DTO.Schedule.Unit> scheduleUnits, int scheduleId,int defaultPort)
        {
            foreach (lfa.pmgmt.data.DTO.Schedule.Unit scheduleUnit in scheduleUnits)
            {
                string address = scheduleUnit.Address;

                lfa.pmgmt.data.DAO.Schedule.Device deviceDAO = new data.DAO.Schedule.Device();
                deviceDAO.ConnectionString = _connectionString;

                List<lfa.pmgmt.data.DTO.Schedule.Device> unitDevices = deviceDAO.ListById(scheduleUnit.Id, scheduleId);

                LoadShedUnit(unitDevices,defaultPort, scheduleUnit);
            }
        }

        private void GetScheduleUnitDetailsForId(List<lfa.pmgmt.data.DTO.Schedule.Unit> scheduleUnits, int scheduleId,
                                                List<int> ruleEnabledUnits, int defaultPort)
        {
            foreach (lfa.pmgmt.data.DTO.Schedule.Unit scheduleUnit in scheduleUnits)
            {
                string address = scheduleUnit.Address;

                lfa.pmgmt.data.DAO.Schedule.Device deviceDAO = new data.DAO.Schedule.Device();
                deviceDAO.ConnectionString = _connectionString;

                if (!ruleEnabledUnits.Contains(scheduleUnit.Id))
                {
                    List<lfa.pmgmt.data.DTO.Schedule.Device> unitDevices = deviceDAO.List(scheduleUnit.Id, scheduleId);

                    LoadShedUnit(unitDevices, defaultPort,scheduleUnit);
                }
            }
        }

        private void LoadShedUnit(List<lfa.pmgmt.data.DTO.Schedule.Device> unitDevices, int defaultPort, lfa.pmgmt.data.DTO.Schedule.Unit unit)
        {
            int status = 0;

            foreach (lfa.pmgmt.data.DTO.Schedule.Device unitDevice in unitDevices)
            {
                lfa.pmgmt.data.DAO.Configuration.Device deviceDAO = new data.DAO.Configuration.Device();
                deviceDAO.ConnectionString = _connectionString;
 

                string deviceName = unitDevice.Name;
                int deviceConfigId = deviceDAO.GetDeviceConfigId(unit.Id_ScheduleUnit, unitDevice.Id);

                string deviceAddress = deviceDAO.GetDeviceAddress(deviceConfigId);
                string deviceSwitch = deviceDAO.GetDeviceSwitch(deviceConfigId);

                bool switchOn = unitDevice.DeviceOn;

                if (switchOn)
                {
                    status = 1;
                }
                else
                {
                    status = 2;
                }

                SendSwitchState(deviceAddress, defaultPort, deviceSwitch, status);
            }
        }

        private static bool ExecutePriority(string connectionString, string priorityValue)
        {
            bool executeRule = false;

            List<lfa.pmgmt.data.DTO.BusinessRule.Load> loadList = new List<data.DTO.BusinessRule.Load>();

            lfa.pmgmt.data.DAO.BusinessRule.Load loadDAO = new data.DAO.BusinessRule.Load();
            loadDAO.ConnectionString = connectionString;

            loadList = loadDAO.List();

            int currentUnitLoad = loadList[0].CurrentLoad;

            lfa.pmgmt.data.DAO.BusinessRule.RuleSet ruleSetDAO = new data.DAO.BusinessRule.RuleSet();
            ruleSetDAO.ConnectionString = connectionString;

            List<lfa.pmgmt.data.DTO.BusinessRule.Priority> priorityRules = ruleSetDAO.ListPriority();

            foreach (lfa.pmgmt.data.DTO.BusinessRule.Priority priorityRule in priorityRules)
            {
                if(priorityRule.PriorityType.ToLower().Equals(priorityValue.ToLower()))
                {
                    lfa.pmgmt.data.DAO.BusinessRule.Rule ruleDAO = new data.DAO.BusinessRule.Rule();
                    ruleDAO.ConnectionString = connectionString;

                    lfa.pmgmt.data.DTO.BusinessRule.Rule ruleDTO = ruleDAO.GetFromRuleSet(priorityRule.Id_RuleSet);

                    string[] ruleArray = ruleDTO.Condition.Split(".".ToCharArray());
                    int unitId = int.Parse(ruleArray[0].ToString());
                    int deviceId = int.Parse(ruleArray[1].ToString());
                    string mathMetric = ruleArray[2].ToString();
                    int loadValue = int.Parse(ruleArray[3].ToString());

                    switch (mathMetric)
                    {
                        case "<=":
                            executeRule = CurrentLoadSmallerThenEqualsValue(executeRule, loadValue, currentUnitLoad);
                            break;
                        case ">=":
                            executeRule = CurrentLoadBiggerThenEqualsValue(executeRule, loadValue, currentUnitLoad);
                            break;
                        case "<":
                            executeRule = CurrentLoadSmallerThenValue(executeRule, loadValue, currentUnitLoad);
                            break;
                        case ">":
                            executeRule = CurrentLoadBiggerThenValue(executeRule, loadValue, currentUnitLoad);
                            break;
                        case "==":
                            executeRule = CurrentLoadEqualsValue(executeRule, loadValue, currentUnitLoad);
                            break;
                    }
                }
            }

            #region OBSOLETE
            //int currentUnitLoad = loadList[0].CurrentLoad;
            //int maxLoad = loadList[0].MaximumLoad;

            //if (currentUnitLoad >= maxLoad)
            //{
            //    executePriority = true;
            //}
            #endregion

            return executeRule;
        }

        private static bool CurrentLoadEqualsValue(bool executeRule, int loadValue, int currentUnitLoad)
        {
            if (currentUnitLoad == loadValue)
            {
                executeRule = true;
            }

            return executeRule;
        }

        private static bool CurrentLoadBiggerThenValue(bool executeRule, int loadValue, int currentUnitLoad)
        {
            if (currentUnitLoad > loadValue)
            {
                executeRule = true;
            }

            return executeRule;
        }

        private static bool CurrentLoadSmallerThenValue(bool executeRule, int loadValue, int currentUnitLoad)
        {
            if (currentUnitLoad < loadValue)
            {
                executeRule = true;
            }

            return executeRule;
        }

        private static bool CurrentLoadBiggerThenEqualsValue(bool executeRule, int loadValue, int currentUnitLoad)
        {
            if (currentUnitLoad >= loadValue)
            {
                executeRule = true;
            }

            return executeRule;
        }

        private static bool CurrentLoadSmallerThenEqualsValue(bool executeRule, int loadValue, int currentUnitLoad)
        {
            if (currentUnitLoad <= loadValue)
            {
                executeRule = true;
            }

            return executeRule;
        }

        private void SendSwitchState(string ipAddress, int port, string swState, int status)
        {
            BravaConnection myConnection = new BravaConnection();

            myConnection.BravaIP = System.Net.IPAddress.Parse(ipAddress);

            myConnection.BravaPort = port;

            BravaCodes.SwitchState[] mySwitchStates = new BravaCodes.SwitchState[8];

            SetSwitchState(swState, status, mySwitchStates);

            SwitchbankUpdate mySwitchbankUpdate = new SwitchbankUpdate(
                mySwitchStates[0],
                mySwitchStates[1],
                mySwitchStates[2],
                mySwitchStates[3],
                mySwitchStates[4],
                mySwitchStates[5],
                mySwitchStates[6],
                mySwitchStates[7]);

            BravaSocket mySocket = new BravaSocket(mySwitchbankUpdate, myConnection);

            try
            {
                mySocket.OpenConnection();

                mySocket.DoTransaction();

                myConnection.rqStream.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mySocket.SocketClient.Close();
            }
        }

        private static void SetSwitchState(string swState, int status, BravaCodes.SwitchState[] mySwitchStates)
        {
            if (swState == "Switch 1")
            {
                if (status == 1)
                {
                    mySwitchStates[0] = BravaCodes.SwitchState.SwitchOn;
                }
                else
                {
                    mySwitchStates[0] = BravaCodes.SwitchState.SwitchOff;
                }
            }

            if (swState == "Switch 2")
            {
                if (status == 1)
                {
                    mySwitchStates[1] = BravaCodes.SwitchState.SwitchOn;
                }
                else
                {
                    mySwitchStates[1] = BravaCodes.SwitchState.SwitchOff;
                }
            }

            if (swState == "Switch 3")
            {// cbSingleSw3.Checked)
                if (status == 1)
                {
                    mySwitchStates[2] = BravaCodes.SwitchState.SwitchOn;
                }
                else
                {
                    mySwitchStates[2] = BravaCodes.SwitchState.SwitchOff;
                }
            }

            if (swState == "Switch 4") // cbSingleSw4.Checked)
            {
                if (status == 1)
                {
                    mySwitchStates[3] = BravaCodes.SwitchState.SwitchOn;
                }
                else
                {
                    mySwitchStates[3] = BravaCodes.SwitchState.SwitchOff;
                }
            }

            if (swState == "Switch 5") // cbSingleSw5.Checked)
            {
                if (status == 1)
                {
                    mySwitchStates[4] = BravaCodes.SwitchState.SwitchOn;
                }
                else
                {
                    mySwitchStates[4] = BravaCodes.SwitchState.SwitchOff;
                }
            }

            if (swState == "Switch 6") // cbSingleSw6.Checked)
            {
                if (status == 1)
                {
                    mySwitchStates[5] = BravaCodes.SwitchState.SwitchOn;
                }
                else
                {
                    mySwitchStates[5] = BravaCodes.SwitchState.SwitchOff;
                }
            }

            if (swState == "Switch 7") // cbSingleSw7.Checked)
            {
                if (status == 1)
                {
                    mySwitchStates[6] = BravaCodes.SwitchState.SwitchOn;
                }
                else
                {
                    mySwitchStates[6] = BravaCodes.SwitchState.SwitchOff;
                }
            }

            if (swState == "Switch 8") // cbSingleSw8.Checked)
            {
                if (status == 1)
                {
                    mySwitchStates[7] = BravaCodes.SwitchState.SwitchOn;
                }
                else
                {
                    mySwitchStates[7] = BravaCodes.SwitchState.SwitchOff;
                }
            }
        }
        #endregion
    }
}
