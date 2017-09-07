/*
 * Trey Kreis
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.host {
    class Program {
        static void Main( string[] args )
        {
            int hours = 5;
            hours = 10;
            // Verbatim string - no escape sequences (/n, /t)
            string path = @"C:\\temp\\test.txt";

            string name = "John";
            string names = "John" + " Williams" + " Henry"; //ineffiecint, creates alot of memory locations
            StringBuilder builder = new StringBuilder(); // most effienceny way, but it's ugly
            builder.Append("John");
            builder.Append("William");
            builder.Append("Henry");
            string names2 = builder.ToString();
            string names3 = String.Concat("John", " Williams", " Henry"); // option 3
            // compiler will convert option 1 to option 3 for small number of strings. larger numbers use option 2

            // John worked 10 hours
            // String formatting
            string format1 = name + " worked " + hours.ToString() + " hours.";

            string format2 = String.Format("{0} worked for {1} hours", name, hours);
        }
    }
}
