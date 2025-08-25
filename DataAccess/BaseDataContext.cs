using Microsoft.EntityFrameworkCore;
using poroject_777.BusinessLogic.BusinessSearch.Models;

namespace poroject_777.DataAccess
{
    public abstract class BaseDataContext : DbContext
    {
        protected BaseDataContext(DbContextOptions options)
            : base(options)
        {
        }

        public override DbSet<T> Set<T>() where T : class
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
