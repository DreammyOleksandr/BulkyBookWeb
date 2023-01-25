using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models;

public class Category
{
    [Key] public int Id { get; set; }
    [Required] public string Name { get; set; }
    [DisplayName("Display order")] [Range(1, 100, ErrorMessage = "Display order must be in range from 1 to 100")] public int DisplayOrder { get; set; }
    public DateTime CreationTime { get; set; } = DateTime.Now.ToUniversalTime();
}