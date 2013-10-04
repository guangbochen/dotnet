using System;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    public class Battle
    {
    //    private const int percent = 100;
    //    private enum Range : int 
    //    { 
    //        MaxUndamage = 100, 
    //        MaxLightDama = 99, MinLightDama = 90,
    //        MaxmodeDama = 89, MinmodeDama = 70,
    //        MaxheavyDama = 68, MinheavyDama = 40,
    //    };

        public Battle(Fleet fleet1, Fleet fleet2)
        {
            //calls the startBattle method to start battle
            //StartBattle(firstFleet, secondFleet, generator);
            Console.WriteLine(fleet1.NumberOfShips);
            Console.WriteLine(fleet2.NumberOfShips);
            Console.WriteLine(fleet1.Ships.Length);
            foreach (Ship s in fleet1.Ships)
            {
                Console.WriteLine(s.Name);
            }
        }

    //    /**
    //     * this method starts the battle
    //     **/
    //    private void StartBattle(Fleet firstFleet, Fleet secondFleet, Generator generator)
    //    {
    //        int round = 1;
    //        Random rand = generator.Rand;

    //        while (firstFleet.LostTheBattle == false && secondFleet.LostTheBattle == false)
    //        {
    //            //reset each ships as not target in each new round 
    //            EraseIsTarget(firstFleet);
    //            EraseIsTarget(secondFleet);


    //            //fleet starts battle
    //            FireWeapons(firstFleet, secondFleet, rand, round);
    //            FireWeapons(secondFleet, firstFleet, rand, round);

    //            //remove the destroyed ships
    //            RemoveDestroyedShip(firstFleet,round);
    //            RemoveDestroyedShip(secondFleet,round);

    //            //regenerate the shield strength after each round
    //            RegenerateShields(firstFleet);
    //            RegenerateShields(secondFleet);

    //            round++;
    //        }

    //        //print out the battle result
    //        PrintResult(firstFleet, secondFleet, round);

    //    }


        

    //    /**
    //     * this method start a round of battle and fires its weapon
    //     **/
    //    private void FireWeapons(Fleet fireFleet, Fleet targetFleet, Random rand, int round)
    //    {
    //        Ship targetShip;
    //        int ranDamage, damage, numOfTarget, selectShip;
    //        Ship[] targetShips = targetFleet.Ships;
    //        foreach (Ship ship in fireFleet.Ships)
    //        {

    //            //if fleet losts all his ships the battle ends
    //            if (targetShips.Length == 0)
    //                break;

    //            //calculate the total damage upon base and random damag
    //            ranDamage = ship.RandomDamage;
    //            damage = ship.BaseDamage + rand.Next(ranDamage);

    //            // randomly selecting a ship to fire on
    //            numOfTarget = targetShips.Length;
    //            selectShip = rand.Next(numOfTarget);
    //            targetShip = targetShips[selectShip];
    //            targetShips[selectShip].IsTarget = true;

    //            //apply the damage to the target
    //            ApplyDamageToTarget(damage, targetShip, targetFleet, round);

    //        }

    //    }

    //    /**
    //     * This method gets the damage and apply it to the target
    //     **/
    //    private void ApplyDamageToTarget(int damage, Ship targetShip, Fleet targetFleet, int round)
    //    {
    //        if (damage <= targetShip.ShieldStrength)
    //        {
    //            targetShip.ShieldStrength = targetShip.ShieldStrength - damage;
    //        }
    //        else
    //        {
    //            //if target ship has remaning shield strength then use it first
    //            if (targetShip.ShieldStrength > 0)
    //            {
    //                damage = damage - targetShip.ShieldStrength;
    //                //set target shield strength to 0
    //                targetShip.ShieldStrength = 0;
    //            }
    //            //applys the damage to the hull strength 
    //            targetShip.HullStrength = targetShip.HullStrength - damage;

    //        }
    //    }

    //    /**
    //     * This method removes the ship from the fleet if it is destroyed
    //     **/
    //    private void RemoveDestroyedShip(Fleet targetFleet, int round)
    //    {
    //        int position = 0;
    //        int size=0;
    //        Ship[] temp = targetFleet.Ships;

    //        foreach (Ship s in temp)
    //        {
    //            if (s.HullStrength > 0)
    //                size++;
    //        }

    //        //declares a new array of ships
    //        Ship[] newShips = new Ship[size];

    //        foreach (Ship ship in temp)
    //        {
    //            //save undestotyed ships into new array of ship
    //            if (ship.HullStrength > 0 && position <= size)
    //            {
    //                newShips[position++] = ship;
    //            }
    //            else
    //            {
    //                Console.WriteLine("After round " + round + " the " + targetFleet.FleetName + " fleet has lost");
    //                Console.WriteLine("  " + ship.Name + " destroyed\n");
    //            }
    //        }
    //        //update the ships of target fleet
    //        targetFleet.Ships = newShips;

    //        if (newShips.Length == 0)
    //        {
    //            //set lost as true
    //            targetFleet.LostTheBattle = true;
    //        }
    //    }

    //    /**
    //     * This method regenerate the ship's shield strength if it is not destroyed
    //     **/
    //    private void RegenerateShields(Fleet fleet)
    //    {
    //        foreach (Ship ship in fleet.Ships)
    //        {
    //            int shieldStrength = ship.ShieldStrength;
    //            int regenerateRate = ship.RegenerationRate;
    //            //if ship is not destroyed and not being target in that round
    //            //regenerate their shieldStrength
    //            if (shieldStrength < ship.MaxShieldStrength && ship.IsTarget == false)
    //            {
    //                ship.ShieldStrength = shieldStrength + regenerateRate;
    //            }
    //        }
    //    }

    //    /**
    //     * this method print out the battle result
    //     **/
    //    private void PrintResult(Fleet firFleet, Fleet secFleet, int round)
    //    {
    //        //set round to the round when it finished battle
    //        int theRound = round - 1;
    //        int lostShips, survivedShips, maxShips;

    //        if (firFleet.LostTheBattle == false)
    //        {
    //            maxShips = firFleet.NumberOfShips;
    //            survivedShips = firFleet.Ships.Length;
    //            lostShips = maxShips - survivedShips;
    //            Console.WriteLine("After round " + theRound + " the " + firFleet.FleetName + " fleet won");
    //            Console.WriteLine("  " + secFleet.NumberOfShips + " enemy ships destroyed");
    //            Console.WriteLine("  " + lostShips + " ships lost");
    //            Console.WriteLine("  " + survivedShips + " ships survived");
    //            CalculateDamageLvl(firFleet);
    //        }
    //        else if (secFleet.LostTheBattle == false)
    //        {
    //            maxShips = secFleet.NumberOfShips;
    //            survivedShips = secFleet.Ships.Length;
    //            lostShips = maxShips - survivedShips;
    //            Console.WriteLine("After round " + theRound + " the " + secFleet.FleetName + " fleet won");
    //            Console.WriteLine("  " + firFleet.NumberOfShips + " enemy ships destroyed");
    //            Console.WriteLine("  " + lostShips + " ships lost");
    //            Console.WriteLine("  " + survivedShips + " ships survived");
    //            CalculateDamageLvl(secFleet);
    //        }
    //        else
    //        {
    //            //print as a widthdraw
    //            Console.WriteLine("After round " + theRound + " the battle has been a "+
    //                "draw with both sides destroyed");
    //        }
    //    }

    //    /**
    //     * this method calculates the level of damage
    //     **/
    //    private void CalculateDamageLvl(Fleet fleet)
    //    {
    //        foreach (Ship ship in fleet.Ships)
    //        {
    //            string damResult = "";
    //            int hullStrength = ship.HullStrength;
    //            int maxHullStrength = ship.MaxHullStrength;
    //            int perOfDamage = (hullStrength * percent) / maxHullStrength;
    //            if (perOfDamage == (int)Range.MaxUndamage)
    //                damResult = "undamaged";
    //            else if (perOfDamage <= (int)Range.MaxLightDama 
    //                && perOfDamage >= (int)Range.MinLightDama)
    //                damResult = "lightly damaged";
    //            else if (perOfDamage <= (int)Range.MaxmodeDama 
    //                && perOfDamage >= (int)Range.MinmodeDama)
    //                damResult = "moderately damaged";
    //            else if (perOfDamage <= (int)Range.MaxheavyDama 
    //                && perOfDamage >= (int)Range.MinheavyDama)
    //                damResult = "heavily damaged";
    //            else
    //                damResult = "very heavily damaged";
    //            Console.WriteLine("    " + ship.Name + " - " + damResult);
    //        }
    //    }

    //    /**
    //     * this method reset ship is targe as false in each new round
    //     */
    //    private void EraseIsTarget(Fleet fleet)
    //    {
    //        foreach (Ship ship in fleet.Ships)
    //        {
    //            ship.IsTarget = false;
    //        }
    //    }
    }
}