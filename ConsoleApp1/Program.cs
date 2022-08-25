using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Test
    {
        public static void Main()
        {
            try
            {
                // @"C:\Users\Mathias Baasch\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net5.0\flyvning1.csv"
                //@"C:\flyvning1.csv"
                using (var reader = new StreamReader("flyvning1.csv"))
                {
                    List<string> exportSVC = new List<string>();
                    List<string> dataArrays = new List<string>();
                    List<string> gpsLong = new List<string>();
                    List<string> gpsLat = new List<string>();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(";");
                        gpsLat.Add(values[2]);
                        gpsLong.Add(values[3]);
                    }

                    for (int i = 2; i < gpsLong.Count - 1; i++)
                    {
                        gpsLong[i] = gpsLong[i].Replace(".",string.Empty);
                        gpsLong[i] = gpsLong[i].Insert(2, ".");
                    }
                    for (int i = 2; i < gpsLat.Count - 1; i++)
                    {
                        gpsLat[i] = gpsLat[i].Replace(".", string.Empty);
                        gpsLat[i] = gpsLat[i].Insert(1, ".");
                    }
                    for (int i = 0; i < gpsLong.Count - 1; i++)
                    {
                        Console.WriteLine(gpsLat[i]);
                        Console.WriteLine(gpsLong[i]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
