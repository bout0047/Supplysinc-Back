using System;
using System.IO;

namespace SupplySyncBackend.Utilities
{
    public static class LoggerUtility
    {
        private static readonly string LogFilePath = "logs/log.txt";

        public static void LogInfo(string message)
        {
            Log("INFO", message);
        }

        public static void LogWarning(string message)
        {
            Log("WARNING", message);
        }

        public static void LogError(string message)
        {
            Log("ERROR", message);
        }

        private static void Log(string level, string message)
        {
            try
            {
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
                Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath));
                File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write log: {ex.Message}");
            }
        }
    }
}
