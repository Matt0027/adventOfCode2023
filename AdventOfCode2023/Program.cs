using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

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

            //var dayTwoInput = File.ReadAllLines(@"C:\Users\Mine\Documents\AdventOfCodeInput\AoC Day2 Input.txt");
            //Console.WriteLine(Day2.Day2Main(dayTwoInput));
            //Console.WriteLine(Day2.Day2Main2(dayTwoInput));

            //-----------------------------------------------------------------------------------------------

            // Day 3
            //var dayThreeExampleInput = File.ReadAllLines(@"C:\Users\Mine\Documents\AdventOfCodeInput\AoC Day3 Example.txt");
            //Console.WriteLine(Day3.Day3Main(dayThreeExampleInput));
            //Console.WriteLine(Day3.Day3Main2(dayThreeExampleInput));

            //var dayThreeInput = File.ReadAllLines(@"C:\Users\Mine\Documents\AdventOfCodeInput\AoC Day3 Input.txt");
            //Console.WriteLine(Day3.Day3Main(dayThreeInput));
            //Console.WriteLine(Day3.Day3Main2(dayThreeInput));

            // Day 4
            //var dayFourExampleInput = File.ReadAllLines(@"C:\Users\Mine\Documents\AdventOfCodeInput\AoC Day4 Example.txt");
            ////Console.WriteLine("Example answer: " + Day4.Day4Main(dayFourExampleInput));
            //Console.WriteLine("Example answer: " + Day4.Day4Main2(dayFourExampleInput));

            //var dayFourInput = File.ReadAllLines(@"C:\Users\Mine\Documents\AdventOfCodeInput\AoC Day4 Input.txt");
            ////Console.WriteLine("Answer: " + Day4.Day4Main(dayFourInput));
            //Console.WriteLine("Answer: " + Day4.Day4Main2(dayFourInput));

            // Day 5
            var dayFiveExampleInput = File.ReadAllText(@"C:\Users\Mine\Documents\AdventOfCodeInput\AoC Day5 Example.txt");
            //Console.WriteLine(Day5.Day5Main(dayFiveExampleInput));

            var dayFiveInput = File.ReadAllText(@"C:\Users\Mine\Documents\AdventOfCodeInput\AoC Day5 Input.txt");
            //Console.WriteLine(Day5.Day5Main(dayFiveInput));

            Console.WriteLine(Day5.Day5Main2(dayFiveExampleInput));
            Console.WriteLine(Day5.Day5Main2(dayFiveInput));
        }
    }
}
