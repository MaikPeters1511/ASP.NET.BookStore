namespace asp.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IGategoryRepository Category { get; }
        ICoverTypeRepository CoverType { get; }
        IProductRepository Product { get; }

        void Save();
    }
}
