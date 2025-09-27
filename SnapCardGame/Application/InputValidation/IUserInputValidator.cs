namespace SnapCardGame.Application.InputValidation
{
    public interface IUserInputValidator
    {
        int ValidatePacks(string? numOfPacks);
        char ValidateBothRankAndSuit(string? optedBothRankAndSuit);
        char ValidateRank(string? optedRank);
        char ValidateSuit(string? optedSuit);
    }
}
