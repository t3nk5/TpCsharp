using System.Diagnostics;
using Tp.Actions.Damages;
using Tp.Characters;

namespace Tp.Actions.Attack;

public class Attack
{
    public readonly string Name;
    private readonly Character Characters;
    public readonly int Damage;
    public readonly Damage TypeDamage;
    public Target Target;
    public List<Character> CharactersTarget;

    public Attack(string name, Character attacker, Target target, int damage, Damage typeDamage,
        List<Character> characters)
    {
        Name = name;
        Characters = attacker;
        Target = target;
        Damage = damage;
        TypeDamage = typeDamage;
        CharactersTarget = characters;
    }

    
    public void Execute()
    {
        Console.WriteLine("type de l'attaque " + GetType().Name);
        foreach (var character in CharactersTarget)
        {
            character.GetAttackPhysical(TypeDamage, Damage);
        }
        
    }
    
}