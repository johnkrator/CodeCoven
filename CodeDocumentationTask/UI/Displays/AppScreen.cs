using BLL.Implementation;
using DATA.Enums;

namespace UI.Displays;

[Document("A software Engineering Trainer")]
public class AppScreen
{
    public static void Run()
    {
        DocumentAttribute documentAttributeService = new DocumentAttribute("description");
        documentAttributeService.GetDocs(typeof(Schools));

        MyClass myClass = new MyClass();
        myClass.MySampleMethod("James");
    }
}
