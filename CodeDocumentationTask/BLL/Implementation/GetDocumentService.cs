using System.Reflection;
using BLL.Interfaces;
using DATA.Models;

namespace BLL.Implementation;

[AttributeUsage(AttributeTargets.All)]
public class GetDocumentService : DocumentEntity, IGetDocument
{
    public GetDocumentService(string description)
    {
        Description = description;
    }

    public void GetDocs()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        foreach (Type type in assembly.GetTypes())
        {
            var attributes = type.GetCustomAttributes(typeof(GetDocumentService), true);
            if (attributes.Length > 0)
            {
                Console.WriteLine($"Type: {type.Name}");
                foreach (GetDocumentService attribute in attributes)
                {
                    Console.WriteLine($"Description: {attribute.Description}");
                    Console.WriteLine($"Input: {attribute.Input}");
                    Console.WriteLine($"Output: {attribute.Output}");
                }
            }

            foreach (MethodInfo method in type.GetMethods())
            {
                var methodAttributes = method.GetCustomAttributes(typeof(GetDocumentService), true);
                if (methodAttributes.Length > 0)
                {
                    Console.WriteLine($"Method: {method.Name}");
                    foreach (GetDocumentService attribute in methodAttributes)
                    {
                        Console.WriteLine($"Description: {attribute.Description}");
                        Console.WriteLine($"Input: {attribute.Input}");
                        Console.WriteLine($"Output: {attribute.Output}");
                    }
                }
            }
        }
    }
}
