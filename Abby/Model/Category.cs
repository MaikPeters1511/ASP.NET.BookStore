using System.ComponentModel.DataAnnotations;

namespace Abby.Model;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public int DisplayOrders { get; set; }
}
