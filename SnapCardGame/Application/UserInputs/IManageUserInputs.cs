using SnapCardGame.Models.UserSettings;

namespace SnapCardGame.Application.UserInputs
{
    /// <summary>
    /// Interface to manage user prompts and inputs
    /// </summary>
    public interface IManageUserInputs
    {
        /// <summary>
        /// Get user settings by prompting
        /// </summary>
        /// <returns></returns>
        UserSettings GetUserSettings();
    }
}
