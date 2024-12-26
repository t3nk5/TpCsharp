namespace Tp.Character.Warrior
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
            Spells.Add(new Spell("Whirlwind", 2, (int)Math.Round(0.33 * PhysicalAttack), this, Target.TeamEnemiesTarget, Damage.Physical, 0, null));
        }

        /// <summary>
        /// Overrides the base method to handle attacks specifically for the Warrior class.
        /// </summary>
        /// <param name="damage">The amount of damage to be taken.</param>
        /// <param name="damageType">The type of damage (Physical or Magical).</param>
        /// <param name="attacker">The character who is attacking.</param>
        public override void GetAttack(int damage, Damage damageType, Character attacker)
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

                        var counterAttackDamage = (int)(damage * 1.5);
                        CounterAttack(counterAttackDamage, attacker);
                    }
                    else
                    {
                        damage = CalculateDamageByArmors(damage, isPhysical: true, Armor);
                    }

                    break;
                }

                case Damage.Magical:
                {
                    if (ResistMagic())
                    {
                        Console.WriteLine($"{Name} resisted the magical attack. No damage taken.");
                        return;
                    }

                    damage = CalculateDamageByArmors(damage, isPhysical: true, Armor);
                    break;
                }
            }
            
            PvActual = Math.Max(0, PvActual - damage);
            Console.WriteLine($"{Name} suffered {damage} damage. HP: {PvActual}/{Pv}");

            if (PvActual <= 0)
            {
                Dead();
            }
            else if (damageType == Damage.Physical && !Parry())
            {
                var rng = new Random();
                if (rng.Next(100) < 25)
                {
                    var counterAttackDamage = (int)(damage * 0.5);
                    CounterAttack(counterAttackDamage, attacker);
                }
            }
        }

        /// <summary>
        /// Performs a counterattack on the attacker.
        /// </summary>
        /// <param name="damage">The amount of damage to inflict on the attacker.</param>
        /// <param name="attacker">The character who is being counterattacked.</param>
        private void CounterAttack(int damage, Character attacker)
        {
            Console.WriteLine($"{Name} counterattacks and inflicts {damage} damage to {attacker.Name}!");
            attacker.PvActual = Math.Max(0, attacker.PvActual - damage);
            Console.WriteLine(
                $"{attacker.Name} suffered {damage} damage from the counterattack. HP: {attacker.PvActual}/{attacker.Pv}");
        }
    }
}