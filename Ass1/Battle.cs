using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    public class Battle
    {
        private int round = 0;
        public Battle(Fleet fleet1, Fleet fleet2, Random rand)
        {
            while (!fleet1.lostTheBattel() && !fleet2.lostTheBattel())
            {
                round++;

                //reset each ships as not target in each new round 
                fleet1.fireWeapon(fleet2, rand);
                fleet2.fireWeapon(fleet1, rand);

                //remove the destroyed ships
                fleet1.removeDestroyedShips(round);
                fleet2.removeDestroyedShips(round);

                //regenerate the shield strength after each round
                fleet1.regenerateShield();
                fleet2.regenerateShield();
            }

            //print out the battle result
            PrintResult(fleet1, fleet2, round);
        }

        /**
         * this method print out the battle result
         **/
        private void PrintResult(Fleet fleet1, Fleet fleet2, int round)
        {
            if (!fleet1.lostTheBattel())
            {
                //fleet 1 win the battle
                getDamageReport(fleet1, fleet2);
            }
            else if (!fleet2.lostTheBattel())
            {
                //fleet 2 win the battle
                getDamageReport(fleet2, fleet1);
            }
            else
            {
                //print battle result as a draw
                Console.WriteLine("After round " + round + " the battle has been a " +
                    "draw with both sides destroyed");
            }
        }

        /**
         * this method calculates the level of damage
         **/
        private void getDamageReport(Fleet fleet1, Fleet fleet2)
        {
            int lostShips, survivedShips;
            Ships ships = fleet1.Ships;
            survivedShips = ships.ShipList.Count;
            lostShips = fleet1.NumberOfShips - survivedShips;
            Console.WriteLine("\nAfter round " + round + " the " + fleet1.FleetName + " fleet won");
            Console.WriteLine("  " + fleet2.NumberOfShips + " enemy ships destroyed");
            Console.WriteLine("  " + lostShips + " ships lost");
            Console.WriteLine("  " + survivedShips + " ships survived");
            foreach (BaseShip ship in ships.ShipList)
            {
                Hull hull = ship.Hull;
                Console.WriteLine("    " + ship.Name + " - " + hull.getDamageRating());
            }
        }

    }
}