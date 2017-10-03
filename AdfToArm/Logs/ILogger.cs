namespace AdfToArm.Logs
{
    public interface ILogger
    {
        void SetLoggingLevel(bool verbose);

        void Info(string message);

        void Warn(string message);

        void Error(string message);
    }
}