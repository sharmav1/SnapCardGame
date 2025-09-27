using SnapCardGame.Application.InputValidation;
using SnapCardGame.Models.UserSettings;

namespace SnapCardGame.Application.UserInputs
{
    /// <summary>
    /// Class to manage user prompts and inputs
    /// </summary>
    public class ManageUserInputs : IManageUserInputs
    {
        private readonly IUserInputValidator _userInputValidator;
        public ManageUserInputs(IUserInputValidator userInputValidator)
        {
            _userInputValidator = userInputValidator;
        }

        /// <summary>
        /// Get user settings by prompting
        /// </summary>
        /// <returns></returns>
        public UserSettings GetUserSettings()
        {
            Console.WriteLine("****Snap Card Game****");
            Console.WriteLine("----------------------");
            Console.WriteLine("Before we start, please enter few of the below things to set up game of snap to be played between 2 players:");
            Console.WriteLine();

            int numOfPacks = GetNumberOfPacks();

            Console.WriteLine("Please choose the matching conditions you would like to setup to play this game: ");

            bool hasOptedBoth = char.ToLower(GetRankAndSuit()) == 'y';
            bool rankOpted = !hasOptedBoth ? char.ToLower(GetRank()) == 'y' : true;
            bool suitOpted = !hasOptedBoth ? char.ToLower(GetSuit()) == 'y' : true;

            return new UserSettings()
            {
                NumberOfPacks = numOfPacks,
                MatchByRankAndSuit = hasOptedBoth,
                MatchByRank = rankOpted,
                MatchBySuit = suitOpted
            };
        }

        /// <summary>
        /// Prompt for number of packs
        /// </summary>
        /// <returns></returns>
        private int GetNumberOfPacks()
        {
            int numOfPacks;
            while (true)
            {
                Console.Write("Please enter the number of packs to be used: ");
                var packInput = Console.ReadLine();
                try
                {
                    numOfPacks = _userInputValidator.ValidatePacks(packInput);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return numOfPacks;
        }

        /// <summary>
        /// Prompt for both rank and suit
        /// </summary>
        /// <returns></returns>
        private char GetRankAndSuit()
        {
            char bothRankAndSuit;
            while (true)
            {
                Console.Write("1. Match by Both Rank and Suit (y/n): ");
                //bothRankAndSuit = Console.ReadKey().KeyChar;
                var bothRankAndSuitInput = Console.ReadLine();
                Console.WriteLine();
                try
                {
                    bothRankAndSuit = _userInputValidator.ValidateBothRankAndSuit(bothRankAndSuitInput);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return bothRankAndSuit;
        }

        /// <summary>
        /// Prompt for Rank
        /// </summary>
        /// <returns></returns>
        private char GetRank()
        {
            char rank;
            while (true)
            {
                Console.Write("2. Match by Rank (y/n): ");
                var rankInput = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    rank = _userInputValidator.ValidateRank(rankInput);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return rank;
        }

        /// <summary>
        /// Prompt for Suit
        /// </summary>
        /// <returns></returns>
        private char GetSuit()
        {
            char suit;
            while (true)
            {
                Console.Write("3. Match by Suit (y/n): ");
                var suitInput = Console.ReadLine();

                try
                {
                    suit = _userInputValidator.ValidateSuit(suitInput);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
            return suit;
        }
    }
}
