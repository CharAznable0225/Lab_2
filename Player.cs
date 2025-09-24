using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class Player
    {
        public string Name { get; set; }
        public int CurrentRoll { get; set; }
        public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
            CurrentRoll = 0;
            Score = 0;
        }
    }
}
