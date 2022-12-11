using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonUnderground
{
    internal class Station 
    {
        private string name;
        //What is the name of the Station
 
        int[] lineIndex = new int[10];
        //What is the position of the station on all 10 lines
        
        public Station(string name, int[] lineIndex)
        {
            this.name = name;

            for (int i = 0; i < lineIndex.Length; i++)
            {
                this.lineIndex[i] = lineIndex[i];
            }
        } //This constructor sets up the station from data from the file

        public bool CheckIfOnLine(int lineNo)
        {
            bool isOnLine;

            if (this.lineIndex[lineNo] == 0)
            {
                isOnLine = false;
            }
            else
            {
                isOnLine = true;
            }

            return isOnLine;
        } //This Method checks to see if this station is on a specific line

        public string GetName()
        {
            return name;
        } // This method returns the name of the station

        public void PrintStation()
        {
            Console.WriteLine(name);

            foreach(int i in lineIndex)
            {
                Console.WriteLine(i);
            }
        } //This Method prints out all data from the station
        public int GetLineIndex(int lineNo) 
        {
            return lineIndex[lineNo];
        } //This Method returns the position of a station on a specific line

        public void CloseStation()
        {
            for (int i = 0; i < lineIndex.Length; i++)
            {
                lineIndex[i] = 0;
            }
        } //This Method closes all lines on the station
        public void CloseLine(int lineNo)
        {
            lineIndex[lineNo] = 0;
        } //This method closes one particular line on the station
    }
}
