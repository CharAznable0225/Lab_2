using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class GameManager
    {
        private Player human;
        private Player computer;
        private List<Die> startingDice;

        public void Run()
        {
            PrintTitle();
            SetupGame();

            bool playAgain = true;
            while (playAgain)
            {
                StartGame();
                playAgain = AskPlayAgain();
            }

            PrintGoodbye();
        }

        private void PrintTitle()
        {
            Console.WriteLine("*********************************");
            Console.WriteLine(" Welcome to the Dice Battle Game ");
            Console.WriteLine("*********************************");
        }

        private void SetupGame()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine() ?? "Player";

            Console.WriteLine($"{name}, welcome to the Dice Battle!");
            Console.WriteLine("Game rules: Both you and the computer will roll dice. Higher roll wins the round!");
            Console.WriteLine("Each die can only be used once.");
            Console.WriteLine();

            startingDice = new List<Die>
            {
                new Die(6),
                new Die(8),
                new Die(12),
                new Die(20)
            };

            human = new Player(name, false, startingDice);
            computer = new Player("Computer", true, startingDice);
        }

        private void StartGame()
        {
            Console.WriteLine("Are you ready? (yes/no)");
            string? input = Console.ReadLine()?.ToLower();
            if (input != "yes") return;

            int rounds = startingDice.Count;

            for (int round = 1; round <= rounds; round++)
            {
                Console.WriteLine($"\n--- Round {round} ---");

                int humanRoll = human.TakeTurn();
                int computerRoll = computer.TakeTurn();

                if (humanRoll > computerRoll)
                {
                    Console.WriteLine($"{human.Name} wins the round!");
                    human.Score++;
                }
                else if (computerRoll > humanRoll)
                {
                    Console.WriteLine($"{computer.Name} wins the round!");
                    computer.Score++;
                }
                else
                {
                    Console.WriteLine("It's a tie! No points awarded.");
                }
            }

            PrintSummary();
        }

        private void PrintSummary()
        {
            Console.WriteLine("\n=== Game Summary ===");

            Console.WriteLine($"{human.Name}: {human.Score} points, total rolls = {Sum(human.Rolls)}, rolls: {string.Join(", ", human.Rolls)}");
            Console.WriteLine($"{computer.Name}: {computer.Score} points, total rolls = {Sum(computer.Rolls)}, rolls: {string.Join(", ", computer.Rolls)}");

            if (human.Score > computer.Score)
                Console.WriteLine($"{human.Name} wins the game!");
            else if (computer.Score > human.Score)
                Console.WriteLine($"{computer.Name} wins the game!");
            else
                Console.WriteLine("It's a draw!");
        }

        private int Sum(List<int> rolls)
        {
            int total = 0;
            foreach (int r in rolls) total += r;
            return total;
        }

        private bool AskPlayAgain()
        {
            Console.WriteLine("\nWould you like to play again? (yes/no)");
            string? input = Console.ReadLine()?.ToLower();
            return input == "yes";
        }

        private void PrintGoodbye()
        {
            Console.WriteLine("\n*********************************");
            Console.WriteLine(" Thanks for playing Dice Battle! ");
            Console.WriteLine("*********************************");
        }
    }
}
