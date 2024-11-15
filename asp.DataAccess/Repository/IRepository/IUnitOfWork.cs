namespace asp.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IGategoryRepository Category { get; }
        void Save();
    }
}
