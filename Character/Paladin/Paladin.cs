namespace Tp.Character.Paladin
{
    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;
    using Spell.DamageType;


    public class Paladin : Character
    {
        public Paladin()
        {
            Name = "Paladin";
            PvActual = 95;
            PV = 95;
            PhysicalAttack = 40;
            MagicalAttack = 40;
            Armor = Armors.Mesh;
            DodgeChance = 0.05;
            ParadeChance = 0.10;
            SpellResistanceChance = 0.20;
            
            Speed = 40; 
            Mana = 60;
            Spells.Add(new Spell("Cry Of Battle", 3, 25, this, Target.Team, Damage.Other, 0, null));

            Spells.Add(new Spell("RIP my ACL", 2, PhysicalAttack, this, Target.EnemyTarget, Damage.Physical, 5, null));
            Spells.Add(new Spell("Judgment", 2, MagicalAttack, this, Target.EnemyTarget, Damage.Magical, 10, null));
            Spells.Add(new Spell("Flash of Light", 2, (int)1.25 * MagicalAttack, this, Target.Partner, Damage.Heal, 25, null));
            
            
            
            
        }

        
    }
}