using BLL.Implementation;

namespace UI.Displays;

public class AppScreen
{
    public static void Run()
    {
        GetDocumentService getDocumentService = new GetDocumentService("description", "input", "output");
        getDocumentService.GetDocs();
    }
}
