namespace Tp.Character.Thief
{
    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;
    using Spell.DamageType;


    public class Thief : Character
    {
        public Thief(string name)
        {
            Name = name;
            PvActual = 80;
            PV = 80;
            PhysicalAttack = 55;
            MagicalAttack = 0;
            Armor = Armors.Leather;
            DodgeChance = 0.15;
            ParadeChance = 0.25;
            SpellResistanceChance = 0.25;
            
            Speed = 100;
            Mana = 0;
            
            
            Spells.Add(new Spell("Cheap Shot", 2, PhysicalAttack, this, Target.EnemyTarget, Damage.Physical, 0, null));
            Spells.Add(new Spell("Evasion", 1, 0, this, Target.Yourself, Damage.Other, 0, null));
            Spells.Add(new Spell("Dagger in the back ", -1, 15, this, Target.EnemyTarget, Damage.Physical, 0, null));
            
            
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