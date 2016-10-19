using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Infrastructure.Repositories
{
    using Context;
    using Models;

    public class UserRepository : IUserRepository
    {
        protected WebAdminContext databaseContext;

        public UserRepository(WebAdminContext context)
        {
            databaseContext = context;
        }

        public User GetUser(int id)
        {
            return databaseContext.Users
                .Where(u => u.UserID == id)
                .Include(u => u.UserStatus)
                .FirstOrDefault();
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await databaseContext.Users
                .Where(u => u.UserID == id)
                .Include(u => u.UserStatus)
                .SingleOrDefaultAsync();

            return user;
        }

        public IQueryable<User> GetUsers()
        {
            return databaseContext.Users.Include(u => u.UserStatus);
        }
    }
}