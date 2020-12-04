using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            int amountOftrees = GetTrees(input);
            Console.WriteLine($"Part one: there are {amountOftrees} trees");
        }

        private int GetTrees(string[] input)
        {
            int xLength = input[0].Length;
            int yLength = input.Length;
           
            int xGrow = 3;
            int yGrow = 1;
            
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

     
    }
}
