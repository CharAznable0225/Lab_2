using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    class TreasureRoom : Room
    {
        private bool itemTaken = false;

        public override string RoomDescription() => "A glittering treasure room.";

        public override void OnRoomSearched(Player player)
        {
            if (!itemTaken)
            {
               
                var rand = new Random();
                int choice = rand.Next(4);
                Item item;
                switch (choice)
                {
                    case 0: item = new Weapon("Longsword", 1, 8); break;
                    case 1: item = new Consumable("Large Healing Potion", 2, 10); break;
                    case 2: item = new Artifact("Ancient Coin", 1, 6); break;
                    default: item = new Tool("Rope", 2, 4); break;
                }
                Console.WriteLine($"You found a {item.Name}!");
                player.Inventory.Add(item);
                itemTaken = true;
            }
            else
            {
                Console.WriteLine("You already searched this room.");
            }
        }
    }
}
