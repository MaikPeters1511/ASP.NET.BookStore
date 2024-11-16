using asp.DataAccess.Data;
using asp.DataAccess.Repository.IRepository;
using asp.Models;

namespace asp.DataAccess.Repository;

public class CoverTypeRepository(ApplicationDbContext? context) : Repository<CoverType>(context), ICoverTypeRepository
{
    private readonly ApplicationDbContext? _context = context;

    public void Update(CoverType obj) => _context?.CoverTypes.Update(obj);
}
