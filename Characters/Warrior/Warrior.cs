using Tp.Actions.Attack;
using Tp.Actions.Damages;
using static Tp.Armors.Armors;

namespace Tp.Characters.Warrior;

public class Warrior : Character
{
    public Warrior(
        string name,
        int pv = 100,
        int pvActual = 100,
        int speed = 50,
        int physicalAttack = 50,
        int magicalAttack = 0,
        double dodgeChance = 0.05,
        double paradeChance = 0.25,
        double spellChance = 0.1)
        : base(name, pv, pvActual, speed, physicalAttack, magicalAttack, Plate, dodgeChance, paradeChance, spellChance)
    {
    }

    private static readonly Random RandomGenerator = new Random();
    
    public override void Attack(List<Character> targetCharacters, string nameAttack)
    {
        switch (nameAttack)
        {
            case "Heroic Strike":
                var heroicStrike = new Attack(
                    "Heroic Strike",
                    this,
                    Target.EnemyTarget,
                    PhysicalAttack,
                    Damage.Physical,
                    targetCharacters
                );
                heroicStrike.Execute();
                break;

            case "Battle Cry":
                foreach (var hero in targetCharacters)
                {
                    hero.PhysicalAttack += 25;
                }

                PhysicalAttack += 25;
                break;

            case "Swirl":
                var swirl = new Attack(
                    "Swirl",
                    this,
                    Target.TeamEnemiesTarget,
                    (int)Math.Round(0.33 * PhysicalAttack),
                    Damage.Physical,
                    targetCharacters
                );
                swirl.Execute();
                break;
        }
    }

    public override void GetAttackPhysical(Damage damageType, int damage)
    {
        if (!IsAlive)
        {
            Console.WriteLine($"{Name} is already dead and cannot be attacked.");
            return;
        }
        /*
        if (Dodge())
        {
            Console.WriteLine($"{Name} dodged the attack !");
            return;
        }
        
        var hasBlocked = Parade();
        var damageTaken = hasBlocked ? damage / 2 : damage;
        
        //calculer en fonction de l'armure 
        var resultDamage = CalculateDamage(damageType, damageTaken);
        TakeDamage(resultDamage);
        
        */
        TakeDamage(damage);

        //CounterAttack();
        


    }

    private void CounterAttack(Character character, Damage damage)
    {
        
    }
    
    

    public override int CalculateDamage(Damage damageType, int damage)
    {
        var result = 0;
        
        


        return result;
    }
    
    
    
    
    

    public void TakeDamage(int damage)
    {
        PvActual -= damage;
        if (PvActual <= 0)
        {
            PvActual = 0;
            IsAlive = false;
            Console.WriteLine($"{Name} has been defeated.");
        }
        else
        {
            Console.WriteLine($"{Name} now has {PvActual} health.");
        }
    }

    protected override bool Dodge()
    {
        var roll = RandomGenerator.NextDouble();
        Console.WriteLine($"Dodge roll: {roll:F2}, DodgeChance: {DodgeChance:F2}");
        return roll < DodgeChance;
    }

    protected override bool Parade()
    {
        var roll = RandomGenerator.NextDouble();
        Console.WriteLine($"Parade roll: {roll:F2}, ParadeChance: {ParadeChance:F2}");
        return roll < ParadeChance;
    }

    public override string ToString()
    {
        return $"Warrior: {Name}\n" +
               $"Health: {PvActual}/{Pv}\n" +
               $"Speed: {Speed}\n" +
               $"Physical Attack: {PhysicalAttack}\n" +
               $"Magical Attack: {MagicalAttack}\n" +
               $"Dodge Chance: {DodgeChance * 100:0.##}%\n" +
               $"Parade Chance: {ParadeChance * 100:0.##}%\n" +
               $"Spell Chance: {SpellChance * 100:0.##}%\n" +
               $"Armor: Plate\n";
    }
}