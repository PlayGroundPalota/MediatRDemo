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
        // GET: /<controller>/
        [HttpGet(Name = "GetUsersList")]
        public async Task<IEnumerable<SingleSignOnDTO>> Get()
        {
            return await _mediator.Send(new GetUsersQuery());

        }
        [HttpPost(Name = "InsertUser")]
        public async Task Post(SingleSignOnUserModel model)
        {
            await _mediator.Send(new CreateUserCommand(model));
        }
    }
}


