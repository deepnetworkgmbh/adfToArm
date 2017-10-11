using AdfToArm.Core;
using AdfToArm.Core.Logs;
using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdfToArm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logger.Instance = new ConsoleLogger();
            var result = Parser.Default.ParseArguments<Options>(args)
              .WithParsed(RunCompiler)
              .WithNotParsed(LogErrors);
        }

        private static void RunCompiler(Options obj)
        {
            Logger.Instance.SetLoggingLevel(obj.Verbose);
            Regex rgx = new Regex("[^a-zA-Z0-9]");

            try
            {
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
            catch(Exception ex)
            {
                Logger.Instance.Error($"Unexpected exception {ex.Message} of type {ex.GetType()} at {Environment.NewLine}{ex.StackTrace}");
            }
        }

        private static void LogErrors(IEnumerable<Error> errors)
        {
            if (errors.FirstOrDefault(i => i is HelpRequestedError) != null)
                return;

            if (errors.FirstOrDefault(i => i is VersionRequestedError) != null)
                return;

            Logger.Instance.Error("Compiler wasn't able to parse your input");
            foreach (var error in errors)
            {
                Logger.Instance.Warn(error.ToString());
            }
        }
    }
}
