using System;
using System.IO;

namespace Ass1
{
    public class Fleet
    {
        private const int minuValue = 0;
        private const int shipValues = 6;

        private Boolean lostTheBattle;
        private string fleetName;
        private Ship[] ships;
        private int numberOfShips;
        private Random rand;

        private string line;
        private Boolean fileIsFine;

        public Fleet(string fleetFile, Random r)
        {
            //initalize variables
            //lostTheBattle = false;
            //fileIsFine = true;

            rand = r;

            //validate the file is exist
            ValidateFile(fleetFile);

        }

        public Ship[] Ships
        {
            get { return ships; }
            set { if(value != null) ships = value; }
        }

        public string FleetName
        {
            get { return fleetName; }
        }

        public int NumberOfShips
        {
            get { return numberOfShips; }
        }

        public Boolean LostTheBattle
        {
            get { return lostTheBattle; }
            set { if(value != false) lostTheBattle = value; }
        }

        /**
         * this method validates the file is exist or not
         */
        private void ValidateFile(string fleetFile)
        {
            if (File.Exists(fleetFile))
                throw new Exception(fleetFile + " file not found");
            StreamReader fin = new StreamReader(fleetFile);
            if (fin == null) throw new Exception("Unable to open " + fleetFile);

            //if file is exist load fleet and ships from the file
            InitializeShips(fleetFile);
            LoadFleet(fleetFile);
        }

        /**
         * this method initialize the array size of the ships
         */
        private void InitializeShips(string fleetFile)
        {
            fleetName = "";
            ships = null;
            numberOfShips = 0;

            StreamReader fin = new StreamReader(fleetFile);
            int shipCount = 0;
            //get the count of file lines
            while (!fin.EndOfStream)
            {
                line = fin.ReadLine();
                line.Trim();
                if (line.Length > 0)
                    shipCount++;
            }
            fin.Close();

            //create ships array
            shipCount = shipCount/shipValues;
            ships = new Ship[shipCount];

        }

        /**
         * this method load the ships form the input file
         **/
        private void LoadFleet(string fleetFile)
        {
            StreamReader fin = new StreamReader(fleetFile);
            //load fleet name
            LoadFleetName(fin, fleetFile);
            //load total number of ship
            LoadTotalNumOfShips(fin, fleetFile);
            //load ships
            LoadShips(fin, fleetFile);

            //check whether the fleet has more ships than it declared
            ValidateNumberOfShips(fin, fleetFile);
            CheckNumberofShips(fin, fleetFile);

            fin.Close();
        }

        /**
         * this method loads the fleet name
         */
        private void LoadFleetName(StreamReader fin,string fleetFile)
        {
            //load the fleet name and number of ships
            try
            {
                fleetName = fin.ReadLine();
                if (FleetName == "")
                {
                    ErrorException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Missing fleet name in " + fleetFile + "\n");
            }

        }

        /**
         * this method loads the total number of ships the fleet contains
         */
        private void LoadTotalNumOfShips(StreamReader fin, string fleetFile)
        {
            try
            {
                line = fin.ReadLine();
                if (!Int32.TryParse(line, out numberOfShips) || numberOfShips <= minuValue)
                {
                    ErrorException();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Invalid number of ships in " + fleetFile + "\n");
            }
        }
        
        /**
         * this method load the ship from file and add it into array
         */
        private void LoadShips(StreamReader fin, string fleetFile)
        {
            for (int i = 0; i < ships.Length; i++)
            {
                string name;
                int sStrength, rate, hStrength, bDamage, rDamage;

                name = loadShipName(fin, fleetFile);
                sStrength = LoadShieldStre(fin, fleetFile, name);
                rate = LoadRate(fin, fleetFile, name);
                hStrength = LoadHullStre(fin, fleetFile, name);
                bDamage = LoadBaseDamage(fin, fleetFile, name);
                rDamage = LoadRandDamage(fin, fleetFile, name);

                //add ship object into array
                ships[i] = new Ship(name, sStrength, rate, hStrength, bDamage, rDamage, sStrength, hStrength);
            }

        }

        private String loadShipName(StreamReader fin, string fleetFile)
        {
            try
            {
                //load ship name
                String name = fin.ReadLine();
                if (name == "")
                {
                    ErrorException();
                }
                else
                {
                    return name;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Ship class name missing in " + fleetFile + "\n");
            }
            return null;
        }

        private int LoadShieldStre(StreamReader fin, string fleetFile, string name)
        {
            int sStrength;
            try
            {
                //load ship shield strength 
                line = fin.ReadLine();
                if (!Int32.TryParse(line, out sStrength) || sStrength <= minuValue)
                {
                    ErrorException();
                }
                else
                {
                    return sStrength;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Invalid shield strength in ship class " + name + " in " + fleetFile + "\n");
            }

            return minuValue;
        }

        private int LoadRate(StreamReader fin, string fleetFile, string name)
        {
            int rate;
            try
            {
                //load ship rate 
                line = fin.ReadLine();
                if (!Int32.TryParse(line, out rate) || rate <= minuValue)
                {
                    ErrorException();
                }
                else
                {
                    return rate;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Invalid rege rate in ship class " + name + " in " + fleetFile + "\n");
            }
            return minuValue;
        }

        private int LoadHullStre(StreamReader fin, string fleetFile, string name)
        {
            int hStrength;
            try
            {
                //load ship hull strength
                line = fin.ReadLine();
                if (!Int32.TryParse(line, out hStrength) || hStrength <= minuValue)
                {
                    ErrorException();
                }
                else
                {
                    return hStrength;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Invalid hull strength in ship class " + name + " in " + fleetFile + "\n");
            }
            return minuValue;
        }

        private int LoadBaseDamage(StreamReader fin, string fleetFile, string name)
        {
            int bDamage;
            try
            {
                //load ship base damage
                line = fin.ReadLine();
                if (!Int32.TryParse(line, out bDamage) || bDamage <= minuValue)
                {
                    ErrorException();
                }
                else
                {
                    return bDamage;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Invalid weapon base in ship class " + name + " in " + fleetFile + "\n");
            }
            return minuValue;
        }

        private int LoadRandDamage(StreamReader fin, string fleetFile, string name)
        {
            int rDamage;
            try
            {
                //load ship rand damage
                line = fin.ReadLine();
                if (!Int32.TryParse(line, out rDamage) || rDamage <= minuValue)
                {
                    ErrorException();
                }
                else
                {
                    return rDamage;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Invalid weapon random in ship class " + name + " in " + fleetFile + "\n");
            }
            return minuValue;
        }

        private void ValidateNumberOfShips(StreamReader fin, string fleetFile)
        {
            //validate the loaded ships is equals to the number it declares
            line = fin.ReadLine();
            if (line != null)
            {
                fileIsFine = false;
                Console.WriteLine("Program failed with following error");
                Console.WriteLine("More ships than stated in" + fleetFile + "\n");
            }
        }

        private void CheckNumberofShips(StreamReader fin, string fleetFile)
        {
            if (numberOfShips > ships.Length && fileIsFine == true)
            {
                fileIsFine = false;
                Console.WriteLine("Program failed with following error");
                Console.WriteLine("More ships than stated in" + fleetFile + "\n");
            }
            else if (ships.Length > numberOfShips && fileIsFine == true)
            {
                fileIsFine = false;
                Console.WriteLine("Program failed with following error");
                Console.WriteLine("More ships than stated in" + fleetFile + "\n");
            }
        }

        private void ErrorException()
        {
            fileIsFine = false;
            throw new Exception("Program failed with following error");
        }
    }
}
