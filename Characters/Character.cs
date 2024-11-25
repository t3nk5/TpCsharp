using Tp.Actions.Attack;

namespace Tp.Characters;

public abstract class Character
{
        public string Name { get; set; }
        public int Pv { get; set; }
        public int PvActual { get; set; }
        protected int PhysicalAttack { get; set; }
        protected int MagicalAttack { get; set; }
        protected Armors.Armors Armor { get; set; }
        protected decimal DodgeChance { get; set; }
        protected decimal ParadeChance { get; set; }
        protected decimal SpellChance { get; set; }
        
        public bool IsAlive { get; set; } =  true;

        
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
                
                
                var damage = attack.Damage;
                
                
                
                
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

        
        

     
    
    
    
}