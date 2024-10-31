using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.CreatureState
{
    public class AliveState : ICreatureState
    {
        public void ReceiveHit(Creature creature, int damage)
        {
            int reduceDam = damage - creature.DefenceItem.ReduceHitPoint;
            creature.HitPoint -= reduceDam;
            Console.WriteLine($"{creature.Name} gets hit for {reduceDam} damage and has {creature.HitPoint} remaining!");

            if (creature.HitPoint <= 0 ) 
            {
                creature.ChangeState(new DeadState());
            }
        }

        public void SendHit(Creature attacker, Creature opponent)
        {
            
        }
    }
}
