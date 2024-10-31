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
    public class Creature : WorldObject, INotifyPropertyChanged, ICreatureState
    {
        public string Name { get; set; }
        public int HitPoint { get; set; }
        public ICreatureState CreatureState { get; set; }

        public AttackItem? AttackItem { get; set; }
        public DefenceItem? DefenceItem { get; set; }
        /// <summary>
        /// Creature constructor
        /// </summary>
        /// <param name="creaturename">Name of the creature</param>
        /// <param name="hp">Health/hitpoints of the creature</param>
        public Creature(string creaturename,
                        int hp)
        {
            Name = creaturename;
            HitPoint = hp;
        }

        public int HP
        {
            get => HitPoint;
            set
            {
                if (value == HitPoint) return;
                HitPoint = value;
                NotifyPropertyChanged("HP");
                CreatureState = new AliveState();
            }
        }
        public void ChangeState(ICreatureState state)
        {
            CreatureState = state;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") //CallerMemberName allows for the HP variable to be saved as propertyName
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void ReceiveHit(int damage)
        {
            
        }

        public void SendHit(Creature opponent)
        {
            
        }
        //public void Hit(Creature opponent)
        //{
        //    Creature.SendHit(this, opponent);
        //}

        //public void ReceiveHit(int damagetaken)
        //{
        //    int damReduction = DefenceItem.Sum(defence => defence.reducehp);
        //    //Creature.ReceiveHit(this, damagetaken);
        //}

        public void Death()
        {
            if (HitPoint <= 0)
            {
                Console.WriteLine($"{Name} has died");
                //Do some cleanup here that removes the creature from the game
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
                //add some stuff here about it being added to your inv
            }
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint.ToString()}, {nameof(AttackItem)}={AttackItem}, {nameof(DefenceItem)}={DefenceItem}}}";
        }
    }
}
