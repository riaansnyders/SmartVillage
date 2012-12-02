using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lfa.pmgmt.ui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            Application.Run(new Frm_Main());
        }
    }
}
