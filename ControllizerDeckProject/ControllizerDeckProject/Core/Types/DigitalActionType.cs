namespace ControllizerDeckProject.Core.ControllizerActions.Types
{
    /// <summary>
    /// Map index with event names for digital actions
    /// </summary>
    public enum DigitalActionType
    {
        /// <summary>
        /// No mapping
        /// </summary>
        None = 0,
        /// <summary>
        /// Mapped to <see cref="ActionRunProgram"/>
        /// </summary>
        LaunchApp = 1,
        /// <summary>
        /// Mapped to <see cref="ActionOpenWebsite"/>
        /// </summary>
        OpenWebsite = 2,
        /// <summary>
        /// Mapped to nothing...yet.
        /// </summary>
        SendDiscordMessage = 3,
    }
}
