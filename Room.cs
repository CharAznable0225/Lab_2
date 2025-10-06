using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    abstract class Room
    {
        public bool Visited { get; private set; } = false;

        public Room? North { get; set; }
        public Room? South { get; set; }
        public Room? East { get; set; }
        public Room? West { get; set; }

        public abstract string RoomDescription();

        public virtual void OnRoomEntered()
        {
            if (!Visited)
            {
                Console.WriteLine("First time here!");
                Console.WriteLine(RoomDescription());
                Visited = true;
            }
            else
            {
                Console.WriteLine("You've been here before.");
            }
        }

        public abstract void OnRoomSearched(Player player);

        public virtual void OnRoomExit()
        {
            Console.WriteLine("You leave the room...");
        }
    }
}
