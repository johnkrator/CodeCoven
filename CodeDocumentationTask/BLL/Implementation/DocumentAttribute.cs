using System.Reflection;
using BLL.Interfaces;

namespace BLL.Implementation;

[Document(Description = "Class", Input = "Takes in methods", Output = "Method objects\n")]
public class DocumentAttribute : DATA.Models.Entities.DocumentAttribute, IDocumentAttribute
{
    [Document(Description = "Method", Input = "HandleGetDocs()", Output = "HandleGetDocs()\n")]
    public void GetDocs()
    {
        HandleGetDocs();
    }

    [Document(Description = "Method", Input = "A method to handle receiving documents", Output = "none\n")]
    public void HandleGetDocs()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();
        foreach (var type in types)
        {
            var attributes = type.GetCustomAttributes(typeof(DocumentAttribute), true);
            foreach (DocumentAttribute attribute in attributes)
            {
                Console.WriteLine($"{type.Name}: {attribute.Description}");
                Console.WriteLine($"Input: {attribute.Input}");
                Console.WriteLine($"Output: {attribute.Output}");
            }

            var members = type.GetMembers();
            foreach (var member in members)
            {
                var memberAttributes = member.GetCustomAttributes(typeof(DocumentAttribute), true);
                foreach (DocumentAttribute attribute in memberAttributes)
                {
                    Console.WriteLine($"{member.Name}: {attribute.Description}");
                    Console.WriteLine($"Input: {attribute.Input}");
                    Console.WriteLine($"Output: {attribute.Output}");
                }
            }
        }
    }
}
