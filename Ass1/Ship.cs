using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    public class Ship
    {
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
        private enum HullDamagePercent
        {
            VERY_HEAVY_DAMAGE = 0,
            HEAVY_DAMAGE = 40,
            MODERATE_DAMAGE = 70,
            LIGHT_DAMAGE = 90,
            UNDAMAGED = 100
        }

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

        public int HullStrength
        {
            get { return hullStrength; }
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

        public void setIsTarget(Boolean value)
        {
            isTarget = value;
        }

        public void takeDamage(int damage)
        {
            int damageRemain = damage - shieldStrength;
            isTarget = true;
            if (damageRemain > 0)
            {
                //apply remaining damage to hullStrength
                hullStrength -= damageRemain;
                shieldStrength = 0;
            }
            else
            {
                shieldStrength -= damage;
            }
        }

        public int getDamage(Random rand)
        {
            int damage = 0;
            damage = baseDamage + rand.Next(randomDamage);
            return damage;
        }

        public void regenerateShield()
        {
            //if the ship is not destroyed and is not target in this round
            //regenerate their shieldStrength
            if (isTarget == false)
            {
                shieldStrength += rate;
                if (shieldStrength > maxShieldStrength)
                    shieldStrength = maxShieldStrength;
            }
        }


        public string getDamageRating()
        {
            int undamagedPercent = (hullStrength) * 100 / maxHullStrength;

            if (undamagedPercent == (int)HullDamagePercent.UNDAMAGED) return "undamaged";
            if (undamagedPercent >= (int)HullDamagePercent.LIGHT_DAMAGE) return "lightly damaged";
            if (undamagedPercent >= (int)HullDamagePercent.MODERATE_DAMAGE) return "moderately damaged";
            if (undamagedPercent >= (int)HullDamagePercent.HEAVY_DAMAGE) return "heavily damaged";
            return "very heavily damaged";
        }
    }
}
