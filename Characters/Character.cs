using Tp.Actions.Attack;
using Tp.Actions.Damages;

namespace Tp.Characters;

public abstract class Character
{
        public string Name { get; set; }
        public int Pv { get; set; }
        public int PvActual { get; set; }
        protected int PhysicalAttack { get; set; }
        protected int MagicalAttack { get; set; }
        protected Armors.Armors Armor { get; set; }
        private decimal DodgeChance { get; set; }
        private decimal ParadeChance { get; set; }
        protected decimal SpellChance { get; set; }

        private bool IsAlive { get; set; } =  true;

        
        protected Character(string name, int pv, int pvActual, int physicalAttack, int magicalAttack, Armors.Armors armor, decimal dodgeChance, decimal paradeChance, decimal spellChance)
        {
                Name = name;
                Pv = pv;
                PvActual = pvActual;
                PhysicalAttack = physicalAttack;
                MagicalAttack = magicalAttack;
                Armor = armor;
                DodgeChance = dodgeChance;
                ParadeChance = paradeChance;
                SpellChance = spellChance;
        }

        public void GetAttack(Attack attack)
        {
                if (!IsAlive)
                {
                        Console.WriteLine($"{Name} is already dead and can't be attacked.");
                        return;
                }
                if (Dodge(attack))
                {
                        Console.WriteLine($"{Name} dodged the attack {attack.Name} !");
                        return;
                }

                if (Parade(attack))
                {
                        Console.WriteLine($"{Name} parried the attack {attack.Name}!");
                        return;
                }
                
                
                
                var damage = CalculateDamage(attack);
                ApplyDamage(damage);

                
                if (PvActual <= 0)
                {
                        IsAlive = false;
                        PvActual = 0;
                        Console.WriteLine($"{Name} has died.");
                }
                
        }
        
        
        
        private bool Dodge(Attack attack)
        {
                var rand = new Random();
                return rand.NextDouble() < (double)DodgeChance;
        }
        private bool Parade(Attack attack)
        {
                var rand = new Random();
                return rand.NextDouble() < (double)ParadeChance;
        }

        private int CalculateDamage(Attack attack)
        {
                var damage = attack.Damage;
                
                if (attack.TypeDamage == Damage.Physical)
                {
                        damage = (int)(damage * GetPhysicalArmorReduction());
                }
                else if (attack.TypeDamage == Damage.Magical)
                {
                        damage = (int)(damage * GetMagicalArmorReduction());
                }

                return damage;
        }

        private decimal GetPhysicalArmorReduction()
        {
                
        }

        private decimal GetMagicalArmorReduction()
        {
        }
        
        
        private void ApplyDamage(int damage)
        {
                PvActual -= damage;
                Console.WriteLine($"{Name} takes {damage} damage. Remaining HP: {PvActual}/{Pv}");
        }





}