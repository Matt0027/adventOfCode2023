using System;
using System.IO;

namespace AdventOfCode2023
{
    internal class Day1
    {
        //public static int SumFirstAndLastNum(string[] array)
        //{
        //    var sum = 0;

        //    foreach (var line in array)
        //    {
        //        int firstNumber = 0;
        //        int lastNumber = 0;

        //        var characterArray = line.ToCharArray();

        //        for (var i = 0; i < characterArray.Length; i++)
        //        {
        //            if (Char.IsNumber(characterArray[i]))
        //            {
        //                firstNumber = Convert.ToInt32(new string(characterArray[i], 1));
        //                break;
        //            }
        //            else if (i == characterArray.Length - 1)
        //                throw new ArgumentException("Number not found in line: " + line);  
        //        }

        //        for (var i = characterArray.Length - 1; i >= 0; i--)
        //        {
        //            if (Char.IsNumber(characterArray[i]))
        //            {
        //                lastNumber = Convert.ToInt32(new string(characterArray[i], 1));
        //                break;
        //            }
        //            else if (i == 0)
        //                throw new ArgumentException("Number not found in line: " + line);
        //        }

        //        sum += (10 * firstNumber) + lastNumber;
        //    }

        //    return sum;
        //}

        public static int SumFirstAndLastNum2(string[] array)
        {
            var sum = 0;
            var numberIntStr = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            var numberTextStr = new string[10] { "zero", "one", "two", "three", "four",
                                                "five", "six", "seven", "eight", "nine"};

            foreach (var line in array)
            {
                int firstNumberIndex = -1;
                int lastNumberIndex = -1;
                int firstNumber = 0;
                int lastNumber = 0;

                for (var i = 0; i < 10; i++)
                {
                    var indexInt = line.IndexOf(numberIntStr[i]);
                    var indexText = line.IndexOf(numberTextStr[i]);

                    if (indexInt >= 0)
                    {
                        if (firstNumberIndex == -1 || indexInt < firstNumberIndex)
                        {
                            firstNumberIndex = indexInt;
                            firstNumber = i;
                        }

                        var lastIndexInt = line.LastIndexOf(numberIntStr[i]);
                        if (lastNumberIndex == -1 || lastIndexInt > lastNumberIndex)
                        {
                            lastNumberIndex = lastIndexInt;
                            lastNumber = i;
                        }
                    }
                    if (indexText >= 0)
                    {
                        if (firstNumberIndex == -1 || indexText < firstNumberIndex)
                        {
                            firstNumberIndex = indexText;
                            firstNumber = i;
                        }

                        var lastIndexText = line.LastIndexOf(numberTextStr[i]);
                        if (lastNumberIndex == -1 || lastIndexText > lastNumberIndex)
                        {
                            lastNumberIndex = lastIndexText;
                            lastNumber = i;
                        }
                    }
                }

                if (firstNumberIndex == -1 || lastNumberIndex == -1)
                    throw new InvalidDataException("No numbers found in line: " + line);

                sum += (10 * firstNumber) + lastNumber;
            }

            return sum;
        }
    }
}
