using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace HighLowGame
{
    internal class Program
    {
        // High/Low Guessing Game using user inputs as the guesses
        static void HighLowHumanGuess()
        {
            bool repeat = false;
            do
            {
                Random rand = new();
                int numberToGuess = rand.Next(1, 11); // Generate the random number between 1 and 10
                int userInput;
                int doofusCounter = 0; //Counter to end program if the user enters 3 invalid inputs in one round of the game

                Console.WriteLine("\nWelcome to the High/Low Guessing Game.\n" +
                                  "The computer has generated a number between 1 and 10. (1, 2, 3, 4, 5, 6, 7, 8, 9, or 10\n" +
                                  "Take a guess and it will tell you if the number is higher or lower than correct number until you get it right.\n" +
                                  "-----------------------------------------------------------------------------------------------------------------");
                while (true) 
                {
                    while (true)
                    {
                        // Validate Guess
                        Console.Write($"Enter an integer [1-10]: ");
                        if (int.TryParse(Console.ReadLine(), out int value) && value >= 1 && value <= 10)
                        {
                            userInput = value;
                            break;
                        }
                        Console.WriteLine($"Invalid input. Please enter an integer ranging from 1 to 10.");
                        doofusCounter += 1;

                        if (doofusCounter == 3)
                        {
                            Console.WriteLine("Doofus threshold achieved. Game privileges revoked.");
                            return;
                        }
                    }

                    // Send the appropriate response based on the user guess
                    if (userInput > numberToGuess)
                    {
                        Console.WriteLine("Lower");
                    }
                    if (userInput < numberToGuess)
                    {
                        Console.WriteLine("Higher");
                    }
                    if (userInput == numberToGuess)
                    {
                        Console.WriteLine("Correct");
                        break;
                    }
                }

                // Ask the user if they wish to play anotehr round
                Console.WriteLine("Would you like to play again? 1 for yes, 2 for no.");

                while (true)
                {
                    Console.Write($"Enter an integer [1-2]: ");
                    if (int.TryParse(Console.ReadLine(), out int value) && value == 1 || value == 2)
                    {
                        userInput = value;
                        break;
                    }
                    Console.WriteLine($"Invalid input. Please enter 1 or 2.");
                    doofusCounter += 1;

                    if (doofusCounter == 3)
                    {
                        Console.WriteLine("Doofus threshold achieved. Game privileges revoked.");
                        return;
                    }
                }

                if (userInput == 1)
                {
                    repeat = true;
                }

            } while (repeat);
        }

        // 2. High/Low Guessing Game where the program generate the guess
        static void HighLowComputerGuess()
        {
            Random rand = new();
            int min = 1; // Min value to be updated on future guesses
            int max = 11; // Max value to be updated on future guesses
            int numberToGuess = rand.Next(min, max); // Generate the random number between 1 and 10

            Console.WriteLine("\nWelcome to the High/Low Guessing Game.\n" +
                                "The computer has generated a number between 1 and 10. (1, 2, 3, 4, 5, 6, 7, 8, 9, or 10\n" +
                                "Now it will guess and determine if the number is higher or lower until it reaches the correct answer.\n" +
                                "-----------------------------------------------------------------------------------------------------------------");
            while (true)
            {
                int guess = rand.Next(min, max); // Generate the random number to use as a guess

                Console.WriteLine("Computer's Guess: " + guess);

                // Update bounds of guess and display message based on the previous guess
                if (guess > numberToGuess)
                {
                    Console.WriteLine("Lower");
                    max = guess;
                }
                if (guess < numberToGuess)
                {
                    Console.WriteLine("Higher");
                    min = guess + 1;
                }
                if (guess == numberToGuess)
                {
                    Console.WriteLine("Correct");
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Choose a program to run.\n" +
                                "1. High/Low Human Guess\n" +
                                "2. High/Low Computer Guess");

            int userInput;
            while (true)
            {
                Console.Write($"Enter an integer [1-2]: ");
                if (int.TryParse(Console.ReadLine(), out int value) && value == 1 || value == 2)
                {
                    userInput = value;
                    break;
                }
                Console.WriteLine($"Invalid input. Please enter 1 or 2.");
            }

            if (userInput == 1)
            {
                HighLowHumanGuess();
            }
            if (userInput == 2)
            {
                HighLowComputerGuess();
            }
        }
    }
}
