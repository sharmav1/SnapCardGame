using SnapCardGame.Models.Deck;

namespace SnapCardGame.Application.Shuffle
{
    /// <summary>
    /// This interface defines a contract for shuffling multiple packs of cards into a single deck.
    /// </summary>
    public interface IShuffleCard
    {
        /// <summary>
        /// Shuffles the specified number of card packs into a single deck.
        /// </summary>
        /// <param name="numOfPacks"></param>
        /// <returns></returns>
        List<Card> Execute(int numOfPacks);
    }
}
