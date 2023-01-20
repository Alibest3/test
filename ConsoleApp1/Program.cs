using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Part_1(word,number));
            Console.ReadLine();
        }
        static int Part_1(string word,int number)
        {
 
            int occurness = 0;

            for (int i = 0; i < 100000; i++)
            {
                StreamReader sr = new StreamReader($"E:\\ds-project\\ds-project\\DataSet\\Text_{Convert.ToString(i)}.txt");
                int count = 0;
                while (!sr.EndOfStream)
                {
                    var counts = sr
                        .ReadLine()
                        .Split(' ')
                        .GroupBy(s => s)
                        .Select(g => new { Word = g.Key, Count = g.Count() });
                    var wc = counts.SingleOrDefault(c => c.Word == word);
                    count += (wc == null) ? 0 : wc.Count;
                }

                if (count >= number && count != 0)
                {
                    Console.WriteLine(i);
                    occurness += 1;
                }
                   
            }
            return occurness;
        }
    }
}
