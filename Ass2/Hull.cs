using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ass2
{
    public class Hull
    {
        private int hullStrength;
        private int maxHullStrength;
        private string line;
        private const int percent = 100;
        private enum HullDamagePercent
        {
            VERY_HEAVY_DAMAGE = 0,
            HEAVY_DAMAGE = 40,
            MODERATE_DAMAGE = 70,
            LIGHT_DAMAGE = 90,
            UNDAMAGED = 100
        }

        public int HullStrength
        {
            get { return hullStrength; }
        }

        public void init(int hull)
        {
            hullStrength = maxHullStrength = hull;
        }

        public Hull()
        {
            hullStrength = maxHullStrength = -1;
            line = "";
        }

        //this method load the ship hull strength
        public void loadHullStre(StreamReader fin, string name)
        {
            line = fin.ReadLine();
            if (!Int32.TryParse(line, out hullStrength) || hullStrength < 1)
                throw new Exception("Invalid hull strength in ship class " + name);
            maxHullStrength = hullStrength;
        }

        //this method takes damage and apply to the hull strength
        public void takeDamage(int damage)
        {
            hullStrength -= damage;
        }

        //this method calculate and return the damage percent
        public string getDamageRating()
        {
            int undamagedPercent = (hullStrength) * percent / maxHullStrength;
            if (undamagedPercent == (int)HullDamagePercent.UNDAMAGED)
                return "undamaged";
            if (undamagedPercent >= (int)HullDamagePercent.LIGHT_DAMAGE)
                return "lightly damaged";
            if (undamagedPercent >= (int)HullDamagePercent.MODERATE_DAMAGE)
                return "moderately damaged";
            if (undamagedPercent >= (int)HullDamagePercent.HEAVY_DAMAGE)
                return "heavily damaged";
            return "very heavily damaged";
        }
    }
}
