using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace Lab_4
{
    public class Player
    {
        public string Name { get; private set; }
        public bool IsComputer { get; private set; }
        public List<Die> Dice { get; private set; }
        public int Score { get; set; }
        public List<int> Rolls { get; private set; }

        private Random random = new Random();

        public Player(string name, bool isComputer, List<Die> dice)
        {
            Name = name;
            IsComputer = isComputer;
            Dice = new List<Die>(dice);
            Score = 0;
            Rolls = new List<int>();
        }

        public int TakeTurn()
        {
            if (Dice.Count == 0)
                return 0;

            Die chosenDie;

            if (IsComputer)
            {
                // Computer chooses randomly
                int index = random.Next(Dice.Count);
                chosenDie = Dice[index];
                Console.WriteLine($"{Name} picked d{chosenDie.Sides}");
            }
            else
            {
                // Human chooses
                Console.WriteLine($"{Name}, it's your turn. Choose one die:");
                for (int i = 0; i < Dice.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. d{Dice[i].Sides}");
                }

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > Dice.Count)
                {
                    Console.WriteLine("Invalid choice, try again.");
                }

                chosenDie = Dice[choice - 1];
                Console.WriteLine($"{Name} picked d{chosenDie.Sides}");
            }

            int roll = chosenDie.Roll();
            Rolls.Add(roll);
            Dice.Remove(chosenDie);

            Console.WriteLine($"{Name} rolls a {roll}");
            return roll;
        }
    }
}
