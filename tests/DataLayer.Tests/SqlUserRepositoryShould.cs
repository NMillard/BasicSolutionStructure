using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Configurations;
using DataLayer.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

/*
 * Install Microsoft.EntityFrameworkCore.InMemory
 *
 * Test only the repository's interface - that is, providing X input do I get Y output?
 */

namespace DataLayer.Tests {
    public class SqlUserRepositoryShould {
        private readonly AppDbContext context;

        public SqlUserRepositoryShould() {
            DbContextOptionsBuilder dbOptions = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(
                    Guid.NewGuid().ToString() // Use GUID so every test will use a different db
                );
            
            context = new AppDbContext(dbOptions.Options);
        }
        
        [Fact]
        public async Task AddUser() {
            // Arrange
            var sut = new SqlUserRepository(context);
            var user = new User("test-name");
            
            // Act
            bool result = await sut.CreateUserAsync(user);
            
            // Assert
            List<DomainUserPersistence> users = context.Users.ToList();
            Assert.True(result);
            Assert.Single(users);
        }

        [Fact]
        public async Task GetUser() {
            // Arrange
            var userId = Guid.NewGuid();
            context.Users.Add(new DomainUserPersistence {
                Id = userId,
                Username = "test-name"
            });
            await context.SaveChangesAsync();

            var sut = new SqlUserRepository(context);
            
            // Act
            User result = await sut.GetUserAsync(userId);
            
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllUsers() {
            var users = new List<DomainUserPersistence>() {
                new() {Id = Guid.NewGuid(), Username = "test1"},
                new() {Id = Guid.NewGuid(), Username = "test2"},
                new() {Id = Guid.NewGuid(), Username = "test3"},
            };
            
            context.Users.AddRange(users);
            await context.SaveChangesAsync();
            
            var sut = new SqlUserRepository(context);

            IEnumerable<User> result = await sut.GetUsersAsync();
            
            Assert.Equal(users.Count, result.Count());
        }
    }
}