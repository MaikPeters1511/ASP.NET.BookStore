using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Required]
    public string ISBN { get; set; } = string.Empty;

    [Required]
    public string Author { get; set; } = string.Empty;

    [Required]
    [Range(1, 10000)]
    public double ListPrice { get; set; }

    [Required]
    [Range(1, 10000)]
    public double Price { get; set; }

    [Required]
    [Range(1, 10000)]
    public double Price50 { get; set; }

    [Required]
    [Range(1, 10000)]
    public double Price100 { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Category")]
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

    [Required]
    [Display(Name ="Cover Type")]
    public int CoverTypeId { get; set; }
    public CoverType CoverType { get; set; }
}