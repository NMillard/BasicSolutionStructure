using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using DataLayer.Configurations;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories {
    /*
     * Simple repository, nothing fancy going on here.
     */
    internal class SqlUserRepository : IUserRepository {
        private readonly AppDbContext context;

        public SqlUserRepository(AppDbContext context) {
            this.context = context;
        }

        public async Task<User?> GetUserAsync(Guid id) =>
            await context.Users.SingleOrDefaultAsync(u => u.Id == id);

        public async Task<IEnumerable<User>> GetUsersAsync() => (await context.Users.ToListAsync())
            .Select(u => (User) u);
        
        public async Task<bool> CreateUserAsync(User user) {
            await context.Users.AddAsync(new DomainUserPersistence {
                Id = user.Id,
                Username = user.Username,
            });
            
            try {
                await context.SaveChangesAsync();
                return true;
            } catch (DbUpdateException) {
                return false;
            }
        }
    }
}