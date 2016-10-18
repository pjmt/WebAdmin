using System.Linq;

namespace WebAdmin.Infrastructure.Repositories
{
    using Models;

    public interface IUserRepository
    {
        User GetUser(int userID);
        IQueryable<User> GetUsers();
    }
}