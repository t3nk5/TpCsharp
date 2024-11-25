namespace Tp.Characters.wizard;

public class Wizard: Character
{
    public Wizard(string name,
        int pv = 60,
        int pvActual = 60,
        int physicalAttack = 0,
        int magicalAttack = 75,
        decimal dodgeChance = 0.05m,
        decimal paradeChance = 0.05m,
        decimal spellChance = 0.25m)
        : base(name, pv, pvActual, physicalAttack, magicalAttack, Armors.Armors.Fabric, dodgeChance, paradeChance, spellChance)
    {}
    
}