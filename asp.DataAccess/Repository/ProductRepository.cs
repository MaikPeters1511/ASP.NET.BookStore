using asp.DataAccess.Data;
using asp.DataAccess.Repository.IRepository;
using asp.Models;

namespace asp.DataAccess.Repository;

public class ProductRepository(ApplicationDbContext? context) : Repository<Product>(context), IProductRepository
{
    private readonly ApplicationDbContext? _context = context;

    public void Update(Product obj)
    {
        var objFromDb = _context.Products.FirstOrDefault(u => u.Id == obj.Id);
        if (objFromDb != null)
        {
            objFromDb.Title = obj.Title;
            objFromDb.ISBN = obj.ISBN;
            objFromDb.Price = obj.Price;
            objFromDb.Price50 = obj.Price50;
            objFromDb.ListPrice = obj.ListPrice;
            objFromDb.Price100 = obj.Price100;
            objFromDb.Description = obj.Description;
            objFromDb.CategoryId = obj.CategoryId;
            objFromDb.Author = obj.Author;
            objFromDb.CoverTypeId = obj.CoverTypeId;
            if (obj.ImageUrl != null)
            {
                objFromDb.ImageUrl = obj.ImageUrl;
            }
        }
    }
}
