namespace SnapCardGame.Application.InputValidation
{
    /// <summary>
    /// This interface defines methods for validating user inputs for the Snap Card Game.
    /// </summary>
    public interface IUserInputValidator
    {
        /// <summary>
        /// Validates the number of packs input by the user.
        /// </summary>
        /// <param name="numOfPacks"></param>
        /// <returns></returns>
        int ValidatePacks(string? numOfPacks);

        /// <summary>
        /// Validates the input for matching by both rank and suit.
        /// </summary>
        /// <param name="optedBothRankAndSuit"></param>
        /// <returns></returns>
        char ValidateBothRankAndSuit(string? optedBothRankAndSuit);

        /// <summary>
        /// Validates the input for matching by rank.
        /// </summary>
        /// <param name="optedRank"></param>
        /// <returns></returns>
        char ValidateRank(string? optedRank);

        /// <summary>
        /// Validates the input for matching by suit.
        /// </summary>
        /// <param name="optedSuit"></param>
        /// <returns></returns>
        char ValidateSuit(string? optedSuit);
    }
}
