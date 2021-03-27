using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hotel
{
    static class Program
    {
        public static SqlConnectionStringBuilder sql = new SqlConnectionStringBuilder
        {
            AttachDBFilename = Environment.CurrentDirectory + "\\Hotel.mdf",
            //InitialCatalog = "Hotel",
            DataSource = @".\sqlexpress",
            IntegratedSecurity = true,
            //UserID = "sa",
            //Password = "123456"
        };

        /// <summary>
        /// Главная точка входа для приложения.
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
