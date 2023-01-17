using System.Reflection;
using BLL.Interfaces;
using DATA.Models;

namespace BLL.Implementation;

[Document("A software Engineering Training")]
public class DocumentAttribute : DocumentEntity, IDocumentAttribute
{
    [Document("The Initializes the Our Class")]
    public DocumentAttribute(string description)
    {
        Description = description;
    }

    [Document("Get Our Documents When Called")]
    public void GetDocs(Type type)
    {
        GetClass(type);
        GetMethods(type);
        GetProperties(type);
    }

    [Document("Gets the Method")]
    public void GetMethods(Type type)
    {
        MethodInfo[] methodInfo = type.GetMethods();
        for (int i = 0; i < methodInfo.Length; i++)
        {
            object[] methods = methodInfo[i].GetCustomAttributes(true);
            foreach (Attribute myMethod in methods.Cast<Attribute>())
            {
                if (myMethod is DocumentAttribute)
                {
                    DocumentAttribute documentAttribute = (DocumentAttribute)myMethod;
                    Console.WriteLine(documentAttribute.Description);
                }
            }
        }
    }

    [Document("The the Class")]
    public void GetClass(Type type)
    {
        Console.WriteLine($"Assembly: {Assembly.GetExecutingAssembly()}");
        object[] classInfo = type.GetCustomAttributes(true);
        foreach (object attribute in classInfo)
        {
            if (attribute is DocumentAttribute)
            {
                DocumentAttribute documentAttribute = (DocumentAttribute)attribute;
                Console.WriteLine(documentAttribute.Description);
            }
        }
    }

    [Document("Gets the properties")]
    public void GetProperties(Type type)
    {
        PropertyInfo[] propertyInfos = type.GetProperties();
        for (int i = 0; i < propertyInfos.Length; i++)
        {
            object[] prop = propertyInfos[i].GetCustomAttributes(true);
            foreach (Attribute myprop in prop.Cast<Attribute>())
            {
                if (myprop is DocumentAttribute)
                {
                    DocumentAttribute documentAttribute = (DocumentAttribute)myprop;
                    Console.WriteLine(documentAttribute.Description);
                }
            }
        }
    }
}
