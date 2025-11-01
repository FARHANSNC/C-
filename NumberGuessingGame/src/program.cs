using System;

namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                Random random = new Random();
                int target = random.Next(1, 101);
                int attempts;
                Console.WriteLine("Welcome to the Number Guessing Game!");
                Console.WriteLine("I'm thinking of a number between 1 and 100 and you ave to guess the correct number.");
                Console.WriteLine();
                Console.WriteLine("Select a difficulty level to start the game.");
                Console.WriteLine("1 - Easy (10 attempts)");
                Console.WriteLine("2 - Medium (7 attempts)");
                Console.WriteLine("3 - Hard (5 attempts)");
                try
                {
                    int difficulty = Convert.ToInt32(Console.ReadLine());
                    switch (difficulty)
                    {
                        case 1:
                            attempts = 10;
                            break;
                        case 2:
                            attempts = 7;
                            break;
                        case 3:
                            attempts = 5;
                            break;
                        default:
                            attempts = 7;
                            Console.WriteLine("Invalid choice... Using Medium difficulty.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input... Using Medium difficulty (7 attempts).");
                    attempts = 7;
                }
                Console.WriteLine($"You have {attempts} attempts.");
                int counter = 0;
                int guess = 0;
                bool result = false;
                while (counter < attempts && !result)
                {
                    counter++;
                    Console.WriteLine($"Attempt {counter} of {attempts} .... ( {attempts - counter} attempts left )");
                    try
                    {
                        Console.Write("Your guess : ");
                        guess = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid number!");
                        counter--;
                        continue;
                    }
                    if (guess >= 1 && guess <= 100)
                    {
                        if (guess == target)
                        {
                            result = true;
                            Console.WriteLine("Congratulations! You've guessed the correct number!");
                        }
                        else if (guess < target)
                        {
                            Console.WriteLine("Your guess is too low. Try again.");
                        }
                        else
                        {
                            Console.WriteLine("Your guess is too high. Try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number between 1 and 100.");
                        counter--;
                    }
                }
                switch (result)
                {
                    case true:
                        Console.WriteLine($"You guessed it in {counter} attempts.");
                        break;
                    case false:
                        Console.WriteLine("Game Over");
                        Console.WriteLine($"Sorry, you've used all your attempts. The correct number was {target}.");
                        break;

                }


                Console.WriteLine("Play again? (y/n)");
                string response = Console.ReadLine();
                playAgain = (response.ToLower() == "y");
                Console.Clear();
            }
            Console.WriteLine("Thanks for playing! Goodbye!");
        }
    }
}
