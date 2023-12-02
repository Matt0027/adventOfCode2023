using System;
using System.IO;

namespace AdventOfCode2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Day 1

            //var exampleInput = File.ReadAllLines(@"C:\Users\Mine\Documents\AdventOfCodeInput\AoC Day1 Example.txt");
            //Console.WriteLine("The sum is: " + Day1.SumFirstAndLastNum(exampleInput));

            //var dayOneInput = File.ReadAllLines(@"C:\Users\Mine\Documents\AdventOfCodeInput\AoC Day 1 Input.txt");
            //Console.WriteLine("The sum is: " + Day1SumFirstAndLastNum(dayOneInput));

            //var dayOneExampleTwoInput = File.ReadAllLines(@"C:\Users\Mine\Documents\AdventOfCodeInput\AoC Day1 Example2.txt");
            //Console.WriteLine("The sum is: " + Day1SumFirstAndLastNum2(dayOneExampleTwoInput));

            //Console.WriteLine("The sum is: " + Day1.SumFirstAndLastNum2(dayOneInput));

            //-----------------------------------------------------------------------------------------------

            // Day 2
            //var dayTwoExampleInput = File.ReadAllLines(@"C:\Users\Mine\Documents\AdventOfCodeInput\AoC Day2 Example.txt");
            //Console.WriteLine(Day2.Day2Main(dayTwoExampleInput));
            //Console.WriteLine(Day2.Day2Main2(dayTwoExampleInput));

            var dayTwoInput = File.ReadAllLines(@"C:\Users\Mine\Documents\AdventOfCodeInput\AoC Day2 Input.txt");
            Console.WriteLine(Day2.Day2Main(dayTwoInput));
            Console.WriteLine(Day2.Day2Main2(dayTwoInput));
        }
    }
}
