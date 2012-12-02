namespace lfa.pmgmt.control.service
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;

    using lfa.pmgmt.data.DAO.BusinessRule;
    using lfa.pmgmt.data.DAO.Configuration;
    using lfa.pmgmt.data.DAO.Schedule;
    using lfa.pmgmt.data.DTO.BusinessRule;
    using lfa.pmgmt.data.DTO.Configuration;
    using lfa.pmgmt.data.DTO.Schedule;

    using lfa.pmgmt.businessrules;
    using lfa.pmgmt.schedule;

    using BravaSystem.Communication;
    #endregion

    public partial class Service : ServiceBase
    {
        private static List<int> _ruleEnabledUnits = null;
        private static string _connectionString = string.Empty;
        private static bool _doLogging = false;
        private static int _defaultPort = 0;
        private static int _interval = 2000;

        #region Service Methods
        public Service()
        {
            InitializeComponent();

            _doLogging = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableLogging"].ToString());
            _defaultPort = int.Parse(ConfigurationManager.AppSettings["DefaultPort"].ToString());
            _interval = int.Parse(ConfigurationManager.AppSettings["Interval"].ToString());

            tmrManager = new System.Timers.Timer();
            tmrManager.Enabled = true;
            tmrManager.Interval = 2000;
            tmrManager.Elapsed += new System.Timers.ElapsedEventHandler(tmrManager_Elapsed);
        }

        protected override void OnStart(string[] args)
        {
            tmrManager.Start();
        }

        protected override void OnStop()
        {
            tmrManager.Stop();
        }
        #endregion

        #region Timer Tick Event Handler
        private void tmrManager_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                tmrManager.Stop();
                tmrManager.Enabled = false;

                _connectionString = ConfigurationManager.AppSettings["ConnectionString"];

                Rules loadShed = new Rules(_connectionString,_defaultPort);

                bool hasLoadShedAll = false;

                if (!hasLoadShedAll)
                {
                    if (!HasRulesToExecute())
                    {
                        Scheduling schedule = new Scheduling(_connectionString);
                        schedule.Execute(_defaultPort);
                    }
                    else
                    {
                        _ruleEnabledUnits = new List<int>();

                        Rules loadshedRules = new Rules(_connectionString, _defaultPort);
                        List<lfa.pmgmt.data.DTO.BusinessRule.RuleSet> ruleSets = loadshedRules.ListActiveRuleSets();

                        if (ruleSets.Count > 0)
                        {
                            ExecuteScheduleOnNonRuleEnabledUnits();

                            _ruleEnabledUnits.Clear();
                        }
                        else
                        {
                            Scheduling schedule = new Scheduling(_connectionString);
                            schedule.Execute(int.Parse(ConfigurationManager.AppSettings["DefaultPort"].ToString()));
                        }
                    }

                    LogLoadShedRulesExecuted();
                }           
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            finally
            {
                tmrManager = new System.Timers.Timer();
                tmrManager.Enabled = true;
                tmrManager.Interval = _interval;
                tmrManager.Elapsed += new System.Timers.ElapsedEventHandler(tmrManager_Elapsed);
                tmrManager.Start();
            }
        }
        #endregion

        #region Private Methods
        private static void LogLoadShedRulesExecuted()
        {
            if (_doLogging)
            {
                System.Diagnostics.EventLog.WriteEntry("Power Management Controller",
                                                        "Controller executed load shedding rules and schedules",
                                                        System.Diagnostics.EventLogEntryType.Information);
            }
        }


        private static void LogScheduleExecuted()
        {
            if (_doLogging)
            {
                System.Diagnostics.EventLog.WriteEntry("Power Management Controller",
                                                        "Controller executed schedules",
                                                        System.Diagnostics.EventLogEntryType.Information);
            }
        }

        private static void HandleException(Exception ex)
        {
            System.Diagnostics.EventLog.WriteEntry("Power Management Controller", 
                                                   "The following exception was raised: " + ex.ToString(), 
                                                   System.Diagnostics.EventLogEntryType.Error);
        }
        #endregion

        #region Power Management Methods
        private static bool HasRulesToExecute()
        {
            bool hasRules = false;

            lfa.pmgmt.data.DAO.BusinessRule.RuleSet ruleSetDAO = new lfa.pmgmt.data.DAO.BusinessRule.RuleSet();
            ruleSetDAO.ConnectionString = _connectionString;
            List<lfa.pmgmt.data.DTO.BusinessRule.RuleSet> ruleSets = ruleSetDAO.List();

            if (ruleSets.Count > 0)
                hasRules = true;

            return hasRules;
        }

        private static void ExecuteScheduleOnNonRuleEnabledUnits()
        {
            Scheduling schedule = new Scheduling(_connectionString);

            List<lfa.pmgmt.data.DTO.Schedule.Schedule> scheduleList = schedule.ListSchedules();

            schedule.ExecuteSchedule(scheduleList, _ruleEnabledUnits,
                                    int.Parse(ConfigurationManager.AppSettings["DefaultPort"].ToString()));
        }

        private static void ExecuteLoadShedRules(Rules loadshedRules, List<lfa.pmgmt.data.DTO.BusinessRule.RuleSet> ruleSets)
        {
            foreach (lfa.pmgmt.data.DTO.BusinessRule.RuleSet ruleSet in ruleSets)
            {
                List<lfa.pmgmt.data.DTO.BusinessRule.Rule> rules = loadshedRules.ListRulesForRuleSet(ruleSet.Id);

                foreach (lfa.pmgmt.data.DTO.BusinessRule.Rule rule in rules)
                {
                    string[] ruleArray = rule.Condition.Split(".".ToCharArray());

                    int unitId = int.Parse(ruleArray[0].ToString());

                    if (rule.Priority.ToLower().Equals("none"))
                    {
                        if (loadshedRules.ExecuteRule(rule.Condition))
                        {
                            loadshedRules.Execute(rule.Result);

                            _ruleEnabledUnits.Add(unitId);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
