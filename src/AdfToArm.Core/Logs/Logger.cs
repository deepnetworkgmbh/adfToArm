namespace AdfToArm.Core.Logs
{
    public static class Logger
    {
        public static ILogger Instance { get; set; } = new TraceLogger();
    }
}
