using DATA.Models.Enums;

namespace DATA.Models.Entities;

public class AgeModel
{
    [Document(Description = "Describes a persons age", Input = "Takes in an integer")]
    public int Age { get; set; }

    [Document(Description = "Physical attributes that define the person's sex", Input = "Takes in an enum")]
    public GenderEnum Gender { get; set; }
}
