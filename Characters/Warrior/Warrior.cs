using static Tp.Armors.Armors;

namespace Tp.Characters.Warrior;

public class Warrior : Character
{
    public Warrior(string name,
            int pv = 100,
            int pvActual = 100,
            int physicalAttack = 50,
            int magicalAttack = 0,
            decimal dodgeChance = 0.05m,
            decimal paradeChance = 0.25m,
            decimal spellChance = 0.1m)
    : base(name, pv, pvActual, physicalAttack, magicalAttack, Plate, dodgeChance, paradeChance, spellChance)
    {}


   
    
    
}