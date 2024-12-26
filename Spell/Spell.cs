namespace Tp.Spell
{
    using TargetType;
    using DamageType; 
    using Character;

    /// <summary>
    /// Represents a spell that a character can use in the game, with various attributes such as cooldown, damage, target, and mana usage.
    /// </summary>
    public class Spell
    {
        public string Name { get; set; }
        public int Cooldown { get; set; } 
        public int ActualCooldown { get; set; } //1 = available this turn 1 time
        public int Damage { get; set; }
        public Character Attacker { get; set; }
        public Target TargetType { get; set; }
        public Damage TypeDamage { get; set; }
        public int ManaUse { get; set; }
        public List<Character> TargetCharacters { get; set; }

        /// <summary>
        /// Constructor for creating a new spell with specific attributes.
        /// </summary>
        /// <param name="name">The name of the spell.</param>
        /// <param name="cooldown">The cooldown duration in turns.</param>
        /// <param name="damage">The damage dealt by the spell.</param>
        /// <param name="attacker">The character casting the spell.</param>
        /// <param name="targetType">The type of target (team, enemy, etc.).</param>
        /// <param name="typeDamage">The type of damage (physical, magical, etc.).</param>
        /// <param name="manaUse">The amount of mana used by the spell.</param>
        /// <param name="target">The list of characters affected by the spell.</param>
        public Spell(string name, int cooldown, int damage, Character attacker, Target targetType, Damage typeDamage, int manaUse, List<Character> target)
        {
            Name = name;
            Cooldown = cooldown;
            ActualCooldown = 1;
            Damage = damage;
            Attacker = attacker;
            TargetType = targetType;
            TypeDamage = typeDamage;
            ManaUse = manaUse;
            TargetCharacters = target;
        }

        /// <summary>
        /// The method to use the spell. It applies the effects (damage, healing, etc.) to the target characters.
        /// </summary>
        public virtual void Use()
        {
            foreach (var character in TargetCharacters)
            {
                switch (TypeDamage)
                {
                    case DamageType.Damage.Physical:
                        character.GetAttack(Damage, TypeDamage, Attacker);
                        break;
                    
                    case DamageType.Damage.Magical:
                        character.GetAttack(Damage, TypeDamage, Attacker);
                        break;
                    
                    case DamageType.Damage.Heal:
                        character.Heal(Damage);
                        break;
                    
                    case DamageType.Damage.Mana:
                        character.RemoveMana(Damage);
                        break;
                    
                    case DamageType.Damage.Shield:
                        break;
                    case DamageType.Damage.Other:
                        break;
                }
            }
            SetCooldown();
        }

        /// <summary>
        /// Set the cooldown of the spell to its original value.
        /// </summary>
        private void SetCooldown()
        {
            ActualCooldown = Cooldown;
        }
        
        /// <summary>
        /// Returns a string representation of the spell, showing its name, damage, cooldown, and mana usage.
        /// </summary>
        /// <returns>A string with the spell's information.</returns>
        public override string ToString()
        {
            return $"Name: {Name}, Damage: {Damage}, Cooldown: {Cooldown}, Mana: {ManaUse}, Target: {TargetCharacters}";
        }
    }
}