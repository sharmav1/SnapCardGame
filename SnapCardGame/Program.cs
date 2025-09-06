// See https://aka.ms/new-console-template for more information
using SnapCardGame.Application;
using SnapCardGame.Application.SnapMatch.Factory;
using SnapCardGame.Models.UserSettings;
using SnapCardGame.UI;

// Take user inputs
var result = UserInputs.Take();

// Map the inputs to UserSettings model
UserSettings userSettings = new UserSettings
{
    NumberOfPacks = result.Item1,
    MatchByRankAndSuit = result.Item2,
    MatchByRank = result.Item3,
    MatchBySuit = result.Item4
};

// Shuffle the cards and get the pile
var pile = ShuffleCards.Execute(userSettings.NumberOfPacks);

// Get Matching Strategy
ISnapMatchFactory snapMatchFactory = new SnapMatchFactory();
var matchStrategy = snapMatchFactory.GetMatchStrategy(userSettings);

// Start the game
PlayGame.Start(userSettings, pile, matchStrategy);
