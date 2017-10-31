using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nile.Windows {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // string split example
            /*var csv = "Field1 | Field2 ,, Field3 | Field4";
            var delemiters = new char[2];
            delemiters[0] = '|';
            delemiters[1] = ',';
            var tokens = csv.Split(delemiters, StringSplitOptions.RemoveEmptyEntries);
            var numberOfElements = tokens.Length;*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
