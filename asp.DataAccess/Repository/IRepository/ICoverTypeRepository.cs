using asp.Models;

namespace asp.DataAccess.Repository.IRepository;

public interface ICoverTypeRepository : IRepository<CoverType>
{
    void Update(CoverType obj);

}