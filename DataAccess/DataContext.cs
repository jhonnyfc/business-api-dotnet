using Microsoft.EntityFrameworkCore;

namespace poroject_777.DataAccess
{
    public class DataContext : BaseDataContext
    {
        protected DataContext(DbContextOptions options) : base(options)
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
