using Microsoft.EntityFrameworkCore;
using TicketingSystem.Domain.Common;
using TicketingSystem.Domain.Exceptions;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected readonly TicketingSystemDbContext _context;

        public RepositoryBase(TicketingSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            var entities = await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();

            return entities;
        }

        public async Task<T> FindByIdAsync(int id)
        {
            var entity = await _context.Set<T>()
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }

        public virtual async Task<T> CreateAsync(T entityToCreate)
        {
            var createdEntity = await _context.Set<T>().AddAsync(entityToCreate);

            return createdEntity.Entity;
        }

        public async Task<T> UpdateAsync(T entityToUpdate)
        {
            var entity = await _context.Set<T>()
                .FindAsync(entityToUpdate.Id);

            if (entity is null)
            {
                throw new EntityNotFoundException($"Entity {typeof(T)} with id: {entityToUpdate.Id} was not found.");
            }

            var updatedEntity = _context.Set<T>().Update(entityToUpdate);

            return updatedEntity.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>()
                .FindAsync(id);

            if (entity is null)
            {
                throw new EntityNotFoundException($"{nameof(entity)} with id: {id} does not exist.");
            }

            _context.Set<T>().Remove(entity);
        }
    }
}
