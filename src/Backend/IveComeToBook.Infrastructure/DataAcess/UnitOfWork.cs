using IveComeToBook.Domain.Repositories;

namespace IveComeToBook.Infrastructure.DataAcess
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IveComeToBookDbContext _dbContext;

        public UnitOfWork(IveComeToBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
