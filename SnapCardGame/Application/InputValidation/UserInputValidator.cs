namespace SnapCardGame.Application.InputValidation
{
    public class UserInputValidator : IUserInputValidator
    {
        public int ValidatePacks(string? packInput)
        {
            int result;
            if (!int.TryParse(packInput, out result))
                throw new ArgumentException("Invalid input, please enter a number greater than 0.");
            else if (result <= 0)
                throw new ArgumentOutOfRangeException("Invalid input, please enter a number greater than 0.");

            return result;
        }

        public char ValidateBothRankAndSuit(string? bothRankAndSuit)
        {
            char result;

            if (string.IsNullOrWhiteSpace(bothRankAndSuit) || bothRankAndSuit.Length != 1)
                throw new ArgumentException("Invalid input for rank and suit matching condition. Please enter 'y' or 'n'.");

            result = bothRankAndSuit[0];

            if (char.ToLower(result) != 'y' && char.ToLower(result) != 'n')
                throw new ArgumentException("Invalid input for rank and suit matching condition. Please enter 'y' or 'n'.");

            return result;
        }

        public char ValidateRank(string? rank)
        {
            char result;

            if (string.IsNullOrWhiteSpace(rank) || rank.Length != 1)
                throw new ArgumentException("Invalid input for rank matching condition. Please enter 'y' or 'n'.");

            result = rank[0];

            if (char.ToLower(result) != 'y' && char.ToLower(result) != 'n')
                throw new ArgumentException("Invalid input for rank matching condition. Please enter 'y' or 'n'.");

            return result;
        }

        public char ValidateSuit(string? suit)
        {
            char result;

            if (string.IsNullOrWhiteSpace(suit) || suit.Length != 1)
                throw new ArgumentException("Invalid input for suit matching condition. Please enter 'y' or 'n'.");

            result = suit[0];

            if (char.ToLower(result) != 'y' && char.ToLower(result) != 'n')
                throw new ArgumentException("Invalid input for suit matching condition. Please enter 'y' or 'n'.");

            return result;
        }

    }
}
