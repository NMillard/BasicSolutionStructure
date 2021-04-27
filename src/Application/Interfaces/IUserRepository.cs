using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Application.Interfaces {
    public interface IUserRepository {
        public Task<User> GetUserAsync(Guid id);
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<IEnumerable<DomainUser>> GetDomainUsersAsync();
        Task<bool> CreateUserAsync(User user);
    }
}