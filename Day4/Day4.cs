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

        private static bool isPairOverlapEntirely(string pair1, string pair2)
        {
            var p1 = pairParts(pair1);
            var p2 = pairParts(pair2);

            return (p1.Item1 >= p2.Item1 && p1.Item2 <= p2.Item2) || (p2.Item1 >= p1.Item1 && p2.Item2 <= p1.Item2);
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
                if (isPairOverlapEntirely(pair1, pair2))
                {
                    count++;
                    Console.Write(" - overlaps");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Number of Entirely Overlapping Pairs: " + count);
        }

        private static bool isPairOverlap(string pair1, string pair2)
        {
            var p1 = pairParts(pair1);
            var p2 = pairParts(pair2);

            bool overlapsEntirely = isPairOverlapEntirely(pair1, pair2);

            return overlapsEntirely || (p1.Item2 <= p2.Item1 || p1.Item1 <= p2.Item2) && (p2.Item2 <= p1.Item1 || p2.Item1 <= p1.Item2);
        }

        private static void PartTwo()
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
            //PartOne();
            PartTwo();
        }
    }
}