using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;

namespace WebAdmin.Infrastructure.Repositories
{
    using Context;
    using Models;

    public class OrganisationRepository : IOrganisationRepository
    {
        protected WebAdminContext databaseContext;

        public OrganisationRepository(WebAdminContext context)
        {
            databaseContext = context;
        }

        public async Task<Organisation> GetOrganisationAsync(int id)
        {
            return await databaseContext.Organisations
                .Where(o => o.OrganisationID == id)
                .Include(org => org.OrganisationStatus)
                .SingleOrDefaultAsync();
        }

        public IQueryable<Organisation> GetOrganisations()
        {
            return databaseContext.Organisations
                .Include(org => org.OrganisationStatus);
        }

        public IQueryable<Organisation> GetChildOrganisations(int parentOrganistationID)
        {
            return databaseContext.Organisations
                .Where(o => o.ParentOrganisationID == parentOrganistationID)
                .Include(org => org.OrganisationStatus);
        }
    }
}