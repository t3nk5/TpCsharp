namespace Tp.Character.Wizard
{
    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;
    
    
    public class Wizard : Character, IMana.IMana
    {
        public int MaxMana { get; set; }

        public Wizard(string name)
        {
            Name = name;
            PvActual = 60;
            PV = 60;
            PhysicalAttack = 0;
            MagicalAttack = 75;
            Armor = Armors.Fabric;
            DodgeChance = 0.05;
            ParadeChance = 0.05;
            SpellResistanceChance = 0.25;
            Speed = 75;
            
            Mana = 100;
            MaxMana = 100;
            
            
            /*
            Spells.Add(new Spell("Frost Bolt", 2, Target.EnemyTarget, 15));
            Spells.Add(new Spell("Frost Barrier ", 3, Target.Yourself, 25));
            Spells.Add(new Spell("Blizzard", 3, Target.TeamEnemiesTarget, 25));
            */
        }

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


        public override void Choice(string choice)
        {
            throw new NotImplementedException();
        }
    }
}