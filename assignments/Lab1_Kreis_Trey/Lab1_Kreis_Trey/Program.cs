/*
 * Student: Trey Kreis
 * Class: ITSE 1430
 * Lab: 1
 * Date: 16 September 2017
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Kreis_Trey 
{

    class Program 
    {
        static void Main(string[] args)
        {
            bool quit = false;
            do
            {
                char choice = GetInput();
                switch (choice)
                {
                    case 'L': ListMovies(); break;
                    case 'A': AddMovie(); break;
                    case 'R': RemoveMovie(); break;
                    case 'Q': quit = true; break;
                };
            } while (!quit);
        }
        
        static void AddMovie()
        {
            Console.Write("Enter the title: ");
            movieTitle = Console.ReadLine();
            // check if empty

            Console.Write("Enter optional description: ");
            movieDescription = Console.ReadLine();

            Console.Write("Enter the optional length (in minutes): ");
            movieLength = ReadInt();

            Console.Write("Do you own the movie? (Y/N): ");
            movieIsOwned = ReadBoolean();

        }

        static void ListMovies()
        {
            if (movieTitle == String.Empty || movieTitle == null)
            {
                Console.WriteLine("No movies avaible");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(movieTitle);
                Console.WriteLine(movieDescription);
                string msgTime = $"Run length = {movieLength} minutes";
                Console.WriteLine(msgTime);
                string msgOwned = $"Status = {(movieIsOwned ? "Owned":" On Wishlist")}";
                Console.WriteLine(msgOwned);
            }

        }

        static void RemoveMovie()
        {
            movieTitle = "";
            movieLength = 0;
            movieDescription = "";
            movieIsOwned = false;
        }

        static char GetInput()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("".PadLeft(10, '-'));
                Console.WriteLine("L)ist Movies");
                Console.WriteLine("A)dd Movie");
                Console.WriteLine("R)emove Movie");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine().Trim();

                if (input != String.Empty)
                {
                    char letter = Char.ToUpper(input[0]);
                    if (letter == 'L')
                        return 'L';
                    else if (letter == 'A')
                        return 'A';
                    else if (letter == 'R')
                        return 'R';
                    else if (letter == 'Q')
                        return 'Q';
                }
                // user input doesnt match any of the above
                Console.WriteLine("Please choose a valid option");
            }
        }

        static bool ReadBoolean ()
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

        static int ReadInt()
        {
            do
            {
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out int result))
                    return result;
                Console.WriteLine("Enter a valid length");
            } while (true);
        }


        static string movieTitle;
        static string movieDescription;
        static int movieLength; // length in minutes
        static bool movieIsOwned;
    }
}
