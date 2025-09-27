using SnapCardGame.Models.Deck;
using SnapCardGame.Application.SnapMatch;
using Xunit;

namespace SnapCardGame.Tests.Application.SnapMatch
{
    public class SnapMatchStrategyTests
    {
        private readonly Card _aceHearts = new Card(Suit.Hearts, Rank.Ace);
        private readonly Card _aceSpades = new Card(Suit.Spades, Rank.Ace);
        private readonly Card _kingHearts = new Card(Suit.Hearts, Rank.King);
        private readonly Card _aceHeartsDuplicate = new Card(Suit.Hearts, Rank.Ace);

        [Fact]
        public void RankMatchStrategy_IsSnap_ReturnsTrue_WhenRanksMatch()
        {
            var strategy = new RankMatchStrategy();
            Assert.True(strategy.IsSnap(_aceHearts, _aceSpades)); // Same rank, different suit
            Assert.True(strategy.IsSnap(_aceHearts, _aceHeartsDuplicate)); // Same rank, same suit
        }

        [Fact]
        public void RankMatchStrategy_IsSnap_ReturnsFalse_WhenRanksDoNotMatch()
        {
            var strategy = new RankMatchStrategy();
            Assert.False(strategy.IsSnap(_aceHearts, _kingHearts)); // Different rank, same suit
        }

        [Fact]
        public void SuitMatchStrategy_IsSnap_ReturnsTrue_WhenSuitsMatch()
        {
            var strategy = new SuitMatchStrategy();
            Assert.True(strategy.IsSnap(_aceHearts, _kingHearts)); // Same suit, different rank
            Assert.True(strategy.IsSnap(_aceHearts, _aceHeartsDuplicate)); // Same suit, same rank
        }

        [Fact]
        public void SuitMatchStrategy_IsSnap_ReturnsFalse_WhenSuitsDoNotMatch()
        {
            var strategy = new SuitMatchStrategy();
            Assert.False(strategy.IsSnap(_aceHearts, _aceSpades)); // Different suit, same rank
        }

        [Fact]
        public void RankAndSuitMatchStrategy_IsSnap_ReturnsTrue_WhenRankAndSuitMatch()
        {
            var strategy = new RankAndSuitMatchStrategy();
            Assert.True(strategy.IsSnap(_aceHearts, _aceHeartsDuplicate)); // Both rank and suit match
        }

        [Fact]
        public void RankAndSuitMatchStrategy_IsSnap_ReturnsFalse_WhenOnlyRankOrSuitMatches()
        {
            var strategy = new RankAndSuitMatchStrategy();
            Assert.False(strategy.IsSnap(_aceHearts, _aceSpades)); // Only rank matches
            Assert.False(strategy.IsSnap(_aceHearts, _kingHearts)); // Only suit matches
        }

        [Fact]
        public void RankAndSuitMatchStrategy_IsSnap_ReturnsFalse_WhenNeitherMatches()
        {
            var strategy = new RankAndSuitMatchStrategy();
            var queenSpades = new Card(Suit.Spades, Rank.Queen);
            Assert.False(strategy.IsSnap(_aceHearts, queenSpades));
        }
    }
}