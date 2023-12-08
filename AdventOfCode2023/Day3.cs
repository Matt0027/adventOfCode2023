using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace AdventOfCode2023
{
    internal class Day3
    {
        internal static int Day3Main (string[] inputArray)
        {
            var sumReturn = 0;

            // Search each line in the input
            for (var i = 0; i < inputArray.Length; i++)
            {
                var number = 0;
                var firstIndex = -1;
                var lastIndex = -1;
                var symbolFound = false;

                // Search each character in each line of input for a number
                for (var j = 0; j < inputArray[i].Length; j++)
                {
                    if (Char.IsNumber(inputArray[i][j]))
                    { 
                        number = (number * 10) + Convert.ToInt32(new string(inputArray[i][j], 1));

                        if (firstIndex == -1)
                            firstIndex = j;

                        lastIndex = j;
                    }
                    
                    if (!Char.IsNumber(inputArray[i][j]) || j == inputArray[i].Length - 1)
                    {
                        // A number is found if the Indices exist, search for surrounding symbol
                        if (firstIndex >= 0 && lastIndex >= 0)
                        {
                            int beginSearchLine;
                            int endSearchLine;

                            if (i == 0)
                                beginSearchLine = 0;
                            else
                                beginSearchLine = i - 1;

                            if (i == inputArray.Length - 1)
                                endSearchLine = inputArray.Length - 1;
                            else
                                endSearchLine = i + 1;

                            int beginSearchIndex;
                            int endSearchIndex;

                            if (firstIndex == 0)
                                beginSearchIndex = 0;
                            else
                                beginSearchIndex = firstIndex - 1;

                            if (lastIndex == inputArray[i].Length - 1)
                                endSearchIndex = inputArray[i].Length - 1;
                            else
                                endSearchIndex = lastIndex + 1;

                            for (var k = beginSearchLine; k <= endSearchLine && !symbolFound; k++)
                            {
                                for (var l = beginSearchIndex; l <= endSearchIndex; l++)
                                {
                                    if (!Char.IsNumber(inputArray[k][l]) && inputArray[k][l] != '.')
                                    {
                                        symbolFound = true;
                                        break;
                                    }
                                }

                                if (symbolFound)
                                    break;
                            }

                            // If a symbol is found, add the number found to the sum
                            if (symbolFound)
                                sumReturn += number;

                            // Reset fields to look for the next number and it's indices
                            number = 0;
                            firstIndex = -1;
                            lastIndex = -1;
                            symbolFound = false;
                        }
                    }
                }
            }

            return sumReturn;
        }

        internal static int Day3Main2(string[] inputArray)
        {
            var sumReturn = 0;
            var gearDictionary = new Dictionary<string, List<int>>();

            // Search each line in the input
            for (var i = 0; i < inputArray.Length; i++)
            {
                var number = 0;
                var firstIndex = -1;
                var lastIndex = -1;
                var gearFound = false;

                // Search each character in each line of input for a number
                for (var j = 0; j < inputArray[i].Length; j++)
                {
                    if (Char.IsNumber(inputArray[i][j]))
                    {
                        number = (number * 10) + Convert.ToInt32(new string(inputArray[i][j], 1));

                        if (firstIndex == -1)
                            firstIndex = j;

                        lastIndex = j;
                    }

                    if (!Char.IsNumber(inputArray[i][j]) || j == inputArray[i].Length - 1)
                    {
                        // A number is found if the Indices exist, search for surrounding symbol
                        if (firstIndex >= 0 && lastIndex >= 0)
                        {
                            int beginSearchLine;
                            int endSearchLine;

                            if (i == 0)
                                beginSearchLine = 0;
                            else
                                beginSearchLine = i - 1;

                            if (i == inputArray.Length - 1)
                                endSearchLine = inputArray.Length - 1;
                            else
                                endSearchLine = i + 1;

                            int beginSearchIndex;
                            int endSearchIndex;

                            if (firstIndex == 0)
                                beginSearchIndex = 0;
                            else
                                beginSearchIndex = firstIndex - 1;

                            if (lastIndex == inputArray[i].Length - 1)
                                endSearchIndex = inputArray[i].Length - 1;
                            else
                                endSearchIndex = lastIndex + 1;

                            for (var k = beginSearchLine; k <= endSearchLine && !gearFound; k++)
                            {
                                for (var l = beginSearchIndex; l <= endSearchIndex; l++)
                                {
                                    if (inputArray[k][l] == '*')
                                    {
                                        var gearCoord = Convert.ToString(k + "," + l);

                                        // If a symbol is found, add the number found to the sum
                                        gearFound = true;

                                        if (gearDictionary.ContainsKey(gearCoord))
                                            gearDictionary[gearCoord].Add(number);
                                        else
                                            gearDictionary.Add(gearCoord, new List<int> { number });

                                        break;
                                    }
                                }
                            }
                            // Reset fields to look for the next number and it's indices
                            number = 0;
                            firstIndex = -1;
                            lastIndex = -1;
                            gearFound = false;
                        }
                    }
                }
            }

            foreach (KeyValuePair <string, List<int>> kvp in gearDictionary)
            {
                if (kvp.Value.Count == 2)
                {
                    var product = 1;

                    foreach (var value in kvp.Value)
                    {
                        product *= value;
                    }

                    sumReturn += product;
                }
            }

            return sumReturn;
        }
    }
}
