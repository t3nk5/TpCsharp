namespace Tp.Character;

public class Character
{ 
        protected string Name { get; set; }
        protected int Pv { get; set; }
        protected int PvActual { get; set; }
        protected int PhysicalAttack { get; set; }
        protected int MagicalAttack { get; set; }
        protected Armors.Armors Armor { get; set; }
        protected decimal DodgeChance { get; set; }
        protected decimal ParadeChance { get; set; }
        protected decimal SpellChance { get; set; }
        
        
        protected bool IsAlive { get; set; } =  true;

        public Character(string name, int pv, int pvActual, int physicalAttack, int magicalAttack, Armors.Armors armor, decimal dodgeChance, decimal paradeChance, decimal spellChance)
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
        
        

     
    
    
    
}