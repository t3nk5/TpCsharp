namespace Tp.Character.Wizard
{
    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;
    using Spell.DamageType;
    
    
    public class Wizard : Character, IMana.IMana
    {
        public Wizard()
        {
            Name = "Wizzard";
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
            
            
            
            Spells.Add(new Spell("Frost Bolt", 2, MagicalAttack, this, Target.EnemyTarget, Damage.Magical, 15, null));
            Spells.Add(new Spell("Frost Barrier ", 3, 0, this, Target.Yourself, Damage.Shield, 25, null));
            Spells.Add(new Spell("Blizzard", 3, (int)0.5 * MagicalAttack, this, Target.TeamEnemiesTarget, Damage.Magical, 25, null));
            Spells.Add(new Spell("Casting of the spell", 3, 0, this, Target.EnemyTarget, Damage.Magical, 25, null));
            
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


        public override void Choice()
        {
            Console.WriteLine("Which specialties used");
            string? action = null;

            while (action != "1" && action != "2" && action != "3")
            {
                Console.WriteLine("Which specialties to use? (1, 2, or 3)");
                action = Console.ReadLine();

                if (action != "1" && action != "2" && action != "3")
                {
                    Console.WriteLine("Invalid input. Please choose 1, 2, or 3.");
                }
            }
            
            switch (action)
            {
                case "1":
                    
                    break;
                case "2":
                    
                    break;
                case "3":
                    break;
                
            }
        }
    }
}