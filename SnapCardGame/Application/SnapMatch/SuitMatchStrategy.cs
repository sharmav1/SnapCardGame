using SnapCardGame.Models.Deck;

namespace SnapCardGame.Application.SnapMatch
{
    /// <summary>
    /// Defines a strategy for determining if two cards form a "snap" match based on suit only.
    /// </summary>
    public class SuitMatchStrategy : ISnapMatchStrategy
    {
        /// <summary>
        /// Determines if the current card and previous card form a snap match based on suit only.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="previous"></param>
        /// <returns></returns>
        public bool IsSnap(Card current, Card previous) => current.Suit == previous.Suit;
    }
}
