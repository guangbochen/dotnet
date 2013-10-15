using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    class BattleCruiser : BaseShip
    {
        private string name;
        private Shield shieldStrength;
        private int rate;
        private Hull hullStrength;
        private Damage damage;

        public BattleCruiser()
        {
            name = "Battle Cruiser";
            rate = 2;
            shieldStrength = new Shield();
            hullStrength = new Hull();
            damage = new Damage();

            //initialize variables
            shieldStrength.init(90);
            hullStrength.init(25);
            damage.init(13, 5);
        }
        public override Damage Damage
        {
            get { return damage; }
        }

        public override Hull Hull
        {
            get { return hullStrength; }
        }

        public override Shield Shield
        {
            get { return shieldStrength; }
        }

        public override string Name
        {
            get { return name; }
        }

        public override int Rate
        {
            get { return rate; }
        }

    }
}
