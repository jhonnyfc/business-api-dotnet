using Microsoft.EntityFrameworkCore;
using poroject_777.src.BusinessLogic.Interfaces.Repositories;
using poroject_777.src.DataAccess;

namespace poroject_777.src.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly DbSet<T> dataDBContext;
        private readonly DataContext dataContext;

        public GenericRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
            dataDBContext = dataContext.GetSet<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await dataDBContext.ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await dataDBContext.FindAsync(id, cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await dataDBContext.AddAsync(entity, cancellationToken);
            await dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(T entity, CancellationToken cancellationToken)
        {
            dataDBContext.Update(entity);
            await dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            dataDBContext.Remove(await GetByIdAsync(id, cancellationToken));
            await dataContext.SaveChangesAsync();
        }
    }
}
