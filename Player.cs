using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Player
    {
        public string Name { get; }
        public List<Die> Inventory { get; }

        private Random random = new Random();

        public Player(string name)
        {
            Name = name;
            Inventory = new List<Die> { new Die(6) }; // start with 1 die
        }

        public int TakeTurn()
        {
            // pick first die
            if (Inventory.Count == 0) return 0;

            Die die = Inventory[0];
            int roll = die.Roll();
            Console.WriteLine($"{Name} rolls a {roll} on d{die.Sides}");
            return roll;
        }
    }
}
