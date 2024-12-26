namespace Tp.Character.IMana
{
    /// <summary>
    /// Represents an entity that has mana and can perform actions related to mana consumption and regeneration.
    /// </summary>
    public interface IMana
    {
        /// <summary>
        /// Gets or sets the current amount of mana the entity has.
        /// </summary>
        int Mana { get; set; }
        
        /// <summary>
        /// Gets or sets the maximum amount of mana the entity can have.
        /// </summary>
        int MaxMana { get; set; }
        
        /// <summary>
        /// Regenerates mana, typically by drinking a potion or similar action.
        /// </summary>
        void DrinkMana();
        
        /// <summary>
        /// Uses a specified amount of mana.
        /// </summary>
        /// <param name="mana">The amount of mana to use.</param>
        void UseMana(int mana);

    }
}