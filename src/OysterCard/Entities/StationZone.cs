using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OysterCard
{
    public static class Station
    {
        public const string HOLBORN = "1";
        public const string EARLS_COURT = "1,2";        
        public const string WIMBLEDON = "3";
        public const string HAMMERSMITH = "2";
    }

    public class StationZone
    {    
        private readonly string _zone;

        public StationZone(string zone)
        {
            _zone = zone;
        }

        public string GetZone()
        {
            return _zone;
        }
    }
}
