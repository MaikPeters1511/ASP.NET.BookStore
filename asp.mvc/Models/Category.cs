using System.ComponentModel.DataAnnotations;

namespace asp.mvc.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public DateTime CreateDateT { get; set; } = DateTime.Now;
}