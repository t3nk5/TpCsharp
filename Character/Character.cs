namespace Tp.Character
{
    using Spell;
    using Spell.DamageType;


    public abstract class Character
    {
        public string Name { get; set; }
        public int PV { get; set; }
        public int PvActual { get; set; }
        public int Speed { get; set; }
        public int PhysicalAttack { get; set; }
        public int MagicalAttack { get; set; }
        public Armors.Armors Armor { get; set; }
        protected double DodgeChance { get; set; }
        protected double ParadeChance { get; set; }
        public double SpellResistanceChance { get; set; }
        public List<Spell> Spells { get; set; } = [];

        public int Mana { get; set; }
        public int MaxMana { get; set; }

        public bool IsAlive { get; set; } = true;

        public void GetAttack(int damage, Damage damageType)
        {
            if (Damage.Physical == damageType)
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
            }else if (Damage.Magical == damageType){
                if (ResistMagic())
                {
                    Console.WriteLine($"{Name} resisted the magical attack. No damage taken.");
                    return;
                }
            }


            var previousPv = PvActual;
            PvActual = Math.Max(0, PvActual - damage);

            Console.WriteLine($"{Name} suffered {damage} damage. HP: {previousPv} → {PvActual}/{PV}");
            if (PvActual <= 0)
            {
                Dead();
            }
        }

        private bool Dodge()
        {
            var random = new Random();
            var roll = random.NextDouble();
            if (roll < DodgeChance)
            {
                return true;
            }

            return false;
        }

        private bool Parry()
        {
            var random = new Random();
            var roll = random.NextDouble();
            return roll < ParadeChance;
        }

        private bool ResistMagic()
        {
            var random = new Random();
            var roll = random.NextDouble();
            return roll < SpellResistanceChance;
        }
        
        public void Heal(int heal)
        {
            var healAmount = Math.Min(heal, PV - PvActual);

            if (healAmount <= 0)
            {
                Console.WriteLine($"{Name} is already at full health. No healing was applied.");
                return;
            }

            PvActual += healAmount;
            Console.WriteLine($"{Name} was healed by {healAmount} points. Current HP: {PvActual}/{PV}");
        }
        
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

        private void Dead()
        {
            IsAlive = false;
            Console.WriteLine($"{Name} is dead !");
        }
        
        
    }
}