using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    public class Ship : BaseShip
    {
        private string name;
        private Shield shieldStrength;
        private int rate;
        private Hull hullStrength;
        private Damage damage;
        private string line;

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

        public Ship()
        {
            name = "";
            line = "";
            shieldStrength = new Shield();
            hullStrength = new Hull();
            damage = new Damage();
        }

        public void loadShip(StreamReader fin)
        {
            loadShipName(fin);
            shieldStrength.loadShield(fin, name);
            loadRate(fin, name);
            hullStrength.loadHullStre(fin, name);
            damage.loadDamage(fin, name);
        }

        private void loadShipName(StreamReader fin)
        {
            //load ship name
            name = fin.ReadLine();
            if (name == null || name.Length == 0)
                throw new Exception("Ship class name missing");
        }

        private void loadRate(StreamReader fin, string name)
        {
            //load ship rate 
            line = fin.ReadLine();
            if (!Int32.TryParse(line, out rate) || rate < 1)
                throw new Exception("Invalid rege rate in ship class " + name);
        }

    }
}
