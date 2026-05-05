namespace IveComeToBook.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}
