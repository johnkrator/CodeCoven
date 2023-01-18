using System.Reflection;
using BLL.Interfaces;
using DATA.Models;

namespace BLL.Implementation;

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public class DocumentAttribute : DATA.Models.DocumentAttribute, IDocumentAttribute
{
    public DocumentAttribute(string description, string input = "", string output = "")
    {
        Description = description;
        Input = input;
        Output = output;
    }

    public void GetDocs(Type type)
    {
        GetClass(type);
        GetMethods(type);
        GetProperties(type);
    }

    public void GetClass(Type type)
    {
        Console.WriteLine($"Assembly: {Assembly.GetExecutingAssembly()}");
        Console.WriteLine($"\nClass: \n\n{type.Name}");

        object[] classAttr = type.GetCustomAttributes(true);

        foreach (Attribute item in classAttr)
        {
            if (item is DocumentAttribute)
            {
                DocumentAttribute doc = (DocumentAttribute)item;
                Console.WriteLine($"\nDescription:\n\t{doc.Description}\n");
            }
        }
    }

    public void GetMethods(Type type)
    {
        Console.WriteLine("\nMethods:\n");
        MethodInfo[] methods = type.GetMethods();


        for (int i = 0; i < methods.GetLength(0); i++)
        {
            object[] methAttr = methods[i].GetCustomAttributes(true);

            foreach (Attribute item in methAttr)
            {
                if (item is DocumentAttribute)
                {
                    DocumentAttribute doc = (DocumentAttribute)item;
                    Console.WriteLine($"{methods[i].Name}\nDescription:\n\t{doc.Description}\nInput:\n\t{doc.Input}\n");
                }
            }
        }
    }

    public void GetProperties(Type type)
    {
        Console.WriteLine("\n\nProperties: ");
        Console.WriteLine();

        PropertyInfo[] properties = type.GetProperties();

        for (int i = 0; i < properties.GetLength(0); i++)
        {
            object[] propAttr = properties[i].GetCustomAttributes(true);

            foreach (Attribute item in propAttr)
            {
                if (item is DocumentAttribute)
                {
                    DocumentAttribute doc = (DocumentAttribute)item;
                    Console.WriteLine(
                        $"{properties[i].Name}\nDescription:\n\t{doc.Description}\nInput:\n\t{doc.Input}\n");
                }
            }
        }
    }
}
