using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ass2
{
    public class Galor : BaseShip
    {
        private const string name = "Galor";
        private const int rate = 1;
        private Shield shieldStrength;
        private Hull hullStrength;
        private Damage damage;
        private enum ShipValue : int
        {
            sShield = 80,
            sHull = 7,
            sBaseWeapon = 8,
            sRandomWeapon = 3
        }

        public Galor()
        {
            shieldStrength = new Shield();
            hullStrength = new Hull();
            damage = new Damage();

            //initialize ship variables
            shieldStrength.init((int)ShipValue.sShield);
            hullStrength.init((int)ShipValue.sHull);
            damage.init((int)ShipValue.sBaseWeapon, (int)ShipValue.sRandomWeapon);
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
