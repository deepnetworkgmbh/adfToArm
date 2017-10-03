using System;

namespace AdfToArm.Logs
{
    public class ConsoleLogger : ILogger
    {
        private bool _verbose;

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine($"[{DateTime.UtcNow}]: ERROR! {message}");
            Console.WriteLine();
            Console.ResetColor();
        }

        public void Info(string message)
        {
            if (!_verbose)
                return;

            Console.WriteLine($"[{DateTime.UtcNow}]: {message}");
        }

        public void SetLoggingLevel(bool verbose)
        {
            _verbose = verbose;
        }

        public void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine($"[{DateTime.UtcNow}]: {message}");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}