using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace WebAdmin.Infrastructure.Repositories
{
    using Context;
    using Models;

    public class OrganisationRepository
    {
        protected WebAdminContext databaseContext;

        public OrganisationRepository(WebAdminContext context)
        {
            databaseContext = context;
        }

        public Organisation GetOrganisation(int id)
        {
            return databaseContext.Organisations
                .Where(o => o.OrganisationID == id)
                .Include(org => org.OrganisationStatus)
                .FirstOrDefault();
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