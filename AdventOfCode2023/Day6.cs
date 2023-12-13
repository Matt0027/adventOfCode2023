using System;
using System.Linq;

namespace AdventOfCode2023
{
    internal class Day6
    {
        public static int Day6Main(string[] input)
        {
            var times = input[0].Split(':')[1].Trim().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var distances = input[1].Split(':')[1].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int winOptionProduct = 1;
            
            for (var i = 0; i < times.Length; i++)
            {
                winOptionProduct *= CheckRaceWinOptions(times[i], distances[i]);
            }

            return winOptionProduct;
        }

        internal static int CheckRaceWinOptions(int raceTime, int distanceToBeat)
        {
            var winOptionCount = 0;

            for (var holdSec = 0; holdSec <= raceTime; holdSec++)
            {
                var distance = (raceTime - holdSec) * holdSec;

                if (distance > distanceToBeat)
                    winOptionCount += 1;
            }
            
            return winOptionCount;
        }

        // Part 2 - Has larger numbers. Since the distance formula is a parabola, will look for the
        //          first one to win and last one to win and have the difference as the answer
        public static long Day6Main2(string[] input)
        {
            var raceTime = Convert.ToInt64(input[0].Split(':')[1].Trim().Replace(" ",""));
            var distanceToBeat = Convert.ToInt64(input[1].Split(':')[1].Trim().Replace(" ",""));
            long lowestWinOption = 0;
            long highestWinOption = 0;

            // Lowest winning seconds of holding
            for (var holdSec = 0; holdSec <= raceTime; holdSec++)
            {
                if ((raceTime - holdSec) * holdSec > distanceToBeat)
                {
                    lowestWinOption = holdSec;
                    break;
                }
            }

            // Highest winning seconds of holding
            for (var holdSec = raceTime; holdSec <= raceTime; holdSec--)
            {
                if ((raceTime - holdSec) * holdSec > distanceToBeat)
                {
                    highestWinOption = holdSec;
                    break;
                }
            }

            // Count equals distance between range, plus one
            return highestWinOption - lowestWinOption + 1;
        }
    }
}
