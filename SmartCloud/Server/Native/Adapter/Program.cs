namespace SmartPower.SmartCloud.Adapter
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
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
                if (args.Length > 0)
                {
                    string activatedEndpoint = args[0];
                    string loadId = args[1];
                    string token = args[2];

                    switch (activatedEndpoint)
                    {
                        case "AddSwitch":
                        break;
                        default:
                        throw new ArgumentOutOfRangeException("The defined action or end point has not been found or is unavailable. Please try again.");
                        break;
                    }


                }
                else
                {
                    throw new ArgumentNullException("No parameters defined for provided action or end point!");
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
            string json = "{ status: \"500\", identifier: {0}, exception: \"{1}\"}";

            return string.Format(json, System.Guid.NewGuid().ToString(), ex.Message);
        }
        #endregion
    }
}
