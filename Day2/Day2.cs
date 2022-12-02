using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day2
    {
        private static Dictionary<string, int> Shapes = new Dictionary<string, int>
        {
            {"A", 1}, // Rock
            {"B", 2}, // Paper
            {"C", 3}, // Scissors
            {"X", 1}, // Rock || Loss
            {"Y", 2}, // Paper || Draw 
            {"Z", 3}  // Scissors || Win
        };

        private enum Result
        {
            Loss = 0,
            Draw = 3,
            Win = 6
        }

        private static int PlayRound(int theirMove, int yourMove)
        {
            // Draw
            if (theirMove.Equals(yourMove)) return yourMove + (int)Result.Draw;

            // Beat rock with  paper
            if (theirMove == 1 && yourMove == 2) return (int)Result.Win + yourMove;

            // Beat paper with scissors
            if (theirMove == 2 && yourMove == 3) return (int)Result.Win + yourMove;

            // Beat scissors with rock
            if (theirMove == 3 && yourMove == 1) return (int)Result.Win + yourMove;

            // Otherwise, loss
            return yourMove + (int)Result.Loss;
        }

        private static void PartOne()
        {
            List<string> input = File.ReadAllLines("..\\..\\..\\Day2.txt").ToList();

            int totalScore = 0;
            char delim = ' ';

            foreach (string line in input)
            {
                string[] lineSplit = line.Split(delim);
                totalScore += PlayRound(Shapes[lineSplit[0]], Shapes[lineSplit[1]]);
            }

            Console.WriteLine(totalScore);
        }

        private static void PartTwo()
        {
            List<string> input = File.ReadAllLines("..\\..\\..\\Day2.txt").ToList();

            int totalScore = 0;
            char delim = ' ';

            foreach (string line in input)
            {
                string[] lineSplit = line.Split(delim);

                Result requiredResult = RequiredResult(lineSplit[1]);

                int yourMove = 0;
                int theirMove = Shapes[lineSplit[0]];
                switch (requiredResult)
                {
                    case Result.Loss:
                        yourMove = CalculateLoss(theirMove);
                        break;

                    case Result.Draw:
                        yourMove = theirMove;
                        break;

                    case Result.Win:
                        yourMove = CalculateWin(theirMove);
                        break;

                    default:
                        break;
                }

                totalScore += PlayRound(theirMove, yourMove);
            }

            Console.WriteLine(totalScore);
        }

        private static Result RequiredResult(string move)
        {
            if (Shapes[move] == 1) return Result.Loss;
            if (Shapes[move] == 2) return Result.Draw;
            if (Shapes[move] == 3) return Result.Win;
            return Result.Loss;
        }

        private static int CalculateLoss(int theirMove)
        {
            if (theirMove == 1) return 3;
            if (theirMove == 2) return 1;
            if (theirMove == 3) return 2;
            return 0;
        }

        private static int CalculateWin(int theirMove)
        {
            if (theirMove == 1) return 2;
            if (theirMove == 2) return 3;
            if (theirMove == 3) return 1;
            return 0;
        }

        public static void main()
        {
            PartTwo();
        }
    }
}