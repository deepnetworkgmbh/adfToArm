using System;
using System.Diagnostics;

namespace AdfToArm.Core.Logs
{
    class TraceLogger : ILogger
    {
        public void Error(string message)
        {
            Trace.WriteLine($"[{DateTime.Now}] - ERROR:{message}");
        }

        public void Info(string message)
        {
            Trace.WriteLine($"[{DateTime.Now}] - INFO:{message}");
        }

        public void SetLoggingLevel(bool verbose)
        {
        }

        public void Warn(string message)
        {
            Trace.WriteLine($"[{DateTime.Now}] - WARN:{message}");
        }
    }
}
