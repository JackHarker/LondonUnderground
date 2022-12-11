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
 
        int[] lineIndex = new int[10];
        
        public Station(string name, int[] lineIndex)
        {
            this.name = name;

            for (int i = 0; i < lineIndex.Length; i++)
            {
                this.lineIndex[i] = lineIndex[i];
            }
        }
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
        }
        public string GetName()
        {
            return name;
        }
        public void PrintStation()
        {
            Console.WriteLine(name);

            foreach(int i in lineIndex)
            {
                Console.WriteLine(i);
            }
        }
        public int GetLineIndex(int lineNo) 
        {
            return lineIndex[lineNo];
        }
        public void CloseStation()
        {
            for (int i = 0; i < lineIndex.Length; i++)
            {
                lineIndex[i] = 0;
            }
        }
        public void CloseLine(int lineNo)
        {
            lineIndex[lineNo] = 0;
        }
    }
}
