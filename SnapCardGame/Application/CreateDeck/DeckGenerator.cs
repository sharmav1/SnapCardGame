using SnapCardGame.Models.Deck;

namespace SnapCardGame.Application.CreateDeck
{
    /// <summary>
    /// This class is responsible for generating decks of cards.
    /// </summary>
    public class DeckGenerator : IDeckGenerator
    {
        /// <summary>
        /// Generates a standard 52-card deck.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Card> GenerateStandard()
        {
            var deck = new List<Card>();
            foreach (var suit in Enum.GetValues(typeof(Suit)).Cast<Suit>())
            {
                foreach (var rank in Enum.GetValues(typeof(Rank)).Cast<Rank>())
                {
                    deck.Add(new Card(suit, rank));
                }
            }
            return deck;
        }
    }
}
