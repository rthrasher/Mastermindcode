using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Greetings!");
            Console.WriteLine("I have generated a random code of 4 digits:");
            Console.WriteLine("Each digit falls between 1 and 6");
            Console.WriteLine("You have up to 10 tries to guess my secret code.");
            Console.WriteLine("After each guess, you will be recive a respond using the following symbols");
            Console.WriteLine("'+' indicates that number was correct in that position");
            Console.WriteLine("'-' indicates that the number is in the code but not in the right spot");
            Console.WriteLine("' ' indicates that this number is not in the code");
            Console.WriteLine("Please enter your guess now.");

            var game = new Game();

            do
            {
                Console.Write("\n> ");
                var guess = Console.ReadLine();

                Console.WriteLine(game.Guess(guess));

            } while (!game.IsFinished);
        }
    }
}
