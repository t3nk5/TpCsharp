namespace Tp.Character.Priest
{

    using Tp.Character;
    using Armors;
    using Spell;
    using Spell.TargetType;

    public class Priest : Character
    {
        public Priest(string name)
        {
            Name = name;
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
            
            
            /*
            Spells.Add(new Spell("Punishment", 2, Target.EnemyTarget, 15));
            Spells.Add(new Spell("Circle Of Care", 3, Target.Team, 30));
            Spells.Add(new Spell("Mana Burn", 2, Target.EnemyTarget, 20));
            */
            
            
        }


        public override void Choice(string choice)
        {
            throw new NotImplementedException();
        }
    }
}