using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EngineersTools
{
    public class SiteConfigurationData
    {
        public XmlDocument SiteConfigurationXML;
        public XmlDocument DeviceTypesXML;
        public XmlDocument UnitDetailsXML;

        // ctor
        public SiteConfigurationData()
        {
            this.SiteConfigurationXML = null;
            this.DeviceTypesXML = null;
            this.UnitDetailsXML = null;
        }
    }
}
