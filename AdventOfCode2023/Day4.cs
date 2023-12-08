using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Day4
    {
        // Part 1
        internal static int Day4Main (string[] inputArray)
        {
            var returnNumber = 0;
            foreach (var card in inputArray)
            {
                var winningNums = ((card.Split(':')[1]).Split('|')[0]).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var myNums = ((card.Split(':')[1]).Split('|')[1]).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var cardValue = 0;
                
                foreach (var winningNum in winningNums)
                {
                    if (myNums.Contains(winningNum))
                    {
                        if (cardValue == 0)
                            cardValue = 1;
                        else
                            cardValue *= 2;
                    }
                }

                returnNumber += cardValue;
            }

            return returnNumber;
        }

        // Part 2
        internal static int Day4Main2 (string[] inputArray)
        {
            var copyCards = new Dictionary<int, int>();
            int totalCopies = 0;

            // Loop through each card
            for (var i = 0; i < inputArray.Length; i++)
            {
                var winningNums = ((inputArray[i].Split(':')[1]).Split('|')[0]).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var myNums = ((inputArray[i].Split(':')[1]).Split('|')[1]).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var matchCounter = 0;

                // Count the number of matches on this card
                foreach (var winningNum in winningNums)
                {
                    if (myNums.Contains(winningNum))
                    {
                        matchCounter += 1;
                    }
                }

                // For every match on card, add a copy to that many of the next cards for each instance of this card
                for (var j = 1; j <= matchCounter; j++)
                {
                    var cardCount = 1;

                    if (copyCards.ContainsKey(i))
                        cardCount += copyCards[i];

                    if (copyCards.ContainsKey(i + j))
                        copyCards[i + j] += cardCount;
                    else
                        copyCards.Add(i + j, cardCount);
                }
            }

            foreach (KeyValuePair<int,int> pair in copyCards)
                totalCopies += pair.Value;

            // Return the sum of all cards (original + total copies)
            return (inputArray.Length + totalCopies);
        }
    }
}
