using System;

namespace AdfToArm
{
    [Serializable]
    public class AdfParseException : Exception
    {
        public AdfParseException(string message) : base(message)
        {
        }

        public AdfParseException(string message, string filePath) : base(message)
        {
            FilePath = filePath;
        }

        public AdfParseException(string message, Exception ex) : base(message, ex)
        {
        }

        public AdfParseException(string message, Exception ex, string filePath) : base(message, ex)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }
    }
}
