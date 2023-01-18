using System.Reflection;
using BLL.Interfaces;
using DATA.Models;

namespace BLL.Implementation;

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public class DocumentAttribute : DocumentEntity, IDocumentAttribute
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
                    Console.WriteLine("{0}\nDescription:\n\t{1}\nInput:\n\t{2}", methods[i].Name, doc.Description,
                        doc.Input);
                }
            }
        }
    }

    public void GetClass(Type type)
    {
        Console.WriteLine("Assembly: {0}", Assembly.GetExecutingAssembly());
        Console.WriteLine("\nClass: \n\n{0}", type.Name);

        object[] classAttr = type.GetCustomAttributes(true);

        foreach (Attribute item in classAttr)
        {
            if (item is DocumentAttribute)
            {
                DocumentAttribute doc = (DocumentAttribute)item;
                Console.WriteLine("\nDescription:\n\t{0}", doc.Description);
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
                    Console.WriteLine("{0}\nDescription:\n\t{1}\nInput:\n\t{2}\n", properties[i].Name, doc.Description,
                        doc.Input);
                }
            }
        }
    }
}
