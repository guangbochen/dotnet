using System;
using System.IO;
using System.Collections.Generic;

namespace Ass1
{
    public class Fleet
    {
        private Boolean lostTheBattle;
        private string fleetName;
        private Ship[] ships;
        private int numberOfShips;
        private string line;
        private List<BaseShip> shipList;

        public int NumberOfShips
        {
            get { return numberOfShips; }
        }

        public string FleetName
        {
            get { return fleetName; }
        }

        public Ship[] Ships
        {
            get { return ships; }
        }

        public List<BaseShip> ShipList
        {
            get { return shipList; }
        }

        public Fleet(string fleetFile)
        {
            initFleet(fleetFile);

            //validate the file is exist
            validateFile(fleetFile);

            //read the file version and load ships for the fleet
            if (!isNewFileVersion(fleetFile))
                readAsOldVersion(fleetFile);
        }

        private Boolean isNewFileVersion(string fleetFile)
        {
            StreamReader fin = new StreamReader(fleetFile);
            try
            {
                String version = fin.ReadLine();
                if (version == null || version.Length == 0)
                    throw new Exception("Missing fleet name");
                if (version.Equals("#2"))
                {
                    loadNewFileFormat(fin);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + " in " + fleetFile);
            }
            finally
            {
                fin.Close();
            }
            return false;
        }


        private void loadNewFileFormat(StreamReader fin)
        {
            String shipName;
            int count;
            LoadFleetName(fin);
            while (!fin.EndOfStream)
            {
                shipName = fin.ReadLine();
                if (shipName == null || shipName.Length == 0)
                    throw new Exception(shipName + "is not a valid ship class name");
                line = fin.ReadLine();
                if (!Int32.TryParse(line, out count) || count < 1)
                    throw new Exception("Invalid number of ships");

                //add new ships to the ship list
                addShipsToList(shipName, count);
            }

            //test
            int i = 0;
            foreach(BaseShip s in shipList)
                Console.WriteLine(++i +"ship name =  " + s.Name);
        }


        private void addShipsToList(string shipName, int count)
        {
            BaseShip bship = null;
            if (shipName.Equals("Defiant")) bship = new Defiant();
            else if (shipName.Equals("Akira")) bship = new Akira();
            else if (shipName.Equals("Galaxy")) bship = new Galaxy();
            else if (shipName.Equals("Bird of Prey")) bship = new BirdOfPrey();
            else if (shipName.Equals("Vor'cha")) bship = new Vorcha();
            else if (shipName.Equals("Attack Ship")) bship = new AttackShip();
            else if (shipName.Equals("Battle Cruiser")) bship = new BattleCruiser();
            else if (shipName.Equals("Galor")) bship = new Galor();
            else throw new Exception(shipName + " is not a valid ship name");
            for (int i = 0; i < count; i++)
            {
                shipList.Add(bship);
            }
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
            lostTheBattle = false;
            shipList = new List<BaseShip>();
        }

        /**
         * this method load the ships from the input file
         **/
        private void readAsOldVersion(string fleetFile)
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

        /**
         * methods for game battle
         **/
        public Boolean lostTheBattel() 
        {
            if(numberOfShips == 0 || ships.Length == 0)
                lostTheBattle = true;
            return lostTheBattle;
        }

        public void removeDestroyedShips(Ship[] newShips)
        {
            ships = newShips;
        }

    }
}
