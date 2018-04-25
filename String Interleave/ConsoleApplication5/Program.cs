using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write(InterleaveString("abdce", "223345"));
            Console.ReadLine();
        }

        private static string InterleaveString(string str1, string str2)
        {
            var result = new List<char>();
            int maxElements = str1.Length > str2.Length ? str1.Length : str2.Length;

            for (var z = 0; z < maxElements; z++)
            {
                if (z < str1.Length)
                    result.Add(str1[z]);
                if (z < str2.Length)
                    result.Add(str2[z]);
            }

            return (string.Join("", result.ToArray()));
        }
    }
}



