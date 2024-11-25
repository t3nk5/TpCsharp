using Tp.Actions.Damages;
using Tp.Characters;

namespace Tp.Actions.Attack;

public class Attack
{
    public readonly string Name;
    private Character Attacker;
    private Character Target;
    public readonly int Damage;
    private Damage TypeDamage;

    public Attack(string name, Character attacker, Character target, int damage, Damage typeDamage)
    {
        Name = name;
        Attacker = attacker;
        Target = target;
        Damage = damage;
        TypeDamage = typeDamage;
    }


    public void Execute()
    {
        Target.PvActual -= Damage;
        
        if (Target.PvActual < 0)
        {
            Target.PvActual = 0;
        }
        
        Console.WriteLine($"{Attacker.Name} use {Name} on {Target.Name} and make {Damage} damages {TypeDamage}.");
        Console.WriteLine($"{Target.Name} has now {Target.PvActual}/{Target.Pv} health points.");
    }
}