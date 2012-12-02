using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Indus.ACSI.Core
{
    public abstract class Server
    {
        private ArrayList _serviceAccessPoints= new ArrayList();
        private ArrayList _logicalDevices= new ArrayList();
        private ArrayList _files= new ArrayList();
        private ArrayList _twopartyAssociation= new ArrayList();
        private ArrayList _multicastAssociation= new ArrayList();

        #region Public Methods

        public string[] GetServerDirectory(ObjectClassEnum objectClass)
        {
            ArrayList objects = new ArrayList();
            if (objectClass == ObjectClassEnum.LogicalDevice)
            {
                foreach(LogicalDevice ld  in this.LogicalDevices)
                {
                    objects.Add(ld.LDName);

                }
            }
            return (string[])objects.ToArray(typeof(string));
            
        }
        public void  AddServiceAccessPoint(ServiceAccessPoint point)
        {
            _serviceAccessPoints.Add(point);
        }

        public void AddLogicalDevice(LogicalDevice  logicalNode)
        {
            _logicalDevices.Add(logicalNode );
        }

        public void AddFile(File  file)
        {
            _files.Add(file );
        }
        #endregion
        #region Public Properties
        public ServiceAccessPoint[] ServiceAccessPoints
        {
            get
            {
                return (ServiceAccessPoint[]) _serviceAccessPoints.ToArray(typeof(ServiceAccessPoint));
               
            }
        }

        public LogicalDevice[] LogicalDevices
        {
            get
            {
                return (LogicalDevice [])_logicalDevices.ToArray(typeof(LogicalDevice ));

            }
        }

        public File[] Files
        {
            get
            {
                return (File [])_files.ToArray(typeof(File ));

            }
        }

        public TPAA [] TPPAssociations
        {
            get
            {
                return (TPAA [])_twopartyAssociation.ToArray(typeof(TPAA ));

            }
        }

        public MCAA [] MCPAssociations
        {
            get
            {
                return (MCAA [])_multicastAssociation.ToArray(typeof(MCAA ));

            }
        }
        #endregion 
        
        
    }
}
