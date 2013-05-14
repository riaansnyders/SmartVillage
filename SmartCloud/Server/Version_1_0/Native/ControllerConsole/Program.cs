namespace lfa.pmgmt.control.console
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;

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

    public class Program
    {
        private static string _connectionString = string.Empty;
        private static List<int> _ruleEnabledUnits = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting power management controller service...");

            try
            {
                _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                int defaultPort = int.Parse(ConfigurationManager.AppSettings["DefaultPort"].ToString());

                Console.WriteLine("Power management controller service running...");

                Rules loadShed = new Rules(_connectionString,defaultPort);
                //bool hasLoadShedAll = loadShed.EntireLoadShed();
                bool hasLoadShedAll = false;

                if (!hasLoadShedAll)
                {
                    if (!HasRulesToExecute())
                    {
                        Scheduling schedule = new Scheduling(_connectionString);
                        schedule.Execute(defaultPort);
                    }
                    else
                    {
                        _ruleEnabledUnits = new List<int>();

                        Rules loadshedRules = new Rules(_connectionString, defaultPort);
                        List<lfa.pmgmt.data.DTO.BusinessRule.RuleSet> ruleSets = loadshedRules.ListActiveRuleSets();

                        if (ruleSets.Count > 0)
                        {
                            ExecuteScheduleOnNonRuleEnabledUnits();

                            //ExecuteLoadShedRules(loadshedRules, ruleSets);

                            _ruleEnabledUnits.Clear();
                        }
                        else
                        {
                            Scheduling schedule = new Scheduling(_connectionString);
                            schedule.Execute(int.Parse(ConfigurationManager.AppSettings["DefaultPort"].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //Console.WriteLine("Press any key to exit");
            //Console.ReadKey();
        }

        #region Private Methods
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
