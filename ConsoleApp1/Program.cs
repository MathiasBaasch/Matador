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
                using (var reader = new StreamReader(@"C:\flyvning1.csv"))
                {
                    List<string> ExportSVC = new List<string>();
                    List<string> DataArrays = new List<string>();
                    List<string> gpsLong = new List<string>();
                    List<string> gpsLat = new List<string>();

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(";");
                        gpsLong.Add(values[2]);
                        gpsLong.Add(values[3]);
                    }

                    for (int i = 2; i < gpsLong.Count - 1; i++)
                    {
                        gpsLong[i] = gpsLong[i].Replace(".",string.Empty);
                        gpsLong[i] = gpsLong[i].Insert(1, ".");
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
