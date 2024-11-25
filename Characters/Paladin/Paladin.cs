namespace Tp.Characters.Paladin;

public class Paladin : Character
{
    public Paladin(string name,
        int pv = 95,
        int pvActual = 95,
        int physicalAttack = 40,
        int magicalAttack = 40,
        decimal dodgeChance = 0.05m,
        decimal paradeChance = 0.1m,
        decimal spellChance = 0.20m)
        : base(name, pv, pvActual, physicalAttack, magicalAttack, Armors.Armors.Mesh, dodgeChance, paradeChance, spellChance)
    {}
}