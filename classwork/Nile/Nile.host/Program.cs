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
            productPrice = ReadDecimal();

            Console.Write("Enter optional description: ");
            productDescription = Console.ReadLine();

            Console.Write("Is it discontinued? (Y/N): ");
            productDiscontinued = ReadYesNo();

        }
        private static void ListProducts()
        {
            // Name  Price  [Discontinued]
            // Description

            //string msg = String.Format("{0}\t\t\t${1}\t\t{2}", productName, productPrice, productDiscontinued ? "[Discontinued]" : "");
            string msg = $"{productName}\t\t${productPrice}\t\t{(productDiscontinued ? "[Discontinued]" : "")}";

            Console.WriteLine(msg);
            Console.WriteLine(productDescription);
        }

        static char GetInput ()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("".PadLeft(10, '-'));
                Console.WriteLine("A)dd Product");
                Console.WriteLine("L)ist Products");
                Console.WriteLine("Q)uit");

                var input = Console.ReadLine().Trim();
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

        /// <summary>Reads a decimal from Console.</summary>
        /// <returns>The decimal value</returns>
        static decimal ReadDecimal()
        {
            do
            {
                string input = Console.ReadLine();
                if (Decimal.TryParse(input, out decimal result))
                    return result;
                Console.WriteLine("Enter a valid decimal");
            } while (true);
        }
        static string ReadString(string errorMessage, bool allowEmpty)
        {
            //if (errorMessage == null)
            //errorMessage = "Enter a valid string";
            // null coalesce
            errorMessage = errorMessage ?? "Enter a valid string";


            // null conditional. does the expression only if it is not null
            errorMessage = errorMessage?.Trim();
            do
            {
                var input = Console.ReadLine();
                if (String.IsNullOrEmpty(input) && allowEmpty)
                    return "";
                else if (!String.IsNullOrEmpty(input))
                    return input;
                Console.WriteLine(errorMessage);


            } while (true);
        }
        static bool ReadYesNo()
        {
            do
            {
                string input = Console.ReadLine();
                
                if (!String.IsNullOrEmpty(input))
                {
                    switch (Char.ToUpper(input[0]))
                    {
                        case 'Y': return true;
                        case 'N': return false;
                    };
                };

                Console.WriteLine("Enter either Y or N");
            } while (true);
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

            //value type
            int value1 = 100;
            Program program = new Program();
            var areEqual1 = value1 == 100;

            /* Parameter kinds

             * Input parameter  (int param)
             * Input/Output param (ref int param)
             * Output param (out int param)
             * 1: func must write
             */

            // reference types handle null
            // value types cannot be null
            // value types are almost always immutable

            

        }
        // Product
        static string productName;
        static decimal productPrice;
        static string productDescription;
        static bool productDiscontinued;
    }
}
