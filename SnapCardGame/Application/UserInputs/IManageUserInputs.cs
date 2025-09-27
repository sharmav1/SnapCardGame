using SnapCardGame.Models.UserSettings;

namespace SnapCardGame.Application.UserInputs
{
    public interface IManageUserInputs
    {
        UserSettings GetUserSettings();
    }
}
