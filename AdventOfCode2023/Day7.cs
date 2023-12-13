using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Day7
    {
        public static long Day7Main(string[] inputArray)
        {
            var hands = new List<Hand>();
            long totalSum = 0;

            foreach (var input in inputArray)
                hands.Add(new Hand(input.Split(' ')[0], Convert.ToInt32(input.Split(' ')[1])));

            hands.Sort();

            for (var i = 0; i < hands.Count; i++)
                totalSum += (i + 1) * hands[i].bid;

            return totalSum;
        }

        class Hand : IComparable<Hand>
        {
            public string hand;
            public int bid;
            public int strength;
            
            public Hand(string hand, int bid)
            {
                this.hand = hand;
                this.bid = bid;
                this.strength = HandStrength(hand.ToCharArray());
            }

            public int HandStrength(char[] cards)
            {
                var cardCounts = new Dictionary<char, int> {{'A', 0},{'K', 0},{'Q', 0},{'J', 0},{'T', 0},{'9', 0},
                                                   {'8', 0},{'7', 0},{'6', 0},{'5', 0},{'4', 0},{'3', 0},{'2', 0}};

                foreach (var card in cards)
                    cardCounts[card]++;

                if (cardCounts.Any(c => c.Value == 5))
                    return 7;
                if (cardCounts.Any(c => c.Value == 4))
                    return 6;
                if (cardCounts.Any(c => c.Value == 3) && cardCounts.Any(c => c.Value == 2))
                    return 5;
                if (cardCounts.Any(c => c.Value == 3))
                    return 4;
                if (cardCounts.Count(c => c.Value == 2) == 2)
                    return 3;
                if (cardCounts.Any(c => c.Value == 2))
                    return 2;
                else
                    return 1;
            }

            public int CompareTo(Hand other)
            {
                if (other == null)
                    return 1;

                var strengthCompare = strength.CompareTo(other.strength);
                if (strengthCompare != 0)
                    return strengthCompare;
                else
                {
                    var cardValue = new List<char> { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };

                    for (var i = 0; i < hand.Length; i++)
                    {
                        var cardCompare = cardValue.IndexOf(other.hand[i]).CompareTo(cardValue.IndexOf(hand[i]));
                        if (cardCompare != 0)
                            return cardCompare;
                    }
                }
                return 0;
            }
        }

        // Part 2 - Jokers
        public static long Day7Main2(string[] inputArray)
        {
            var hands = new List<Hand2>();
            long totalSum = 0;

            foreach (var input in inputArray)
                hands.Add(new Hand2(input.Split(' ')[0], Convert.ToInt32(input.Split(' ')[1])));

            hands.Sort();

            for (var i = 0; i < hands.Count; i++)
                totalSum += (i + 1) * hands[i].bid;

            return totalSum;
        }

        class Hand2 : IComparable<Hand2>
        {
            public string hand;
            public int bid;
            public int strength;

            public Hand2(string hand, int bid)
            {
                this.hand = hand;
                this.bid = bid;
                this.strength = HandStrength(hand.ToCharArray());
            }

            public int HandStrength(char[] cards)
            {
                var jokerCount = 0;
                var cardCounts = new Dictionary<char, int> {{'A', 0},{'K', 0},{'Q', 0},{'T', 0},{'9', 0},{'8', 0},
                                                            {'7', 0},{'6', 0},{'5', 0},{'4', 0},{'3', 0},{'2', 0}};
                
                foreach (var card in cards)
                {
                    if (card == 'J')
                        jokerCount++;
                    else
                        cardCounts[card]++;
                }

                if (jokerCount > 0)
                {
                    var maxCard = cardCounts.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                    cardCounts[maxCard] += jokerCount;
                }

                if (cardCounts.Any(c => c.Value == 5))
                    return 7;
                if (cardCounts.Any(c => c.Value == 4))
                    return 6;
                if (cardCounts.Any(c => c.Value == 3) && cardCounts.Any(c => c.Value == 2))
                    return 5;
                if (cardCounts.Any(c => c.Value == 3))
                    return 4;
                if (cardCounts.Count(c => c.Value == 2) == 2)
                    return 3;
                if (cardCounts.Any(c => c.Value == 2))
                    return 2;
                else
                    return 1;
            }

            public int CompareTo(Hand2 other)
            {
                if (other == null)
                    return 1;

                var strengthCompare = strength.CompareTo(other.strength);
                if (strengthCompare != 0)
                    return strengthCompare;
                else
                {
                    var cardValue = new List<char> { 'A', 'K', 'Q', 'T', '9', '8', '7', '6', '5', '4', '3', '2', 'J' };

                    for (var i = 0; i < hand.Length; i++)
                    {
                        var cardCompare = cardValue.IndexOf(other.hand[i]).CompareTo(cardValue.IndexOf(hand[i]));
                        if (cardCompare != 0)
                            return cardCompare;
                    }
                }
                return 0;
            }
        }
    }
}
