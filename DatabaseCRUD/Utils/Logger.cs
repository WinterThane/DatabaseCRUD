using System;
using System.IO;

namespace DatabaseCRUD.Utils
{
    public static class Logger
    {
        private static readonly string LogFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
        private static string LogFilePath = Path.Combine(LogFolderPath, $"{DateTime.Now:yyyy-MM}.log");

        public enum ErrorType
        {
            DEBUG,
            INFO,
            WARNING,
            ERROR,
            SEVERE,
            CRITICAL
        }

        public static void Log(string message, Exception ex, ErrorType errorType)
        {
            Log($"{errorType}: {message}\n{ex.StackTrace}");
        }

        public static void Log(string message, ErrorType errorType)
        {
            Log($"{errorType}: {message}");
        }

        private static void Log(string message)
        {
            try
            {
                CheckLogFolder();
                using StreamWriter writer = File.AppendText(LogFilePath);
                writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while logging: {ex.Message}");
            }
        }

        private static void CheckLogFolder()
        {
            if(!Directory.Exists(LogFolderPath))
            {
                Directory.CreateDirectory(LogFolderPath);
            }
        }
    }
}
