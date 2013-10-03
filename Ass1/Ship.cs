using System;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    public class Ship
    {
        private const int badValue = -9999;
        private string name;
        int shieldStrength;
        private int rate;
        int hullStrength;
        private int baseDamage;
        private int randomDamage;
        private int maxShieldStrength;
        private int maxHullStrength;
        private Boolean isTarget = false;

        public Ship(string n, int ss, int r, int hs, int bd, int rd, int maxSS, int maxHS)
        {
            name = n;
            shieldStrength = ss;
            rate = r;
            hullStrength = hs;
            baseDamage = bd;
            randomDamage = rd;
            maxShieldStrength = maxSS;
            maxHullStrength = maxHS;
            isTarget = false;
        }

        public string Name
        {
            get { return name; }
        }

        public int ShieldStrength
        {
            get { return shieldStrength; }
            set 
            {
                if (value != badValue)
                shieldStrength = value; 
            }
        }

        public int RegenerationRate
        {
            get { return rate; }
        }

        public int HullStrength
        {
            get { return hullStrength; }
            set 
            {
                if (value != badValue)
                hullStrength = value; 
            }
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
            set
            {
                if (value != null)
                isTarget = value;
            }
        }
    }
}
