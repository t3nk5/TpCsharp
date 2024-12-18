namespace Tp.Character.Priest
{

    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;
    using Spell.DamageType;

    public class Priest : Character
    {
        public Priest()
        {
            Name = "Priest";
            PvActual = 70;
            PV = 70;
            PhysicalAttack = 0;
            MagicalAttack = 65;
            Armor = Armors.Fabric;
            DodgeChance = 0.1;
            ParadeChance = 0;
            SpellResistanceChance = 0.20;
            Speed = 70;
            Mana = 100;
            
            Spells.Add(new Spell("Heroic Attack", 2, 50, this, Target.EnemyTarget, Damage.Physical, 0, null));

            
            Spells.Add(new Spell("Punishment", 2, (int)0.75 * MagicalAttack, this, Target.EnemyTarget, Damage.Magical, 15, null));
            Spells.Add(new Spell("Circle Of Care", 3, (int)0.75 * MagicalAttack, this, Target.Team, Damage.Heal, 30, null));
            Spells.Add(new Spell("Mana Burn", 4, (int)0.5, this, Target.EnemyTarget, Damage.Mana, 20, null));
            
            
            
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