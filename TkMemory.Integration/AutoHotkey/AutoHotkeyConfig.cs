namespace TkMemory.Integration.AutoHotkey
{
    /// <summary>
    /// Contains recommendations for configuration settings of AutoHotkey.
    /// </summary>
    public static class AutoHotkeyConfig
    {
        /// <summary>
        /// Default settings recommended for all instances of AutoHotkey.
        /// </summary>
        public const string DefaultConfig = @"
#NoEnv ; Recommended for performance and compatibility with future AutoHotkey releases.
#InstallMouseHook ; Enables mouse buttons as hotkey triggers.
#SingleInstance force ; Ensures only a single instance of the script is running at any given time.

ListLines Off ; Disables logging of executed lines in history.
SetBatchLines -1 ; Runs script at maximum speed.
SetKeyDelay, 0, 0 ; Sends keys at maximum speed.
SetWorkingDir %A_ScriptDir% ; Ensures a consistent starting directory.

; Sets coordinate modes for various commands to be relative to either the active window or the screen
CoordMode, Mouse, Client
CoordMode, Pixel, Screen
CoordMode, ToolTip, Screen
";
    }
}
