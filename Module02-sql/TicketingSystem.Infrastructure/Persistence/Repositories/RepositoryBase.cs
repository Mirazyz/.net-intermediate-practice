using Microsoft.EntityFrameworkCore;
using TicketingSystem.Domain.Common;
using TicketingSystem.Domain.Exceptions;
using TicketingSystem.Domain.Interfaces.Repositories;

namespace TicketingSystem.Infrastructure.Persistence.Repositories
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
                .FindAsync(id);

            if (entity is null)
            {
                throw new EntityNotFoundException($"Entity {typeof(T)} with id: {id} was not found.");
            }

            return entity;
        }

        public async Task<T> CreateAsync(T entityToCreate)
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
