using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<User> GetUserAsync(Guid id) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsersAsync() => await context.Users.ToListAsync();

        public async Task<IEnumerable<DomainUser>> GetDomainUsersAsync() => (await context.DomainUsers.ToListAsync())
            .Select(u => (DomainUser) u);

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