using SnapCardGame.Models.Deck;

namespace SnapCardGame.Application
{
    /// <summary>
    /// Generates a standard 52-card deck.
    /// </summary>
    public static class CreateDeck
    {
        /// <summary>
        /// Generates a standard 52-card deck.
        /// </summary>
        /// <returns></returns>
        public static List<Card> GenerateStandard()
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
