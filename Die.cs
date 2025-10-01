using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class Die
    {
        private Random random = new Random();
        public int Sides { get; private set; }

        public Die(int sides)
        {
            Sides = sides;
        }

        public int Roll()
        {
            return random.Next(1, Sides + 1);
        }
    }
}
