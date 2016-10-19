using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Infrastructure.Repositories
{
    using Models;

    public interface IUserRepository
    {
        User GetUser(int userID);
        IQueryable<User> GetUsers();

        Task<User> GetUserAsync(int userID);
    }
}