using StoreApp.Repository.Repositories;

namespace StoreApp.Repository.Comman;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }
    Task SaveChangesAsync();
}
