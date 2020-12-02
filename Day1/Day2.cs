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
    public class Day2
    {
        public void ReadPassword()
        {
            string path = @"Password.txt";
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

             var result = passwordList.Where(x => x.Validate()).Count();
             Console.WriteLine(result);
        }

    }
 
}
