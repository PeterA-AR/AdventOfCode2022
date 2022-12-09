using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day9
    {
        private static List<Point> headPoints = new List<Point>() { new Point(0, 0) };
        private static List<Point> tailPoints = new List<Point>() { new Point(0, 0) };

        private static List<List<Point>> longTail = new List<List<Point>>();

        private static int tailHits = 0;

        // Add the direction and amount as a new Point to headPoints

        // Update tailPoint to be 1-less in the coordinate with the difference over the previous move
        private static void MoveTail(List<Point> tailPoints, string direction)
        {
            Point currentTail = tailPoints.Last();
            Point currentHead = headPoints.Last();
            if (IsNear(currentHead, currentTail))
            {
                WritePoints(direction);
                return;
            }

            int xDiff = currentHead.X - currentTail.X;
            int yDiff = currentHead.Y - currentTail.Y;

            int newX, newY;
            if (direction == "U" || direction == "D")
            {
                newX = currentHead.X;
                xDiff = 0;
            }
            else
            {
                newX = currentTail.X + xDiff;
            }

            if (direction == "L" || direction == "R")
            {
                newY = currentHead.Y;
                yDiff = 0;
            }
            else
            {
                newY = currentTail.Y + yDiff;
            }

            if (xDiff != 0 && newX == currentHead.X)
            {
                newX = xDiff < 0 ? newX + 1 : newX - 1;
            }

            if (yDiff != 0 && newY == currentHead.Y)
            {
                newY = yDiff < 0 ? newY + 1 : newY - 1;
            }

            Point newTail = new Point() { X = newX, Y = newY };

            if (tailPoints.Contains(newTail)) tailHits++;
            tailPoints.Add(newTail);
            WritePoints(direction + " 1");
        }

        private static bool IsNear(Point head, Point tail)
        {
            int xDiff = head.X - tail.X;
            int yDiff = head.Y - tail.Y;
            // IS NEAR IF BOTH DIFFS ARE WITHIN 1 UNIT
            return ((-2 < xDiff && xDiff < 2) && (-2 < yDiff && yDiff < 2));
        }

        public static int NumberOfPointsBetween(Point point1, Point point2)
        {
            int xDiff = point1.X - point2.X;
            int yDiff = point1.Y - point2.Y;
            xDiff = xDiff < 0 ? xDiff * -1 : xDiff;
            yDiff = yDiff < 0 ? yDiff * -1 : yDiff;
            if (xDiff > yDiff)
            {
                return xDiff;
            }
            else
            {
                return yDiff;
            }
        }

        private static void MoveHead(string direction, int moveAmount)
        {
            Point currentHead = headPoints.Last();
            switch (direction)
            {
                case "U":
                    headPoints.Add(new Point { X = currentHead.X, Y = currentHead.Y + moveAmount });
                    break;

                case "D":
                    headPoints.Add(new Point { X = currentHead.X, Y = currentHead.Y - moveAmount });
                    break;

                case "R":
                    headPoints.Add(new Point { X = currentHead.X + moveAmount, Y = currentHead.Y });
                    break;

                case "L":
                    headPoints.Add(new Point { X = currentHead.X - moveAmount, Y = currentHead.Y });
                    break;
            }
        }

        private static void WritePoints(string header)
        {
            //Console.WriteLine(header + "\t H: " + headPoints.Last().ToString() + "\t T: " + tailPoints.Last().ToString());
        }

        private static void PartOne(List<string> lines)
        {
            WritePoints("0 0");
            Console.Write("\n");
            foreach (string line in lines)
            {
                var lineSplit = line.Split(' ');
                var direction = lineSplit[0];
                var moveAmount = int.Parse(lineSplit[1]);

                for (int i = 1; i <= moveAmount; i++)
                {
                    MoveHead(direction, 1);
                    MoveTail(tailPoints, direction);
                }
            }

            var distinctTails = tailPoints.Distinct().ToList();
            Console.WriteLine("Tail Points: " + distinctTails.Count());
        }

        private static void PartTwo(List<string> lines)
        {
            for (int i = 0; i < 9; i++)
            {
                longTail.Add(new List<Point>() { new Point(0, 0) });
            }

            foreach (string line in lines)
            {
                var lineSplit = line.Split(' ');
                var direction = lineSplit[0];
                var moveAmount = int.Parse(lineSplit[1]);

                for (int i = 1; i <= moveAmount; i++)
                {
                    MoveHead(direction, 1);
                    foreach (var tailBit in longTail)
                    {
                        MoveTail(tailBit, direction);
                    }
                }
            }

            int count = 0;
            foreach (var tailBit in longTail)
            {
                count += tailBit.Distinct().ToList().Count();
            }
            Console.WriteLine("Part 2: " + count);
        }

        public static void main()
        {
            List<string> lines = File.ReadAllLines("input.txt").ToList();
            //PartOne(lines);
            PartTwo(lines);
        }
    }
}