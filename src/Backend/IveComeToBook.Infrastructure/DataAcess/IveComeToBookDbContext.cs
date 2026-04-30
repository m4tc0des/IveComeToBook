using IveComeToBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IveComeToBook.Infrastructure.DataAcess
{
    public class IveComeToBookDbContext: DbContext
    {
        public IveComeToBookDbContext(DbContextOptions<IveComeToBookDbContext> options): base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IveComeToBookDbContext).Assembly);
        }
    }
}
