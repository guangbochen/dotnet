using System;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    public class Battle
    {
        private int round = 0;
        public Battle(Fleet fleet1, Fleet fleet2 ,Random rand)
        {
            while (!fleet1.lostTheBattel() && !fleet2.lostTheBattel())
            {
                round++;

                //reset each ships as not target in each new round 
                eraseIsTarget(fleet1);
                eraseIsTarget(fleet2);

                startBattle(fleet1, fleet2, rand);
                startBattle(fleet2, fleet1, rand);

                //remove the destroyed ships
                removeDestroyedShip(fleet1, round);
                removeDestroyedShip(fleet2, round);

                //regenerate the shield strength after each round
                regenerateShield(fleet1);
                regenerateShield(fleet2);
            }

            //print out the battle result
            PrintResult(fleet1, fleet2, round);
        }

        /**
         * this method start a round of battle and fires its weapon
         **/
        private void startBattle(Fleet attacker, Fleet targetFleet, Random rand)
        {
            Ship[] targetShips = targetFleet.Ships;

            foreach (Ship ship in attacker.Ships)
            {
                //if fleet losts all his ships the battle ends
                if (targetShips.Length == 0) break;

                //get generated damage from attacker
                int damage = ship.getDamage(rand);

                // randomly selecting a ship to fire on
                int selectShip = rand.Next(targetShips.Length);

                //apply the damage to the target
                targetShips[selectShip].takeDamage(damage);

            }
        }

        /**
         * this method removes the destroyed ship after each round of battle
         **/
        private void removeDestroyedShip(Fleet fleet, int round)
        {
            int position = 0;
            int size = 0;

            foreach (Ship s in fleet.Ships)
            {
                if (s.HullStrength > 0)
                    size++;
            }

            //declares a new array of ships
            Ship[] newShips = new Ship[size];

            bool shipLost = false;
            foreach (Ship ship in fleet.Ships)
            {
                //save undestotyed ships into new array of ship
                if (ship.HullStrength > 0 && position <= size)
                {
                    newShips[position++] = ship;
                }
                else
                {
                    if (shipLost == false)
                    {
                        Console.WriteLine("\nAfter round " + round + " the " + fleet.FleetName + " fleet has lost");
                        shipLost = true;
                    }
                    Console.WriteLine("  " + ship.Name + " destroyed");
                }
            }

            //update the ships of target fleet
            fleet.removeDestroyedShips(newShips);

            //validate fleet lost battle or not
            fleet.lostTheBattel();
        }

        /**
         * This method regenerate the ship's shield strength if it is not destroyed
         **/
        private void regenerateShield(Fleet fleet)
        {
            foreach (Ship ship in fleet.Ships)
            {
                ship.regenerateShield();
            }
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
            survivedShips = fleet1.Ships.Length;
            lostShips = fleet1.NumberOfShips - survivedShips;
            Console.WriteLine("\nAfter round " + round + " the " + fleet1.FleetName + " fleet won");
            Console.WriteLine("  " + fleet2.NumberOfShips + " enemy ships destroyed");
            Console.WriteLine("  " + lostShips + " ships lost");
            Console.WriteLine("  " + survivedShips + " ships survived");
            foreach (Ship ship in fleet1.Ships)
            {
                Console.WriteLine("    " + ship.Name + " - " + ship.getDamageRating());
            }
        }

        /**
         * this method reset ship is targe as false in each new round
         */
        private void eraseIsTarget(Fleet fleet)
        {
            foreach (Ship ship in fleet.Ships)
            {
                ship.setIsTarget(false);
            }
        }
    }
}