using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    public class Ships
    {
        private string line;
        private List<BaseShip> shipList;

        public Ships()
        {
            line = "";
            shipList = new List<BaseShip>();
        }

        public List<BaseShip> ShipList
        {
            get { return shipList; }
        }

        public int loadNewVersionShips(StreamReader fin)
        {
            int totalCount = 0;;
            String shipName;
            int count;
            while (!fin.EndOfStream)
            {
                shipName = fin.ReadLine();
                if (shipName == null || shipName.Length == 0)
                    throw new Exception(shipName + "is not a valid ship class name");
                line = fin.ReadLine();
                if (!Int32.TryParse(line, out count) || count < 1)
                    throw new Exception("Invalid number of ships");
                totalCount += count;
                //add new ships to the ship list
                addShipsToList(shipName, count);
            }
            return totalCount;
        }

        private void addShipsToList(string shipName, int count)
        {
            for (int i = 0; i < count; i++)
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
                shipList.Add(bship);
            }
        }

        public void loadOldVersionShips(StreamReader fin, int numberOfShips)
        {
            for (int i = 0; i < numberOfShips; i++)
            {
                Ship ship = new Ship();
                ship.loadShip(fin);
                BaseShip bship = ship;
                shipList.Add(bship);
            }
        }

    }
}
