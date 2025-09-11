namespace GD13_Lab1_Chris_Chuang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Hello, World!");

            {
                System.Console.WriteLine("Hello! My name is Chris, today is " + System.DateTime.Today.ToString("yyyy-MM-dd") + ".\n");

                int[] nums = { 0, 1, 2, 4, 8, 16, 32, 64, 100, 255 };

                foreach (int n in nums)
                    System.Console.WriteLine("Decimal: " + n +
                                             " → Binary: " + System.Convert.ToString(n, 2) +
                                             " → Hex: " + n.ToString("X"));

                System.Console.WriteLine("\nGoodbye from Chris! Program finished on " + System.DateTime.Today.ToString("yyyy-MM-dd") + ".");
            }
        }
    }
}
