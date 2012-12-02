using System;
using System.Collections.Generic;
using System.Text;

namespace Indus.Services.Core.Logging
{
    public class Logger
    {
        private StringBuilder _builder;
        public Logger()
        {
            _builder = new StringBuilder();
        }
        public void WriteLog(string logInfo)
        {
            
            _builder.AppendLine(logInfo);
            _builder.AppendLine();
        }

        public string CurrentLogInfo
        {
            get
            {
               return  _builder.ToString();
            }
        }
        


    }
}
