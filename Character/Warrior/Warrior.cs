namespace Tp.Character.Warrior
{
    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;
    

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

            /*
            Spells.Add(new Spell("Heroic Attack", 2, Target.EnemyTarget, 0));
            Spells.Add(new Spell("Cry Of Battle", 3, Target.Team, 0));
            Spells.Add(new Spell("Whirlwind", 2, Target.TeamEnemiesTarget, 0));
*/

        }


        public override void GetAttack(int damage)
        {
            base.GetAttack(damage);
            
        }

        public override void Choice(string choice)
        {
            switch (choice)
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