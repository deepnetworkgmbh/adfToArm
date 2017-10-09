namespace AdfToArm.Core.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class ArmParameterAttribute : System.Attribute
    {
        public ArmParameterAttribute(string type = "string")
        {
            Type = type;
        }

        public string Type { get; private set; }

        public string Name { get; set; }

        public bool RemoveBrackets { get; set; } = true;
    }
}
