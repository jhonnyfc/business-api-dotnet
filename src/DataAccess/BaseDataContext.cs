using Microsoft.EntityFrameworkCore;
using poroject_777.src.BusinessLogic.BusinessSearch.Models;

namespace poroject_777.src.DataAccess
{
    public abstract class BaseDataContext : DbContext
    {
        protected BaseDataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<T> GetSet<T>() where T : class
        {
            return Set<T>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Business>().ToTable("Businesses"); ;
        }
    }
}
