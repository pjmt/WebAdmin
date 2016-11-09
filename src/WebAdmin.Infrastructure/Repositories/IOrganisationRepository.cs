using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Infrastructure.Repositories
{
    using Models;

    public interface IOrganisationRepository
    {
        Task<Organisation> GetOrganisationAsync(int id);
        IQueryable<Organisation> GetOrganisations();
        IQueryable<Organisation> GetChildOrganisations(int parentOrganisationID);
    }
}