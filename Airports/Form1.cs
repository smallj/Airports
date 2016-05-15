using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airports
{
    public partial class Form1 : Form
    {
        private List<Airport> allAirports;
        
        public Form1()
        {
            InitializeComponent();

            //setup a simple list of airports
            InitializeAirportList();
            
            //Set the text in the combo box to give the user some instruction.
            startingAirportCombo.Text = "Select a starting airport...";

        }

        /// <summary>
        /// This is test code to create a list of airports with connetions.  Normally this
        /// would be read in from another source, a database or file maybe.  For the purposes of this
        /// example this is just a simple list of 5 airports with connections.
        /// </summary>
        public void InitializeAirportList()
        {
            //Initialize airport list.
            allAirports = new List<Airport>();

            allAirports.Add(createAirport("A"));
            allAirports.Add(createAirport("B"));
            allAirports.Add(createAirport("C"));
            allAirports.Add(createAirport("D"));
            allAirports.Add(createAirport("E"));

            //create connections
            List<String> connections;
            connections = new List<String> { "B", "C", "D", "E" };
            addDirectConnects("A", connections);

            connections = new List<String> { "A", "C", "E" };
            addDirectConnects("B", connections);

            connections = new List<String> { "A", "B" };
            addDirectConnects("C", connections);

            connections = new List<String> { "A", "E" };
            addDirectConnects("D", connections);

            connections = new List<String> { "B", "A", "D" };
            addDirectConnects("E", connections);


        }

        /// <summary>
        /// Creates an airport object with a given code or name
        /// </summary>
        /// <param name="airportCode">airport code, String</param>
        /// <returns>Airport object</returns>
        public Airport createAirport(String airportCode)
        {
            Airport airport = new Airport();

            airport.airportCode = airportCode;

            return airport;
        }

        /// <summary>
        /// Add a list of direct connections to a given airport
        /// </summary>
        /// <param name="airportCode">airport code</param>
        /// <param name="connectsCode">List of connections</param>
        public void addDirectConnects(String airportCode, List<String> connectsCode)
        {
            Airport airport;

            try
            {
                //Find the airport by the airport code and add the direct connections.
                airport = allAirports.Find(air => air.airportCode == airportCode);

                if (airport == null)
                    throw new ArgumentNullException("Airport (" + airport.airportCode + ") not found.", new Exception());

                airport.directFlights = buildDirectConnects(connectsCode);
            }
            catch (ArgumentNullException e) 
            {
                MessageBox.Show(e.Message, "Invalid airport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Creates a list of direct connected airports for each airport code passed in.
        /// </summary>
        /// <param name="connectsCode">List of airports</param>
        /// <returns>list of all connected airports</returns>
        public List<Airport> buildDirectConnects(List<String> connectsCode)
        {
            Airport airport;
            List<Airport> directConnects = new List<Airport>();


            foreach (String a in connectsCode)
            {
                try
                {
                    //Find the current airport in the list of all airports.
                    airport = allAirports.Find(air => air.airportCode == a);

                    if (airport == null)
                        throw new ArgumentNullException("Airport (" + airport.airportCode + ") not found.", new Exception());

                    directConnects.Add(airport);
                }
                catch (ArgumentNullException e)
                {
                    MessageBox.Show(e.Message, "Invalid airport", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return directConnects;
        }

        /// <summary>
        /// Prints all airports that can be reached from a given airport and how many 
        /// "hops" it takes to get to each airport.
        /// </summary>
        /// <param name="visited"></param>
        /// <param name="current"></param>
        public void printRoute(List<Airport> visited, Airport current)
        {

            foreach (Airport a in current.getDirectFlights())
            {
                if (!visited.Contains(a))
                {
                    visited.Add(a);
                    printRoute(visited, a);
                }
            }
            showList(visited);
            visited.RemoveAt(visited.Count() - 1);
        }

        /// <summary>
        /// displays the route on the screen with the "hops" for each possible destination.
        /// </summary>
        /// <param name="airportList"></param>
        public void showList(List<Airport> airportList)
        {
            //don't count the starting airport.
            if (airportList.Count() > 1)
            {
                routesTextBox.AppendText(String.Format("Hops: {0} ", airportList.Count() - 1));
                foreach (Airport a in airportList)
                {
                    routesTextBox.AppendText(String.Format("{0} ", a.airportCode));
                }
                routesTextBox.AppendText("\n");
            }
        }

        /// <summary>
        /// Button handler for the "Get Flights" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void get_flights_Click(object sender, EventArgs e)
        {
            List<Airport> visited = new List<Airport>();

            routesTextBox.Text = String.Empty;

            //make sure the user selected an airport before finding routes.
            if ((startingAirportCombo.Text == String.Empty) ||
                (startingAirportCombo.Text == "Select a starting airport..."))
                MessageBox.Show("You must specify a starting airport.", "Missing Starting Airport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    Airport airport = allAirports.Find(air => air.airportCode == startingAirportCombo.Text.ToUpper());

                    if (airport == null)
                        throw new ArgumentNullException("Selected airport (" + startingAirportCombo.Text + ") not available.", new Exception());
                    visited.Add(airport);

                    printRoute(visited, airport);
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message , "No routes for selected airport", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
