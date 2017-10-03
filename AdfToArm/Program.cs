using System;
using System.IO;

namespace AdfToArm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter path to solution with ADF projects");
            var path = Console.ReadLine();

            string[] allFiles = Directory.GetFiles(path, "*.dfproj", SearchOption.AllDirectories);

            var directory = Directory.CreateDirectory(Path.Combine(path, "ArmTemplates"));

            foreach (var file in allFiles)
            {
                var fileInfo = new FileInfo(file);
                var name = fileInfo.Name
                    .Substring(0, fileInfo.Name.Length - 7)
                    .Replace('.', '-');

                AdfCompiler
                    .New(file)
                    .ParseAdfTemplates()
                    .CreateArmTemplate()
                    .SaveArmTo(Path.Combine(directory.FullName, $"{name}.json"));
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
