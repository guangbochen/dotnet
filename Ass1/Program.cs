using System;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    class Program
    {
        static void Main(string[] args)
        {

            Random rand = null;
            Console.WriteLine("TrekBattle by Guangbo Chen");

            try
            {
                //validate command line input
                ValidateInput(args, out rand);

                //load first file and create fleet1
                Fleet fleet1 = new Fleet(args[1]);

                //load second file and create fleet2
                Fleet fleet2 = new Fleet(args[2]);

                //if load the file successfully, start the battle
                Battle battle = new Battle(fleet1, fleet2);

            }
            catch (Exception e)
            {
                Console.WriteLine("Program failed with following error");
                Console.WriteLine(e.Message);
            }

        }

        static void ValidateInput(String[] args, out Random rand)
        {
            //validate the length of input command line
            if (args.Length != 3) 
                throw new Exception("Invalid number of command line arguments entered\n");

            //validate the value of input seed
            int seed;
            bool result = Int32.TryParse(args[0], out seed);
            if (result == false || seed < 0) 
                throw new Exception("Invalid seed value entered");

            //create the random number generator
            rand = new Random(seed);
        }

    }
}
