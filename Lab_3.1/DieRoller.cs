using System;

namespace Lab_3
{
    public class DieRoller
    {
        private Random random;

        public DieRoller()
        {
            random = new Random(); 
        }

        
        public int Roll(params int[] sides)
        {
            int total = 0;
            Console.WriteLine("=== Rolling Dice ===");

            for (int i = 0; i < sides.Length; i++)
            {
                int roll = random.Next(1, sides[i] + 1);
                Console.WriteLine($"d{sides[i],-3}: {roll}");
                total += roll;
            }

            return total;
        }
    }
}