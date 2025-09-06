using SnapCardGame.Models.Deck;

namespace SnapCardGame.Application.SnapMatch
{
    /// <summary>
    /// Defines a strategy for determining if two cards form a "snap" match based on rank only.
    /// </summary>
    public class RankMatchStrategy : ISnapMatchStrategy
    {
        /// <summary>
        /// Determines if the current card and previous card form a snap match based on rank only.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="previous"></param>
        /// <returns></returns>
        public bool IsSnap(Card current, Card previous) => current.Rank == previous.Rank;
    }
}
