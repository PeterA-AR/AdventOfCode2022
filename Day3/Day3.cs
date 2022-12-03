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

        private static List<char> CompareCompartments(string compartment1, string compartment2)
        {
            List<char> repeatingChars = new List<char>();

            foreach (char c in compartment1)
            {
                if (compartment2.Contains(c) && !repeatingChars.Contains(c)) repeatingChars.Add(c);
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

            var sharedCharacters = CompareCompartments(compartment1, compartment2);

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

            Console.WriteLine(score);
        }

        public static void main()
        {
            PartOne();
        }
    }
}