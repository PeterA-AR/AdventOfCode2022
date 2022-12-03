using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day3
    {
        private static List<string> GetInputFile()
        {
            return File.ReadAllLines("input.txt").ToList();
        }

        private static int GetLetterPriority(char letter)
        {
            var letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return (letters.IndexOf(letter) + 1);
        }

        private static List<char> CompareTwo(string compartment1, string compartment2)
        {
            List<char> repeatingChars = new List<char>();

            foreach (char c in compartment1)
            {
                if (compartment2.Contains(c) && !repeatingChars.Contains(c)) repeatingChars.Add(c);
            }

            return repeatingChars;
        }

        private static List<char> CompareThree(string compartment1, string compartment2, string compartment3)
        {
            List<char> repeatingChars = new List<char>();

            foreach (char c in compartment1)
            {
                if (compartment2.Contains(c) && compartment3.Contains(c) && !repeatingChars.Contains(c))
                {
                    repeatingChars.Add(c);
                }
            }

            return repeatingChars;
        }

        private static int ScoreLine(string line)
        {
            int score = 0;
            Console.Write("Length: " + line.Length);

            var compartment1 = line.Substring(0, line.Length / 2);
            Console.Write(" - C1 L: " + compartment1.Length);
            var compartment2 = line.Substring(line.Length / 2);
            Console.Write(" - C2 L: " + compartment2.Length);

            var sharedCharacters = CompareTwo(compartment1, compartment2);

            foreach (char c in sharedCharacters)
            {
                Console.Write(" - Repeating Char: " + c);
                score += GetLetterPriority(c);
            }

            return score;
        }

        private static void PartOne()
        {
            List<string> lines = GetInputFile();
            Console.WriteLine("Number of Lines: " + lines.Count);
            int score = 0;

            foreach (var line in lines)
            {
                var lineScore = ScoreLine(line);
                Console.WriteLine(" - Line Score: " + lineScore);
                score += lineScore;
            }

            Console.WriteLine("Part One Score: " + score);
        }

        private static int ScoreTriplet(string line1, string line2, string line3)
        {
            int score = 0;

            var sharedCharacters = CompareThree(line1, line2, line3);

            foreach (char c in sharedCharacters)
            {
                score += GetLetterPriority(c);
            }

            return score;
        }

        private static void PartTwo()
        {
            List<string> lines = GetInputFile();
            Console.WriteLine("Number of Lines: " + lines.Count);
            int score = 0;

            for (int i = 0; i < lines.Count; i += 3)
            {
                score += ScoreTriplet(lines[i], lines[i + 1], lines[i + 2]);
            }

            Console.WriteLine("Part Two Score: " + score);
        }

        public static void main()
        {
            PartOne();
            PartTwo();
        }
    }
}