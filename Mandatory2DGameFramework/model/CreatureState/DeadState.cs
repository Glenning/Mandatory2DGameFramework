using Mandatory2DGameFramework.model.Cretures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.CreatureState
{
    public class DeadState : ICreatureState
    {
        public void ReceiveHit(Creature creature, int damage)
        {
            Console.WriteLine($"{creature.CreatureName} is dead");
        }

        public void Attack(Creature creature, Creature opponent)
        {
            Console.WriteLine($"{creature.CreatureName} is dead");
        }
    }
}
