using BLL.Implementation;

namespace UI.Displays;

public class AppScreen
{
    public static void Run()
    {
        GetDocument getDocument = new GetDocument();
        getDocument.GetDocs();
    }
}
