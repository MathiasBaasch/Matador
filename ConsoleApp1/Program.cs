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

                string finalLine = string.Empty;
                // @"C:\Users\Mathias Baasch\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net5.0\flyvning1.csv"
                //@"C:\flyvning1.csv"
                using (var reader = new StreamReader("flyvning1.csv"))
                {
                    List<string> exportSVC = new List<string>();
                    List<string> dataArrays = new List<string>();

                    List<string> ticks = new List<string>();
                    List<string> offSetTime = new List<string>();
                    List<string> gpsLong = new List<string>();
                    List<string> gpsLat = new List<string>();
                    List<string> gpsDate = new List<string>();
                    List<string> gpsTime = new List<string>();
                    List<string> gpsHeightMSL = new List<string>();
                    List<string> gpshDOP = new List<string>();
                    List<string> gpspDOP = new List<string>();
                    List<string> gpssAcc = new List<string>();
                    List<string> gpsnumGPS = new List<string>();
                    List<string> gpsnumGLNAS = new List<string>();
                    List<string> gpsnumSV = new List<string>();
                    List<string> gpscombinded = new List<string>();
                    int u = 0;

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(";");
                        ticks.Add(values[0]);
                        offSetTime.Add(values[1]);
                        gpsLat.Add(values[2]);
                        gpsLong.Add(values[3]);
                        gpsDate.Add(values[4]);
                        gpsTime.Add(values[5]);
                        gpsHeightMSL.Add(values[6]);
                        gpshDOP.Add(values[7]);
                        gpspDOP.Add(values[8]);
                        gpssAcc.Add(values[9]);
                        gpsnumGPS.Add(values[10]);
                        gpsnumGLNAS.Add(values[11]);
                        gpsnumSV.Add(values[12]);
                        //gpscombinded.Add(values[13]);
                        if (u == 0)
                        {
                            finalLine = line + "; GPSKoord \n";
                        }
                        u++;
                    }

                    for (int i = 2; i < gpsLong.Count; i++)
                    {
                        gpsLong[i] = gpsLong[i].Replace(".",string.Empty);
                        gpsLong[i] = gpsLong[i].Insert(2, ".");
                    }
                    for (int i = 2; i < gpsLat.Count; i++)
                    {
                        gpsLat[i] = gpsLat[i].Replace(".", string.Empty);
                        gpsLat[i] = gpsLat[i].Insert(1, ".");
                    }

                    for (int i = 2; i < gpsLong.Count; i++)
                    {
                        gpscombinded.Add(gpsLat[i] + "," + gpsLong[i]);
                    } 

                    for (int i = 2; i < gpsLong.Count; i++)
                    {
                        Console.WriteLine(ticks[i] + ";" + offSetTime[i] + ";" + gpsLat[i] + ";" + gpsLong[i] + ";" + gpsDate[i] + ";" + gpsTime[i] + ";" + gpsHeightMSL[i] + ";" + gpshDOP[i] + ";" + gpspDOP[i] + ";" + gpssAcc[i] + ";" + gpsnumGPS[i] + ";" + gpsnumGLNAS[i] + ";" + gpsnumSV[i] + ";" + gpscombinded[i-2]);
                        finalLine += ticks[i] + ";" + offSetTime[i] + ";" + gpsLat[i] + ";" + gpsLong[i] + ";" + gpsDate[i] + ";" + gpsTime[i] + ";" + gpsHeightMSL[i] + ";" + gpshDOP[i] + ";" + gpspDOP[i] + ";" + gpssAcc[i] + ";" + gpsnumGPS[i] + ";" + gpsnumGLNAS[i] + ";" + gpsnumSV[i] + ";" + gpscombinded[i-2] + "\n";
                    }
                }
                File.WriteAllText("flyvning2.csv", finalLine);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
