using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day3
{
    public class Day3Part1
    {
        public void ReadData()
        {
            string path = @"Day3/Trees.txt";
            var input = File.ReadAllLines(path);

            //part one
            int xGrow = 3;
            int yGrow = 1;
            int amountOftrees = GetTrees(input, xGrow, yGrow);
            Console.WriteLine($"Part one: there are {amountOftrees} trees");

            BigInteger part2Result = GetPartTwoResult(input);
            Console.WriteLine($"Part two: there are {part2Result} trees");
        }

        private static int GetTrees(string[] input, int xGrow, int yGrow)
        {
            int xLength = input[0].Length;
            int yLength = input.Length;
            
            int totalTrees = 0;
            int x = 0;
            int y = 0;


            while (y != yLength - 1)
            {
                y += yGrow;
                x += xGrow;
                if (x >= xLength)
                {
                    x -= xLength;
                }

                char map = input[y][x];
                if (map.ToString() == "#")
                {
                    totalTrees++;
                }
            }
            return totalTrees;
          
        }

        private static BigInteger GetPartTwoResult(string[] input)
        {
            List<int> trees = new List<int>();
            List<Slope> slopes = new List<Slope>()
            {
                new Slope(){ X=1, Y=1},
                new Slope(){ X=3, Y=1},
                new Slope(){ X=5, Y=1},
                new Slope(){ X=7, Y=1},
                new Slope(){ X=1, Y=2}
            };

            foreach (Slope slope in slopes) trees.Add(GetTrees(input, slope.X, slope.Y));
            return trees.Aggregate(BigInteger.One, (x, y) => x * y);
        }
    }

    internal class Slope
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
