using System;

namespace Testing
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Whats is your name ?");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}");
        }
    }
}