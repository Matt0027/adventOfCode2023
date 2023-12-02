using System;
using System.IO;

namespace AdventOfCode2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Day 1

            //var exampleInput = File.ReadAllLines(@"C:\Users\Mine\Documents\AoC Day1 Example.txt");
            //Console.WriteLine("The sum is: " + Day1.SumFirstAndLastNum(exampleInput));

            var dayOneInput = File.ReadAllLines(@"C:\Users\Mine\Documents\AoC Day 1 Input.txt");
            //Console.WriteLine("The sum is: " + Day1SumFirstAndLastNum(dayOneInput));

            //var dayOneExampleTwoInput = File.ReadAllLines(@"C:\Users\Mine\Documents\AoC Day1 Example2.txt");
            //Console.WriteLine("The sum is: " + Day1SumFirstAndLastNum2(dayOneExampleTwoInput));

            Console.WriteLine("The sum is: " + Day1.SumFirstAndLastNum2(dayOneInput));
            
        }
    }
}
