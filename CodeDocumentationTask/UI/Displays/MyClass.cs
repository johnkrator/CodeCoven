using DATA.Models;
using DATA.Models.Enums;

namespace UI.Displays;

public class MyClass : AgeEntity
{
    public MyClass(int age, GenderEnum gender)
    {
        Age = age;
        Gender = gender;
    }

    [BLL.Implementation.Document("Describes a persons age", "Takes in an integer")]
    public int Age { get; set; }

    [BLL.Implementation.Document("Physical attributes that define the person's sex", "Takes in an enum")]
    public GenderEnum Gender { get; set; }

    [BLL.Implementation.Document("Showcases the person's defined gender")]
    public enum GenderEnum
    {
        Male,
        Female,
        SheMale
    }

    [BLL.Implementation.Document("Displays mentions", "Age and gender", "Returns mentions as a string argument")]
    public void MakeSentenceWithPerson(int age, GenderEnum gender)
    {
        this.Gender = gender;
        this.Age = age;

        if (GenderEnum.Male == gender) Console.WriteLine($"We have a {age} year old male");
        else Console.WriteLine($"We have a {age} year old female");
    }
}
