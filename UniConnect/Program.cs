using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniConnect
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Make sure the app fully exits when the last form closes
            Application.ApplicationExit += (s, e) =>
            {
                Environment.Exit(0);
            };

            Application.Run(new frmStudentLogin());
        }
    }
}