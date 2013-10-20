using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ass2
{
    public class Battle
    {
        private int round = 0;
        public Battle(Fleet fleet1, Fleet fleet2, Random rand, Ass2Form form)
        {
            while (!fleet1.lostTheBattel() && !fleet2.lostTheBattel())
            {
                round++;

                //reset each ships as not target in each new round 
                fleet1.fireWeapon(fleet2, rand);
                fleet2.fireWeapon(fleet1, rand);

                //remove the destroyed ships
                fleet1.removeDestroyedShips(round, form);
                fleet2.removeDestroyedShips(round, form);

                //regenerate the shield strength after each round
                fleet1.regenerateShield();
                fleet2.regenerateShield();
            }

            //print out the battle result
            PrintResult(fleet1, fleet2, round, form);
        }

        /**
         * this method print out the battle result
         **/
        private void PrintResult(Fleet fleet1, Fleet fleet2, int round, Ass2Form form)
        {
            if (!fleet1.lostTheBattel())
            {
                //fleet 1 win the battle
                getDamageReport(fleet1, fleet2, form);
            }
            else if (!fleet2.lostTheBattel())
            {
                //fleet 2 win the battle
                getDamageReport(fleet2, fleet1, form);
            }
            else
            {
                //print battle result as a draw
                form.addTextToResult("After round " + round + " the battle has been a " +
                    "draw with both sides destroyed");
            }
        }

        /**
         * this method calculates the level of damage
         **/
        private void getDamageReport(Fleet fleet1, Fleet fleet2, Ass2Form form)
        {
            int lostShips, survivedShips;
            Ships ships = fleet1.Ships;
            survivedShips = ships.ShipList.Count;
            lostShips = fleet1.NumberOfShips - survivedShips;
            form.addTextToResult("\r\nAfter round " + round + " the " + fleet1.FleetName + " fleet won");
            form.addTextToResult("  " + fleet2.NumberOfShips + " enemy ships destroyed");
            form.addTextToResult("  " + lostShips + " ships lost");
            form.addTextToResult("  " + survivedShips + " ships survived");
            foreach (BaseShip ship in ships.ShipList)
            {
                Hull hull = ship.Hull;
                form.addTextToResult("    " + ship.Name + " - " + hull.getDamageRating());
            }
        }
    }
}