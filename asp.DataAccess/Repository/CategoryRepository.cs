using System.Linq.Expressions;
using asp.DataAccess.Data;
using asp.DataAccess.Repository.IRepository;
using asp.Models;

namespace asp.DataAccess.Repository;

public class CategoryRepository(ApplicationDbContext? context) : Repository<Category>(context), IGategoryRepository
{
    public void Update(Category obj)
    {
        context?.Categories.Update(obj);
    }

    public void Save()
    {
        context?.SaveChangesAsync();
    }
}