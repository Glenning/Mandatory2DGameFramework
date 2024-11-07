using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.model.Cretures;

Console.WriteLine("This is a test environment");

Creature Krigeren = CreatureFactory.MakeCreature(CreatureType.Warrior);
Creature Modstanderen = CreatureFactory.MakeCreature(CreatureType.Beast);

Console.WriteLine($"{Krigeren.CreatureName} ready for battle with his {Krigeren.AttackItem.Name} doing {Krigeren.AttackItem.Hit} damage and his defence item: {Krigeren.DefenceItem.Name}, shielding him from {Krigeren.DefenceItem.ReduceHitPoint} damage!");
Console.WriteLine($"{Modstanderen.CreatureName} ready for battle with his {Modstanderen.AttackItem.Name} doing {Modstanderen.AttackItem.Hit} damage and his defence item: {Modstanderen.DefenceItem.Name}, shielding him from {Modstanderen.DefenceItem.ReduceHitPoint} damage!");

while (Krigeren.HitPoint > 0 && Modstanderen.HitPoint > 0)
{
    Krigeren.Attack(Modstanderen);
    if (Modstanderen.HitPoint <= 0)
    {
        Modstanderen.Death();
        Console.WriteLine($"{Krigeren.CreatureName} wins!");
        break;
    }

    Modstanderen.Attack(Krigeren);
    if (Krigeren.HitPoint <= 0)
    {
        Krigeren.Death();
        Console.WriteLine($"{Modstanderen.CreatureName} wins!");
        break;
    }
}