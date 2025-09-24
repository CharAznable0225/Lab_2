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

        public int Roll(int sides)
        {
            return random.Next(1, sides + 1);
        }
    }
}
