using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LondonUnderground
{
    internal class Underground
    {
        Stations[] allStations = new Stations[54];
        Commuter lateRunner;
        Random random = new Random();

        public Underground()
        {
            LoadData();
            lateRunner = new Commuter(allStations[random.Next(0, allStations.Length - 1)], 
                allStations[random.Next(0, allStations.Length - 1)]);

            SolutionLoop();

        }
        public void PrintAll()
        {
            for (int i =0; i < allStations.Length;i++)
            {
                Console.WriteLine(allStations[i].GetName());
            }
            
        }
        public void PrintCentralLine()
        {
            for (int i = 0; i < allStations.Length; i++)
            {
                if(allStations[i].GetCentral() == true)
                {
                    Console.WriteLine(allStations[i].GetName()); 
                }                               
            }
        }
        public void SolutionLoop()
        {
            while (true)
            {
                lateRunner.PrintStatus();


                Console.ReadKey();
            }    
        }
        public void LoadData()
        {
            string[] readLines = System.IO.File.ReadAllLines("C:/Users/j_w_h/source/repos/LondonUnderground/LondonUnderground/Underground.csv");
            /*int lineCount = 0;
            
            foreach (string line in readLines)
            {
                Console.WriteLine(line);
                lineCount++;
            }
            Console.WriteLine(lineCount.ToString());
            */
            for (int i = 0; i < readLines.Length; i++)
            {
                string[] columns = readLines[i].Split(',');

                bool[] boolConvert = new bool[columns.Length - 1];

                for (int j = 0; j < boolConvert.Length; j++)
                {
                    int temp = Convert.ToInt16(columns[j + 1]);
                    boolConvert[j] = Convert.ToBoolean(temp);
                }

                allStations[i] = new Stations(columns[0], boolConvert[0], boolConvert[1],
                    boolConvert[2], boolConvert[3], boolConvert[4], boolConvert[5], boolConvert[6],
                    boolConvert[7], boolConvert[8], boolConvert[9]);
            }
        }
    }
}
