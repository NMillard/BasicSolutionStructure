using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.UserEvents {
    public record CreateNewUser(string Username) : IRequest<bool>;
    
    internal class CreateNewUserHandler : IRequestHandler<CreateNewUser, bool> {
        private readonly IUserRepository repository;

        public CreateNewUserHandler(IUserRepository repository) {
            this.repository = repository;
        }
        
        public async Task<bool> Handle(CreateNewUser request, CancellationToken cancellationToken) {
            var user = new User(request.Username);
            
            bool created = await repository.CreateUserAsync(user);
            return created;
        }
    }
}