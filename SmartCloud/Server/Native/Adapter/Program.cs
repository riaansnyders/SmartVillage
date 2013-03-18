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
            lfa.pmgmt.data.DAO.Configuration.Zone zoneDAO = null;

            try
            {
                if (args.Length > 0)
                {
                    string activatedEndpoint = args[0];
                    string loadId = args[1];
                    string token = args[2];

                    switch (activatedEndpoint)
                    {
                        #region /* Zone Service Methods */
                        case "AddZone":
                            zoneDAO = new lfa.pmgmt.data.DAO.Configuration.Zone();
                            zoneDAO.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
                            zoneDAO.Insert(args[3], DateTime.Now);

                            Console.WriteLine(HandleOK("zone/create"));
                        break;
                        case "EditZone":
                            zoneDAO = new lfa.pmgmt.data.DAO.Configuration.Zone();
                            zoneDAO.Update(int.Parse(args[3]), args[4]);

                            Console.WriteLine(HandleOK("zone/edit"));
                        break;
                        case "DeleteZone":
                        default:
                        case "ZoneState":
                        break;
                        #endregion

                        throw new ArgumentOutOfRangeException(@"The defined action or end point has not 
                                                               been found or is unavailable. Please try again.");
                    }

                }
                else
                {
                    throw new ArgumentNullException(@"No parameters defined for provided 
                                                      action or end point!");
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
            string json = "{ status: \"500\", identifier: \"" + System.Guid.NewGuid().ToString()  + "\", exception: \"" + ex.Message + "\"}";

            return json;
        }
        #endregion

        #region OK Result
        private static string HandleOK(string method)
        {
            string json = "{ status: \"200\", identifier: \"" + System.Guid.NewGuid().ToString() + "\", method: \"" + method + "\" description: \"Method executed with no errors!\"}";

            return json;
        }
        #endregion
    }
}
