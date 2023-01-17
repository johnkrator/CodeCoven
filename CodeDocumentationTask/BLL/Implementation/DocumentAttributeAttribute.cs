using System.Reflection;
using BLL.Interfaces;
using DATA.Models;

namespace BLL.Implementation;

public class DocumentAttributeAttribute : DocumentEntity, IDocumentAttribute
{
    public DocumentAttributeAttribute(string description)
    {
        Description = description;
    }

    public void GetDocs()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var types = assembly.GetTypes();

        foreach (var type in types)
        {
            var members = type.GetMembers();
            foreach (var member in members)
            {
                var attribute = member.GetCustomAttribute(typeof(DocumentAttributeAttribute)) as DocumentAttributeAttribute;
                if (attribute != null)
                {
                    Console.WriteLine($"Member: {member.Name}");
                    Console.WriteLine($"Description: {attribute.Description}");
                    Console.WriteLine($"Input: {attribute.Input}");
                    Console.WriteLine($"Output: {attribute.Output}");
                }
            }
        }
    }
}
