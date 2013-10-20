using System;
using System.IO;
using System.Collections.Generic;

namespace Ass2
{
    public class Fleet
    {
        private Boolean lostTheBattle;
        private string fleetName;
        private int numberOfShips;
        private string line;
        private Ships ships;

        public Ships Ships
        {
            get { return ships; }
        }

        public int NumberOfShips
        {
            get { return numberOfShips; }
        }

        public string FleetName
        {
            get { return fleetName; }
        }

        public Fleet(string fleetFile)
        {
            initFleet();

            //validate the file is exist or not
            validateFile(fleetFile);

            //read the file version and load ships for the fleet
            if (!isNewFileVersion(fleetFile))
                readAsOldVersion(fleetFile);
        }

        /**
         * this method checks the file version and load the file if is new version
         **/
        private Boolean isNewFileVersion(string fleetFile)
        {
            StreamReader fin = new StreamReader(fleetFile);
            try
            {
                string version = fin.ReadLine();
                if (version == null || version.Length == 0)
                    throw new Exception("Missing fleet name");
                if (validateFileName(version))
                {
                    LoadFleetName(fin);
                    numberOfShips = ships.loadNewVersionShips(fin);
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



        /**
         * this method validates the file is exist or not
         **/
        private void validateFile(string fleetFile)
        {
            if (!File.Exists(fleetFile))
                throw new Exception(fleetFile + "\r does not exist");
            StreamReader fin = new StreamReader(fleetFile);
            if (fin == null) throw new Exception("Unable to open " + fleetFile);

        }

        /**
         * this method initialize the fleet object
         **/
        private void initFleet()
        {
            fleetName = "";
            numberOfShips = 0;
            ships = new Ships();
            line = "";
            lostTheBattle = false;
        }

        /**
         * this method loads the fleet and its ships from the old version file
         **/
        private void readAsOldVersion(string fleetFile)
        {
            StreamReader fin = new StreamReader(fleetFile);
            try
            {
                LoadFleetName(fin);
                LoadTotalNumOfShips(fin);

                //load ships into fleet in older version
                ships.loadOldVersionShips(fin, numberOfShips);

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

        //this method validate file name contains characters #2
        private Boolean validateFileName(string file)
        {
            if (file.Length > 1)
            {
                if (file[0].CompareTo('#') == 0 && file[1].CompareTo('2') == 0)
                    return true;
            }
            return false;
        }

        /**
         * this method loads the fleet name
         */
        private void LoadFleetName(StreamReader fin)
        {
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
        }

        /**
         * this method validates the total number of ships
         **/
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
         * this method calls fleet ships to fire its weapon to the targe ships
         **/
        public void fireWeapon(Fleet targetFleet, Random rand)
        {
            Ships targetShips  = targetFleet.Ships;
            List<BaseShip> targetShipList = targetShips.ShipList;
            foreach (BaseShip ship in ships.ShipList)
            {
                //get generated damage
                int damage = ship.Damage.getDamage(rand);

                // randomly selecting a ship to fire on
                int count = targetShipList.Count;
                int targetId = rand.Next(count);
                
                //apply damage to the target ship
                BaseShip targetShip = targetShipList[targetId];
                int damageRemain = targetShip.Shield.absorbDamage(damage);
                targetShip.Hull.takeDamage(damageRemain);
            }
        }


        /**
         * this method removes the destroyed ships
         **/
        public void removeDestroyedShips(int round, Ass2Form form)
        {
            //make a copy of current fleet ships
            Ships newShips = new Ships();

            bool shipLost = false;
            foreach (BaseShip ship in ships.ShipList)
            {
                Hull hull = ship.Hull;
                if (hull.HullStrength > 0)
                    newShips.ShipList.Add(ship);
                else
                {
                    if (shipLost == false)
                    {
                        form.addTextToResult("\r\nAfter round " + round + " the "
                            + fleetName + " fleet has lost");
                        shipLost = true;
                    }
                    form.addTextToResult(" " + ship.Name + " destroyed");
                }
            }

            //update fleet ships after removing destroyed ships
            ships = newShips;
        }

        //this method regenerates the ship shield strength
        public void regenerateShield()
        {
            foreach (BaseShip ship in ships.ShipList)
            {
                int rate = ship.Rate;
                ship.Shield.regenerateShield(rate);
            }
        }

        //this method validates fleet lost the battle or not
        public Boolean lostTheBattel() 
        {
            if(numberOfShips == 0 || ships.ShipList.Count == 0)
                lostTheBattle = true;
            return lostTheBattle;
        }

    }
}
