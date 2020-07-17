using AutoHotkey.Interop;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Diagnostics;
using System.IO;
using TkMemory.Integration.AutoHotkey;
using TkMemory.Integration.TkClient;

namespace TkMemory.Application.Common
{
    public static class TkTrainerFactory
    {
        #region Fields

        private const string SerilogOutputTemplate = "{Timestamp:HH:mm:ss:fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

        #endregion Fields

        #region Public Methods

        /// <summary>
        /// Initializes the trainer with recommended settings for logging and for AutoHotkey.
        /// </summary>
        /// <param name="trainerName">The name of the trainer. This is used only for the log file
        /// name, and it is always either the base path of the character being automated
        /// or "AutoFollow" for the auto-follow trainer.</param>
        public static void Initialize(string trainerName)
        {
            var logFilePath = Path.Combine(
                Constants.FileSinkPath,
                $"{trainerName}-.log");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(
                    theme: SystemConsoleTheme.Colored,
                    outputTemplate: SerilogOutputTemplate,
                    restrictedToMinimumLevel: LogEventLevel.Information)
                .WriteTo.File(
                    fileSizeLimitBytes: 250000000,
                    outputTemplate: SerilogOutputTemplate,
                    path: logFilePath,
                    retainedFileCountLimit: 10,
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Debug)
                .CreateLogger();

            var ahk = AutoHotkeyEngine.Instance;
            ahk.LoadScript(AutoHotkeyConfig.DefaultConfig);

            if (!Log.IsEnabled(LogEventLevel.Information))
            {
                return;
            }

            var assembly = System.Reflection.Assembly.GetCallingAssembly();
            var name = assembly.GetName().Name;
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            var version = fvi.FileVersion;
            Log.Information($"Starting {name} Version {version}...");

            var datedLogFilePath = logFilePath.Replace(".log", DateTime.Today.ToString("yyyyMMdd") + ".log");
            Log.Information($"Debug events will be logged at: {datedLogFilePath}");
        }

        /// <summary>
        /// Terminates the bot after logging an exception.
        /// </summary>
        /// <param name="ex">The exception that was thrown.</param>
        public static void Terminate(Exception ex)
        {
            Log.Fatal($"{ex.GetType()}: {ex.Message}\n{ex.StackTrace}");
            Environment.Exit(-1);
        }

        /// <summary>
        /// Terminates the bot with experience and mana restoration item usage reports.
        /// </summary>
        /// <param name="client">The TkClient controlled by the bot.</param>
        public static void Terminate(TkClient client)
        {
            Log.Information(client.GetExpReport());
            Log.Information(client.GetManaRestorationItemUsageReport());

            Console.WriteLine();
            Console.WriteLine(@"Press ""Esc"" to exit...");
            while (Console.ReadKey(true).Key != ConsoleKey.Escape) { }
            Environment.Exit(0);
        }

        #endregion Public Methods
    }
}
