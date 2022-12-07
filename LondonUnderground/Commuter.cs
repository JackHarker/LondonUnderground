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

      

        public Commuter(Stations startStation, Stations targetStation)
        {
            this.startStation = startStation;
            this.targetStation = targetStation;
        }
        public void PrintStatus()
        {
            Console.WriteLine("Currently at " + startStation.GetName() + " Heading to " + targetStation.GetName());

            if( startStation.GetCentral() == true && targetStation.GetCentral()== true )
            {
                Console.WriteLine("I can travel on the Central line!!");
            }
            else
            {
                Console.WriteLine("No direct Route");
            }
        }
    }
}
