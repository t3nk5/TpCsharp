namespace Tp.Character.Thief
{
    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;


    public class Thief : Character
    {
        public Thief(string name)
        {
            Name = name;
            PvActual = 80;
            PV = 80;
            PhysicalAttack = 55;
            MagicalAttack = 0;
            Armor = Armors.Leather;
            DodgeChance = 0.15;
            ParadeChance = 0.25;
            SpellResistanceChance = 0.25;
            Speed = 100;
            Mana = 0;
            
            Spells.Add(new Spell("Cheap Shot", 1, Target.EnemyTarget, 0));
            Spells.Add(new Spell("Evasion", 0, Target.Yourself, 0));
            
            
        }

    }

}