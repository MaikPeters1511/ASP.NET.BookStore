using System.Linq.Expressions;
using asp.DataAccess.Data;
using asp.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace asp.DataAccess.Repository;

public class Repository<T>(ApplicationDbContext? context) : IRepository<T> where T : class
{
	private readonly ApplicationDbContext? _context = context;
	private readonly DbSet<T> _dbSet = context.Set<T>();

	public Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> filter)
	{
		IQueryable<T> query = _dbSet;
		query = query.Where(filter);
		return query.FirstOrDefaultAsync();
	}

	public IEnumerable<T> GetAll()
	{
		IQueryable<T> query = _dbSet;
		return [.. query];
	}

	public void Add(T entity) => _dbSet.Add(entity);

	public void Remove(T entity) => _dbSet.Remove(entity);

	public void RemoveRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);
}
