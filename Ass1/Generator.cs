using System;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{

    public class Generator
    {
        private Random rand;
        public Random Rand
        {
            get { return rand; }
        }

        public Generator(int seed)
        {
            rand = new Random(seed);
        }

    }
}
