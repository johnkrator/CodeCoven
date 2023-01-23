using DATA.Models.Enums;

namespace UI.Displays;

public class MyClass
{
    public MyClass(int age, GenderEnum gender)
    {
        Age = age;
        Gender = gender;
    }

    [BLL.Implementation.Document(Description = "Describes a persons age", Input = "Takes in an integer")]
    public int Age { get; set; }

    [BLL.Implementation.Document(Description = "Physical attributes that define the person's sex",
        Input = "Takes in an enum")]
    public GenderEnum Gender { get; set; }

    [BLL.Implementation.Document(Description = "Displays mentions", Input = "Age and gender",
        Output = "Returns mentions as a string argument")]
    public void MakeSentenceWithPerson(int age, GenderEnum gender)
    {
        this.Gender = gender;
        this.Age = age;

        if (GenderEnum.Male == gender) Console.WriteLine($"We have a {age} year old male");
        else Console.WriteLine($"We have a {age} year old female");
    }
}
