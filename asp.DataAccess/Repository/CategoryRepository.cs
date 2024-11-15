using asp.DataAccess.Data;
using asp.DataAccess.Repository.IRepository;
using asp.Models;

namespace asp.DataAccess.Repository;

public class CategoryRepository(ApplicationDbContext? context) : Repository<Category>(context), IGategoryRepository
{
    private readonly ApplicationDbContext? _context = context;

    public void Update(Category obj)
    {
        _context?.Categories.Update(obj);
    }
}
