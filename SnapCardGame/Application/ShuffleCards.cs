using SnapCardGame.Models.Deck;

namespace SnapCardGame.Application
{
    /// <summary>
    /// Handles shuffling of multiple packs of cards into a single deck.
    /// </summary>
    public class ShuffleCards
    {
        /// <summary>
        /// Shuffles the specified number of card packs into a single deck.
        /// </summary>
        /// <param name="numOfPacks"></param>
        /// <returns></returns>
        public static List<Card> Execute(int numOfPacks)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Shuffling cards...");

            // Create the combined deck
            var deck = new List<Card>();
            for (int i = 0; i < numOfPacks; i++)
            {
                deck.AddRange(CreateDeck.GenerateStandard());
            }

            // Shuffle using Fisher-Yates algorithm
            var rng = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (deck[n], deck[k]) = (deck[k], deck[n]);
            }

            Console.WriteLine("Cards shuffled successfully!");
            Console.WriteLine();
            return deck;
        }
    }
}
