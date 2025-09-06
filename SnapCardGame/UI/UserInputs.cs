namespace SnapCardGame.UI
{
    /// <summary>
    /// This class handles user inputs for the Snap Card Game.
    /// </summary>
    public static class UserInputs
    {
        /// <summary>
        /// Takes input from the user.
        /// </summary>
        public static (int numOfPacks, bool matchByRankAndSuit, bool matchByRank, bool matchBySuit) Take()
        {
            Console.WriteLine("****Snap Card Game****");
            Console.WriteLine("----------------------");
            Console.WriteLine("Please enter few of the below things to set up game of snap to be played between 2 players:");
            Console.WriteLine();
            Console.Write("Please enter the number of packs to be used: ");
            var packInput = Console.ReadLine();
            int numOfPacks = ValidatePacks(packInput);

            Console.WriteLine("Please choose the matching conditions you would like to setup to play this game: ");
            Console.Write("1. Match by Both Rank and Suit (y/n): ");
            var bothRankAndSuit = Console.ReadKey().KeyChar;
            Console.WriteLine();

            // Validate input for both rank and suit
            ValidateRankAndSuit(bothRankAndSuit);

            var hasOptedBoth = char.ToLower(bothRankAndSuit) == 'y' ? true : false;

            // If user has opted for both rank and suit, no need to ask for individual options
            if (!hasOptedBoth)
            {
                Console.Write("2. Match by Rank (y/n): ");
                var rank = Console.ReadKey().KeyChar;
                Console.WriteLine();
                ValidateRank(rank);

                Console.Write("3. Match by Suit (y/n): ");
                var suit = Console.ReadKey().KeyChar;
                Console.WriteLine();
                ValidateSuit(suit);

                return (numOfPacks, 
                    matchByRankAndSuit: false, 
                    matchByRank: char.ToLower(rank) == 'y', 
                    matchBySuit: char.ToLower(suit) == 'y');
            }
            return (numOfPacks, matchByRankAndSuit: true, matchByRank: true, matchBySuit: true);
        }

        private static int ValidatePacks(string packInput)
        {
            int result;
            if (!int.TryParse(packInput, out result))
                throw new ArgumentOutOfRangeException("Invalid input, please enter a number greater than 0.");
            else if (result <= 0)
                throw new ArgumentOutOfRangeException("Invalid input, please enter a number greater than 0.");
            
            return result;
        }

        private static void ValidateRankAndSuit(char bothRankAndSuit)
        {
            if (char.ToLower(bothRankAndSuit) != 'y' && char.ToLower(bothRankAndSuit) != 'n')
                throw new ArgumentException("Invalid input for rank matching condition. Please enter 'y' or 'n'.");
        }

        private static void ValidateRank(char rank)
        {
            if (char.ToLower(rank) != 'y' && char.ToLower(rank) != 'n')
                throw new ArgumentException("Invalid input for rank matching condition. Please enter 'y' or 'n'.");
        }

        private static void ValidateSuit(char suit)
        {
            if (suit != 'y' && suit != 'n')
                throw new ArgumentException("Invalid input for rank matching condition. Please enter 'y' or 'n'.");
        }
    }
}
