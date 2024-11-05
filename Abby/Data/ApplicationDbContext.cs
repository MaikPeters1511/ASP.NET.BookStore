using Abby.Model;
using Microsoft.EntityFrameworkCore;

namespace Abby.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }

}
