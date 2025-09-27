using SnapCardGame.Models.Deck;

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
            Console.WriteLine("Before we start, please enter few of the below things to set up game of snap to be played between 2 players:");
            Console.WriteLine();

            int numOfPacks = PromptAndValidatePacks();

            Console.WriteLine("Please choose the matching conditions you would like to setup to play this game: ");

            char bothRankAndSuit = PromptAndValidateBothRankAndSuit();
            var hasOptedBoth = char.ToLower(bothRankAndSuit) == 'y' ? true : false;

            // If user has opted for both rank and suit, no need to ask for individual options
            if (!hasOptedBoth)
            {
                char rank = PromptAndValidateRank();
                char suit = PromptAndValidateSuit();

                return (numOfPacks,
                    matchByRankAndSuit: false,
                    matchByRank: char.ToLower(rank) == 'y',
                    matchBySuit: char.ToLower(suit) == 'y');
            }
            return (numOfPacks, matchByRankAndSuit: true, matchByRank: true, matchBySuit: true);
        }

        private static char PromptAndValidateSuit()
        {
            char suit;
            while (true)
            {
                Console.Write("3. Match by Suit (y/n): ");
                suit = Console.ReadKey().KeyChar;
                Console.WriteLine();

                try
                {
                    ValidateSuit(suit);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                
            }
            return suit;
        }

        private static char PromptAndValidateRank()
        {
            char rank;
            while (true)
            {
                Console.Write("2. Match by Rank (y/n): ");
                rank = Console.ReadKey().KeyChar;
                Console.WriteLine();

                try
                {
                    ValidateRank(rank);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return rank;
        }

        private static char PromptAndValidateBothRankAndSuit()
        {
            char bothRankAndSuit;
            while (true)
            {
                Console.Write("1. Match by Both Rank and Suit (y/n): ");
                bothRankAndSuit = Console.ReadKey().KeyChar;
                Console.WriteLine();
                try
                {
                    ValidateRankAndSuit(bothRankAndSuit);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            
            return bothRankAndSuit;
        }

        private static int PromptAndValidatePacks()
        {
            int numOfPacks;
            while (true)
            {
                Console.Write("Please enter the number of packs to be used: ");
                var packInput = Console.ReadLine();
                try
                {
                    numOfPacks = ValidatePacks(packInput!);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return numOfPacks;
        }

        private static int ValidatePacks(string packInput)
        {
            int result;
            if (!int.TryParse(packInput, out result))
                throw new ArgumentException("Invalid input, please enter a number greater than 0.");
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
