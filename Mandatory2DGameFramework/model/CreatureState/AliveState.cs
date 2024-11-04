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
        /// <summary>
        /// Calculates the reduction of HP when a creature is hit, taking the DefenceItem into account
        /// </summary>
        /// <param name="creature">The creature that gets hit</param>
        /// <param name="damage">Raw damage w/o DefenceItem</param>
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
