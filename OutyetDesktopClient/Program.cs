using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace OutyetDesktopClient
{
    static class Program
    {
        private static BLL b = new BLL();

        public static BLL BLL
        {
            get
            {
                return b;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
