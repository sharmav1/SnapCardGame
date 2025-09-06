using SnapCardGame.Models.Deck;

/// <summary>
/// Defines a strategy for determining if two cards form a "snap" match.
/// </summary>
public interface ISnapMatchStrategy
{
    /// <summary>
    /// Determines if the current card and previous card form a snap match based on the strategy.
    /// </summary>
    /// <param name="current"></param>
    /// <param name="previous"></param>
    /// <returns></returns>
    bool IsSnap(Card current, Card previous);
}
