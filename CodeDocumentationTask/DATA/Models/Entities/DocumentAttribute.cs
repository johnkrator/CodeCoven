namespace DATA.Models.Entities;

[AttributeUsage(AttributeTargets.All)]
public class DocumentAttribute : Attribute
{
    [Document(Description = "Model", Input = "Object description", Output = "Returns a string\n")]
    public string Description { get; set; }

    public string Input { get; set; }
    public string Output { get; set; }
}
