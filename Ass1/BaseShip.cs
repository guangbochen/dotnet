using System;
using System.Text;
using System.Threading.Tasks;

namespace Ass1
{
    public abstract class BaseShip
    {
       abstract public string Name { get; }
       abstract public int ShieldStrength { get; }
       abstract public int Rate { get; }
       abstract public int HullStrength { get; }
       abstract public int BaseDamage { get; }
       abstract public int RandomDamage { get; }
    }
}
