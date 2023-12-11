using TicketingSystem.Domain.Common;

namespace TicketingSystem.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> FindAllAsync();
        Task<T> FindByIdAsync(int id);
        Task<T> CreateAsync(T entityToCreate);
        Task<T> UpdateAsync(T entityToUpdate);
        Task DeleteAsync(int id);
    }
}
