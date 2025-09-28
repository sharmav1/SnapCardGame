namespace SnapCardGame.Models.UserSettings
{
    /// <summary>
    /// This class represents user settings for the Snap Card Game.
    /// </summary>
    public class UserSettings
    {
        /// <summary>
        /// Number of packs to be used in the game.
        /// </summary>
        public int NumberOfPacks { get; init; }

        /// <summary>
        /// Indicates if the game should match by rank.
        /// </summary>
        public bool MatchByRank { get; init; }

        /// <summary>
        /// Indicates if the game should match by suit.
        /// </summary>
        public bool MatchBySuit { get; init; }

        /// <summary>
        /// Indicates if the game should match by both rank and suit.
        /// </summary>
        public bool MatchByRankAndSuit { get; init; }

        /// Number of players can also be setup here and ManageUserInput class similar to other inputs
    }
}
