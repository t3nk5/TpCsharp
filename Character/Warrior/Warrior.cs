﻿namespace Tp.Character.Warrior
{
    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;
    using Spell.DamageType;
    
    /// <summary>
    /// Represents a Warrior character, a strong and resilient fighter focused on physical combat.
    /// </summary>
    public class Warrior : Character
    {
        /// <summary>
        /// Constructor for initializing the Warrior character with default values.
        /// </summary>
        public Warrior()
        {
            //Set every value of Warrior
            Name = "Warrior";
            PvActual = 100;
            Pv = 100;
            PhysicalAttack = 50;
            MagicalAttack = 0;
            Armor = Armors.Fabric;
            DodgeChance = 0.05;
            ParadeChance = 0.25;
            SpellResistanceChance = 0.1;
            Speed = 50;
            Mana = 0;

            
            Spells.Add(new Spell("Heroic Attack", 2, 50, this, Target.EnemyTarget, Damage.Physical, 0, null));
            Spells.Add(new Spell("Cry Of Battle", 3, 25, this, Target.Team, Damage.Other, 0, null));
            Spells.Add(new Spell("Whirlwind", 2, (int)Math.Round(0.33*PhysicalAttack), this, Target.TeamEnemiesTarget, Damage.Physical, 0, null));


        }
    }
}