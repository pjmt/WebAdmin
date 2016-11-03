using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Infrastructure.Repositories
{
    using Models;

    public interface IOrganisationRepository
    {
        Task<Organisation> GetOrganisation(int id);
        IQueryable<Organisation> GetOrganisations();
        IQueryable<Organisation> GetChildOrganisations(int parentOrganisationID);
    }
}