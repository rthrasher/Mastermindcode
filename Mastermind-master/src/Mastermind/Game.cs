using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind
{
    public class Game
    {
        private static Random _randomizer = new Random();
        private GuessAnalyzer inspector;
        private List<Turn> _turns = new List<Turn>();

        public Game() : this(GenerateCode()) { }

        public Game(string code)
        {
            Code = code;
            inspector = new GuessAnalyzer(Code);
        }

        //generates code and converts it to a string value
        private static string GenerateCode(int length = 4)
        {
            var builder = new StringBuilder(length);
            for (var index = 0; index < length; index++)
                builder.Append(_randomizer.Next(1, 6));
            return builder.ToString();
        }

        public string Code { get; set; }
        public bool IsFinished { get; private set; }

        //function to loop with players guess, will return response if the player wins or loses
        public string Guess(string guess)
        {
            var turn = new Turn
            {
                Number = _turns.Count + 1,
                Guess = guess,
                Response = inspector.Analyze(guess)
            };
            _turns.Add(turn);

            if (turn.Response == "++++")
            {
                IsFinished = true;
                Console.WriteLine($"Congratulations, you won!\n(in only {turn.Number} turns)");
            }

            if (turn.Number > 9)
            {
                IsFinished = true;
                Console.WriteLine($"Sorry, you lose.\n(the code was \"{Code}\")");
            }

            return turn.Response;
        }
    }
}