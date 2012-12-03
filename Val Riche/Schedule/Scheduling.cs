namespace lfa.pmgmt.schedule
{
    #region Using Directives
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Xml;

    using lfa.pmgmt.data.DAO.Configuration;
    using lfa.pmgmt.data.DAO.Logging;
    using lfa.pmgmt.data.DAO.Schedule;
    using lfa.pmgmt.data.DTO.Configuration;
    using lfa.pmgmt.data.DTO.Logging;
    using lfa.pmgmt.data.DTO.Schedule;

    using BravaSystem.Communication;
    #endregion

    public class Scheduling
    {
        private string _connectionString = string.Empty;
        private List<string> _executed = null;
        private Dictionary<string, List<lfa.pmgmt.data.DTO.Schedule.Unit>> _defaultUnits = null;
        private static Dictionary<string, string> _switchStates = null;

        #region Constructor
        public Scheduling(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region Schedule Start
        public void Execute(int defaultPort)
        {
            _switchStates = new Dictionary<string, string>();

            _executed = new List<string>();
            int ruleCount = 0;

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

                    if (scheduleStart > scheduleEnd)
                    {
                        scheduleEnd = scheduleEnd.AddDays(1);
                    }

                    if (currentTime <= scheduleEnd)
                    {
                        if (currentTime >= scheduleStart)
                        {
                            lfa.pmgmt.data.DAO.Schedule.Schedule DAO = new data.DAO.Schedule.Schedule();
                            DAO.ConnectionString = _connectionString;

                            string priorityValue = DAO.GetPriority(schedule.Id);

                            if (string.IsNullOrEmpty(priorityValue))
                            {
                                int status = 0;
                                lfa.pmgmt.data.DAO.Schedule.Unit unitDAO = new data.DAO.Schedule.Unit();
                                unitDAO.ConnectionString = _connectionString;
                                List<lfa.pmgmt.data.DTO.Schedule.Unit> scheduleUnits = unitDAO.List(schedule.Id);

                                GetScheduleUnitDetails(scheduleUnits, schedule.Id, defaultPort,status);
                            }
                            else
                            {
                                    int status = 0;
                                    lfa.pmgmt.data.DAO.Schedule.Unit unitDAO = new data.DAO.Schedule.Unit();
                                    unitDAO.ConnectionString = _connectionString;
                                    List<lfa.pmgmt.data.DTO.Schedule.Unit> scheduleUnits = unitDAO.List(schedule.Id);

                                    if (ExecutePriority(_connectionString, priorityValue, out status, out ruleCount))
                                    {
                                        GetScheduleUnitDetails(scheduleUnits, schedule.Id, defaultPort, status);

                                        _executed.Add("true");
                                    }
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

            int status = 0;
            int ruleCount = 0;

            foreach (lfa.pmgmt.data.DTO.Schedule.Schedule schedule in scheduleList)
            {
                if (schedule.IsActive)
                {
                    string scheduleStartTime = schedule.StartTime;
                    string scheduleEndTime = schedule.EndTime;

                    DateTime currentTime = DateTime.Now;
                    DateTime scheduleStart = Convert.ToDateTime(scheduleStartTime);
                    DateTime scheduleEnd = Convert.ToDateTime(scheduleEndTime);

                    if (scheduleStart > scheduleEnd)
                    {
                        scheduleEnd = scheduleEnd.AddDays(1);
                    }

                    if (currentTime.TimeOfDay <= scheduleEnd.TimeOfDay)
                    {
                        if (currentTime.TimeOfDay >= scheduleStart.TimeOfDay)
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

                                GetScheduleUnitDetailsForId(scheduleUnits, schedule.Id, ruleEnabledUnits, defaultPort, status);
                            }
                            else
                            {
                                lfa.pmgmt.data.DAO.Schedule.Unit unitDAO = new data.DAO.Schedule.Unit();
                                unitDAO.ConnectionString = _connectionString;
                                List<lfa.pmgmt.data.DTO.Schedule.Unit> scheduleUnits = unitDAO.List(schedule.Id);


                                if (ExecutePriority(_connectionString, priorityValue, out status,out ruleCount))
                                {
                                    GetScheduleUnitDetails(scheduleUnits, schedule.Id, defaultPort, status);

                                    _executed.Add("true");
                                }
                                else
                                {
                                    if (ruleCount <= 0)
                                    {
                                        status = 0;

                                        GetScheduleUnitDetails(scheduleUnits, schedule.Id, defaultPort, status);
                                    }

                                    _executed.Add("true");
                                }
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

                            GetScheduleUnitDetailsForId(scheduleUnits, schedule.Id, ruleEnabledUnits, defaultPort,0);
                        }
                        else
                        {
                            lfa.pmgmt.data.DAO.Schedule.Unit unitDAO = new data.DAO.Schedule.Unit();
                            unitDAO.ConnectionString = _connectionString;
                            List<lfa.pmgmt.data.DTO.Schedule.Unit> scheduleUnits = unitDAO.List(schedule.Id);

                            _defaultUnits.Add(schedule.Id.ToString(), scheduleUnits);
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

                        GetScheduleUnitDetails(units, int.Parse(id), defaultPort,0);
                    }
                }
            }

            _defaultUnits.Clear();
            _executed.Clear();
        }
        #endregion
         
        #region Private Methods
        private void GetScheduleUnitDetails(List<lfa.pmgmt.data.DTO.Schedule.Unit> scheduleUnits, int scheduleId,
                                            int defaultPort, int status)
        {
            foreach (lfa.pmgmt.data.DTO.Schedule.Unit scheduleUnit in scheduleUnits)
            {
                string address = scheduleUnit.Address;

                lfa.pmgmt.data.DAO.Schedule.Device deviceDAO = new data.DAO.Schedule.Device();
                deviceDAO.ConnectionString = _connectionString;

                List<lfa.pmgmt.data.DTO.Schedule.Device> unitDevices = deviceDAO.ListById(scheduleUnit.Id, scheduleId);

                ArrayList parameters = new ArrayList();
                parameters.Add(unitDevices);
                parameters.Add(defaultPort);
                parameters.Add(scheduleUnit);
                parameters.Add(status);

                //AsyncLoadShedUnit(parameters);

                Thread worker = new Thread(new ParameterizedThreadStart(AsyncLoadShedUnit));
                worker.Priority = ThreadPriority.Highest;
                worker.Start(parameters);
            }
        }

        private void GetScheduleUnitDetailsForId(List<lfa.pmgmt.data.DTO.Schedule.Unit> scheduleUnits, int scheduleId,
                                                List<int> ruleEnabledUnits, int defaultPort, int status)
        {
            foreach (lfa.pmgmt.data.DTO.Schedule.Unit scheduleUnit in scheduleUnits)
            {
                string address = scheduleUnit.Address;

                lfa.pmgmt.data.DAO.Schedule.Device deviceDAO = new data.DAO.Schedule.Device();
                deviceDAO.ConnectionString = _connectionString;

                if (!ruleEnabledUnits.Contains(scheduleUnit.Id))
                {
                    List<lfa.pmgmt.data.DTO.Schedule.Device> unitDevices = deviceDAO.List(scheduleUnit.Id, scheduleId);

                    ArrayList parameters = new ArrayList();
                    parameters.Add(unitDevices);
                    parameters.Add(defaultPort);
                    parameters.Add(scheduleUnit);
                    parameters.Add(status);

                    //AsyncLoadShedUnit(parameters);

                    Thread worker = new Thread(new ParameterizedThreadStart(AsyncLoadShedUnit));
                    worker.Priority = ThreadPriority.Highest;
                    worker.Start(parameters);
                }
            }
        }

        private void AsyncLoadShedUnit(object parameters)
        {
            ArrayList parms = parameters as ArrayList;

            List<lfa.pmgmt.data.DTO.Schedule.Device> unitDevices = parms[0] as List<lfa.pmgmt.data.DTO.Schedule.Device>;
            
            int defaultPort = (int)parms[1];
            
            lfa.pmgmt.data.DTO.Schedule.Unit unit = parms[2] as lfa.pmgmt.data.DTO.Schedule.Unit;

            int status = (int)parms[3];

            if (unit.IsActive)
            {
                string deviceAddress = string.Empty;

                SwitchbankUpdate mySwitchbankUpdate = null;

                BravaCodes.SwitchState[] mySwitchStates = new BravaCodes.SwitchState[8];

                for (int x = 0; x <= 7; x++) mySwitchStates[x] = BravaCodes.SwitchState.SwitchOff;

                foreach (lfa.pmgmt.data.DTO.Schedule.Device unitDevice in unitDevices)
                {
                    lfa.pmgmt.data.DAO.Configuration.Device deviceDAO = new data.DAO.Configuration.Device();
                    deviceDAO.ConnectionString = _connectionString;

                    string deviceName = unitDevice.Name;
                    int deviceConfigId = deviceDAO.GetDeviceConfigId(unit.Id_ScheduleUnit, unitDevice.Id);

                    deviceAddress = deviceDAO.GetDeviceAddress(deviceConfigId);
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

                    SetSwitchState(deviceSwitch, status, mySwitchStates, unitDevice.Id.ToString());
                }

                mySwitchbankUpdate = new SwitchbankUpdate(mySwitchStates[0], mySwitchStates[1], mySwitchStates[2],
                                                          mySwitchStates[3], mySwitchStates[4], mySwitchStates[5],
                                                          mySwitchStates[6], mySwitchStates[7]);

                try
                {
                    SendSwitchState(deviceAddress, defaultPort, mySwitchbankUpdate);

                    lfa.pmgmt.data.DAO.Logging.CurrentStatus currentStatusDAO = new data.DAO.Logging.CurrentStatus();
                    currentStatusDAO.ConnectionString = _connectionString;
                    currentStatusDAO.Insert(unit.Name, "OK");
                }
                catch(System.Net.Sockets.SocketException)
                {
                    System.Threading.Thread.Sleep(500);

                    try
                    {
                        mySwitchbankUpdate = new SwitchbankUpdate(mySwitchStates[0], mySwitchStates[1], mySwitchStates[2],
                                                         mySwitchStates[3], mySwitchStates[4], mySwitchStates[5],
                                                         mySwitchStates[6], mySwitchStates[7]);


                        SendSwitchState(deviceAddress, defaultPort, mySwitchbankUpdate);

                        lfa.pmgmt.data.DAO.Logging.CurrentStatus currentStatusDAO = new data.DAO.Logging.CurrentStatus();
                        currentStatusDAO.ConnectionString = _connectionString;
                        currentStatusDAO.Insert(unit.Name, "OK");
                    }
                    catch (System.Net.Sockets.SocketException soex)
                    {
                        lfa.pmgmt.data.DAO.Logging.Log logDAO = new data.DAO.Logging.Log();
                        logDAO.ConnectionString = _connectionString;
                        logDAO.Insert(1, "Unit: " + unit.Name, "TCP/IP Communications Error due to: " + soex.ToString(), DateTime.Now);

                        lfa.pmgmt.data.DAO.Logging.CurrentStatus currentStatusDAO = new data.DAO.Logging.CurrentStatus();
                        currentStatusDAO.ConnectionString = _connectionString;
                        currentStatusDAO.Insert(unit.Name, "ERR");
                    }
                }
            }
        }

        private void LoadShedUnit(List<lfa.pmgmt.data.DTO.Schedule.Device> unitDevices, int defaultPort, 
                                 lfa.pmgmt.data.DTO.Schedule.Unit unit, int status)
        {
            if (unit.IsActive)
            {
                string deviceAddress = string.Empty;

                SwitchbankUpdate mySwitchbankUpdate = null;

                BravaCodes.SwitchState[] mySwitchStates = new BravaCodes.SwitchState[8];

                for (int x = 0; x <= 7; x++) mySwitchStates[x] = BravaCodes.SwitchState.SwitchOff;
                
                foreach (lfa.pmgmt.data.DTO.Schedule.Device unitDevice in unitDevices)
                {
                    lfa.pmgmt.data.DAO.Configuration.Device deviceDAO = new data.DAO.Configuration.Device();
                    deviceDAO.ConnectionString = _connectionString;

                    string deviceName = unitDevice.Name;
                    int deviceConfigId = deviceDAO.GetDeviceConfigId(unit.Id_ScheduleUnit, unitDevice.Id);

                    deviceAddress = deviceDAO.GetDeviceAddress(deviceConfigId);
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

                    SetSwitchState(deviceSwitch, status, mySwitchStates,unitDevice.Id.ToString());
                }

                try
                {
                    mySwitchbankUpdate = new SwitchbankUpdate(
                       mySwitchStates[0],
                       mySwitchStates[1],
                       mySwitchStates[2],
                       mySwitchStates[3],
                       mySwitchStates[4],
                       mySwitchStates[5],
                       mySwitchStates[6],
                       mySwitchStates[7]);

                    SendSwitchState(deviceAddress, defaultPort, mySwitchbankUpdate);

                    lfa.pmgmt.data.DAO.Logging.CurrentStatus currentStatusDAO = new data.DAO.Logging.CurrentStatus();
                    currentStatusDAO.ConnectionString = _connectionString;
                    currentStatusDAO.Insert(unit.Name, "OK");
                }
                catch(System.Net.Sockets.SocketException)
                {
                    System.Threading.Thread.Sleep(200);

                    try
                    {
                       mySwitchbankUpdate = new SwitchbankUpdate(
                       mySwitchStates[0],
                       mySwitchStates[1],
                       mySwitchStates[2],
                       mySwitchStates[3],
                       mySwitchStates[4],
                       mySwitchStates[5],
                       mySwitchStates[6],
                       mySwitchStates[7]);

                        SendSwitchState(deviceAddress, defaultPort, mySwitchbankUpdate);

                        lfa.pmgmt.data.DAO.Logging.CurrentStatus currentStatusDAO = new data.DAO.Logging.CurrentStatus();
                        currentStatusDAO.ConnectionString = _connectionString;
                        currentStatusDAO.Insert(unit.Name, "OK");
                    }
                    catch (System.Net.Sockets.SocketException ex)
                    {
                        lfa.pmgmt.data.DAO.Logging.Log logDAO = new data.DAO.Logging.Log();
                        logDAO.ConnectionString = _connectionString;
                        logDAO.Insert(1, "Unit: " + unit.Name, "TCP/IP Communications Error due to: " + ex.ToString(), DateTime.Now);

                        lfa.pmgmt.data.DAO.Logging.CurrentStatus currentStatusDAO = new data.DAO.Logging.CurrentStatus();
                        currentStatusDAO.ConnectionString = _connectionString;
                        currentStatusDAO.Insert(unit.Name, "ERR");
                    }
                }
            }
        }

        private static bool ExecutePriority(string connectionString, string priorityValue, out int status, out int ruleCount)
        {
            int tempStatus = 0;
            bool executeRule = false;

            List<lfa.pmgmt.data.DTO.BusinessRule.Load> loadList = new List<data.DTO.BusinessRule.Load>();

            lfa.pmgmt.data.DAO.BusinessRule.Load loadDAO = new data.DAO.BusinessRule.Load();
            loadDAO.ConnectionString = connectionString;

            loadList = loadDAO.List();

            int currentUnitLoad = 0;

            if (loadList[0].ManualLoad > 0)
            {
                currentUnitLoad = loadList[0].ManualLoad;
            }
            else
            {
                currentUnitLoad = loadList[0].CurrentLoad;
            }

            lfa.pmgmt.data.DAO.BusinessRule.RuleSet ruleSetDAO = new data.DAO.BusinessRule.RuleSet();
            ruleSetDAO.ConnectionString = connectionString;

            List<lfa.pmgmt.data.DTO.BusinessRule.Priority> priorityRules = ruleSetDAO.ListPriority(priorityValue);

            int tmpRuleCount = 0;

            foreach (lfa.pmgmt.data.DTO.BusinessRule.Priority priorityRule in priorityRules)
            {
                if (priorityRule.PriorityType.ToLower().Equals(priorityValue.ToLower()))
                {
                    lfa.pmgmt.data.DAO.BusinessRule.Rule ruleDAO = new data.DAO.BusinessRule.Rule();
                    ruleDAO.ConnectionString = connectionString;

                    List<lfa.pmgmt.data.DTO.BusinessRule.Rule> ruleDTOList = ruleDAO.GetFromRuleSet(priorityRule.Id_RuleSet);

                    tmpRuleCount = ruleDTOList.Count;

                    foreach (lfa.pmgmt.data.DTO.BusinessRule.Rule ruleDTO in ruleDTOList)
                    {
                        if (executeRule)
                        {
                            break;
                        }

                        string[] ruleArray = ruleDTO.Condition.Split(".".ToCharArray());
                        int unitId = int.Parse(ruleArray[0].ToString());
                        int deviceId = int.Parse(ruleArray[1].ToString());
                        string mathMetric = ruleArray[2].ToString();
                        int loadValue = int.Parse(ruleArray[3].ToString());

                        string[] resultArray = ruleDTO.Result.Split(".".ToCharArray());
                        tempStatus = int.Parse(resultArray[2].ToString());

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

                    if (executeRule)
                    {
                        break;
                    }
                }

                if (executeRule)
                {
                    break;
                }
            }

            status = tempStatus;
            ruleCount = tmpRuleCount;

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

            SetSwitchState(swState, status, mySwitchStates,"");

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
                mySocket.DoTransaction();
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void SendSwitchState(string ipAddress, int port, SwitchbankUpdate mySwitchbankUpdate)
        {
            BravaConnection myConnection = new BravaConnection();

            myConnection.BravaIP = System.Net.IPAddress.Parse(ipAddress);

            myConnection.BravaPort = port;

            BravaSocket mySocket = new BravaSocket(mySwitchbankUpdate, myConnection);

            try
            {
                mySocket.DoTransaction();

                #region Todo: We possibly dont care. Validate and remove
                //if (mySwitchbankUpdate.State == BravaTransaction.TransactionState.Completed)
                //{
                //    mySwitchbankUpdate.State = BravaTransaction.TransactionState.Closed;
                //}

                //if (mySwitchbankUpdate.State == BravaTransaction.TransactionState.Failed)
                //{
                //    throw new System.Net.Sockets.SocketException(10004);
                //}
                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void SendBatchSwitchState(string ipAddress, int port, string swState, int status)
        {
            BravaConnection myConnection = new BravaConnection();

            myConnection.BravaIP = System.Net.IPAddress.Parse(ipAddress);

            myConnection.BravaPort = port;

            BravaCodes.SwitchState[] mySwitchStates = new BravaCodes.SwitchState[8];

            SetSwitchStateBatch(swState, status, mySwitchStates);

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
                mySocket.DoTransaction();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void SetSwitchState(string swState, int status, BravaCodes.SwitchState[] mySwitchStates, string identifier)
        {
            if (_switchStates == null)
            {
                _switchStates = new Dictionary<string, string>();
            }

            if (_switchStates.ContainsKey(identifier))
            {
                int checkStatus = int.Parse(_switchStates[identifier].ToString());

                if (status != checkStatus)
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

                    _switchStates.Remove(identifier);

                    System.Threading.Thread.Sleep(200);

                    _switchStates.Add(identifier, status.ToString());
                }
            }
            else
            {
                _switchStates.Add(identifier, status.ToString());

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
        }

        private static void SetSwitchStateBatch(string swState, int status, BravaCodes.SwitchState[] mySwitchStates)
        {
           mySwitchStates[0] = BravaCodes.SwitchState.SwitchOff;
           mySwitchStates[1] = BravaCodes.SwitchState.SwitchOff;
           mySwitchStates[2] = BravaCodes.SwitchState.SwitchOff;
           mySwitchStates[3] = BravaCodes.SwitchState.SwitchOff;
           mySwitchStates[4] = BravaCodes.SwitchState.SwitchOff;
           mySwitchStates[5] = BravaCodes.SwitchState.SwitchOff;
           mySwitchStates[6] = BravaCodes.SwitchState.SwitchOff;
           mySwitchStates[7] = BravaCodes.SwitchState.SwitchOff;
        }
        #endregion
    }
}
