using BLL.Implementation;

namespace UI;

public class AppScreen
{
    public static void Run()
    {
        AttributeValidation attributeValidation = new AttributeValidation(5, 20);
        attributeValidation.IsValid(true);
    }
}
