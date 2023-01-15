using BLL.Interfaces;
using DATA.Models;

namespace BLL.Implementation;

public class GetDocument : DocumentEntity, IDisplayDocs
{
    public void GetDocs()
    {
        Console.WriteLine("Hello from GetDocs");
    }
}
