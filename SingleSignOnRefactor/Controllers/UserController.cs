using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SingleSignOnRefactor.ApplicatioCommands.CreateUser;
using SingleSignOnRefactor.ApplicatioCommands.UserQuery;
using SingleSignOnRefactor.Models;
using SingleSignOnRefactor.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SingleSignOnRefactor.Controllers
{
    [ApiController]
    // [Authorize]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "InsertUser")]
        public async Task Post(CreateUserRequest model)
        {
            await _mediator.Send(new CreateUserCommand(model));
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(user);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var list = await _mediator.Send(new GetUsersQuery());
            return Ok(list);
        }
    }
}


