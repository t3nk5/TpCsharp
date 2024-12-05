namespace Tp.Character.Paladin
{
    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;


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
            Speed = 40; // quelle vitesse ?
            Mana = 60;
            
/*
            Spells.Add(new Spell("Cross-Strike", 2, Target.EnemyTarget, 5));
            Spells.Add(new Spell("Judgment", 2, Target.EnemyTarget, 10));
            Spells.Add(new Spell("Flash of Light", 2, Target.EnemyTarget, 25));
            */
            
            
            
        }

        public override void Choice(string choice)
        {
            throw new NotImplementedException();
        }
    }
}