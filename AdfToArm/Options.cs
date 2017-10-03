using AdfToArm.Logs;
using CommandLine;
using System;

namespace AdfToArm
{
    public class Options
    {
        private string _path;
        [Option('p', "path", Required = true, HelpText = "Path to the ADF project")]
        public string PathToProject
        {
            get => _path;
            set
            {
                if (value.EndsWith(".dfproj"))
                {
                    _path = value;
                }
                else
                {
                    Logger.Instance.Error("only .dfproj files are supported");
                    throw new NotSupportedException("only .dfproj files are supported");
                }
            }
        }

        [Option('o', "output", Required = true, HelpText = "Directory for generated ARM templates")]
        public string OutputFolder { get; set; }

        [Option(Default = false)]
        public bool Verbose { get; set; }
    }
}
