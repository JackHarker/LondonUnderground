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

        private bool onBakerloo;
        private bool onCentral;
        private bool onCircle;
        private bool onDistrict;
        private bool onHammersmith;
        private bool onJubilee;
        private bool onNorthern;
        private bool onPiccadilly;
        private bool onVictoria;
        private bool onElizabeth;

        public Stations()
        {
            name = "";
        }
        public Stations(string name, bool onBakerloo, bool onCentral, bool onCircle, bool onDistrict, bool onHammersmith, bool onJubilee, bool onNorthern, bool onPiccadilly, bool onVictoria, bool onElizabeth)
        {
            this.name = name;
            this.onBakerloo = onBakerloo;
            this.onCentral = onCentral;
            this.onCircle = onCircle;
            this.onDistrict = onDistrict;
            this.onHammersmith = onHammersmith;
            this.onJubilee = onJubilee;
            this.onNorthern = onNorthern;
            this.onPiccadilly = onPiccadilly;
            this.onVictoria = onVictoria;
            this.onElizabeth = onElizabeth;
        }
        public bool GetCentral()
        {
            return onCentral;
        }
        public string GetName()
        {
            return name;
        }
    }
}
