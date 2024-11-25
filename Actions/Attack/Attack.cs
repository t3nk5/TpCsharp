using Tp.Actions.Damages;
using Tp.Characters;

namespace Tp.Actions.Attack;

public class Attack
{
    public string Name;
    public Character Attacker;
    public Character Target;
    public int Damage;
    public Damage TypeDamage;

    public Attack(string name, Character attacker, Character target, int damage, Damage typeDamage)
    {
        Name = name;
        Attacker = attacker;
        Target = target;
        Damage = damage;
        TypeDamage = typeDamage;
    }

    

    
}