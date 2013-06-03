using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AccountManagerApp
{
    static class Program
    {
        //[DllImport("advapi32.dll", SetLastError = true)]
        //public static extern bool LogonUser(
        //    string lpszUsername,
        //    string lpszDomain,
        //    string lpszPassword,
        //    int dwLogonType,
        //    int dwLogonProvider,
        //    out IntPtr phToken
        //    );
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoginForm());
        }
    }
}
