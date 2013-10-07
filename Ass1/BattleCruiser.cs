﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    class BattleCruiser : BaseShip
    {
        private string name;
        private int shieldStrength;
        private int rate;
        private int hullStrength;
        private int baseDamage;
        private int randomDamage;

        public BattleCruiser()
        {
            name = "Battle Cruiser";
            shieldStrength = 90;
            rate = 2;
            hullStrength = 25;
            baseDamage = 13;
            randomDamage = 5;
        }

        public override string Name
        {
            get { return name; }
        }

        public override int ShieldStrength
        {
            get { return shieldStrength; }
        }

        public override int Rate
        {
            get { return rate; }
        }

        public override int HullStrength
        {
            get { return hullStrength; }
        }

        public override int BaseDamage
        {
            get { return baseDamage; }
        }

        public override int RandomDamage
        {
            get { return randomDamage; }
        }

    }
}
