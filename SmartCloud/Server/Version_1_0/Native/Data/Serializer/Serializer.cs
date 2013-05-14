namespace lfa.pmgmt.data.Serializer
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;

    using System.Web.Script.Serialization;
    #endregion

    public class Serializer
    {
        #region Public Methods
        public static string ToJSON(Object dataObject)
        {
            var serializer = new JavaScriptSerializer();

            return serializer.Serialize(dataObject);
        }

        public static Object FromJSON(string json)
        {
            var serializer = new JavaScriptSerializer();
            return (Object)serializer.Deserialize(json, typeof(Object));
        }
        #endregion
    }
}
