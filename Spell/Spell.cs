namespace Tp.Spell
{
    using TargetType;
    using DamageType;    


    public class Spell
    {
        public string Name { get; set; }
        public int Cooldown { get; set; } //1 = disponible ce tour 1 fois
        public int Damage { get; set; }
        public Target TargetType { get; set; }
        public Damage TypeDamage { get; set; }
        public int ManaUse { get; set; }
        public List<Character.Character> TargetCharacters { get; set; }

        public Spell(string name, int cooldown, int damage, Target targetType, Damage typeDamage, int manaUse, List<Character.Character> target)
        {
            Name = name;
            Cooldown = cooldown;
            Damage = damage;
            TargetType = targetType;
            TypeDamage = typeDamage;
            ManaUse = manaUse;
            TargetCharacters = target;
        }

        public virtual void Use(Character.Character user, List<Character.Character> target)
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
                }
            }
            
            
            
            
        }
    }
}