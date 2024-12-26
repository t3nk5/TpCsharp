namespace Tp.Spell.TargetType
{
    /// <summary>
    /// Represents the possible target types for a spell or ability in the game.
    /// </summary>
    public enum Target
    {
        /// <summary>
        /// The spell targets a single enemy character.
        /// </summary>
        EnemyTarget,
        
        /// <summary>
        /// The spell targets all enemy characters on the opposing team.
        /// </summary>
        TeamEnemiesTarget,
        
        /// <summary>
        /// The spell targets all characters on the caster's team.
        /// </summary>
        Team,
        
        /// <summary>
        /// The spell targets a single friendly character (partner).
        /// </summary>
        Partner,
        
        /// <summary>
        /// The spell targets the caster themselves.
        /// </summary>
        Yourself
    }
}