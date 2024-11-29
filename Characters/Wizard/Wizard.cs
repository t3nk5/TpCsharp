using Tp.Actions.Damages;

namespace Tp.Characters.wizard;


public class Wizard: Character
{
    public Wizard(string name,
        int pv = 60,
        int pvActual = 60,
        int speed = 75,
        int physicalAttack = 0,
        int magicalAttack = 75,
        double dodgeChance = 0.05,
        double paradeChance = 0.05,
        double spellChance = 0.25)
        : base(name, pv, pvActual, physicalAttack, speed, magicalAttack, Armors.Armors.Fabric, dodgeChance, paradeChance, spellChance)
    {}

    public override void Attack(List<Character> targetCharacters, string nameAttack)
    {
        throw new NotImplementedException();
    }

    public override void GetAttackPhysical(Damage damageType, int damage)
    {
        throw new NotImplementedException();
    }

    public override int CalculateDamage(Damage damageType, int damage)
    {
        throw new NotImplementedException();
    }

    protected override bool Dodge()
    {
        throw new NotImplementedException();
    }

    protected override bool Parade()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        throw new NotImplementedException();
    }
}
