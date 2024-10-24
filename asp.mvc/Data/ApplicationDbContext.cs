using asp.mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace asp.mvc.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }

}
