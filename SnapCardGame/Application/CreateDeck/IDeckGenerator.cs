using SnapCardGame.Models.Deck;

namespace SnapCardGame.Application.CreateDeck
{
    /// <summary>
    /// This interface defines a contract for generating decks of cards.
    /// </summary>
    public interface IDeckGenerator
    {
        /// <summary>
        /// Generates a standard 52-card deck.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Card> GenerateStandard();
    }
}
