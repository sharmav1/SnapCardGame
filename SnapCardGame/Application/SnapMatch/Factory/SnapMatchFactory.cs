using SnapCardGame.Models.UserSettings;

namespace SnapCardGame.Application.SnapMatch.Factory
{
    /// <summary>
    /// Handles setting up matching strategy based on user settings
    /// </summary>
    public class SnapMatchFactory : ISnapMatchFactory
    {
        /// <summary>
        /// Handles creating and returning a matching strategy based on user settings
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public ISnapMatchStrategy GetMatchStrategy(UserSettings settings)
        {
            if (settings.MatchByRankAndSuit)
                return new RankAndSuitMatchStrategy();
            if (settings.MatchByRank)
                return new RankMatchStrategy();
            return new SuitMatchStrategy();
        }
    }
}
