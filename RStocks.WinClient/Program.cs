using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RStocks.Model.Factories;
using RStocks.XMLStorage;

namespace RStocks.WinClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static IRepositoryFactory RepositoryFactory = new XmlRepositoryFactory(Application.StartupPath);

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            Application.Run(new Form1());
        }
    }
}
