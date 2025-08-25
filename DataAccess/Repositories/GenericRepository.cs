using Microsoft.EntityFrameworkCore;
using poroject_777.BusinessLogic.Interfaces.Repositories;

namespace poroject_777.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly DbSet<T> dataDBContext;

        public GenericRepository(DataContext dataContext)
        {
            dataDBContext = dataContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await dataDBContext.ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await dataDBContext.FindAsync(id, cancellationToken);
        }

        public Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            return dataDBContext.AddAsync(entity, cancellationToken).AsTask();
        }

        public void Update(T entity, CancellationToken cancellationToken)
        {
            dataDBContext.Update(entity);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            dataDBContext.Remove(await GetByIdAsync(id, cancellationToken));
        }
    }
}
