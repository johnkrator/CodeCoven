using DATA.Enums;

namespace UI.Displays;

public class MyClass
{
    public void MySampleMethod(string name)
    {
        Console.WriteLine($"{name} is a {AttributeTarget.HighSchool} student");
    }
}
