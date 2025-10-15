using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class GameManager
    {
        private Player player = null!;
        private Room currentRoom = null!;

        public void Start()
        {
            Console.WriteLine("Welcome to Assignment_2 Dungeon!");
            Console.Write("Enter your name: ");
            player = new Player(Console.ReadLine() ?? "Hero");

            Map map = new Map(3);
            currentRoom = map.StartRoom();

            while (true)
            {
                currentRoom.OnRoomEntered();
                Console.WriteLine("Choose action: (N/S/E/W) move, (search), (inventory), or (quit)");
                string input = Console.ReadLine()?.ToLower() ?? "";

                if (input == "quit") break;
                else if (input == "search") currentRoom.OnRoomSearched(player);
                else if (input == "inventory")
                {
                    if (player.Inventory.Count == 0) Console.WriteLine("Inventory is empty.");
                    else
                    {
                        player.ShowInventory();
                        Console.Write("Enter item number to use: ");
                        if (int.TryParse(Console.ReadLine(), out int index))
                            player.UseItem(index - 1);
                    }
                }
                else if (input == "n" && currentRoom.North != null) { currentRoom = currentRoom.North; }
                else if (input == "s" && currentRoom.South != null) { currentRoom = currentRoom.South; }
                else if (input == "e" && currentRoom.East != null) { currentRoom = currentRoom.East; }
                else if (input == "w" && currentRoom.West != null) { currentRoom = currentRoom.West; }
                else Console.WriteLine("Invalid move.");
            }

            Console.WriteLine("Thanks for playing!");
        }

        public static void StartBattle()
        {
            Console.WriteLine("Dice combat happens here...");
        }
    }
}
