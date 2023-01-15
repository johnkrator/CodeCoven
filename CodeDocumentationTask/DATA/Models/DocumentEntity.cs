using System.ComponentModel.DataAnnotations;

namespace DATA.Models;

public class DocumentEntity
{
    [Required] public string Description { get; set; }
    public string Input { get; set; }
    public string Output { get; set; }
}
