namespace Tp.Character.Wizard
{
    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;
    using Spell.DamageType;
    
    /// <summary>
    /// Represents a Wizard character, specializing in magical attacks and supportive spells.
    /// </summary>
    public class Wizard : Character, IMana.IMana
    {
        /// <summary>
        /// Constructor for initializing the Wizard character with default values.
        /// </summary>
        public Wizard()
        {
            //Set every value of Wizard
            Name = "Wizard";
            PvActual = 60;
            Pv = 60;
            PhysicalAttack = 0;
            MagicalAttack = 75;
            Armor = Armors.Fabric;
            DodgeChance = 0.05;
            ParadeChance = 0.05;
            SpellResistanceChance = 0.25;
            Speed = 75;
            
            Mana = 100;
            MaxMana = 100;
            
            
            
            Spells.Add(new Spell("Frost Bolt", 2, MagicalAttack, this, Target.EnemyTarget, Damage.Magical, 15, null));
            Spells.Add(new Spell("Frost Barrier ", 3, 0, this, Target.Yourself, Damage.Shield, 25, null));
            Spells.Add(new Spell("Blizzard", 3, (int)0.5 * MagicalAttack, this, Target.TeamEnemiesTarget, Damage.Magical, 25, null));
            Spells.Add(new Spell("Casting of the spell", 3, 0, this, Target.EnemyTarget, Damage.Magical, 25, null));
            
        }

        /// <summary>
        /// The Wizard drinks mana to replenish their mana pool by half of their max mana (or up to the max).
        /// </summary>
        public void DrinkMana()
        {
            if (Mana + MaxMana / 2 >= MaxMana)
            {
                Mana = MaxMana;
            }
            else
            {
                Mana += MaxMana/2;
            }
            Console.WriteLine($"{Name} drink mana and gain {MaxMana/2} mana. \n{Name} have : {Mana}/{MaxMana} mana.");
        }

        /// <summary>
        /// The Wizard uses a specified amount of mana to cast a spell or perform an action.
        /// </summary>
        /// <param name="mana">The amount of mana to use.</param>
        public void UseMana(int mana)
        {
            if (Mana - mana <= 0)
            {
                Console.WriteLine($"Your turn is blown because {Name} doesn't have enough mana.");
            }
            else
            {
                Mana -= mana;
                Console.WriteLine($"{Name} use mana {mana}. He has now {Mana}/{MaxMana} mana."); 
            }
        }


        
    }
}