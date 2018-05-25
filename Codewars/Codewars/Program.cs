using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars
{
    class Program
    {
        static void Main(string[] args)
        {
            var letters = "ABCDEFGHI";
            string[] words = new string[6] { "AB", "AC", "ABC", "ABCD", "ABDH", "ABZDE" };
            List<string> wordsarray = new List<string>();
            foreach (var word in words)
            {
                var cur = letters;
                bool flag = true;
                foreach (var letter in word.ToArray())
                {
                    if (cur.Contains(letter))
                    {
                        cur = cur.Remove(cur.IndexOf(letter), 1);
                    }
                    else
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    wordsarray.Add(word);
                }
            }
            var wordsarr = from word in wordsarray
                           orderby word.Length descending, word
                           select word;
            var result = (from word in wordsarr
                         where word.Length == wordsarr.First().Length
                         select word).ToArray();
            foreach (var s in result)
                Console.WriteLine("{0} ", s);
            Console.ReadKey();
        }
    }
}
