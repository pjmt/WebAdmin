using System.Linq;

namespace WebAdmin.Infrastructure.Repositories
{
    using Models;

    public interface IOrganisationRepository
    {
        Organisation GetOrganisation(int id);
        IQueryable<Organisation> GetOrganisations();
        IQueryable<Organisation> GetChildOrganisations(int parentOrganisationID);
    }
}