using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.defence
{
    public class DefenceItem : WorldObject
    {
        public string Name { get; set; }
        public int ReduceHitPoint { get; set; }
        /// <summary>
        /// Defence constructor
        /// </summary>
        /// <param name="name">Defence name</param>
        /// <param name="reducehp">Amount of damage the defence item repels</param>
        public DefenceItem(string name,
                           int reducehp)
        {
            Name = name;
            ReduceHitPoint = reducehp;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(ReduceHitPoint)}={ReduceHitPoint.ToString()}}}";
        }
    }
}
