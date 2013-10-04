using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    public class Ship
    {
        private const int badValue = -9999;

        private string name;
        private int shieldStrength;
        private int rate;
        private int hullStrength;
        private int baseDamage;
        private int randomDamage;
        private int maxShieldStrength;
        private int maxHullStrength;
        private Boolean isTarget;
        private string line;

        private void initShip()
        {
            name = "";
            shieldStrength = rate = hullStrength = baseDamage = randomDamage = -1;
            isTarget = false;
            line = "";
        }

        public Ship()
        {
            initShip();
        }

        public string Name
        {
            get { return name; }
        }

        public int ShieldStrength
        {
            get { return shieldStrength; }
        }

        public int RegenerationRate
        {
            get { return rate; }
        }

        public int HullStrength
        {
            get { return hullStrength; }
        }

        public int BaseDamage
        {
            get { return baseDamage; }
        }

        public int RandomDamage
        {
            get { return randomDamage; }
        }

        public int MaxShieldStrength
        {
            get { return maxShieldStrength; }
        }

        public int MaxHullStrength
        {
            get { return maxHullStrength; }
        }

        public Boolean IsTarget
        {
            get { return isTarget; }
        }

        public void loadShip(StreamReader fin)
        {
            name = loadShipName(fin);
            maxShieldStrength = shieldStrength = LoadShieldStre(fin, name);
            rate = LoadRate(fin, name);
            maxHullStrength = hullStrength = LoadHullStre(fin, name);
            baseDamage = LoadBaseDamage(fin, name);
            randomDamage = LoadRandDamage(fin, name);
        }

        private String loadShipName(StreamReader fin)
        {
            //load ship name
            String shipName = "";
            shipName = fin.ReadLine();
            if (shipName == null || shipName.Length == 0)
                throw new Exception("Ship class name missing");
            return shipName;
        }

        private int LoadShieldStre(StreamReader fin, string name)
        {
            int sStrength = -1;
            //load ship shield strength 
            line = fin.ReadLine();
            if (!Int32.TryParse(line, out sStrength) || sStrength < 1)
                throw new Exception("Invalid shield strength in ship class " + name);
            return sStrength;
        }

        private int LoadRate(StreamReader fin, string name)
        {
            int shipRate = -1;
            //load ship rate 
            line = fin.ReadLine();
            if (!Int32.TryParse(line, out shipRate) || shipRate < 1)
                throw new Exception("Invalid rege rate in ship class " + name);
            return shipRate;
        }

        private int LoadHullStre(StreamReader fin, string name)
        {
            int hStrength = -1;
            //load ship hull strength
            line = fin.ReadLine();
            if (!Int32.TryParse(line, out hStrength) || hStrength < 1)
                throw new Exception("Invalid hull strength in ship class " + name);
            return hStrength;
        }

        private int LoadBaseDamage(StreamReader fin, string name)
        {
            int bDamage = -1;
            //load ship base damage
            line = fin.ReadLine();
            if (!Int32.TryParse(line, out bDamage) || bDamage < 1)
                throw new Exception("Invalid weapon base in ship class " + name);
            return bDamage;
        }

        private int LoadRandDamage(StreamReader fin, string name)
        {
            int rDamage = -1;
            //load ship rand damage
            line = fin.ReadLine();
            if (!Int32.TryParse(line, out rDamage) || rDamage < 1)
                throw new Exception("Invalid weapon random in ship class " + name);
            return rDamage;
        }

    }
}
