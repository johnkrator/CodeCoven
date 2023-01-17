namespace BLL.Interfaces;

public interface IDocumentAttribute
{
    void GetDocs(Type type);
    void GetMethods(Type type);
    void GetClass(Type type);
    void GetProperties(Type type);
}
