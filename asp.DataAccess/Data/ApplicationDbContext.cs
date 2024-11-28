using asp.Models;
using Microsoft.EntityFrameworkCore;

namespace asp.DataAccess.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<CoverType> CoverTypes { get; set; }
    public DbSet<Product> Products { get; set; }

}
