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
            Console.WriteLine($"{creature.CreatureName} gets hit for {reduceDam} damage and has {creature.HitPoint} remaining!");

            if (creature.HitPoint <= 0 ) 
            {
                creature.ChangeState(new DeadState());
            }
        }

        public void Attack(Creature attacker, Creature opponent)
        {
            int attack = attacker.AttackItem.HitDamage();
            Console.WriteLine($"{attacker.CreatureName} hits {opponent.CreatureName} for {attack} damage!");
            opponent.Attack(attack);

            if (opponent.HitPoint <= 0 )
            {
                opponent.ChangeState(new DeadState());
                Console.WriteLine($"{attacker.CreatureName} has defeated {opponent.CreatureName}!");
            }

            if (attacker.AttackItem == null)
            {
                Console.WriteLine($"{attacker.Name} does not have a weapon!");
                return;
            }
        }
    }
}
