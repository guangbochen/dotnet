using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    public class Hull
    {
        private int hullStrength;
        private int maxHullStrength;
        private string line;
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

        public int MaxHullStrength
        {
            get { return maxHullStrength; }
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

        public void loadHullStre(StreamReader fin, string name)
        {
            //load ship hull strength
            line = fin.ReadLine();
            if (!Int32.TryParse(line, out hullStrength) || hullStrength < 1)
                throw new Exception("Invalid hull strength in ship class " + name);
            maxHullStrength = hullStrength;
        }

        public void takeDamage(int damage)
        {
            hullStrength -= damage;
        }

        public string getDamageRating()
        {
            //calculate and return damage percent
            int undamagedPercent = (hullStrength) * 100 / maxHullStrength;
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
