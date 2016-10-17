using Microsoft.EntityFrameworkCore;

namespace WebAdmin.Infrastructure.Context
{
    using Models;

    public partial class WebAdminContext : DbContext
    {
        public WebAdminContext(DbContextOptions<WebAdminContext> options) : base(options) { }

        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<User> Users { get; set; }
    }
}