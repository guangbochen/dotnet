using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ass2
{
    public abstract class BaseShip
    {
        abstract public Damage Damage { get; }
        abstract public Hull Hull { get; }
        abstract public Shield Shield { get; }
        abstract public string Name { get; }
        abstract public int Rate { get; }
    }
}
