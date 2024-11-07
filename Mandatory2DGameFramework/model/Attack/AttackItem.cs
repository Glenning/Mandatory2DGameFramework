using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.attack
{
    public class AttackItem : WorldObject
    {
        public string Name { get; set; }
        public int Hit { get; set; }
        public int Range { get; set; }
        /// <summary>
        /// Weapon constructor
        /// </summary>
        /// <param name="name">Weapon name</param>
        /// <param name="hit">Weapon damage</param>
        /// <param name="range">Weapon range</param>
        public AttackItem(string name,
                          int hit,
                          int range)
        {
            Name = name;
            Hit = hit;
            Range = range;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Hit)}={Hit.ToString()}, {nameof(Range)}={Range.ToString()}}}";
        }

        internal int AttackDmg()
        {
            return Hit;
        }
    }
}
