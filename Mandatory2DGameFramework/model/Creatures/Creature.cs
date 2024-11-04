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
    public class Creature : WorldObject, ICreatureState
    {
        public string CreatureName { get; set; }
        public int HitPoint { get; set; }
        public ICreatureState CreatureState { get; set; }

        public AttackItem AttackItem { get; set; }
        public DefenceItem DefenceItem { get; set; }
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
        }

        public int HP
        {
            get => HitPoint;
            set
            {
                if (value == HitPoint) return;
                HitPoint = value;
                CreatureState = new AliveState();
            }
        }
        public void ChangeState(ICreatureState state)
        {
            CreatureState = state;
        }

        public void ReceiveHit(Creature creature, int attack)
        {
            CreatureState.ReceiveHit(this, attack);
        }

        public void Attack(Creature creature, Creature opponent)
        {
            CreatureState.Attack(this, opponent);
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

        internal void Attack(int attack) //need to ask why this is required when I already have the other void attack
        {
            throw new NotImplementedException();
        }
    }
}
