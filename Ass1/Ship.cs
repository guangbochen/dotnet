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
            loadShipName(fin);
            loadShieldStre(fin, name);
            loadRate(fin, name);
            loadHullStre(fin, name);
            loadBaseDamage(fin, name);
            loadRandDamage(fin, name);
        }

        private void loadShipName(StreamReader fin)
        {
            //load ship name
            name = fin.ReadLine();
            if (name == null || name.Length == 0)
                throw new Exception("Ship class name missing");
        }

        private void loadShieldStre(StreamReader fin, string name)
        {
            //load ship shield strength 
            line = fin.ReadLine();
            if (!Int32.TryParse(line, out shieldStrength) || shieldStrength < 1)
                throw new Exception("Invalid shield strength in ship class " + name);
            maxShieldStrength = shieldStrength;
        }

        private void loadRate(StreamReader fin, string name)
        {
            //load ship rate 
            line = fin.ReadLine();
            if (!Int32.TryParse(line, out rate) || rate < 1)
                throw new Exception("Invalid rege rate in ship class " + name);
        }

        private void loadHullStre(StreamReader fin, string name)
        {
            //load ship hull strength
            line = fin.ReadLine();
            if (!Int32.TryParse(line, out hullStrength) || hullStrength < 1)
                throw new Exception("Invalid hull strength in ship class " + name);
            maxHullStrength = hullStrength;
        }

        private void loadBaseDamage(StreamReader fin, string name)
        {
            //load ship base damage
            line = fin.ReadLine();
            if (!Int32.TryParse(line, out baseDamage) || baseDamage < 1)
                throw new Exception("Invalid weapon base in ship class " + name);
        }

        private void loadRandDamage(StreamReader fin, string name)
        {
            //load ship rand damage
            line = fin.ReadLine();
            if (!Int32.TryParse(line, out randomDamage) || randomDamage < 1)
                throw new Exception("Invalid weapon random in ship class " + name);
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
