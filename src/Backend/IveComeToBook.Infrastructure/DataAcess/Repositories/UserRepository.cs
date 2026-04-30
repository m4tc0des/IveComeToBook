using IveComeToBook.Domain.Entities;
using IveComeToBook.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace IveComeToBook.Infrastructure.DataAcess.Repositories
{
    public class UserRepository: IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly IveComeToBookDbContext _dbcontext;

        public UserRepository(IveComeToBookDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task Add(User user)
        {
            await _dbcontext.Users.AddAsync(user);
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _dbcontext.Users.AnyAsync(x => x.Email.Equals(email) && x.Active);
        }
    }
}
