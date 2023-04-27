using System;
using MediatR;
using SingleSignOnRefactor.Models;
using SingleSignOnRefactor.Repository;

namespace SingleSignOnRefactor.ApplicatioCommands.CreateUser
{
    public class CreateUserCommand : IRequest<SingleSignOnUserModel>
    {
        public SingleSignOnUserModel User { get; set; }

        public CreateUserCommand(SingleSignOnUserModel user)
        {
            this.User = user;
        }
    }

    public class CreateUserHandler : IRequestHandler<CreateUserCommand, SingleSignOnUserModel>
    {
        private readonly ISingleSignOnUserRepository _singleSignOnUserRepository;

        public CreateUserHandler(ISingleSignOnUserRepository singleSignOnUserRepository)
        {
            _singleSignOnUserRepository = singleSignOnUserRepository;
        }
        public async Task<SingleSignOnUserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _singleSignOnUserRepository.InsertUser(request.User);

            return request.User;
        }
    }
}

