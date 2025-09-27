// See https://aka.ms/new-console-template for more information
using SnapCardGame.Application;
using SnapCardGame.Application.InputValidation;
using SnapCardGame.Application.UserInputs;
using SnapCardGame.Application.SnapMatch.Factory;
using SnapCardGame.Application.Shuffle;
using SnapCardGame.Application.CreateDeck;

IUserInputValidator userInputValidator = new UserInputValidator();
IManageUserInputs manageUserInputs = new ManageUserInputs(userInputValidator);
var userSettings = manageUserInputs.GetUserSettings();

// Shuffle the cards and get the pile
IDeckGenerator deckGenerator = new DeckGenerator();
IShuffleCard shuffleCard = new ShuffleCards(deckGenerator);
var pile = shuffleCard.Execute(userSettings.NumberOfPacks);

// Get Matching Strategy
ISnapMatchFactory snapMatchFactory = new SnapMatchFactory();
var matchStrategy = snapMatchFactory.GetMatchStrategy(userSettings);

// Start the game
PlayGame.Start(userSettings, pile, matchStrategy);
