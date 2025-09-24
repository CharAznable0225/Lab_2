using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class GameManager
    {
        private Player player;
        private Player computer;
        private Die die;

        public GameManager()
        {
            die = new Die();
        }

        public void Play()
        {
            Console.WriteLine("=== Welcome to Lab 4 Dice Game ===");
            Console.WriteLine($"Author: Chris   Date: {DateTime.Now.ToShortDateString()}");
            Console.WriteLine("----------------------------------");

            
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName);
            computer = new Player("Computer");

            
            Random rnd = new Random();
            bool playerFirst = rnd.Next(0, 2) == 0;
            Console.WriteLine(playerFirst ? $"{player.Name} goes first!" : $"{computer.Name} goes first!");
            Console.WriteLine();

            
            if (playerFirst)
            {
                PlayerRoll(player);
                PlayerRoll(computer);
            }
            else
            {
                PlayerRoll(computer);
                PlayerRoll(player);
            }

            
            Console.WriteLine();
            if (player.CurrentRoll > computer.CurrentRoll)
            {
                Console.WriteLine($"{player.Name} wins this round!");
                player.Score++;
            }
            else if (computer.CurrentRoll > player.CurrentRoll)
            {
                Console.WriteLine($"{computer.Name} wins this round!");
                computer.Score++;
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }

            
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Round Summary:");
            Console.WriteLine($"{player.Name} Score: {player.Score}");
            Console.WriteLine($"{computer.Name} Score: {computer.Score}");
            Console.WriteLine("Game Over. Thanks for playing!");
            Console.ReadLine();
        }

        private void PlayerRoll(Player p)
        {
            int sides;

            if (p.Name == "Computer")
            {
                
                int[] options = { 6, 8, 12, 20 };
                Random rnd = new Random();
                sides = options[rnd.Next(options.Length)];
                Console.WriteLine($"Computer chooses a d{sides}");
            }
            else
            {
                
                Console.Write("Choose a die to roll (6, 8, 12, 20): ");
                while (!int.TryParse(Console.ReadLine(), out sides) || (sides != 6 && sides != 8 && sides != 12 && sides != 20))
                {
                    Console.Write("Invalid choice. Please choose 6, 8, 12, or 20: ");
                }
            }

            
            int roll = die.Roll(sides);
            p.CurrentRoll = roll;
            Console.WriteLine($"{p.Name} rolled a {roll} on a d{sides}");
        }
    }
}
