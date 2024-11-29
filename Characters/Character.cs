using Tp.Actions.Attack;
using Tp.Actions.Damages;

namespace Tp.Characters;

public abstract class Character
{
    public string Name { get; set; }
    public int Pv { get; set; }
    public int PvActual { get; set; }
    public int Speed { get; set; }
    public int PhysicalAttack { get; set; }
    public int MagicalAttack { get; set; }
    private Armors.Armors Armor { get; set; }
    protected double DodgeChance { get; set; }
    protected double ParadeChance { get; set; }
    protected double SpellChance { get; set; }

    protected bool IsAlive { get; set; } = true;


    protected Character(string name, int pv, int pvActual, int physicalAttack, int speed, int magicalAttack,
        Armors.Armors armor, double dodgeChance, double paradeChance, double spellChance)
    {
        Name = name;
        Pv = pv;
        PvActual = pvActual;
        Speed = speed;
        PhysicalAttack = physicalAttack;
        MagicalAttack = magicalAttack;
        Armor = armor;
        DodgeChance = dodgeChance;
        ParadeChance = paradeChance;
        SpellChance = spellChance;
    }

    public abstract void Attack(List<Character> targetCharacters, string nameAttack);
    
    public abstract void GetAttackPhysical(Damage damageType, int damage);
    
    public abstract int CalculateDamage(Damage damageType, int damage);

    protected abstract bool Dodge();

    protected abstract bool Parade();

    public abstract override string ToString();

    
    




    public void Heal(int heal)
    {
            PvActual += heal;
    }




}