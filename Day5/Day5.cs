using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day5
    {
        private static Stack<char> stack1 = new Stack<char>("tdwzvp".ToCharArray());
        private static Stack<char> stack2 = new Stack<char>("lswvfjd".ToCharArray());
        private static Stack<char> stack3 = new Stack<char>("zmlsvtbh".ToCharArray());
        private static Stack<char> stack4 = new Stack<char>("rsj".ToCharArray());
        private static Stack<char> stack5 = new Stack<char>("czbgfmlw".ToCharArray());
        private static Stack<char> stack6 = new Stack<char>("qwvhzrgb".ToCharArray());
        private static Stack<char> stack7 = new Stack<char>("vjpcbdn".ToCharArray());
        private static Stack<char> stack8 = new Stack<char>("ptbq".ToCharArray());
        private static Stack<char> stack9 = new Stack<char>("hgzrc".ToCharArray());

        private static Dictionary<string, Stack<char>> stacks = new Dictionary<string, Stack<char>>();

        private static void InitStacks()
        {
            stacks.Add("1", stack1);
            stacks.Add("2", stack2);
            stacks.Add("3", stack3);
            stacks.Add("4", stack4);
            stacks.Add("5", stack5);
            stacks.Add("6", stack6);
            stacks.Add("7", stack7);
            stacks.Add("8", stack8);
            stacks.Add("9", stack9);
        }

        private static void ProcessInstruction(string instruction)
        {
            var instructionSplit = instruction.Split(' ');
            var numToMove = int.Parse(instructionSplit[0]);
            var sourceStack = instructionSplit[1];
            var targetStack = instructionSplit[2];

            Console.WriteLine("Before"); PrintStacks();
            for (int i = 0; i < numToMove; i++)
            {
                stacks[targetStack].Push(stacks[sourceStack].Pop());
            }
            Console.WriteLine("\nAfter"); PrintStacks();
            Console.WriteLine("\n\n");
        }

        private static void ProcessInstruction9001(string instruction)
        {
            var instructionSplit = instruction.Split(' ');
            var numToMove = int.Parse(instructionSplit[0]);
            var sourceStack = instructionSplit[1];
            var targetStack = instructionSplit[2];

            Console.WriteLine("Before"); PrintStacks();
            for (int i = 0; i < numToMove; i++)
            {
                stacks[targetStack].Push(stacks[sourceStack].Pop());
            }
            Console.WriteLine("\nAfter"); PrintStacks();
            Console.WriteLine("\n\n");
        }

        private static void PrintStacks()
        {
            foreach (var stack in stacks)
            {
                Console.Write("Stack " + stack.Key + ": "); PrintStack(stack.Value);
            }
        }

        private static void PrintStack(Stack<char> stack)
        {
            foreach (var item in stack)
            {
                Console.Write($"[{item}]");
            }
            Console.WriteLine();
        }

        private static void PrintTopCrates()
        {
            string crates = "";
            foreach (var stack in stacks)
            {
                crates += stack.Value.First().ToString();
            }
            Console.WriteLine("Top Crates String: " + crates);
        }

        private static void PartOne()
        {
            InitStacks();
            List<string> lines = File.ReadAllLines("input.txt").ToList();

            foreach (string line in lines)
            {
                var trimLine = line.Replace("move ", "").Replace("from ", "").Replace("to ", "");
                Console.WriteLine("Instructions: " + trimLine);
                ProcessInstruction(trimLine);
            }
            PrintTopCrates();
        }

        private static void PartTwo()
        {
            InitStacks();
            List<string> lines = File.ReadAllLines("input.txt").ToList();

            foreach (string line in lines)
            {
                var trimLine = line.Replace("move ", "").Replace("from ", "").Replace("to ", "");
                Console.WriteLine("Instructions: " + trimLine);
                ProcessInstruction9001(trimLine);
            }
            PrintTopCrates();
        }

        public static void main()
        {
            PartOne();
        }
    }
}