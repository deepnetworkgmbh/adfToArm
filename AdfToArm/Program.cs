using AdfToArm.Logs;
using CommandLine;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AdfToArm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<Options>(args)
              .WithParsed(RunCompiler)
              .WithNotParsed(LogErrors);
        }

        private static void RunCompiler(Options obj)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9]");

            var fileInfo = new FileInfo(obj.PathToProject);
            var name = fileInfo.Name
                .Substring(0, fileInfo.Name.Length - 7) // remove .dbproj from the end of the file name
                .Replace('.', '-'); // dots are replaced with dashes for better readability
            name = rgx.Replace(name, "");

            if (!Directory.Exists(obj.OutputFolder))
                Directory.CreateDirectory(obj.OutputFolder);

            AdfCompiler
                .New(obj.PathToProject)
                .ParseAdfTemplates()
                .CreateArmTemplate()
                .SaveArmTo(Path.Combine(obj.OutputFolder, $"{name}.json"));
        }

        private static void LogErrors(IEnumerable<Error> errors)
        {
            Logger.Instance.Error("Compiler wasn't able to parse your input");
            foreach (var error in errors)
            {
                Logger.Instance.Warn(error.ToString());
            }
        }
    }
}
