using BLL.Implementation;

namespace UI.Displays;

[Document("A software Engineering Trainer")]
public class AppScreen
{
    public static void Run()
    {
        DocumentAttribute documentAttributeService = new DocumentAttribute("description");
        documentAttributeService.GetDocs();
    }
}
