using Microsoft.EntityFrameworkCore;

namespace WebAdmin.Infrastructure.Context
{
    using Models;

    public partial class WebAdminContext : DbContext
    {
        public WebAdminContext(DbContextOptions<WebAdminContext> options) : base(options) { }

        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organisation>()
                .ToTable("mpats_Organisation")
                .HasKey(o => o.OrganisationID);

            modelBuilder.Entity<Organisation>()
                .HasOne(o => o.OrganisationStatus);

            modelBuilder.Entity<OrganisationStatus>()
                .Property(os => os.Description)
                .HasColumnName("OrganisationStatus");

            modelBuilder.Entity<OrganisationStatus>()
                .ToTable("mpats_L_OrganisationStatus")
                .HasKey(os => os.OrganisationStatusID);

            modelBuilder.Entity<User>()
                .ToTable("mpats_User")
                .HasKey(u => u.UserID);

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserStatus);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Organisation);

            modelBuilder.Entity<UserStatus>()
                .ToTable("mpats_L_UserStatus")
                .HasKey(us => us.UserStatusID);

            modelBuilder.Entity<UserStatus>()
                .Property(os => os.Description)
                .HasColumnName("UserStatus");

        }
    }
}