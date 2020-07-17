namespace TkMemory.Integration.AutoHotkey
{
    /// <summary>
    /// A facade for getting/setting a Boolean variable in AutoHotkey whose value can be toggled with a hotkey.
    /// </summary>
    public class AutoHotkeyToggle : AutoHotkeyBool
    {
        #region Constructors

        /// <summary>
        /// Declare and initialize a Boolean variable in AutoHotkey whose value can be toggled with a hotkey.
        /// </summary>
        /// <param name="hotkey">The hotkey that will be used to toggle the value of the Boolean.</param>
        /// <param name="name">The name of the Boolean variable in AutoHotkey.</param>
        /// <param name="value">The initial value of the Boolean variable.</param>
        public AutoHotkeyToggle(string hotkey, string name, bool value) : base(name, value)
        {
            Hotkey = hotkey;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The hotkey that toggles the value of the Boolean within AutoHotkey.
        /// </summary>
        public string Hotkey { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Returns AutoHotkey source code for declaring a Boolean variable with a hotkey to toggle its value.
        /// </summary>
        /// <returns>The AutoHotkey declaration for the Boolean toggle.</returns>
        public virtual string GetDeclaration()
        {
            return $"{Hotkey}::{Name} := !{Name}";
        }

        #endregion Public Methods
    }
}
