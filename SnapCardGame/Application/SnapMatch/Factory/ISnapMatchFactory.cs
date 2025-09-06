using SnapCardGame.Models.UserSettings;

namespace SnapCardGame.Application.SnapMatch.Factory
{
    public interface ISnapMatchFactory
    {
        ISnapMatchStrategy GetMatchStrategy(UserSettings settings);
    }
}
