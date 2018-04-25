using System;
using System.IO;
using System.Linq.Expressions;

namespace SearchDirectory
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Only get files that begin with the letter "c."
                string path = Path.GetFullPath("../../searchFolder");
                string output = Path.GetFullPath("../../WriteLines.txt");

                const string searchFilePattern = "*";
                const string searchLinePattern = "one";

                var di = new DirectoryInfo(path);
                var numberOfLines = 0;
                var numberOfMatches = 0;

                var files = di.GetFiles(searchFilePattern, SearchOption.AllDirectories);

                using (var outputFile = new System.IO.StreamWriter(output))
                {
                    foreach (FileInfo file in files)
                    {
                        string[] lines = File.ReadAllLines(file.DirectoryName + '\\' + file);
                        foreach (var x in lines)
                        {
                            if (x.Contains(searchLinePattern))
                            {
                                int i = 0;
                                while ((x.IndexOf(searchLinePattern, i, System.StringComparison.Ordinal)) != -1)
                                {
                                    i += searchLinePattern.Length;
                                    numberOfMatches++;
                                }

                                numberOfLines += 1;
                                try
                                {
                                    outputFile.WriteLine(x);
                                }

                                catch (Exception e)
                                {
                                    Console.WriteLine("Error Writing to Output File");
                                }
                            }
                        }

                    }

                    outputFile.Close();

                    Console.WriteLine("Total Number of Files Searched : " + files.Length);
                    Console.WriteLine("Matching Number of Lines : " + numberOfLines);
                    Console.WriteLine("Matching Number of Occurrences: " + numberOfMatches);

                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

    }
}
