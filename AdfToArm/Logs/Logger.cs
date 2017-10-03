namespace AdfToArm.Logs
{
    public static class Logger
    {
        public static ILogger Instance = new ConsoleLogger();
    }
}
