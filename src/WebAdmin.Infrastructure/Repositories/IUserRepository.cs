using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Infrastructure.Repositories
{
    using Models;

    public interface IUserRepository
    {
        Task<User> GetUserAsync(int userID);
        IQueryable<User> GetUsers();
    }
}