using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rentals
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Calls the Initializer.InitializeDatabase method to create the database, 
            // create the database table schema, and populate the tables with data. 
            Controller.Initializer.InitializeDatabase();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMenu());
        }
    }
}
