
namespace Tp.Character
{
    using Spell;


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

        public bool IsAlive { get; set; } = true;

        public virtual void GetAttack(int damage)
        {
            
            PvActual -= damage;
            Console.WriteLine($"{Name} suffered {damage} damage. PV actual : {PvActual}/{PV}");
            if (PvActual <= 0)
            {
                Dead();
            }
            
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


        public override string ToString()
        {
            return $"{Name}: {PvActual}/{PV} \n Armor {Armor}, Speed : {Speed}";
        }


        protected void Dead()
        {
            IsAlive = false;
            Console.WriteLine($"{Name} is dead !");
        }

        public abstract void Choice();



    }
}