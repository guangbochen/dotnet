using System;
using System.IO;

namespace Ass1
{
    public class Fleet
    {
        //private Boolean lostTheBattle;
        private string fleetName;
        private Ship[] ships;
        private int numberOfShips;
        private string line;

        public int NumberOfShips
        {
            get { return numberOfShips; }
        }

        public Ship[] Ships
        {
            get { return ships; }
        }

        public Fleet(string fleetFile)
        {
            initFleet(fleetFile);

            //validate the file is exist
            validateFile(fleetFile);

            //if file is exist load fleet and ships from the file
            loadFleet(fleetFile);
        }

        /**
         * this method validates the file is exist or not
         **/
        private void validateFile(string fleetFile)
        {
            if (!File.Exists(fleetFile))
                throw new Exception(fleetFile + " file not found");
            StreamReader fin = new StreamReader(fleetFile);
            if (fin == null) throw new Exception("Unable to open " + fleetFile);

        }

        /**
         * this method initialize the fleet object
         **/
        private void initFleet(string fleetFile)
        {
            fleetName = "";
            ships = null;
            numberOfShips = 0;
            line = "";
        }

        /**
         * this method load the ships from the input file
         **/
        private void loadFleet(string fleetFile)
        {
            StreamReader fin = new StreamReader(fleetFile);
            try
            {
                //load fleet name
                LoadFleetName(fin);

                //load total number of ship
                LoadTotalNumOfShips(fin);

                //load a list of ships for the fleet
                LoadShips(fin, fleetFile);

                //check whether the fleet has more ships than it declared
                endOfFleetFile(fin);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + " in " + fleetFile);
            }
            finally
            {
                fin.Close();
            }

        }

        /**
         * this method loads the fleet name
         */
        private void LoadFleetName(StreamReader fin)
        {
            //load the fleet name and number of ships
            fleetName = fin.ReadLine();
            if (fleetName == null || fleetName.Length == 0)
                throw new Exception("Missing fleet name");

        }

        /**
         * this method loads the total number of ships the fleet contains
         */
        private void LoadTotalNumOfShips(StreamReader fin)
        {
            line = fin.ReadLine();
            if (!Int32.TryParse(line, out numberOfShips) || numberOfShips < 1)
                throw new Exception("Invalid number of ships");

            //initialize the number of ship
            ships = new Ship[numberOfShips];
        }
        
        /**
         * this method loads a list of ship from the file
         */
        private void LoadShips(StreamReader fin, string fleetFile)
        {
            for (int i = 0; i < numberOfShips; i++)
            {
                ships[i] = new Ship();
                ships[i].loadShip(fin);
            }

        }

        /**
         * this method validates the total number of ships
         */
        private void endOfFleetFile(StreamReader fin)
        {
            string line = "";
            while (!fin.EndOfStream)
            {
                line = fin.ReadLine().Trim();
                // see if there is any text other than spaces left in file
                if (line.Length > 0) throw new Exception("More ships than stated");
            }
        }
    }
}
