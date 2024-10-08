﻿using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Cretures
{
    public class Creature
    {
        public string Name { get; set; }
        public int HitPoint { get; set; }


        // Todo consider how many attack / defence weapons are allowed
        public AttackItem?   Attack { get; set; }
        public DefenceItem?  Defence { get; set; }

        public Creature()
        {
            Name = string.Empty;
            HitPoint = 100;

            Attack = null;
            Defence = null;

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
