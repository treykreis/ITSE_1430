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

        static void Main( string[] args)
        {
            bool quit = false;
            do
            {
                char choice = GetInput();
                switch (choice)
                {
                    case 'A': AddProduct(); break;
                    case 'L': ListProducts(); break;
                    case 'Q': quit = true; break;
                };
            } while (!quit);
        }


        private static void AddProduct()
        {
            Console.Write("Enter product name: ");
            productName = Console.ReadLine();

            // Ensure not empty

            Console.Write("Enter price (> 0): ");
            string price = Console.ReadLine();

            Console.Write("Enter optional description: ");
            productDescription = Console.ReadLine();

            Console.Write("Is it discontinued? (Y/N): ");
            string discontinued = Console.ReadLine();

        }
        private static void ListProducts()
        {
            
        }

        static char GetInput ()
        {
            while (true)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("".PadLeft(10, '-'));
                Console.WriteLine("A)dd Product");
                Console.WriteLine("L)ist Products");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine().Trim();
                //option 1: if (input != "")
                //option 2: if (input != null && input.Length != 0)
                if (input != String.Empty)
                {
                    //string comparison
                    if (String.Compare(input, "A", true) == 0)
                        return 'A';



                    //char comparison
                    char letter = Char.ToUpper(input[0]);
                    if (letter == 'A')
                        return 'A';
                    else if (letter == 'L')
                        return 'L';
                    else if (letter == 'Q')
                        return 'Q';
                }
                // error
                Console.WriteLine("Please choose a valid option");
            }
        }
        static void Notes( string[] args )
        {
            int hours = 5;
            hours = 10;
            // Verbatim string - no escape sequences (/n, /t)
            string path = @"C:\\temp\\test.txt";

            string name = "John";
            /*string names = "John" + " Williams" + " Henry"; //ineffiecint, creates alot of memory locations
            StringBuilder builder = new StringBuilder(); // most effienceny way, but it's ugly
            builder.Append("John");
            builder.Append("William");
            builder.Append("Henry");
            string names2 = builder.ToString();
            string names3 = String.Concat("John", " Williams", " Henry"); // option 3*/
            // compiler will convert option 1 to option 3 for small number of strings. larger numbers use option 2

            // John worked 10 hours
            // String formatting
            string format1 = name + " worked " + hours.ToString() + " hours.";

            string format2 = String.Format("{0} worked for {1} hours", name, hours);

            string format3 = $"{name} worked for {hours} hours";

        }

        // Product
       static string productName;
       static decimal productPrice;
       static string productDescription;
       static bool productDiscontinued;
    }
}
