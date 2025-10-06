using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class GameManager
    {
        private Player player;
        private Room currentRoom;

        public void Start()
        {
            Console.WriteLine("Welcome to Lab 6 Dungeon!");
            Console.Write("Enter your name: ");
            player = new Player(Console.ReadLine() ?? "Hero");

            Map map = new Map(3);
            currentRoom = map.StartRoom();

            while (true)
            {
                currentRoom.OnRoomEntered();
                Console.WriteLine("Choose action: (N/S/E/W) move, (search), or (quit)");
                string input = Console.ReadLine()?.ToLower() ?? "";

                if (input == "quit") break;
                else if (input == "search") currentRoom.OnRoomSearched(player);
                else if (input == "n" && currentRoom.North != null) { currentRoom.OnRoomExit(); currentRoom = currentRoom.North; }
                else if (input == "s" && currentRoom.South != null) { currentRoom.OnRoomExit(); currentRoom = currentRoom.South; }
                else if (input == "e" && currentRoom.East != null) { currentRoom.OnRoomExit(); currentRoom = currentRoom.East; }
                else if (input == "w" && currentRoom.West != null) { currentRoom.OnRoomExit(); currentRoom = currentRoom.West; }
                else Console.WriteLine("Invalid move.");
            }

            Console.WriteLine("Thanks for playing!");
        }

        public static void StartBattle()
        {
            Console.WriteLine("=== Dice Battle ===");
            Player hero = new Player("Hero");
            Player enemy = new Player("Enemy");

            for (int round = 1; round <= 3; round++)
            {
                Console.WriteLine($"\n--- Round {round} ---");
                int heroRoll = hero.TakeTurn();
                int enemyRoll = enemy.TakeTurn();

                if (heroRoll > enemyRoll) Console.WriteLine("Hero wins this round!");
                else if (enemyRoll > heroRoll) Console.WriteLine("Enemy wins this round!");
                else Console.WriteLine("It's a tie!");
            }
        }
    }
}
