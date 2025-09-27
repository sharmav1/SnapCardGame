using Moq;
using SnapCardGame.Application.InputValidation;
using SnapCardGame.Application.UserInputs;
using System.Text;

namespace SnapCardGame.Tests.Application.UserInputs
{
    public class UserInputManagerTests
    {
        private readonly Mock<IUserInputValidator> _userInputValidatorMock;
        private readonly IManageUserInputs _manageUserInputs;

        private readonly StringBuilder _consoleOutput;
        private Mock<TextReader> _consoleInput;

        public UserInputManagerTests()
        {
            _userInputValidatorMock = new Mock<IUserInputValidator>();
            _manageUserInputs = new ManageUserInputs(_userInputValidatorMock.Object);
            
            _consoleOutput = new StringBuilder();
            var consoleOutputWriter = new StringWriter(_consoleOutput);
            _consoleInput = new Mock<TextReader>();
            
            Console.SetOut(consoleOutputWriter);
            Console.SetIn(_consoleInput.Object);
        }

        [Fact]
        public void GetUserSettings_ShouldFetchSettingsSuccessfully_WhenUserOptsForBothRankAndSuit()
        {
            // Arrange
            _userInputValidatorMock.Setup(v => v.ValidatePacks(It.IsAny<string>())).Returns(2);
            _userInputValidatorMock.Setup(v => v.ValidateBothRankAndSuit(It.IsAny<string>())).Returns('y');

            _consoleInput.SetupSequence(r => r.ReadLine())
                .Returns("2")  // Number of packs
                .Returns("y"); // Both rank and suit

            // Act
            var result = _manageUserInputs.GetUserSettings();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.NumberOfPacks);
            Assert.True(result.MatchByRankAndSuit);
            Assert.True(result.MatchByRank);
            Assert.True(result.MatchBySuit);

            _userInputValidatorMock.Verify(v => v.ValidatePacks(It.IsAny<string>()), Times.Once);
            _userInputValidatorMock.Verify(v => v.ValidateBothRankAndSuit(It.IsAny<string>()), Times.Once);
            _userInputValidatorMock.Verify(v => v.ValidateRank(It.IsAny<string>()), Times.Never);
            _userInputValidatorMock.Verify(v => v.ValidateSuit(It.IsAny<string>()), Times.Never);

            _consoleInput.Verify(r => r.ReadLine(), Times.Exactly(2));
        }

        [Fact]
        public void GetUserSettings_ShouldFetchSettingsSuccessfully_WhenUserOptsForRank()
        {
            // Arrange
            _userInputValidatorMock.Setup(v => v.ValidatePacks(It.IsAny<string>())).Returns(2);
            _userInputValidatorMock.Setup(v => v.ValidateBothRankAndSuit(It.IsAny<string>())).Returns('n');
            _userInputValidatorMock.Setup(v => v.ValidateRank(It.IsAny<string>())).Returns('y');
            _userInputValidatorMock.Setup(v => v.ValidateSuit(It.IsAny<string>())).Returns('n');

            _consoleInput.SetupSequence(r => r.ReadLine())
                .Returns("2")  // Number of packs
                .Returns("n")  // Both rank and suit
                .Returns("y")  // For rank
                .Returns("n"); // For suit

            // Act
            var result = _manageUserInputs.GetUserSettings();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.NumberOfPacks);
            Assert.False(result.MatchByRankAndSuit);
            Assert.True(result.MatchByRank);
            Assert.False(result.MatchBySuit);

            _userInputValidatorMock.Verify(v => v.ValidatePacks(It.IsAny<string>()), Times.Once);
            _userInputValidatorMock.Verify(v => v.ValidateBothRankAndSuit(It.IsAny<string>()), Times.Once);
            _userInputValidatorMock.Verify(v => v.ValidateRank(It.IsAny<string>()), Times.Once);
            _userInputValidatorMock.Verify(v => v.ValidateSuit(It.IsAny<string>()), Times.Once);

            _consoleInput.Verify(r => r.ReadLine(), Times.Exactly(4));
        }

        [Fact]
        public void GetUserSettings_ShouldFetchSettingsSuccessfully_WhenUserOptsForSuit()
        {
            // Arrange
            _userInputValidatorMock.Setup(v => v.ValidatePacks(It.IsAny<string>())).Returns(2);
            _userInputValidatorMock.Setup(v => v.ValidateBothRankAndSuit(It.IsAny<string>())).Returns('n');
            _userInputValidatorMock.Setup(v => v.ValidateRank(It.IsAny<string>())).Returns('n');
            _userInputValidatorMock.Setup(v => v.ValidateSuit(It.IsAny<string>())).Returns('y');

            _consoleInput.SetupSequence(r => r.ReadLine())
                .Returns("2")  // Number of packs
                .Returns("n")  // Both rank and suit
                .Returns("n")  // For rank
                .Returns("y"); // For suit

            // Act
            var result = _manageUserInputs.GetUserSettings();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.NumberOfPacks);
            Assert.False(result.MatchByRankAndSuit);
            Assert.False(result.MatchByRank);
            Assert.True(result.MatchBySuit);

            _userInputValidatorMock.Verify(v => v.ValidatePacks(It.IsAny<string>()), Times.Once);
            _userInputValidatorMock.Verify(v => v.ValidateBothRankAndSuit(It.IsAny<string>()), Times.Once);
            _userInputValidatorMock.Verify(v => v.ValidateRank(It.IsAny<string>()), Times.Once);
            _userInputValidatorMock.Verify(v => v.ValidateSuit(It.IsAny<string>()), Times.Once);

            _consoleInput.Verify(r => r.ReadLine(), Times.Exactly(4));
        }

    }
}
