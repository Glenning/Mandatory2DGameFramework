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
            throw new ArgumentOutOfRangeException($"{creature.Name} is dead");
        }

        public void SendHit(Creature creature, Creature opponent)
        {
            throw new ArgumentOutOfRangeException($"{creature.Name} is dead");
        }
    }
}
