namespace Tp.Character.Priest
{

    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;
    using Spell.DamageType;

    /// <summary>
    /// Represents a Priest character, focused on magical abilities with a strong healing and supportive role.
    /// </summary>
    public class Priest : Character
    {
        /// <summary>
        /// Constructor for initializing the Priest character with default values.
        /// </summary>
        public Priest()
        {
            //Set every value of Priest
            Name = "Priest";
            PvActual = 70;
            Pv = 70;
            PhysicalAttack = 0;
            MagicalAttack = 65;
            Armor = Armors.Fabric;
            DodgeChance = 0.1;
            ParadeChance = 0;
            SpellResistanceChance = 0.20;
            Speed = 70;
            Mana = 100;
            
            Spells.Add(new Spell("Heroic Attack", 2, 50, this, Target.EnemyTarget, Damage.Physical, 0, null));
            Spells.Add(new Spell("Punishment", 2, (int)0.75 * MagicalAttack, this, Target.EnemyTarget, Damage.Magical, 15, null));
            Spells.Add(new Spell("Circle Of Care", 3, (int)0.75 * MagicalAttack, this, Target.Team, Damage.Heal, 30, null));
            Spells.Add(new Spell("Mana Burn", 4, (int)0.5, this, Target.EnemyTarget, Damage.Mana, 20, null));
            
            
            
        }


       
    }
}