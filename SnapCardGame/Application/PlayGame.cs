using SnapCardGame.Models.Deck;
using SnapCardGame.Models.UserSettings;

namespace SnapCardGame.Application
{
    /// <summary>
    /// Handles the main game logic for Snap.
    /// </summary>
    public class PlayGame
    {
        /// <summary>
        /// Starts the Snap game with the given settings and pile of cards.
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="pile"></param>
        public static void Start(UserSettings settings, List<Card> pile, ISnapMatchStrategy matchStrategy)
        {
            Console.WriteLine("Game started!");
            var rng = new Random();

            // To maintain cards played since last snap
            var run = new List<Card>();

            int player1Cards = 0;
            int player2Cards = 0;
            int currentPlayer = 1;

            Card prevCard = null;

            while (pile.Count > 0)
            {
                // Current card to be played from the top of the pile
                var card = pile[0];

                // Remove the card from the pile and add to the run
                pile.RemoveAt(0);
                run.Add(card);

                Console.WriteLine($"Player {currentPlayer} played: {card}");

                // Check for snap
                bool isSnap = prevCard != null && matchStrategy.IsSnap(card, prevCard);
                if (isSnap)
                {
                    // Choose a snap player either 1 or 2 randomly
                    int snapPlayer = rng.Next(1, 3); 
                    Console.WriteLine($"SNAP! Player {snapPlayer} wins {run.Count} cards.");
                    if (snapPlayer == 1)
                        player1Cards += run.Count;
                    else
                        player2Cards += run.Count;

                    run.Clear();
                }

                prevCard = card;

                // Switch to the other player
                currentPlayer = currentPlayer == 1 ? 2 : 1;
            }

            // Discard any remaining cards in run (not won by anyone)
            if (run.Count > 0)
                Console.WriteLine($"{run.Count} cards left in play, discarded.");
            
            DisplayFinalMessages(player1Cards, player2Cards);
        }

        private static void DisplayFinalMessages(int player1Cards, int player2Cards)
        {
            Console.WriteLine();
            Console.WriteLine("Game ended!");
            Console.WriteLine();
            Console.WriteLine($"Player 1 won {player1Cards} cards.");
            Console.WriteLine($"Player 2 won {player2Cards} cards.");

            if (player1Cards > player2Cards)
                Console.WriteLine("Player 1 wins!");
            else if (player2Cards > player1Cards)
                Console.WriteLine("Player 2 wins!");
            else
                Console.WriteLine("It's a draw!");
        }
    }
}
