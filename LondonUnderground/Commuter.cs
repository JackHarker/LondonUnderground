using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonUnderground
{
    internal class Commuter
    {
        private Station startStation;
        private Station targetStation;
        //The two stations in which the commuter is getting to and from

        public Commuter(Station startStation, Station targetStation)
        {
            this.startStation = startStation;
            this.targetStation = targetStation;
        }//This constructs the commuter
        public void PrintStatus()
        {
            Console.WriteLine("Currently at " + startStation.GetName() + " Heading to " + targetStation.GetName());        
        }//This method prints some basic data about the commuters journey
        public Station GetStartStation()
        {
            return startStation;
        } // This returns the starting station
        public Station GetTargetStation()
        {
            return targetStation;
        } // This returns the target station
    }
}
