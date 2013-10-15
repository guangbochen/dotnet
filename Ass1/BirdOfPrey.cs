using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    public class BirdOfPrey : BaseShip
    {
        private string name;
        private Shield shieldStrength;
        private int rate;
        private Hull hullStrength;
        private Damage damage;

        public BirdOfPrey()
        {
            name = "Bird of Prey";
            rate = 1;
            shieldStrength = new Shield();
            hullStrength = new Hull();
            damage = new Damage();

            //initialize variables
            shieldStrength.init(60);
            hullStrength.init(10);
            damage.init(6, 3);
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
