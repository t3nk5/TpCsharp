namespace Tp.Character
{
    using Spell;
    using Spell.DamageType;
    
    /// <summary>
    /// Represents an abstract base class for all characters in the game.
    /// Contains common properties and functionalities shared across all character types.
    /// </summary>
    public abstract class Character
    {
        /// <summary>
        /// Gets or sets the name of the character.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the maximum health points (HP) of the character.
        /// </summary>
        public int Pv { get; set; }
        
        /// <summary>
        /// Gets or sets the current health points (HP) of the character.
        /// </summary>
        public int PvActual { get; set; }
        
        /// <summary>
        /// Gets or sets the speed of the character, used to determine turn order in battle.
        /// </summary>
        public int Speed { get; set; }
        
        /// <summary>
        /// Gets or sets the physical attack power of the character.
        /// </summary>
        protected int PhysicalAttack { get; set; }
        
        /// <summary>
        /// Gets or sets the magical attack power of the character.
        /// </summary>
        protected int MagicalAttack { get; set; }
        
        /// <summary>
        /// Gets or sets the type of armor equipped by the character, which influences damage reduction.
        /// </summary>
        protected Armors.Armors Armor { get; set; }
        
        /// <summary>
        /// Gets or sets the chance to dodge incoming physical attacks.
        /// </summary>
        protected double DodgeChance { get; set; }
        
        /// <summary>
        /// Gets or sets the chance to parry incoming physical attacks, reducing their damage.
        /// </summary>
        protected double ParadeChance { get; set; }

        /// <summary>
        /// Gets or sets the chance to resist magical attacks, nullifying their effects.
        /// </summary>
        protected double SpellResistanceChance { get; set; }
        
        /// <summary>
        /// Gets or sets the list of spells that the character can use during battle.
        /// </summary>
        public List<Spell> Spells { get; set; } = [];

        /// <summary>
        /// Gets or sets the current mana points of the character, used for casting spells.
        /// </summary>
        public int Mana { get; set; }
        
        /// <summary>
        /// Gets or sets the maximum mana points of the character.
        /// </summary>
        public int MaxMana { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the character is alive.
        /// </summary>
        public bool IsAlive { get; set; } = true;

        
        
        
        /// <summary>
        /// Processes an incoming attack, applying dodges, parries, magic resistance,
        /// and armor-based damage reductions as necessary. Updates the character's health accordingly.
        /// </summary>
        /// <param name="damage">The base damage to the incoming attack.</param>
        /// <param name="damageType">The type of damage (Physical or Magical).</param>
        public void GetAttack(int damage, Damage damageType)
        {
            switch (damageType)
            {
                case Damage.Physical:
                {
                    if (Dodge())
                    {
                        Console.WriteLine($"{Name} evaded the attack. No damage taken.");
                        return;
                    }

                    if (Parry())
                    {
                        damage = (int)(damage * 0.5);
                        Console.WriteLine($"{Name} parried the attack, reducing damage to {damage}.");
                    }

                    damage = CalculateDamageByArmors(damage, isPhysical: true, Armor);
                    break;
                }
                case Damage.Magical:
                {
                    if (ResistMagic())
                    {
                        Console.WriteLine($"{Name} resisted the magical attack. No damage taken.");
                        return;
                    }

                    damage = CalculateDamageByArmors(damage,  isPhysical: true, Armor);
                    break;
                }
            }
            
            var previousPv = PvActual;
            PvActual = Math.Max(0, PvActual - damage);

            Console.WriteLine($"{Name} suffered {damage} damage. HP: {previousPv} → {PvActual}/{Pv}");
            
            if (PvActual <= 0)
            {
                Dead();
            }
        }

        /// <summary>
        /// Determines if the character successfully dodges an incoming attack.
        /// The chance of dodging is based on the character's DodgeChance property.
        /// </summary>
        /// <returns>
        /// Returns true if the character dodges the attack, otherwise false.
        /// </returns>
        private bool Dodge()
        {
            var random = new Random();
            var roll = random.NextDouble();
            if (roll < DodgeChance)
            {
                return true; // The attack is dodged
            }

            return false; // The attack is not dodged
        }

        /// <summary>
        /// Determines if the character successfully parries an incoming physical attack.
        /// The chance of parrying is based on the character's ParadeChance property.
        /// </summary>
        /// <returns>
        /// Returns true if the character parries the attack, otherwise false.
        /// </returns>
        private bool Parry()
        {
            var random = new Random();
            var roll = random.NextDouble();
            return roll < ParadeChance;
        }

        /// <summary>
        /// Determines if the character successfully resists an incoming magical attack.
        /// The chance of resisting is based on the character's SpellResistanceChance property.
        /// </summary>
        /// <returns>
        /// Returns true if the character resists the magical attack, otherwise false.
        /// </returns>
        private bool ResistMagic()
        {
            var random = new Random();
            var roll = random.NextDouble();
            return roll < SpellResistanceChance;
        }
        
        /// <summary>
        /// Restores a specified amount of health to the character, up to their maximum health (Pv).
        /// If the character is already at full health, no healing is applied.
        /// </summary>
        /// <param name="heal">The amount of health to restore.</param>
        public void Heal(int heal)
        {
            var healAmount = Math.Min(heal, Pv - PvActual);

            if (healAmount <= 0)
            {
                Console.WriteLine($"{Name} is already at full health. No healing was applied.");
                return;
            }

            PvActual += healAmount;
            Console.WriteLine($"{Name} was healed by {healAmount} points. Current HP: {PvActual}/{Pv}");
        }
        
        /// <summary>
        /// Deducts a specified amount of mana from the character, ensuring the character has enough mana to use the ability.
        /// If the mana cost is greater than the character's current mana, only the available mana is deducted.
        /// </summary>
        /// <param name="manaCost">The amount of mana required to use the ability.</param>
        public void RemoveMana(int manaCost)
        {
            if (manaCost <= 0)
            {
                Console.WriteLine($"Error: Mana cost must be greater than 0. Value provided: {manaCost}");
                return;
            }

            var manaToRemove = Math.Min(manaCost, Mana);

            if (manaToRemove <= 0)
            {
                Console.WriteLine($"{Name} does not have enough mana to use this ability.");
                return;
            }

            Mana -= manaToRemove;
            Console.WriteLine($"{Name} used {manaToRemove} mana. Current mana: {Mana}/{MaxMana}");
        }

        /// <summary>
        /// Marks the character as dead by setting IsAlive to false
        /// and displays a message indicating the character's death.
        /// </summary>
        private void Dead()
        {
            IsAlive = false;
            Console.WriteLine($"{Name} is dead !");
        }

        /// <summary>
        /// Calculates the final damage after applying damage reduction based on the type of armor
        /// and whether the attack is physical or magical.
        /// </summary>
        /// <param name="baseDamage">The initial damage before any reductions.</param>
        /// <param name="isPhysical">Indicates whether the attack is physical (true) or magical (false).</param>
        /// <param name="armorType">The type of armor worn by the character.</param>
        /// <returns>
        /// The damage value after applying the appropriate reduction based on the armor type and attack type.
        /// </returns>
        private int CalculateDamageByArmors(int baseDamage, bool isPhysical, Armors.Armors armorType)
        {
            double reductionPercentage = 0;

            if (isPhysical)
            {
                switch (armorType)
                {
                    case Armors.Armors.Fabric:
                        reductionPercentage = 0;
                        break;
                    case Armors.Armors.Leather:
                        reductionPercentage = 0.15;
                        break;
                    case Armors.Armors.Mesh:
                        reductionPercentage = 0.30;
                        break;
                    case Armors.Armors.Plate:
                        reductionPercentage = 0.45;
                        break;
                }
            }
            else
            {
                switch (armorType)
                {
                    case Armors.Armors.Fabric:
                        reductionPercentage = 0.30;
                        break;
                    case Armors.Armors.Leather:
                        reductionPercentage = 0.20;
                        break;
                    case Armors.Armors.Mesh:
                        reductionPercentage = 0.10;
                        break;
                    case Armors.Armors.Plate:
                        reductionPercentage = 0;
                        break;
                }
            }

            return (int)(baseDamage * (1 - reductionPercentage));
        }


    }
}