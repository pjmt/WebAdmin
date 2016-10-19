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
    /// Tests for methods in the UserRepository class.
    /// </summary>
    [TestClass]
    public class UserRepositoryTests
    {
        const int UserID = 1075;

        protected static WebAdminContext databaseContext;

        [ClassInitialize]
        public static void UserRepositoryTests_Initialise(TestContext testContext)
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
        public static void UserRepositoryTests_Cleanup()
        {
            databaseContext.Dispose();
            databaseContext = null;
        }

        [TestMethod]
        public void GetUser_When_userID_is_invalid_Then_Repository_should_return_default_User()
        {
            // Arrange
            var repository = new UserRepository(databaseContext);

            // Act
            var result = repository.GetUser(-UserID);

            // Assert
            Assert.AreEqual(default(User), result);
        }

        [TestMethod]
        public void GetUser_When_userID_is_valid_Then_Repository_should_return_User()
        {
            // Arrange
            var repository = new UserRepository(databaseContext);

            // Act
            var result = repository.GetUser(UserID);

            // Assert
            Assert.AreEqual("Joe Smith", result.FullName);
            Assert.AreEqual("Active", result.UserStatus.Description);
        }

        [TestMethod]
        public async Task GetUserAsync_When_userID_is_invalid_Then_Repository_should_return_default_User()
        {
            // Arrange
            var repository = new UserRepository(databaseContext);

            // Act
            var result = await repository.GetUserAsync(-UserID);

            // Assert
            Assert.AreEqual(default(User), result);
        }

        [TestMethod]
        public async Task GetUserAsync_When_userID_is_valid_Then_Repository_should_return_User()
        {
            // Arrange
            var repository = new UserRepository(databaseContext);

            // Act
            var result = await repository.GetUserAsync(UserID);

            // Assert
            Assert.AreEqual("Joe Smith", result.FullName);
            Assert.AreEqual("Active", result.UserStatus.Description);
        }

        [TestMethod]
        public void GetUsers_Repository_should_return_IQueryable_of_User()
        {
            // Arrange
            var repository = new UserRepository(databaseContext);

            // Act
            var results = repository.GetUsers();

            // Assert
            Assert.IsInstanceOfType(results, typeof(IQueryable<User>));
            Assert.IsTrue(results.Count() > 0);
        }
    }
}