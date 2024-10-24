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

namespace Mandatory2DGameFramework.model.Cretures
{
    public class Creature : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int HitPoint { get; set; }

        public AttackItem?   Attack { get; set; }
        public DefenceItem?  Defence { get; set; }

        public Creature(string creaturename, int hp)
        {
            Name = creaturename;
            HitPoint = hp;
            Attack = null;
            Defence = null;

        }

        public int HP
        {
            get => HitPoint;
            set
            {
                if (value ==  HitPoint) return;
                HitPoint = value;
                NotifyPropertyChanged("HP");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") //CallerMemberName allows for the HP variable to be saved as propertyName
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Hit()
        {
            throw new NotImplementedException();
        }

        public void ReceiveHit(int hit)
        {
            throw new NotImplementedException();
        }

        public void Death()
        {
            
        }

        public void Loot(WorldObject obj)
        {
            if (obj.Lootable == false)
            {  
                throw new ArgumentException("You can not loot that!");
            }
            else
            {
                Console.WriteLine($"You have acquired: {obj.Name}");
                //add some stuff here about it being added to your inv
            }
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(HitPoint)}={HitPoint.ToString()}, {nameof(Attack)}={Attack}, {nameof(Defence)}={Defence}}}";
        }
    }
}
