namespace Tp.Spell
{
    using TargetType;


    public class Spell
    {
        public string Name { get; set; }
        public int Cooldown { get; set; }
        public Target TargetType { get; set; }
        public int ManaUse { get; set; }

        public Spell(string name, int cooldown, Target targetType, int manaUse)
        {
            Name = name;
            Cooldown = cooldown;
            TargetType = targetType;
            ManaUse = manaUse;
        }

        public virtual void Use(Character.Character user, Character.Character target)
        {
            Console.WriteLine($"{user.Name} use {Name} on {target.Name}.");
        }
    }
}