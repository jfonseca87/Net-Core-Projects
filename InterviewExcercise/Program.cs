using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool hasTheSameLetters = StringChallenge("h3llko", "hello");
            Console.WriteLine(hasTheSameLetters);
            Console.ReadKey();
        }

        public static bool StringChallenge(string str1, string str2)
        {
            char[] arrayCaracteresStr1 = str1.ToCharArray();
            int cantCaracteresStr2 = str2.Length;
            int counter = 0;

            for (int i = 0; i < arrayCaracteresStr1.Length; i++)
            {
                if (str2.Contains(arrayCaracteresStr1[i]))
                    counter++;
            }

            return counter == cantCaracteresStr2;
        }
    }
}
