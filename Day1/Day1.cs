using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day1
    {
        public static void main()
        {
            Console.WriteLine("Advent of Code - Day 1");

            var list = File.ReadAllLines("..\\..\\..\\Day1_Input.txt").ToArray();

            List<int> sums = new List<int>();

            int biggestNumber = 0;
            int currentSum = 0;

            foreach (string line in list)
            {
                int lineNum = 0;
                if (int.TryParse(line, out lineNum))
                {
                    currentSum += lineNum;
                    continue;
                }
                else
                {
                    sums.Add(currentSum);
                    currentSum = 0;
                    continue;
                }
            }

            for (int i = 0; i < sums.Count; i++)
            {
                biggestNumber = sums[i] > biggestNumber ? sums[i] : biggestNumber;
                Console.WriteLine($"Sum #{i}: {sums[i]}");
            }

            Console.WriteLine("Biggest: " + biggestNumber);

            var top3Sum = sums.OrderByDescending(x => x).Take(3).Sum();

            Console.WriteLine("Top 3 Sum: " + top3Sum);
        }
    }
}