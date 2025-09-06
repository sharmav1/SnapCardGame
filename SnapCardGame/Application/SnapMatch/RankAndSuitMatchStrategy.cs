using SnapCardGame.Models.Deck;

namespace SnapCardGame.Application.SnapMatch
{
    /// <summary>
    /// Defines a strategy for determining if two cards form a "snap" match based on both rank and suit.
    /// </summary>
    public class RankAndSuitMatchStrategy : ISnapMatchStrategy
    {
        /// <summary>
        /// Determines if the current card and previous card form a snap match based on both rank and suit.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="previous"></param>
        /// <returns></returns>
        public bool IsSnap(Card current, Card previous) => current.Rank == previous.Rank && current.Suit == previous.Suit;
    }
}
