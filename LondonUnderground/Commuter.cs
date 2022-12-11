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

        public Commuter(Station startStation, Station targetStation)
        {
            this.startStation = startStation;
            this.targetStation = targetStation;
        }
        public void PrintStatus()
        {
            Console.WriteLine("Currently at " + startStation.GetName() + " Heading to " + targetStation.GetName());        
        }
        public Station GetStartStation()
        {
            return startStation;
        }
        public Station GetTargetStation()
        {
            return targetStation;
        }
    }
}
