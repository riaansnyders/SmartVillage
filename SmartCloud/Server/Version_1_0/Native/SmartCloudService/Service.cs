namespace SmartPower.SmartCloudService
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    #endregion

    public partial class Service : ServiceBase
    {
        Process process = null;

        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

          ProcessStartInfo startInfo = new ProcessStartInfo(Constants.NODEPATH, Constants.NODEPARAMETERS);
          startInfo.WindowStyle = ProcessWindowStyle.Hidden;

          process = System.Diagnostics.Process.Start(startInfo);
        }

        protected override void OnStop()
        {
            process.Kill();
        }
    }
}
