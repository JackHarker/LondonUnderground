using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonUnderground
{
    internal class Stations
    {
        private string name;

        string[] lineNames = {"Bakerloo", "Central", "Circle", "District", "Hammersmith", "Jubilee", 
            "Northern", "Picadilly", "Victoria", "Elizabeth"};

        bool[] accessToLines = new bool[10];

        public Stations()
        {
            name = "";
        }
        public Stations(string name, bool[] accessToLines)
        {
            this.name = name;
            
            for(int i = 0; i < accessToLines.Length; i++) 
            {
                this.accessToLines[i] = accessToLines[i];   
            }
        }
        public bool GetLine(int lineNo)
        {
            return accessToLines[lineNo];
        }
        public string GetName()
        {
            return name;
        }
    }
}
