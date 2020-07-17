using AutoHotkey.Interop;
using System.Collections.Generic;
using System.Text;

namespace TkMemory.Integration.AutoHotkey
{
    /// <summary>
    /// Extension methods for the AutoHotkeyEngine object of the AutoHotkey.Interop library.
    /// </summary>
    public static class AutoHotkeyEngineExtensions
    {
        /// <summary>
        /// A convenience method for loading a collection of AutoHotkeyToggle objects into an instance of AutoHotkey.
        /// </summary>
        /// <param name="ahk">The instance of AutoHotkey into which to load the toggles.</param>
        /// <param name="toggles">A collection of AutoHotkeyToggle objects to load into AutoHotkey.</param>
        public static void LoadToggles(this AutoHotkeyEngine ahk, IEnumerable<AutoHotkeyToggle> toggles)
        {
            var sb = new StringBuilder();

            foreach (var toggle in toggles)
            {
                sb.AppendLine(toggle.GetDeclaration());
            }

            ahk.LoadScript(sb.ToString());
        }
    }
}
