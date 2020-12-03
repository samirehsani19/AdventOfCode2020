using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Data
    {
        public void ReadNumbers()
        {
            string path = @"Numbers.txt";
            string[] lines = File.ReadAllLines(path);
            int[] numbers = Array.ConvertAll(lines, s => int.Parse(s));

            var result = from item in numbers.Select((n1, idx) =>
               new { n1, shortList = numbers.Take(idx) })
                         from n2 in item.shortList
                         where item.n1 + n2 == 2020
                         select new { n1 = item.n1, n2 };

            foreach (var item in result)
            {
                Console.WriteLine("the sum of two numbers " + item.n1 + "\t" + item.n2);
                var finalResult = item.n1 * item.n2;
                Console.WriteLine("The result is \t" + finalResult);
            }
        }

    }
    
    public class ResultDay1
    {
        public void GetProduct()
        {
            string path = @"Numbers.txt";
            string[] lines = File.ReadAllLines(path);
            int[] numbers = Array.ConvertAll(lines, s => int.Parse(s));

            List<int> result = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    for (int x = j + 1; x < numbers.Length; x++)
                    {
                        if (numbers[i] + numbers [j] + numbers[x] ==2020)
                        {
                            Console.WriteLine(numbers[i]);
                            Console.WriteLine(numbers[j]);
                            Console.WriteLine(numbers[x]);

                            Console.WriteLine("The product is  \t" + numbers[i] * numbers[j] * numbers [x]);
                        }
                       
                    }
                   
                }
            }
         
        }

    }
}
