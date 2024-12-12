namespace Tp.Character.Warrior
{
    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;
    using Spell.DamageType;
    

    public class Warrior : Character
    {
        public Warrior(string name)
        {
            Name = name;
            PvActual = 100;
            PV = 100;
            PhysicalAttack = 50;
            MagicalAttack = 0;
            Armor = Armors.Fabric;
            DodgeChance = 0.05;
            ParadeChance = 0.25;
            SpellResistanceChance = 0.1;
            Speed = 50;
            Mana = 0;

            
            Spells.Add(new Spell("Heroic Attack", 2, 50, Target.EnemyTarget, Damage.Physical, 0, null));
            Spells.Add(new Spell("Cry Of Battle", 3, 25, Target.Team, Damage.Other, 0, null));
            Spells.Add(new Spell("Whirlwind", 2, (int)Math.Round(0.33*PhysicalAttack), Target.TeamEnemiesTarget, Damage.Physical, 0, null));


        }


        public override void GetAttack(int damage)
        {
            base.GetAttack(damage);
            
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