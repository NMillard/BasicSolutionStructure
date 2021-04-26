using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Application.UserEvents;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Users {
    
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator) {
            this.mediator = mediator;
        }
        
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers() {
            IEnumerable<User> users = await mediator.Send(new GetAllUsers());
            return Ok(users);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateNewUser(CreateUserModel model) {
            bool created = await mediator.Send(new CreateNewUser(model.Username));
            return created ? Ok() : BadRequest();
        }
    }
    
    public record CreateUserModel {
        [Required] public string Username { get; set; }
    }
}