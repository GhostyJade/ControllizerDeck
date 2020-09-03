namespace ControllizerCore.Input.Types
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
        /// Mapped to <see cref="ActionRunMacro"/>
        /// </summary>
        Macro = 3,
        /// <summary>
        /// Mapped to nothing...yet.
        /// </summary>
        SendDiscordMessage = 4,

    }
}
