using BLL.Implementation;

namespace UI.Displays;

public class MyClass
{
    public MyClass(int age, GenderEnum gender)
    {
        Age = age;
        Gender = gender;
    }

    [Document("Describes a persons age", "Takes in an integer")]
    public int Age { get; set; }

    [Document("Physical attributes that define the person's sex", "Takes in an enum")]
    public GenderEnum Gender { get; set; }


    [Document("Showcases the person's defined gender")]
    public enum GenderEnum
    {
        Male,
        Female,
        SheMale
    }

    [Document("Displays mentions", "Age and gender", "Returns mentions as a string argument")]
    public void MakeSentenceWithPerson(int age, GenderEnum gender)
    {
        this.Gender = gender;
        this.Age = age;

        if (GenderEnum.Male == gender) Console.WriteLine($"We have a {age} year old male");
        else Console.WriteLine($"We have a {age} year old female");
    }
}
