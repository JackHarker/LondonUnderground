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
        //All stations available to travel to/from

        Commuter lateRunner;
        //A new instance of a commuter. A commuter has a start and end goal

        Random random = new Random();
        //A new instance of a random object

        public Underground()
        {
            LoadData();

            lateRunner = new Commuter(allStations[random.Next(0, allStations.Length - 1)],
                allStations[random.Next(0, allStations.Length - 1)]);

            SolutionLoop();

        }
        
        private void SolutionLoop()
        {
            while (true)
            {
                Console.Clear();

                lateRunner.PrintStatus();


                Console.ReadKey();

                lateRunner = new Commuter(allStations[random.Next(0, allStations.Length - 1)],
                    allStations[random.Next(0, allStations.Length - 1)]);
            }    
        }
        private void LoadData()
        {
            string[] readLines = System.IO.File.ReadAllLines("C:/Users/j_w_h/source/repos/LondonUnderground/LondonUnderground/Underground.csv");
            
            for (int i = 0; i < readLines.Length; i++)
            {
                string[] readColumns = readLines[i].Split(',');

                bool[] stationOnLines = new bool[readColumns.Length - 1];

                for (int j = 0; j < stationOnLines.Length; j++)
                {
                    int intToBoolConversion = Convert.ToInt16(readColumns[j + 1]);
                    stationOnLines[j] = Convert.ToBoolean(intToBoolConversion);
                }

                allStations[i] = new Stations(readColumns[0], stationOnLines);
            }
        }//This Method loads in data from a CSV file and populates it into an array of stations
        public void PrintAllStations()
        {
            for (int i = 0; i < allStations.Length; i++)
            {
                Console.WriteLine(allStations[i].GetName());
            }

        } //This method prints all stations to screen

        public void PrintLine(int lineNo)
        {
            for (int i = 0; i < allStations.Length; i++)
            {
                if (allStations[i].GetLine(lineNo) == true)
                {
                    Console.WriteLine(allStations[i].GetName());
                }
            }
        } //This method checks all stations based on a number
    }
}
