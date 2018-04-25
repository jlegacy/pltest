using System;
using System.Collections.Generic;
using System.IO;

namespace LiborApp
{
    class DataApi : IDataApi
    {
        public IEnumerable<LiborValues> LoadLiborData(string filePath)
        {
            var liborList = new List<LiborValues>();
            var reader = ((IDataApi)this).GetStreamReader(filePath);
            return ((IDataApi)this).GetLiborValues(reader, liborList);
        }


        StreamReader IDataApi.GetStreamReader(string filePath)
        {
            try
            {
                var reader = new StreamReader(File.OpenRead(filePath));
                return reader;
            }

            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        IEnumerable<LiborValues> IDataApi.GetLiborValues(StreamReader reader, List<LiborValues> liborList)
        {
            try
            {
                if (reader != null)
                    while (!reader.EndOfStream)
                    {
                        var dailyValue = new LiborValues();
                        var line = reader.ReadLine();
                        if (line != null)
                        {
                            string[] parts = line.Split(new[] { '|' });

                            dailyValue.Name = parts[0];
                            dailyValue.Term = Int32.Parse(parts[1]);
                            dailyValue.Rate = float.Parse(parts[2]);
                        }

                        liborList.Add(dailyValue);
                    }
                return liborList;
            }
            catch (Exception e)
            {
                Console.WriteLine("Errors found in File");
                Console.WriteLine(e.Message);
                return null;
            }

        }
    }
}



