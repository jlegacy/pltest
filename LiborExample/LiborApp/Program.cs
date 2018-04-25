using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace LiborApp
{
    internal static class Program
    {

        private static void Main(string[] args)
        {
            var dataApi = new DataApi();
            string filePath = Path.GetFullPath("../../TextFile1.csv");
            var liborList = dataApi.LoadLiborData(
               filePath);
           
            if (liborList != null)
            {
                foreach (var value in liborList)
                {
                    Console.WriteLine(value.Name);
                    Console.WriteLine(value.Term);
                    Console.WriteLine(value.Rate);
                }
            }
            else
            {
                Console.WriteLine("No records read");
            }

            Console.ReadLine();

        }
    }
}

