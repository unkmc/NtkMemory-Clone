namespace TkMemory.Integration.AutoHotkey
{
    /// <summary>
    /// A facade for getting/setting a Boolean variable in AutoHotkey whose value can be toggled with a hotkey.
    /// Toggling the hotkey also toggles whether or not all hotkeys are suspended.
    /// </summary>
    public class AutoHotkeySuspendToggle : AutoHotkeyToggle
    {
        #region Constructors

        /// <summary>
        /// Declare and initialize a Boolean variable in AutoHotkey whose value can be toggled with a hotkey.
        /// </summary>
        /// <param name="hotkey">The hotkey that will be used to toggle the value of the Boolean.</param>
        /// <param name="name">The name of the Boolean variable in AutoHotkey.</param>
        /// <param name="value">The initial value of the Boolean variable.</param>
        public AutoHotkeySuspendToggle(string hotkey, string name, bool value) : base(hotkey, name, value) { }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Returns AutoHotkey source code for declaring a Boolean variable with a hotkey to toggle its value.
        /// Toggling its value with all toggle whether or not all hotkeys are suspended.
        /// </summary>
        /// <returns>The AutoHotkey declaration for the Boolean toggle.</returns>
        public override string GetDeclaration()
        {
            return $@"{Hotkey}::
    Suspend
    {Name} := !{Name}
Return";
        }

        #endregion Public Methods
    }
}
