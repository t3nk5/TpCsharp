﻿namespace Tp.Character.Thief
{
    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;
    using Spell.DamageType;

    /// <summary>
    /// Represents a Thief character, focused on stealth, agility, and physical attacks.
    /// </summary>
    public class Thief : Character
    {
        /// <summary>
        /// Constructor for initializing the Thief character with default values.
        /// </summary>
        public Thief()
        {
            //Set every value of Thief
            Name = "Thief";
            PvActual = 80;
            Pv = 80;
            PhysicalAttack = 55;
            MagicalAttack = 0;
            Armor = Armors.Leather;
            DodgeChance = 0.15;
            ParadeChance = 0.25;
            SpellResistanceChance = 0.25;
            
            Speed = 100;
            Mana = 0;
            
            
            Spells.Add(new Spell("Cheap Shot", 2, PhysicalAttack, this, Target.EnemyTarget, Damage.Physical, 0, null));
            Spells.Add(new Spell("Evasion", 1, 0, this, Target.Yourself, Damage.Other, 0, null));
            Spells.Add(new Spell("Dagger in the back ", -1, 15, this, Target.EnemyTarget, Damage.Physical, 0, null));
            
            
        }

        
    }

}