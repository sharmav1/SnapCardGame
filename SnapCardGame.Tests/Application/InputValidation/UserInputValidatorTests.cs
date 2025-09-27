using SnapCardGame.Application.InputValidation;

namespace SnapCardGame.Tests.Application.InputValidation
{
    public class UserInputValidatorTests
    {
        private readonly IUserInputValidator _validator;

        public UserInputValidatorTests()
        {
            _validator = new UserInputValidator();
        }

        // --- ValidatePacks ---
        [Theory]
        [InlineData("1")]
        [InlineData("10")]
        [InlineData("99")]
        public void ValidatePacks_ValidInput_ReturnsInt(string input)
        {
            var result = _validator.ValidatePacks(input);
            Assert.Equal(int.Parse(input), result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("abc")]
        [InlineData(" ")]
        public void ValidatePacks_InvalidString_ThrowsArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => _validator.ValidatePacks(input));
        }

        [Theory]
        [InlineData("0")]
        [InlineData("-1")]
        public void ValidatePacks_NonPositive_ThrowsArgumentOutOfRangeException(string input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _validator.ValidatePacks(input));
        }

        // --- ValidateBothRankAndSuit ---
        [Theory]
        [InlineData("y")]
        [InlineData("Y")]
        [InlineData("n")]
        [InlineData("N")]
        public void ValidateBothRankAndSuit_ValidInput_ReturnsChar(string input)
        {
            var result = _validator.ValidateBothRankAndSuit(input);
            Assert.Equal(char.ToLower(input[0]), char.ToLower(result));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("yes")]
        [InlineData(" ")]
        [InlineData("z")]
        [InlineData("1")]
        public void ValidateBothRankAndSuit_InvalidInput_ThrowsArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => _validator.ValidateBothRankAndSuit(input));
        }

        // --- ValidateRank ---
        [Theory]
        [InlineData("y")]
        [InlineData("Y")]
        [InlineData("n")]
        [InlineData("N")]
        public void ValidateRank_ValidInput_ReturnsChar(string input)
        {
            var result = _validator.ValidateRank(input);
            Assert.Equal(char.ToLower(input[0]), char.ToLower(result));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("yes")]
        [InlineData(" ")]
        [InlineData("z")]
        [InlineData("1")]
        public void ValidateRank_InvalidInput_ThrowsArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => _validator.ValidateRank(input));
        }

        // --- ValidateSuit ---
        [Theory]
        [InlineData("y")]
        [InlineData("Y")]
        [InlineData("n")]
        [InlineData("N")]
        public void ValidateSuit_ValidInput_ReturnsChar(string input)
        {
            var result = _validator.ValidateSuit(input);
            Assert.Equal(char.ToLower(input[0]), char.ToLower(result));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("yes")]
        [InlineData(" ")]
        [InlineData("z")]
        [InlineData("1")]
        public void ValidateSuit_InvalidInput_ThrowsArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => _validator.ValidateSuit(input));
        }
    }
}
