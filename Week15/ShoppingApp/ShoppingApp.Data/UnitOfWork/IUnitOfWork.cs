namespace ShoppingApp.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        // returns how many records it affects, so int.

        Task BeginTransaction();

        Task CommitTransaction();

        Task RollBackTransaction();
    }
}