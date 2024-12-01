namespace Tp.Character.Wizard
{
    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;
    
    
    public class Wizard : Character
    {

        public Wizard(string name)
        {
            Name = name;
            PvActual = 60;
            PV = 60;
            PhysicalAttack = 0;
            MagicalAttack = 75;
            Armor = Armors.Fabric;
            DodgeChance = 0.05;
            ParadeChance = 0.05;
            SpellResistanceChance = 0.25;
            Speed = 75;
            Mana = 100;
            
            Spells.Add(new Spell("Frost Bolt", 1, Target.EnemyTarget, 15));
            Spells.Add(new Spell("Frost Barrier ", 2, Target.Yourself, 25));
            Spells.Add(new Spell("Blizzard", 2, Target.TeamEnemiesTarget, 25));
            
        }
        
        

    }
}