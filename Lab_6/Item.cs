using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public abstract class Item
    {
        public string Name { get; set; }
        public Item(string name) { Name = name; }
        public abstract void Use(Player player); // 使用道具
    }

    public class Weapon : Item
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        private Random random = new Random();

        public Weapon(string name, int min, int max) : base(name)
        {
            Min = min;
            Max = max;
        }

        public override void Use(Player player)
        {
            int damage = random.Next(Min, Max + 1);
            Console.WriteLine($"{player.Name} uses {Name} and deals {damage} damage!");
        }
    }

    public class Consumable : Item
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        private Random random = new Random();

        public Consumable(string name, int min, int max) : base(name)
        {
            Min = min;
            Max = max;
        }

        public override void Use(Player player)
        {
            int heal = random.Next(Min, Max + 1);
            Console.WriteLine($"{player.Name} uses {Name} and heals {heal} HP!");
        }
    }

    public class Artifact : Item
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        private Random random = new Random();

        public Artifact(string name, int min, int max) : base(name)
        {
            Min = min;
            Max = max;
        }

        public override void Use(Player player)
        {
            int value = random.Next(Min, Max + 1);
            Console.WriteLine($"{player.Name} appraises {Name} and it is worth {value} gold!");
        }
    }

    public class Tool : Item
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        private Random random = new Random();

        public Tool(string name, int min, int max) : base(name)
        {
            Min = min;
            Max = max;
        }

        public override void Use(Player player)
        {
            int effect = random.Next(Min, Max + 1);
            Console.WriteLine($"{player.Name} uses {Name}, effect value: {effect}");
        }
    }
}
