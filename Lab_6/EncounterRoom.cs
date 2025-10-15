using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    public class EncounterRoom : Room
    {
        public override string RoomDescription() => "An enemy lurks here!";

        public override void OnRoomSearched(Player player)
        {
            Console.WriteLine("Searching reveals nothing useful here.");
        }

        public override void OnRoomEntered()
        {
            base.OnRoomEntered();
            Console.WriteLine("Battle begins!");
            GameManager.StartBattle();
        }
    }
}
