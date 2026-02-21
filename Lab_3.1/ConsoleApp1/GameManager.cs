using System;

namespace Lab_3
{
    public class GameManager
    {
        public void Play()
        {
            
            Console.WriteLine("=== Lab 3 – The Game Manager ===");
            Console.WriteLine("Author: Chris Chuang");
            Console.WriteLine("Date: " + DateTime.Now.ToShortDateString());
            Console.WriteLine();

            
            DieRoller roller = new DieRoller();
            int total = roller.Roll(6, 8, 12, 20);
            Console.WriteLine($"\nTotal Score: {total}\n");

            
            ExplainOperators();

            
            Console.WriteLine("\n=== Goodbye! ===");
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        private void ExplainOperators()
        {
            Console.WriteLine("=== Arithmetic Operators in C# ===");

            int a = 5, b = 3;

            Console.WriteLine($"+ (Addition): {a} + {b} = {a + b}");
            Console.WriteLine($"- (Subtraction): {a} - {b} = {a - b}");
            Console.WriteLine($"* (Multiplication): {a} * {b} = {a * b}");
            Console.WriteLine($"/ (Division): {a} / {b} = {a / b} (integer division)");
            Console.WriteLine($"% (Modulus): {a} % {b} = {a % b}");

            int x = 10;
            Console.WriteLine($"++ (Increment): x = {x}, then x++ = {x++}, now x = {x}");

            int y = 10;
            Console.WriteLine($"-- (Decrement): y = {y}, then y-- = {y--}, now y = {y}");
        }
    }
}