using BLL.Implementation;

namespace UI.Displays;

[DocumentAttribute("A software Engineering Trainer")]
public class AppScreen
{
    public static void Run()
    {
        DocumentAttributeAttribute documentAttributeAttributeService = new DocumentAttributeAttribute("description");
        documentAttributeAttributeService.GetDocs();
    }
}
