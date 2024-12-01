
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
        public List<Spell> Spells { get; set; } = new List<Spell>();
        public int Mana { get; set; }

        protected bool IsAlive { get; set; }

        public virtual void Attack(Character target, Spell spell)
        {
            Console.WriteLine($"{Name} use {spell.Name} on {target.Name}.");
        }

        public virtual void GetAttack(int damage)
        {
            PvActual -= damage;
            Console.WriteLine($"{Name} suffered {damage} damage. PV actual : {PvActual}/{PV}");
            if (PvActual <= 0)
            {
                IsAlive = false;
                Dead();
            }
        }

        public virtual void Heal(int heal)
        {
            PvActual += Math.Min(PvActual + heal, PV);
            Console.WriteLine($"{Name} suffered {heal} heal.");
        }


        public override string ToString()
        {
            return $"{Name}: {PvActual}/{PV} \n Armor {Armor}, Speed : {Speed}";
        }


        protected void Dead()
        {
            Console.WriteLine($"{Name} is dead !");
        }

    }
}