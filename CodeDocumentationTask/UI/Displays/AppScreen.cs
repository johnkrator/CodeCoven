using BLL.Implementation;
using DATA.Models;

namespace UI.Displays;

public class AppScreen : DocumentEntity
{
    public static void Run()
    {
        GetDocumentService getDocumentService = new GetDocumentService("");
        getDocumentService.GetDocs();
    }
}
