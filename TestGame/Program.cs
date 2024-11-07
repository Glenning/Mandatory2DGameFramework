using Mandatory2DGameFramework;
using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.model.Cretures;
using static Mandatory2DGameFramework.model.Creatures.CreatureFactory;

Console.WriteLine("This is a test environment ");

Creature Krigeren = CreatureFactory.MakeCreature(CreatureType.Warrior);
Creature Modstanderen = CreatureFactory.MakeCreature(CreatureType.Beast);

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
