using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Constants = TkMemory.Application.Common.Constants;

namespace TkMemory.Application.Infrastructure
{
    internal class ProcessHelpers
    {
        public static byte[] GetEmbeddedExe(string exeName)
        {
            exeName = Path.GetFileNameWithoutExtension(exeName) + ".exe"; // Allows for parameters with or without the extension included

            var assembly = Assembly.GetExecutingAssembly();
            var resources = assembly.GetManifestResourceNames();
            var resourceName = resources.First(resource => resource.EndsWith(exeName));

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    return null;
                }

                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);

                return bytes;
            }
        }

        public static void KillTrainers()
        {
            var processes = Process.GetProcesses()
                .Where(p => p.ProcessName.Equals("AutoFollow", StringComparison.OrdinalIgnoreCase) ||
                            p.ProcessName.Equals("Mage", StringComparison.OrdinalIgnoreCase) ||
                            p.ProcessName.Equals("Poet", StringComparison.OrdinalIgnoreCase) |
                            p.ProcessName.Equals("Rogue", StringComparison.OrdinalIgnoreCase) ||
                            p.ProcessName.Equals("Warrior", StringComparison.OrdinalIgnoreCase) ||
                            p.ProcessName.Equals("AutoHotkeyDllErrorHandler", StringComparison.OrdinalIgnoreCase));

            foreach (var process in processes)
            {
                try
                {
                    process.Kill();
                }
                catch (Win32Exception) { }
            }
        }

        public static void KillClients(string exe)
        {
            var processName = Path.GetFileNameWithoutExtension(exe);

            var processes = Process.GetProcesses()
                .Where(p => string.Equals(p.ProcessName, processName, StringComparison.OrdinalIgnoreCase));

            foreach (var process in processes)
            {
                process.Kill();
            }
        }

        public static void StartEmbeddedExe(string exeName, string[] commandLineArguments, bool startMinimized)
        {
            exeName = Path.GetFileNameWithoutExtension(exeName);

            if (string.IsNullOrWhiteSpace(exeName))
            {
                throw new ArgumentNullException(nameof(exeName));
            }

            if (Process.GetProcessesByName(exeName).Length != 0)
            {
                return;
            }

            var pathToExe = Path.Combine(Constants.TkMemoryAppDataPath, exeName + ".exe");

            using (var process = new Process
            {
                StartInfo =
                {
                    FileName = pathToExe,
                    Arguments = string.Join(" ", commandLineArguments),
                    WindowStyle = startMinimized
                        ? ProcessWindowStyle.Minimized
                        : ProcessWindowStyle.Normal
                }
            })
            {
                try
                {
                    process.Start();
                }
                catch (Win32Exception)
                {
                    MessageBox.Show($@"{exeName}.exe was not found at: {pathToExe}",
                        $@"{exeName}.exe Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
