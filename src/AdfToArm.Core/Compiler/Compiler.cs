using System.IO;

namespace AdfToArm.Core.Compiler
{
    public class Compiler
    {
        private string _from;
        private string _to = "./output";
        private string _name = "adf.json";
        private bool _failFast = true;

        private Compiler() { }

        public static Compiler New() => new Compiler();

        public Compiler From(string path)
        {
            _from = path;
            return this;
        }

        public Compiler To(string pathToFolder)
        {
            if (!Directory.Exists(pathToFolder))
            {
                throw new System.Exception($"Folder {pathToFolder} does not exist");
            }

            _to = pathToFolder;
            return this;
        }

        public Compiler Name(string adfName)
        {
            if (!adfName.EndsWith(".json", System.StringComparison.InvariantCultureIgnoreCase))
                adfName += ".json";

            _name = adfName;
            return this;
        }

        public Compiler FailFast(bool fail = true)
        {
            _failFast = fail;
            return this;
        }

        public void Create()
        {
            if (string.IsNullOrEmpty(_from))
            {
                throw new System.Exception("From field should be specified");
            }

            var parser = new TemplateParser(_from);
            var result = parser.Parse();

            var creator = new TemplateCreator(_from);
            var arm = creator.Create(result.linkedServices, result.dataSets, result.pipelines);

            var finalizer = new TemplateFinalizer($"{_to}/{_name}", arm);
            finalizer.CreateParamsAndSaveToFiles();
        }
    }
}
