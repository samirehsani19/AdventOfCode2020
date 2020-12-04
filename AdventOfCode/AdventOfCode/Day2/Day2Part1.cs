using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day1
{
    public class Password
    {
        public string PasswordText { get; set; }
        public string UniqueChar { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }

        public List<int> passwords = new List<int>();

        public bool Validate()
        {
            var result = PasswordText.Count(x=> x.ToString() == UniqueChar);
            var data = MinLength <= result && MaxLength >= result;
            return data;
        }
    }
    public class Day2Part1
    {
        public void GetPassword()
        {
            string path = @"Day2/Password.txt";
            string[] lines = File.ReadAllLines(path);

            List<Password> passwordList = new List<Password>();
            foreach (var item in lines)
            {
                var length = Regex.Replace(item.Split()[0], @"[^0-9]+", ",");
                var unique = Regex.Replace(item.Split()[1], @"[^a-zA-Z]", ",");
                var passw = Regex.Replace(item.Split()[2], @"[^a-zA-Z]", ",");
                int minLength =int.Parse(length.Split(',')[0]);
                int maxLength = int.Parse(length.Split(',')[1]);

                passwordList.Add(new Password { PasswordText = passw, UniqueChar = unique.Replace(",", ""), MinLength = minLength, MaxLength=maxLength });
            }

            Day2Part2 p = new Day2Part2();
            p.GetResult(passwordList);

             var result = passwordList.Where(x => x.Validate()).Count();
             Console.WriteLine(result);

        }

    }

    public class Day2Part2
    {
        public void GetResult(List<Password> passwords)
        {
            var passwList = passwords;
            List<string> pass = new List<string>();

            foreach (var item in passwList)
            {
                var condition = item.PasswordText[item.MinLength - 1].ToString() == item.UniqueChar &&
                    item.PasswordText[item.MaxLength - 1].ToString() != item.UniqueChar
                    || item.PasswordText[item.MinLength - 1].ToString() != item.UniqueChar &&
                    item.PasswordText[item.MaxLength - 1].ToString() == item.UniqueChar;

                if (condition)
                {
                    pass.Add(item.PasswordText);
                }

            }

            var result = pass.Count();
            Console.WriteLine(result);
        }
    }
 
}
