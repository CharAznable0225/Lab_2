using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Map
    {
        private Room[,] grid;
        private int size;

        public Map(int size)
        {
            this.size = size;
            grid = new Room[size, size];
            Generate();
            LinkNeighbors();
        }

        private void Generate()
        {
            Random rand = new Random();
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (rand.Next(2) == 0)
                        grid[r, c] = new TreasureRoom();
                    else
                        grid[r, c] = new EncounterRoom();
                }
            }
        }

        private void LinkNeighbors()
        {
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    Room room = grid[r, c];
                    room.North = (r > 0) ? grid[r - 1, c] : null;
                    room.South = (r < size - 1) ? grid[r + 1, c] : null;
                    room.West = (c > 0) ? grid[r, c - 1] : null;
                    room.East = (c < size - 1) ? grid[r, c + 1] : null;
                }
            }
        }

        public Room StartRoom() => grid[0, 0];
    }
}
