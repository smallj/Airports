using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports
{
    /// <summary>
    /// The airport class.  Each airport obejct contains the code for the airport and
    /// a list of all direct connections from the airport.
    /// </summary>
    public class Airport
    {
        private String code;
        private List<Airport> directConnects;

        public Airport()
        {
            code = String.Empty;
            directConnects = new List<Airport>();
        }

        public List<Airport> getDirectFlights()
        {
            return directConnects;
        }
        
        public String getCode()
        {
            return code;
        }

        public String airportCode
        {
            get { return code; }
            set { code = value; }
        }

        public List<Airport> directFlights 
        {
            set { directConnects = value; }
        }
    }
}
