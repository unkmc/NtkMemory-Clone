using AutoHotkey.Interop;
using AutoHotkey.Interop.ClassMemory.Infrastructure;
using Serilog;

namespace TkMemory.Integration.AutoHotkey
{
    /// <summary>
    /// A facade for getting/setting a Boolean variable in AutoHotkey and detecting
    /// changes to its value.
    /// </summary>
    public class AutoHotkeyBool
    {
        #region Fields

        protected bool CurrentValue;
        protected bool PreviousValue;

        private readonly AutoHotkeyEngine _ahk = AutoHotkeyEngine.Instance;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Declare and initialize a Boolean variable in AutoHotkey.
        /// </summary>
        /// <param name="name">The name of the Boolean variable in AutoHotkey.</param>
        /// <param name="value">The initial value of the Boolean variable.</param>
        public AutoHotkeyBool(string name, bool value)
        {
            Name = name;
            _ahk.SetBool(Name, value);
            CurrentValue = value;
            PreviousValue = value;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The name of the Boolean variable in AutoHotkey.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The value of the Boolean variable in AutoHotkey.
        /// </summary>
        public bool Value
        {
            get => GetValue();
            set => SetValue(value);
        }

        #endregion Properties

        #region Protected Methods

        protected virtual bool GetValue()
        {
            PreviousValue = CurrentValue;
            CurrentValue = _ahk.GetBool(Name);
            LogValueChange(Name);
            return CurrentValue;
        }

        protected virtual void SetValue(bool value)
        {
            PreviousValue = CurrentValue;
            CurrentValue = value;
            _ahk.SetBool(Name, value);
            LogValueChange(Name);
        }

        #endregion Protected Methods

        #region Private Methods

        private void LogValueChange(string name)
        {
            if (PreviousValue != CurrentValue)
            {
                Log.Information($"'{name}' was toggled from '{PreviousValue}' to '{CurrentValue}'.");
            }
        }

        #endregion Private Methods
    }
}
