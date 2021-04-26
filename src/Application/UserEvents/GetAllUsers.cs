using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.UserEvents {
    public record GetAllUsers() : IRequest<IEnumerable<User>>; 
    
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, IEnumerable<User>> {
        private readonly IUserRepository repository;

        public GetAllUsersHandler(IUserRepository repository) {
            this.repository = repository;
        }
        
        public async Task<IEnumerable<User>> Handle(GetAllUsers request, CancellationToken cancellationToken) {
            return repository.GetUsersAsync();
        }
    }
}