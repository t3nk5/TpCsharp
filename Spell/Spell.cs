namespace Tp.Spell
{
    using TargetType;
    using DamageType; 
    using Character;


    public class Spell
    {
        public string Name { get; set; }
        public int Cooldown { get; set; } //1 = disponible ce tour 1 fois
        public int Damage { get; set; }
        public Character Attacker { get; set; }
        public Target TargetType { get; set; }
        public Damage TypeDamage { get; set; }
        public int ManaUse { get; set; }
        public List<Character> TargetCharacters { get; set; }

        public Spell(string name, int cooldown, int damage, Character attacker, Target targetType, Damage typeDamage, int manaUse, List<Character> target)
        {
            Name = name;
            Cooldown = cooldown;
            Damage = damage;
            Attacker = attacker;
            TargetType = targetType;
            TypeDamage = typeDamage;
            ManaUse = manaUse;
            TargetCharacters = target;
        }

        public virtual void Use(Character user, List<Character> target)
        {
            foreach (var character in target)
            {
                Console.WriteLine($"{user.Name} use {Name} on {character.Name}.");
            }

            foreach (var character in TargetCharacters)
            {
                switch (TypeDamage)
                {
                    case DamageType.Damage.Physical:
                        character.GetAttack(Damage);
                        break;
                    
                    case DamageType.Damage.Magical:
                        character.GetAttack(Damage);
                        break;
                    
                    case DamageType.Damage.Heal:
                        character.Heal(Damage);
                        break;
                    
                    case DamageType.Damage.Mana:
                        character.RemoveMana(Damage);
                        break;
                    
                    case DamageType.Damage.Shield:
                        break;
                        
                        //dans character faire un switch pour avoir le type dans une valeur et override la methode après
                }
            }
            
            
            
            
        }
    }
}