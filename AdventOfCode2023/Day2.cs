using System;
using System.IO;

namespace AdventOfCode2023
{
    internal class Day2
    {
        internal static int Day2Main (string[] inputArray)
        {
            var sum = 0;
            const int maxRedBalls = 12;
            const int maxGreenBalls = 13;
            const int maxBlueBalls = 14;

            foreach (var line in inputArray)
            {
                var semicolonSplit = line.Split(':');
                var gameNum = Convert.ToInt32(semicolonSplit[0].Split(' ')[1]);
                var randDraws = semicolonSplit[1].Split(';');

                var impossibleDraw = false;

                foreach (var draw in randDraws)
                {
                    var numColor = draw.Split(',');

                    foreach (var color in numColor)
                    {
                        var numOfBalls = Convert.ToInt32(color.Trim().Split(' ')[0]);
                        var colorOfBalls = color.Trim().Split(' ')[1];

                        if (colorOfBalls == "red")
                        {
                            if (numOfBalls > maxRedBalls)
                                impossibleDraw = true;
                        }
                        else if (colorOfBalls == "green")
                        {
                            if (numOfBalls > maxGreenBalls)
                                impossibleDraw = true;
                        }
                        else if (colorOfBalls == "blue")
                        {
                            if (numOfBalls > maxBlueBalls)
                                impossibleDraw = true;
                        }
                        else
                            impossibleDraw = true;

                        if (impossibleDraw)
                            break;
                    }
                }

                if (!impossibleDraw)
                    sum += gameNum;
            }

            return sum;
        }

        internal static int Day2Main2 (string[] inputArray)
        {
            var sum = 0;
            //const int maxRedBalls = 12;
            //const int maxGreenBalls = 13;
            //const int maxBlueBalls = 14;

            foreach (var line in inputArray)
            {
                var semicolonSplit = line.Split(':');
                var gameNum = Convert.ToInt32(semicolonSplit[0].Split(' ')[1]);
                var randDraws = semicolonSplit[1].Split(';');

                //var impossibleDraw = false;
                var minRedBalls = 0;
                var minBlueBalls = 0;
                var minGreenBalls = 0;

                foreach (var draw in randDraws)
                {
                    var numColor = draw.Split(',');

                    foreach (var color in numColor)
                    {
                        var numOfBalls = Convert.ToInt32(color.Trim().Split(' ')[0]);
                        var colorOfBalls = color.Trim().Split(' ')[1];

                        if (colorOfBalls == "red")
                        {
                            if (numOfBalls > minRedBalls)
                                minRedBalls = numOfBalls;
                        }
                        else if (colorOfBalls == "green")
                        {
                            if (numOfBalls > minGreenBalls)
                                minGreenBalls = numOfBalls;
                        }
                        else if (colorOfBalls == "blue")
                        {
                            if (numOfBalls > minBlueBalls)
                                minBlueBalls = numOfBalls;
                        }
                        else
                            throw new InvalidDataException("The color is not red, blue, or green for Game " + gameNum);
                    }
                }

                sum += (minRedBalls * minGreenBalls * minBlueBalls);
            }

            return sum;
        }
    }
}
