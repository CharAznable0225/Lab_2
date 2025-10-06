using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("You found a shiny d12!");
                player.Inventory.Add(new Die(12));
                itemTaken = true;
            }
            else
            {
                Console.WriteLine("You already searched this room.");
            }
        }
    }
}
