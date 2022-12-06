using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day6
    {
        private static bool IsMarker(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                string trimPut = input.Remove(i, 1);
                if (trimPut.Contains(c)) return false;
            }
            return true;
        }

        private static void PartTwo()
        {
            string input = File.ReadAllText("input.txt");
            int count = 14;

            for (int i = 13; i < input.Length; i++)
            {
                if (IsMarker(input.Substring(i - 13, 14)))
                {
                    Console.WriteLine("Characters checked before message found: " + count); return;
                }
                count++;
            }
        }

        private static void PartOne()
        {
            string input = File.ReadAllText("input.txt");
            int count = 4;

            for (int i = 3; i < input.Length; i++)
            {
                if (IsMarker(input.Substring(i - 3, 4)))
                {
                    Console.WriteLine("Characters checked before marker found: " + count); return;
                }
                count++;
            }
        }

        public static void main()
        {
            //PartOne();
            PartTwo();
        }
    }
}