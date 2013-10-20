using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ass2
{
    public class Shield
    {
        private Boolean isTarget;
        private int shieldStrength;
        private int maxShieldStrength;
        private int damageRemain;

        public Shield()
        {
            shieldStrength = maxShieldStrength = -1;
            isTarget = false;
            damageRemain = 0;
        }

        public void init(int shield)
        {
            shieldStrength = maxShieldStrength = shield;
        }

        //this method load ship shield strength 
        public void loadShield(StreamReader fin, string name)
        {
            string line = fin.ReadLine();
            if (!Int32.TryParse(line, out shieldStrength) || shieldStrength < 1)
                throw new Exception("Invalid shield strength in ship class " + name);
            maxShieldStrength = shieldStrength;
        }

        //this method use shield to absorb the damage and returns any remaining damage
        public int absorbDamage(int damage)
        {
            damageRemain = damage - shieldStrength;
            isTarget = true;
            if (damageRemain > 0)
            {
                shieldStrength = 0;
                return damageRemain;
            }
            shieldStrength -= damage;
            return 0;
        }

        //this method regenerate the shield if the ship is not targeted in that round
        public void regenerateShield(int rate)
        {
            if (isTarget == false)
            {
                shieldStrength += rate;
                if (shieldStrength > maxShieldStrength)
                    shieldStrength = maxShieldStrength;
            }

            //reset is not target in each new round
            isTarget = false;
        }
    }
}
