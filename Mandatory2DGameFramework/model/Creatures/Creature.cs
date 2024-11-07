using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Mandatory2DGameFramework.model.CreatureState;

namespace Mandatory2DGameFramework.model.Cretures
{
    public class Creature : WorldObject
    {
        public string CreatureName { get; set; }
        public int HitPoint { get; set; }
        public AttackItem AttackItem { get; set; }
        public DefenceItem DefenceItem { get; set; }
        private ICreatureState CreatureState { get; set; }

        /// <summary>
        /// Creature constructor
        /// </summary>
        /// <param name="creaturename">Name of the creature</param>
        /// <param name="hp">Health/hitpoints of the creature</param>
        public Creature(string creaturename,
                        int hp)
        {
            CreatureName = creaturename;
            HitPoint = hp;
            CreatureState = new AliveState();
        }

        public void ChangeState(ICreatureState changedState)
        {
            CreatureState = changedState;
        }

        /// <summary>
        /// Method for subtracting the amount a creature gets attacked for, from the creature's HP
        /// </summary>
        /// <param name="attack">Attack damage</param>
        public void ReceiveHit(int attack)
        {
            CreatureState.ReceiveHit(this, attack);
        }

        /// <summary>
        /// Method for attacking
        /// </summary>
        /// <param name="opponent">The victim of the attack</param>
        public void Attack(Creature opponent)
        {
            CreatureState.Attack(this, opponent);
        }

        /// <summary>
        /// Method that changes the state of the creature to dead if HP <= 0
        /// </summary>
        public void Death()
        {
            if (HitPoint <= 0)
            {
                Console.WriteLine($"{CreatureName} has died.");
                ChangeState(new DeadState());
            }
        }

        /// <summary>
        /// Checks availability of looting
        /// </summary>
        /// <param name="obj">Name of the object acquired</param>
        /// <exception cref="ArgumentException">Error thrown if not lootable</exception>
        public void Loot(WorldObject obj)
        {
            if (obj.Lootable == false)
            {
                Console.WriteLine("You can not loot that!");
            }
            else
            {
                Console.WriteLine($"You have acquired: {obj.Name}");
            }
        }

        public override string ToString()
        {
            return $"{{{nameof(CreatureName)}={CreatureName}, {nameof(HitPoint)}={HitPoint.ToString()}, {nameof(AttackItem)}={AttackItem}, {nameof(DefenceItem)}={DefenceItem}}}";
        }
    }
}
