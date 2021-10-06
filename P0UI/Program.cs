using System;

namespace P0UI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;

            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Store!");
                string userChoice;
                Console.WriteLine("[a] - Are you a customer?");
                Console.WriteLine("[b] - Are you an employee?");
                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "a":
                        Console.WriteLine("What would you like to buy?");
                        break;
                    case "b":
                        Console.WriteLine("What would you like to do?");
                        break;
                    default:
                        Console.WriteLine("Please choose one, try again.");
                        break;
                }
            }
        }
    }
}
