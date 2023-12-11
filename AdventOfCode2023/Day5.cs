using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2023
{
    internal class Day5
    {
        public static long Day5Main(string input)
        {
            var groups = input.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var seeds = groups[0].Split(':')[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            
            // For each map group
            for (var i = 1; i < groups.Length; i++)
            {
                var mapGroupData = groups[i].Split(':')[1].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                // For each seed
                for (var j = 0; j < seeds.Length; j++)
                {
                    // For each map in this group, check for seed mapping 
                    foreach (var map in mapGroupData)
                    {
                        var mapData = map.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                        var destinationStart = mapData[0];
                        var sourceStart = mapData[1];
                        var range = mapData[2];

                        if (seeds[j] >= sourceStart && seeds[j] < sourceStart + range)
                        {
                            seeds[j] = seeds[j] - sourceStart + destinationStart;
                            break;
                        }
                    }
                }
            }

            return seeds.Min();
        }

        public static long? Day5Main2(string input)
        {
            var groups = input.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var seeds = groups[0].Split(':')[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            var seedRanges = new List<long[]> ();
            long? minNumber;

            // Fill seedRanges[] with the start and end values for the starting seed values
            for (var i = 0; i < seeds.Length; i++)
            {
                if (i % 2 == 0)
                    seedRanges.Add(new long[] { seeds[i], seeds[i] + seeds[i + 1] - 1 });
            }

            // For each map group
            for (var i = 1; i < groups.Length; i++)
            {
                var mapGroupData = groups[i].Split(':')[1].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                var newRangeBuffer = new List<long[]>();

                // For each seed range
                for (var j = 0; j < seedRanges.Count; j++)
                {
                    // For each map in this group, check for seed mapping 
                    for (var k = 0; k < mapGroupData.Length; k++)
                    {
                        var mapData = mapGroupData[k].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                        var destinationStart = mapData[0];
                        var sourceStart = mapData[1];
                        var range = mapData[2];
                        var sourceEnd = sourceStart + range - 1;
                        var destinationEnd = destinationStart + range - 1;

                        var seedRangeStart = seedRanges[j][0];
                        var seedRangeEnd = seedRanges[j][1];

                        if (seedRangeStart >= sourceStart && seedRangeStart <= sourceEnd)
                        {
                            // Whole seed range is in map range
                            if (seedRangeEnd >= sourceStart && seedRangeEnd <= sourceEnd)
                            {
                                newRangeBuffer.Add(new long[] { (seedRangeStart - sourceStart + destinationStart), (seedRangeEnd - sourceStart + destinationStart) });
                                break;
                            }
                            // Only the beginning of the seed range is in the map range
                            else
                            {
                                newRangeBuffer.Add(new long[] { (seedRangeStart - sourceStart + destinationStart), destinationEnd });
                                seedRanges.Add(new long[] {(sourceEnd + 1), seedRangeEnd });
                                break;
                            }
                        }
                        // Only the end of the seed rand is in the map
                        else if (seedRangeEnd >= sourceStart && seedRangeEnd <= sourceEnd)
                        {
                            newRangeBuffer.Add(new long[] { destinationStart, (seedRangeEnd - sourceStart + destinationStart) });
                            seedRanges.Add(new long[] { seedRangeStart, (sourceStart - 1) });
                            break;
                        }
                        // The map range is in the middle of the seed range
                        else if (sourceStart > seedRangeStart && sourceEnd < seedRangeEnd)
                        {
                            seedRanges.Add(new long[] { seedRangeStart, (sourceStart - 1) });
                            newRangeBuffer.Add(new long[] { destinationStart, destinationEnd });
                            seedRanges.Add(new long[] { (sourceEnd + 1), seedRangeEnd });
                            break;
                        }
                        // The seed range and map range do not overlap at all
                        else
                        {
                            // If all maps have been checked, copy range to buffer
                            if (k == mapGroupData.Length - 1)
                                newRangeBuffer.Add(new long[] { seedRangeStart, seedRangeEnd });
                        } 
                    }
                }

                seedRanges.Clear();
                seedRanges = new List<long[]>(newRangeBuffer);
                newRangeBuffer.Clear();
            }

            minNumber = seedRanges[0][0];

            foreach (var seedRange in seedRanges)
            {
                if (seedRange[0] < minNumber)
                    minNumber = seedRange[0];
            }

            return minNumber;
        }
    }
}
