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
        Station[] allStations = new Station[54];
        //All stations available to travel to/from

        string[] lineNames = {"Bakerloo", "Central", "Circle", "District", "Hammersmith", "Jubilee",
            "Northern", "Picadilly", "Victoria", "Elizabeth"};
        //A list of strings to describe the 10 lines

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

                CloseLine();
                CloseStation();
                CloseStation();

                SetLateRunner();

                lateRunner.PrintStatus();

                CheckShortestRoutes();
                
                Console.ReadKey();

                
            }
        }
        private void LoadData()
        {
            string[] readLines = System.IO.File.ReadAllLines("C:/Users/j_w_h/source/repos/LondonUnderground/LondonUnderground/Underground.csv");
            

            for (int i = 0; i < readLines.Length; i++)
            {
                string[] readColumns = readLines[i].Split(',');

                int[] stationIndex = new int[readColumns.Length - 1];

                for (int j = 0; j < stationIndex.Length; j++)
                {        
                    stationIndex[j] = Convert.ToInt16(readColumns[j + 1]);
                    
                }

                allStations[i] = new Station(readColumns[0], stationIndex);

                
                    
            }
        }//This Method loads in data from a CSV file and populates it into an array of stations

        public void PrintAllStations()
        {
            for (int i = 0; i < allStations.Length; i++)
            {
                allStations[i].PrintStation();
            }

        } //This method prints all stations to screen

        public void PrintLine(int lineNo)
        {
            for (int i = 0; i < allStations.Length; i++)
            {
                if (allStations[i].CheckIfOnLine(lineNo) == true)
                {
                    Console.WriteLine(allStations[i].GetName());
                }
            }
        } //This method checks all stations based on a number
        public void CheckShortestRoutes()
        {
            List<int> possibleRoutes = new List<int>();

            int[] shortestDist = { -1, -1 };

            for (int i = 0; i < lineNames.Length; i++)
            {
                if (lateRunner.GetStartStation().CheckIfOnLine(i) == true && lateRunner.GetTargetStation().CheckIfOnLine(i) == true)
                {
                    Console.WriteLine("Access via " + lineNames[i]);

                    possibleRoutes.Add(i);
                }
                else
                {
                    Console.WriteLine("No access via " + lineNames[i]);
                }
            }
            Console.WriteLine(possibleRoutes.Count + " possible route(s)");

            foreach (int j in possibleRoutes)
            {
                int tempDist = 0;
                
                tempDist = DistanceBetweenStations(lateRunner.GetStartStation(), lateRunner.GetTargetStation(), j);
                
                if (tempDist < shortestDist[0] || shortestDist[0] == -1)
                {
                    shortestDist[0] = tempDist;
                    shortestDist[1] = j;
                }
                
            }
            if (shortestDist[0] != -1)
            {
                Console.WriteLine("Shortes Route via " + lineNames[shortestDist[1]] + " at only " + shortestDist[0]);
            }
            
            
        }
        private void SetLateRunner()
        {
            lateRunner = new Commuter(allStations[random.Next(0, allStations.Length - 1)],
                    allStations[random.Next(0, allStations.Length - 1)]);
        }
        public int DistanceBetweenStations(Station start, Station end, int lineNo)
        {
            int distance = 0;

            if (start.GetLineIndex(lineNo) > end.GetLineIndex(lineNo))
            {
                distance = start.GetLineIndex(lineNo) - end.GetLineIndex(lineNo);
            }
            else
            {
                distance = end.GetLineIndex(lineNo) - start.GetLineIndex(lineNo);
            }

            return distance;
        }
        private void CloseStation()
        {
            int stationNo = random.Next(0, allStations.Length-1);

            allStations[stationNo].CloseStation();

            Console.WriteLine(allStations[stationNo].GetName() + " is closed!");
        }
        private void CloseLine()
        {
            int lineNo = random.Next(0, lineNames.Length - 1);

            foreach(Station i in allStations)
            {
                if (i.CheckIfOnLine(lineNo) == true)
                {
                    i.CloseLine(lineNo);
                }
            }
            Console.WriteLine(lineNames[lineNo] + " is closed!");
        }
    }
}
