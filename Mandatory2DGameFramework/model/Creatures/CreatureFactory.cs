using Mandatory2DGameFramework.model.Cretures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Creatures
{
    public class CreatureFactory
    {
        public enum CreatureType
        {
            Warrior,
            Beast,
            Boss
        }

        public static Creature MakeCreature(CreatureType type)
        {
            switch (type)
            {
                case CreatureType.Warrior:
                    return new Creature("Warrior", 100)
                    {

                    };
                case CreatureType.Beast:
                    return new Creature("Beast", 75)
                    {

                    };
                case CreatureType.Boss:
                    return new Creature("Boss", 200)
                    {

                    };
                default:
                    return new Creature("Grunt", 25);
            }
        }
    }
}
