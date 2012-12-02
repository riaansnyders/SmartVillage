namespace lfa.pmgmt.businessrules
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
    using lfa.pmgmt.data.DAO.BusinessRule;
    using lfa.pmgmt.data.DTO.Configuration;
    using lfa.pmgmt.data.DTO.BusinessRule;

    using BravaSystem.Communication;
    #endregion

    public class Rules
    {
        private string _connectionString = string.Empty;
        private int _defaultPort = 0;

        #region Constructor
        public Rules(string connectionString, int defaultPort)
        {
            _connectionString = connectionString;
            _defaultPort = defaultPort;
        }
        #endregion

        #region Public Methods
        public List<lfa.pmgmt.data.DTO.BusinessRule.RuleSet> ListActiveRuleSets()
        {
            List<lfa.pmgmt.data.DTO.BusinessRule.RuleSet> ruleSet = new List<pmgmt.data.DTO.BusinessRule.RuleSet>();

            lfa.pmgmt.data.DAO.BusinessRule.RuleSet ruleSetDAO = new pmgmt.data.DAO.BusinessRule.RuleSet();
            ruleSetDAO.ConnectionString = _connectionString;

            ruleSet = ruleSetDAO.List();

            return ruleSet;
        }

        public List<lfa.pmgmt.data.DTO.BusinessRule.Rule> ListRulesForRuleSet(int Id_RuleSet)
        {
            List<lfa.pmgmt.data.DTO.BusinessRule.Rule> rules = new List<pmgmt.data.DTO.BusinessRule.Rule>();

            lfa.pmgmt.data.DAO.BusinessRule.Rule ruleSetDAO = new pmgmt.data.DAO.BusinessRule.Rule();
            ruleSetDAO.ConnectionString = _connectionString;
            rules = ruleSetDAO.List(Id_RuleSet);

            return rules;
        }

        public bool ExecuteRule(string condition)
        {
            bool executeRule = false;

            string[] ruleArray = condition.Split(".".ToCharArray());
            int unitId = int.Parse(ruleArray[0].ToString());
            int deviceId = int.Parse(ruleArray[1].ToString());
            string mathMetric = ruleArray[2].ToString();
            int loadValue = int.Parse(ruleArray[3].ToString());

            int currentUnitLoad = GetLoadReportFromAPI(string.Empty, _connectionString);

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
                case "==" :
                    executeRule = CurrentLoadEqualsValue(executeRule, loadValue, currentUnitLoad);
                    break;
            }

            return executeRule;
        }

        public void Execute(string result)
        {
            string[] ruleArray = result.Split(".".ToCharArray());
            int unitId = int.Parse(ruleArray[0].ToString());
            int deviceId = int.Parse(ruleArray[1].ToString());
            int status = int.Parse(ruleArray[2].ToString());

            EntireLoadShed(unitId, status);
        }

        public bool EntireLoadShed()
        {
            bool hasShedAll = false;

            List<lfa.pmgmt.data.DTO.BusinessRule.Load> loadList = new List<data.DTO.BusinessRule.Load>();

            lfa.pmgmt.data.DAO.BusinessRule.Load loadDAO = new data.DAO.BusinessRule.Load();
            loadDAO.ConnectionString = _connectionString;

            loadList = loadDAO.List();

            if (loadList.Count > 0)
            {
                int current = loadList[0].CurrentLoad;
                int maxLoad = loadList[0].MaximumLoad;

                if (current >= maxLoad)
                {
                    List<lfa.pmgmt.data.DTO.Configuration.Zone> zones = new List<data.DTO.Configuration.Zone>();

                    lfa.pmgmt.data.DAO.Configuration.Zone zoneDAO = new data.DAO.Configuration.Zone();
                    zoneDAO.ConnectionString = _connectionString;
                    zones = zoneDAO.List();

                    foreach (lfa.pmgmt.data.DTO.Configuration.Zone zone in zones)
                    {
                        List<lfa.pmgmt.data.DTO.Configuration.Unit> units = new List<data.DTO.Configuration.Unit>();
                        lfa.pmgmt.data.DAO.Configuration.Unit unitDAO = new data.DAO.Configuration.Unit();
                        unitDAO.ConnectionString = _connectionString;

                        units = unitDAO.List(zone.Id);

                        foreach (lfa.pmgmt.data.DTO.Configuration.Unit unit in units)
                        {
                            List<lfa.pmgmt.data.DTO.Configuration.Device> devices = new List<data.DTO.Configuration.Device>();

                            lfa.pmgmt.data.DAO.Configuration.Device deviceDAO = new data.DAO.Configuration.Device();
                            deviceDAO.ConnectionString = _connectionString;

                            devices = deviceDAO.List(unit.Id);

                            foreach (lfa.pmgmt.data.DTO.Configuration.Device device in devices)
                            {
                                SwitchDeviceOnOff(2, device.Id, device.Id_Unit);

                                UpdateDeviceStatus(device.Id, 2);
                            }
                        }
                    }

                    hasShedAll = true;
                }
            }

            return hasShedAll;
        }

        public bool EntireLoadShed(int zoneId, int status)
        {
            bool hasShedAll = false;

            List<lfa.pmgmt.data.DTO.BusinessRule.Load> loadList = new List<data.DTO.BusinessRule.Load>();

            lfa.pmgmt.data.DAO.BusinessRule.Load loadDAO = new data.DAO.BusinessRule.Load();
            loadDAO.ConnectionString = _connectionString;

            loadList = loadDAO.List();

            if (loadList.Count > 0)
            {
                 List<lfa.pmgmt.data.DTO.Configuration.Zone> zones = new List<data.DTO.Configuration.Zone>();

                 lfa.pmgmt.data.DAO.Configuration.Zone zoneDAO = new data.DAO.Configuration.Zone();
                 zoneDAO.ConnectionString = _connectionString;
                 lfa.pmgmt.data.DTO.Configuration.Zone zone = zoneDAO.Get(zoneId);

                 List<lfa.pmgmt.data.DTO.Configuration.Unit> units = new List<data.DTO.Configuration.Unit>();
                 lfa.pmgmt.data.DAO.Configuration.Unit unitDAO = new data.DAO.Configuration.Unit();
                 unitDAO.ConnectionString = _connectionString;

                 units = unitDAO.List(zone.Id);

                 foreach (lfa.pmgmt.data.DTO.Configuration.Unit unit in units)
                 {
                     List<lfa.pmgmt.data.DTO.Configuration.Device> devices = new List<data.DTO.Configuration.Device>();

                     lfa.pmgmt.data.DAO.Configuration.Device deviceDAO = new data.DAO.Configuration.Device();
                     deviceDAO.ConnectionString = _connectionString;

                     devices = deviceDAO.List(unit.Id);

                     foreach (lfa.pmgmt.data.DTO.Configuration.Device device in devices)
                     {
                       SwitchDeviceOnOff(status, device.Id, device.Id_Unit);

                       UpdateDeviceStatus(device.Id, status);
                     }
                  }

                 hasShedAll = true;
            }

            return hasShedAll;
        }
        #endregion

        #region Private Methods
        private void SwitchDeviceOnOff(int status, int deviceId, int unitId)
        {
            lfa.pmgmt.data.DAO.Configuration.Device deviceDAO = new data.DAO.Configuration.Device();
            deviceDAO.ConnectionString = _connectionString;

            string ipAddress = deviceDAO.GetDeviceAddress(deviceId);
            string deviceSwitch = deviceDAO.GetDeviceSwitch(deviceId);

            SendSwitchState(ipAddress, _defaultPort, deviceSwitch, status);
        }

        private void UpdateDeviceStatus(int deviceId, int status)
        {
            lfa.pmgmt.data.DAO.Configuration.DeviceStatus deviceStatusDAO = new pmgmt.data.DAO.Configuration.DeviceStatus();
            deviceStatusDAO.ConnectionString = _connectionString;
            deviceStatusDAO.Update(deviceId, status);
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

        private static int GetLoadReportFromAPI(string unitAddress, string connectionString)
        {
            List<lfa.pmgmt.data.DTO.BusinessRule.Load> loadList = new List<data.DTO.BusinessRule.Load>();

            lfa.pmgmt.data.DAO.BusinessRule.Load loadDAO = new data.DAO.BusinessRule.Load();
            loadDAO.ConnectionString = connectionString;
            
            loadList = loadDAO.List();

            int currentUnitLoad = loadList[0].CurrentLoad;

            return currentUnitLoad;
        }

        private string GetUnitIpAddress(int unitId)
        {
            lfa.pmgmt.data.DAO.Configuration.Unit unitDAO = new pmgmt.data.DAO.Configuration.Unit();
            unitDAO.ConnectionString = _connectionString;
            lfa.pmgmt.data.DTO.Configuration.Unit unitDTO = unitDAO.Get(unitId);

            return  unitDTO.Address;
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
