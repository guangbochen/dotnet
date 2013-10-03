using System;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    class Program
    {

        static void Main(string[] args)
        {
            //if(Program.ValidateInput(args) == true)
            //{
            //    //if the input argument is fine, load the file
            //    Generator generator = new Generator(seed);
            //    Fleet firstFleet = new Fleet(args[firstFile]);
            //    if (firstFleet.FileIsFine == true)
            //    {
            //        Fleet secondFleet = new Fleet(args[secondFile]);
            //        //if load the file successfully, start the battle
            //        Battle battle = new Battle(firstFleet, secondFleet, generator);
            //     }
            //}

            Fleet fleet1 = null;
            Fleet fleet2 = null;
            Console.WriteLine("TrekBattle by Guangbo Chen");

            try
            {
                ValidateInput(args, out fleet1, out fleet2);
            }
            catch (Exception e)
            {
                Console.WriteLine("Program failed with following error");
                Console.WriteLine(e.Message);
            }

        }

        static void ValidateInput(String[] args, out Fleet fleet1, out Fleet fleet2)
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
            Random rand = new Random(seed);

            //load first file and create fleet1
            fleet1 = new Fleet(args[1], rand);

            //load second file and create fleet2
            fleet2 = new Fleet(args[1], rand);
        }

    }
}
