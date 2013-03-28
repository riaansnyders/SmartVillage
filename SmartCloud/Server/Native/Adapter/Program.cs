namespace SmartPower.SmartCloud.Adapter
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;

    using BravaSystem.Communication;
    using lfa.pmgmt.businessrules;
    using lfa.pmgmt.data;
    using lfa.pmgmt.schedule;
    #endregion

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string connectionString = ConfigurationManager.AppSettings["SqlConnectionString"];

                lfa.pmgmt.data.DAO.Configuration.Device deviceDOA = null;
                lfa.pmgmt.data.DAO.Configuration.Unit unitDOA = null;
                lfa.pmgmt.data.DAO.Configuration.Zone zoneDAO = null;
                lfa.pmgmt.data.DAO.Eventing.DeviceEvent deviceEvent = null;
                lfa.pmgmt.data.DAO.Schedule.Schedule scheduleDAO = null;
                lfa.pmgmt.data.DAO.Schedule.Unit scheduleUnitDOA = null;
                lfa.pmgmt.data.DAO.Security.Device deviceSecurityDAO = null;

                if (args.Length > 0)
                {
                    string activatedEndpoint = args[0];
                    string loadId = args[1];
                    string token = args[2];

                    switch (activatedEndpoint)
                    {
                        #region /* Notification Events */
                        case "Notification":
                           Console.WriteLine(token);
                        break;
                        #endregion

                        #region /*  Security Events */
                        case "Login":
                         deviceSecurityDAO = new lfa.pmgmt.data.DAO.Security.Device();
                         deviceSecurityDAO.ConnectionString = connectionString;
                         token = deviceSecurityDAO.Login(token);

                         lfa.pmgmt.data.DTO.Security.Device securityDevice = new lfa.pmgmt.data.DTO.Security.Device();
                         securityDevice.SessionToken = token;

                         Console.WriteLine(lfa.pmgmt.data.Serializer.Serializer.ToJSON(securityDevice));
                        break;
                        #endregion

                        #region /* Zone Service Methods */
                        case "CreateZone":
                            zoneDAO = new lfa.pmgmt.data.DAO.Configuration.Zone();
                            zoneDAO.ConnectionString = connectionString;
                            zoneDAO.Insert(args[3], DateTime.Now,args[4]);

                            Console.WriteLine(HandleOK("zone/create"));
                        break;
                        case "EditZone":
                            zoneDAO = new lfa.pmgmt.data.DAO.Configuration.Zone();
                            zoneDAO.ConnectionString = connectionString;
                            zoneDAO.Update(int.Parse(args[3]), args[4]);

                            Console.WriteLine(HandleOK("zone/edit"));
                        break;
                        case "DeleteZone":
                            zoneDAO = new lfa.pmgmt.data.DAO.Configuration.Zone();
                            zoneDAO.ConnectionString = connectionString;
                            zoneDAO.Delete(int.Parse(args[3]));

                            Console.WriteLine(HandleOK("zone/delete"));
                        break;
                        case "SetZoneState":
                            string zoneEvent = "ZoneState : {" + args[3] + "," + args[4] + "}";
                            deviceEvent = new lfa.pmgmt.data.DAO.Eventing.DeviceEvent();
                            deviceEvent.ConnectionString = connectionString;
                            deviceEvent.Insert(args[4], zoneEvent);

                            Console.WriteLine(HandleOK("zone/state"));
                        break;
                        case "ListZone":
                            zoneDAO = new lfa.pmgmt.data.DAO.Configuration.Zone();
                            zoneDAO.ConnectionString = connectionString;
                            List<lfa.pmgmt.data.DTO.Configuration.Zone> zones = zoneDAO.List();

                            Console.WriteLine(lfa.pmgmt.data.Serializer.Serializer.ToJSON(zones));
                        break;
                        #endregion

                        #region /* Device Events (Unit) */
                        //NOTE: Device is a logical reference to DOA unit and 
                        //switch is a reference to the DAO device.
                        case "CreateDevice":
                            unitDOA = new lfa.pmgmt.data.DAO.Configuration.Unit();
                            unitDOA.ConnectionString = connectionString;
                            unitDOA.Insert(int.Parse(args[3]), args[4], DateTime.Now, args[5]);

                            Console.WriteLine(HandleOK("device/create"));
                        break;
                        case "DeleteDevice":
                            unitDOA = new lfa.pmgmt.data.DAO.Configuration.Unit();
                            unitDOA.ConnectionString = connectionString;
                            unitDOA.Delete(int.Parse(args[3]));

                            Console.WriteLine(HandleOK("device/delete"));
                        break;
                        case "EditDevice":
                            unitDOA = new lfa.pmgmt.data.DAO.Configuration.Unit();
                            unitDOA.Update(int.Parse(args[3]), int.Parse(args[4]), args[5], args[6]);

                            Console.WriteLine(HandleOK("device/edit"));
                        break;
                        case "SetDeviceState":
                            string devicesEvent = "DeviceState : {" + args[3] + "," + args[4] + "}";
                            deviceEvent = new lfa.pmgmt.data.DAO.Eventing.DeviceEvent();
                            deviceEvent.ConnectionString = connectionString;
                            deviceEvent.Insert(args[4], devicesEvent);

                            Console.WriteLine(HandleOK("device/state"));
                        break;
                        case "LinkDevice":
                            scheduleUnitDOA = new lfa.pmgmt.data.DAO.Schedule.Unit();
                            scheduleUnitDOA.ConnectionString = connectionString;
                            scheduleUnitDOA.Insert(int.Parse(args[3]), int.Parse(args[4]));

                            Console.WriteLine(HandleOK("device/link"));
                        break;
                        case "UnlinkDevice":
                            scheduleUnitDOA = new lfa.pmgmt.data.DAO.Schedule.Unit();
                            scheduleUnitDOA.ConnectionString = connectionString;
                            scheduleUnitDOA.Delete(int.Parse(args[3]), int.Parse(args[4]));

                            Console.WriteLine(HandleOK("device/unlink"));
                        break;
                        case "ListDevice":
                            unitDOA = new lfa.pmgmt.data.DAO.Configuration.Unit();
                            unitDOA.ConnectionString = connectionString;
                            List<lfa.pmgmt.data.DTO.Configuration.Unit> units = unitDOA.List(int.Parse(args[3]));

                            Console.WriteLine(lfa.pmgmt.data.Serializer.Serializer.ToJSON(units));
                        break;
                        #endregion

                        #region /* Switch Events */
                        case "CreateSwitch":
                            deviceDOA = new lfa.pmgmt.data.DAO.Configuration.Device();
                            deviceDOA.ConnectionString = connectionString;
                            deviceDOA.Insert(int.Parse(args[3]),args[4],DateTime.Now,args[5]);

                            Console.WriteLine(HandleOK("switch/create"));
                        break;
                        case "DeleteSwitch":
                            deviceDOA = new lfa.pmgmt.data.DAO.Configuration.Device();
                            deviceDOA.ConnectionString = connectionString;
                            deviceDOA.Delete(int.Parse(args[3]));

                            Console.WriteLine(HandleOK("switch/delete"));
                        break;
                        case "EditSwitch":
                            deviceDOA = new lfa.pmgmt.data.DAO.Configuration.Device();
                            deviceDOA.ConnectionString = connectionString;
                            deviceDOA.Update(int.Parse(args[3]),int.Parse(args[4]),args[5]);

                            Console.WriteLine(HandleOK("switch/edit"));
                        break;
                        case "SetSwitchState":
                            string switchEvent = "SwitchState : {" + args[3] + "," + args[4] + "}";
                            deviceEvent = new lfa.pmgmt.data.DAO.Eventing.DeviceEvent();
                            deviceEvent.ConnectionString = connectionString;
                            deviceEvent.Insert(args[4], switchEvent);

                            Console.WriteLine(HandleOK("switch/state"));
                        break;
                        case "ListSwitches":
                            deviceDOA = new lfa.pmgmt.data.DAO.Configuration.Device();
                            deviceDOA.ConnectionString = connectionString;
                            List<lfa.pmgmt.data.DTO.Configuration.Device> deviceList = deviceDOA.List(int.Parse(args[3]));

                            Console.WriteLine(lfa.pmgmt.data.Serializer.Serializer.ToJSON(deviceList));
                        break;
                        #endregion

                        #region /* Priority Events */
                        case "CreatePriority":
                            scheduleDAO = new lfa.pmgmt.data.DAO.Schedule.Schedule();
                            scheduleDAO.ConnectionString = connectionString;
                            scheduleDAO.InsertPriority(int.Parse(args[3]), args[4]);

                            Console.WriteLine(HandleOK("priority/create"));
                        break;
                        case "DeletePriority":
                            scheduleDAO = new lfa.pmgmt.data.DAO.Schedule.Schedule();
                            scheduleDAO.ConnectionString = connectionString;
                            scheduleDAO.DeletePriority(int.Parse(args[3]));

                            Console.WriteLine(HandleOK("priority/delete"));
                        break;
                        case "ListPriority":
                            scheduleDAO = new lfa.pmgmt.data.DAO.Schedule.Schedule();
                            scheduleDAO.ConnectionString = connectionString;
                            List<lfa.pmgmt.data.DTO.Schedule.Priority> priorities = scheduleDAO.ListPriority();

                            Console.WriteLine(lfa.pmgmt.data.Serializer.Serializer.ToJSON(priorities));
                        break;
                        #endregion

                        #region /* Schedule Events */
                        case "CreateSchedule":
                            scheduleDAO = new lfa.pmgmt.data.DAO.Schedule.Schedule();
                            scheduleDAO.ConnectionString = connectionString;
                            scheduleDAO.Insert(args[3], args[4], args[5], 1000, DateTime.Now);

                            Console.WriteLine(HandleOK("schedule/create"));
                        break;
                        case "EditSchedule":
                            scheduleDAO = new lfa.pmgmt.data.DAO.Schedule.Schedule();
                            scheduleDAO.ConnectionString = connectionString;
                            scheduleDAO.Update(int.Parse(args[3]),args[4], args[5], args[6], 1000);

                            Console.WriteLine(HandleOK("schedule/edit"));
                        break;
                        case "DeleteSchedule":
                            scheduleDAO = new lfa.pmgmt.data.DAO.Schedule.Schedule();
                            scheduleDAO.ConnectionString = connectionString;
                            scheduleDAO.Delete(int.Parse(args[3]));

                            Console.WriteLine(HandleOK("schedule/delete"));
                        break;
                        case "EnableSchedule":
                            scheduleDAO = new lfa.pmgmt.data.DAO.Schedule.Schedule();
                            scheduleDAO.ConnectionString = connectionString;
                            scheduleDAO.EnableDisable(int.Parse(args[3]), true);

                            Console.WriteLine(HandleOK("schedule/enable"));
                        break;
                        case "DisableSchedule":
                            scheduleDAO = new lfa.pmgmt.data.DAO.Schedule.Schedule();
                            scheduleDAO.ConnectionString = connectionString;
                            scheduleDAO.EnableDisable(int.Parse(args[3]), false);

                            Console.WriteLine(HandleOK("schedule/disable"));
                        break;
                        case "ListSchedule":
                            scheduleDAO = new lfa.pmgmt.data.DAO.Schedule.Schedule();
                            scheduleDAO.ConnectionString = connectionString;
                            List<lfa.pmgmt.data.DTO.Schedule.Schedule> schedules = scheduleDAO.List();

                            Console.WriteLine(lfa.pmgmt.data.Serializer.Serializer.ToJSON(schedules));
                        break;
                        #endregion

                        default:
                        throw new ArgumentOutOfRangeException(@"The defined action or end point has not been found or is unavailable. Please try again.");
                    }
                }
                else
                {
                    throw new ArgumentNullException(@"No parameters defined for provided action or end point!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(HandleException(ex));
            }
        }

        #region Exception Handling
        private static string HandleException(Exception ex)
        {
            string json = "{ status: \"500\", identifier: \"" + System.Guid.NewGuid().ToString()  + "\",";
            json = json +  "exception: \"" + ex.Message + "\"}";

            return json;
        }
        #endregion

        #region OK Result
        private static string HandleOK(string method)
        {
            string json = "{ status: \"200\", identifier: \"" + System.Guid.NewGuid().ToString() + "\", ";
            json = json + "method: \"" + method + "\" description: \"Success!\"}";

            return json;
        }
        #endregion
    }
}
