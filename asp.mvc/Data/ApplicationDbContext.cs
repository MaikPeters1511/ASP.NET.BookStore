using asp.mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace asp.mvc.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }

}
