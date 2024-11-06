using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Cretures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Creatures
{
    public enum CreatureType
    {
        Warrior,
        Beast,
        Boss
    }

    public class CreatureFactory
    {
        /// <summary>
        /// Creating the standard variant of each creature along with the default "Grunt" type
        /// </summary>
        /// <param name="type">The variant of creature to be made</param>
        /// <returns></returns>
        public static Creature MakeCreature(CreatureType type)
        {
            switch (type)
            {
                case CreatureType.Warrior:
                    return new Creature("Warrior", 100)
                    {
                        AttackItem = new attack.AttackItem("Sword", 10, 3),
                        DefenceItem = new defence.DefenceItem("Shield", 3)
                    };
                case CreatureType.Beast:
                    return new Creature("Beast", 75)
                    {
                        AttackItem = new attack.AttackItem("Claw", 10, 3),
                        DefenceItem = new defence.DefenceItem("Scales", 3)
                    };
                case CreatureType.Boss:
                    return new Creature("Boss", 200)
                    {
                        AttackItem = new attack.AttackItem("Zweihander", 20, 5),
                        DefenceItem = new defence.DefenceItem("Chainmail", 6)
                    };
                default:
                    return new Creature("Grunt", 25);
            }
        }
    }
}
