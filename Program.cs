using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace
namespace NumberGuesser
{
    //Main Class
    class Program
    {
        //Entry Point Method
        static void Main(string[] args)
        {

            GetAppInfo();

            string name = GetName();
            Console.WriteLine("Hello {0}, lets play the game", name);

            bool play = true;

            while (play)
            {
                //Set correct number 
                //int correctNumber = 7;

                int correctNumber = SetRandomNumber();

                //Init guess var
                int guess = 0;

                //Ask user for number
                Console.WriteLine("Guess a number between 1 and 10");

                while (guess != correctNumber)
                {
                    

                    //Get users input
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out guess))
                    {
                        PrintMessage(ConsoleColor.Red, "Invalid Input, try again");
                        continue;
                    }

                    //Cast to int and put in guess
                    guess = Int32.Parse(input);

                    //Match guess to correct number
                    if (guess != correctNumber)
                    {
                        PrintMessage(ConsoleColor.Red, "Wrong number guessed, try again");
                        continue;
                    }
                }

                PrintMessage(ConsoleColor.Yellow, "Congrats! You guessed the correct number");
                play = PlayAgain();
            }
        }

        static void GetAppInfo()
        {
            //Set app vars
            string appName = "Number Guesser";
            string appVersion = "1.0.0";
            string appAuthor = "Leslie Pan";

            //change text color
            Console.ForegroundColor = ConsoleColor.Green;

            //Write out app info 
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);

            //Reset console color
            Console.ResetColor();
        }

        static string GetName()
        {
            //Ask users name
            Console.WriteLine("What is your name?");

            //Get user input
            string input = Console.ReadLine();

            return input;
        }

        static int SetRandomNumber()
        {
            //create new random object
            Random random = new Random();

            int correctNumber = random.Next(1, 10);

            return correctNumber;
        }

        static void PrintMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static bool PlayAgain()
        {

            //ask to play again
            Console.WriteLine("Play again? [Y or N]");

            string answer = Console.ReadLine().ToUpper();

            if (answer == "Y")
            {
                return true;
            }
            else if (answer == "N")
            {
                Console.WriteLine("User terminated program");
                return false;
            }
            else
            {
                Console.WriteLine("Input invalid, try again");
                return PlayAgain();
            };
        }
    }
}
