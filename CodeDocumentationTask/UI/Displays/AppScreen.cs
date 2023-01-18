using BLL.Implementation;

namespace UI.Displays;

public class AppScreen
{
    public static void Run()
    {
        DocumentAttribute documentAttributeService = new DocumentAttribute("");
        documentAttributeService.GetDocs(typeof(MyClass));
    }
}
