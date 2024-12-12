namespace Tp.Character.Paladin
{
    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;
    using Spell.DamageType;


    public class Paladin : Character
    {
        public Paladin(string name)
        {
            Name = name;
            PvActual = 95;
            PV = 95;
            PhysicalAttack = 40;
            MagicalAttack = 40;
            Armor = Armors.Mesh;
            DodgeChance = 0.05;
            ParadeChance = 0.10;
            SpellResistanceChance = 0.20;
            
            Speed = 40; 
            Mana = 60;
            Spells.Add(new Spell("Cry Of Battle", 3, 25, Target.Team, Damage.Other, 0, null));

            Spells.Add(new Spell("RIP my ACL", 2, PhysicalAttack, Target.EnemyTarget, Damage.Physical, 5, null));
            Spells.Add(new Spell("Judgment", 2, MagicalAttack, Target.EnemyTarget, Damage.Magical, 10, null));
            Spells.Add(new Spell("Flash of Light", 2, (int)1.25 * MagicalAttack, Target.Partner, Damage.Heal, 25, null));
            
            
            
            
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