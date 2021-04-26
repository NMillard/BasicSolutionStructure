using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories {
    internal class SqlUserRepository : IUserRepository {
        private readonly AppDbContext context;

        public SqlUserRepository(AppDbContext context) {
            this.context = context;
        }

        public User GetUserAsync(Guid id) {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsersAsync() => context.Users;

        public async Task<bool> CreateUserAsync(User user) {
            await context.AddAsync(user);
            try {
                await context.SaveChangesAsync();
                return true;
            } catch (DbUpdateException e) {
                return false;
            }
        }
    }
}