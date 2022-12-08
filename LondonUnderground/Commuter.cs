using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonUnderground
{
    internal class Commuter
    {
        Stations startStation;
        Stations targetStation;



        string[] lineNames = {"Bakerloo", "Central", "Circle", "District", "Hammersmith", "Jubilee",
            "Northern", "Picadilly", "Victoria", "Elizabeth"};

        public Commuter(Stations startStation, Stations targetStation)
        {
            this.startStation = startStation;
            this.targetStation = targetStation;
        }
        public void PrintStatus()
        {
            Console.WriteLine("Currently at " + startStation.GetName() + " Heading to " + targetStation.GetName());

            for (int i = 0; i < lineNames.Length; i++) 
            {
                if (startStation.GetLine(i) == true && targetStation.GetLine(i) == true)
                {
                    Console.WriteLine("Access via " + lineNames[i]);
                }
                else
                {
                    Console.WriteLine("No access via " +lineNames[i]);
                }
            }
        }
    }
}
