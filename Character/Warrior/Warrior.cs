namespace Tp.Character.Warrior
{
    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;
    using Spell.DamageType;
    

    public class Warrior : Character
    {
        public Warrior()
        {
            Name = "Warrior";
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

            
            Spells.Add(new Spell("Heroic Attack", 2, 50, this, Target.EnemyTarget, Damage.Physical, 0, null));
            Spells.Add(new Spell("Cry Of Battle", 3, 25, this, Target.Team, Damage.Other, 0, null));
            Spells.Add(new Spell("Whirlwind", 2, (int)Math.Round(0.33*PhysicalAttack), this, Target.TeamEnemiesTarget, Damage.Physical, 0, null));


        }


        public override void GetAttack(int damage, Damage damageType)
        {
            base.GetAttack(damage, damageType);
            
        }

       
        
        
        

        
    
    }
}