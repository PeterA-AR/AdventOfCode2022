using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day4
    {
        private static (int, int) pairParts(string pair)
        {
            return (int.Parse(pair.Split('-')[0]), int.Parse(pair.Split('-')[1]));
        }

        private static bool isPairOverlap(string pair1, string pair2)
        {
            var pair1Parts = pairParts(pair1);
            var pair2Parts = pairParts(pair2);

            return (pair1Parts.Item1 >= pair2Parts.Item1 && pair1Parts.Item2 <= pair2Parts.Item2) || (pair2Parts.Item1 >= pair1Parts.Item1 && pair2Parts.Item2 <= pair1Parts.Item2);
        }

        public static void PartOne()
        {
            List<string> lines = File.ReadAllLines("input.txt").ToList();
            int count = 0;
            foreach (string line in lines)
            {
                Console.Write(line);
                string[] split = line.Split(',');
                string pair1 = split[0];
                string pair2 = split[1];
                if (isPairOverlap(pair1, pair2))
                {
                    count++;
                    Console.Write(" - overlaps");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Number of Overlapping Pairs: " + count);
        }

        public static void main()
        {
            PartOne();
        }
    }
}