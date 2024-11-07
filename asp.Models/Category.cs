using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace asp.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Display Order")]
    [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100.")]
    public int DisplayOrder { get; set; }

    public DateTime CreateDateTime { get; set; } = DateTime.Now;
}