using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    public class Damage
    {
        private int baseDamage;
        private int randomDamage;
        private string line;

        public Damage()
        {
            this.baseDamage = this.randomDamage = -1;
            line = "";
        }

        public string toStrings()
        {
            return "base : " + baseDamage + " random " + randomDamage;
        }

        public void init(int baseD, int randomD)
        {
             this.baseDamage = baseD;
             this.randomDamage = randomD;
        }

        public void loadDamage(StreamReader fin, string name)
        {
            //load ship base damage
            this.line = fin.ReadLine();
            if (!Int32.TryParse(line, out baseDamage) || baseDamage < 1)
                throw new Exception("Invalid weapon base in ship class " + name);

            //load ship rand damage
            line = fin.ReadLine();
            if (!Int32.TryParse(line, out randomDamage) || randomDamage < 1)
                throw new Exception("Invalid weapon random in ship class " + name);
        }

        public int getDamage(Random rand)
        {
            int damage = baseDamage + rand.Next(randomDamage);
            return damage;
        }
    }
}
