using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.IO;
using System.Linq;
using System.Threading.Tasks;

using WebAdmin.Infrastructure.Context;
using WebAdmin.Infrastructure.Models;
using WebAdmin.Infrastructure.Repositories;

namespace WebAdmin.IntegrationTests.Infrastructure.Repositories
{
    /// <summary>
    /// Tests for methods in the OrganisationRepository class.
    /// </summary>
    [TestClass]
    public class OrganisationRepositoryTests
    {
        const int OrganisationID = 1048;

        protected static WebAdminContext databaseContext;

        [ClassInitialize]
        public static void OrganisationRepositoryTests_Initialise(TestContext testContext)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();
            var databaseConnectionString = configuration["ConnectionStrings:DefaultConnection"];

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<WebAdminContext>().UseSqlServer(databaseConnectionString);

            databaseContext = new WebAdminContext(dbContextOptionsBuilder.Options);
        }

        [ClassCleanup]
        public static void OrganisationRepositoryTests_Cleanup()
        {
            databaseContext.Dispose();
            databaseContext = null;
        }

        [TestMethod]
        public async Task GetOrganisationAsync_When_organisationID_is_invalid_Then_Repository_should_return_default_Organisation()
        {
            // Arrange
            var repository = new OrganisationRepository(databaseContext);

            // Act
            var result = await repository.GetOrganisationAsync(-OrganisationID);

            // Assert
            Assert.AreEqual(default(Organisation), result);
        }

        [TestMethod]
        public async Task GetOrganisationAsync_When_organisationID_is_valid_Then_Repository_should_return_Organisation()
        {
            // Arrange
            var repository = new OrganisationRepository(databaseContext);

            // Act
            var result = await repository.GetOrganisationAsync(OrganisationID);

            // Assert
            Assert.AreEqual("Demo Agency ", result.OrganisationName);
            Assert.AreEqual("Full client", result.OrganisationStatus.Description);
        }

        [TestMethod]
        public void GetOrganisations_Repository_should_return_IQueryable_of_Organisation()
        {
            // Arrange
            var repository = new OrganisationRepository(databaseContext);

            // Act
            var results = repository.GetOrganisations();

            // Assert
            Assert.IsInstanceOfType(results, typeof(IQueryable<Organisation>));
            Assert.IsTrue(results.Count() > 0);
        }

        [TestMethod]
        public void GetChildOrganisations_When_parentOrganisationID_is_invalid_Then_Repository_should_return_nothing()
        {
            // Arrange
            var repository = new OrganisationRepository(databaseContext);

            // Act
            var results = repository.GetChildOrganisations(-OrganisationID).ToList();

            // Assert
            Assert.IsFalse(results.Any());
        }

        [TestMethod]
        public void GetChildOrganisations_When_parentOrganisationID_is_invalid_Then_Repository_should_return_child_organisations()
        {
            // Arrange
            var repository = new OrganisationRepository(databaseContext);

            // Act
            var results = repository.GetChildOrganisations(OrganisationID).ToList();

            // Assert
            Assert.IsTrue(results.Any());
        }
    }
}