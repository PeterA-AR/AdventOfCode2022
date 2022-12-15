using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day10
    {
        private static List<int> Register = new List<int>() { 1 };

        private static void ExecuteInstruction(string instruction)
        {
            if (instruction.Contains("noop")) Register.Add(Register.Last());

            var instructionSplit = instruction.Split(' ');
            if (instructionSplit.Length == 2 && instructionSplit[0].Equals("addx"))
            {
                int add = int.Parse(instructionSplit[1]);
                int registerVal = Register.Last();
                Register.Add(registerVal);
                Register.Add(registerVal + add);
            }
        }

        private static void PartOne(List<string> input)
        {
            foreach (var line in input)
            {
                ExecuteInstruction(line);
            }
            Console.WriteLine("Cycles Complete: " + Register.Count);
            int ss20 = 20 * Register.ElementAt(20 - 1); Console.WriteLine("Signal Strength @ 20th: " + ss20);
            int ss60 = 60 * Register.ElementAt(60 - 1); Console.WriteLine("Signal Strength @ 60th: " + ss60);
            int ss100 = 100 * Register.ElementAt(100 - 1); Console.WriteLine("Signal Strength @ 100th: " + ss100);
            int ss140 = 140 * Register.ElementAt(140 - 1); Console.WriteLine("Signal Strength @ 140th: " + ss140);
            int ss180 = 180 * Register.ElementAt(180 - 1); Console.WriteLine("Signal Strength @ 180th: " + ss180);
            int ss220 = 220 * Register.ElementAt(220 - 1); Console.WriteLine("Signal Strength @ 220th: " + ss220);
            Console.WriteLine("Sum of Signal Strenght: " + (ss20 + ss60 + ss100 + ss140 + ss180 + ss220));
        }

        public static void main()
        {
            List<string> input = File.ReadAllLines("input.txt").ToList();

            PartOne(input);
        }
    }
}