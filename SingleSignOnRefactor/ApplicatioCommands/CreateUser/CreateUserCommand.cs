using System;
using AutoMapper;
using MediatR;
using SingleSignOnRefactor.Models;
using SingleSignOnRefactor.Repository;

namespace SingleSignOnRefactor.ApplicatioCommands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public CreateUserRequest User { get; set; }

        public CreateUserCommand(CreateUserRequest user)
        {
            this.User = user;
        }

        public class CreateUserHandler : IRequestHandler<CreateUserCommand>
        {
            private readonly ISingleSignOnUserRepository _singleSignOnUserRepository;
            private readonly IMapper _mapper;

            public CreateUserHandler(IMapper mapper, ISingleSignOnUserRepository singleSignOnUserRepository)
            {
                _singleSignOnUserRepository = singleSignOnUserRepository;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                await _singleSignOnUserRepository.InsertUser(_mapper.Map<SingleSignOnUserModel>(request.User));

                return Unit.Value;
            }
        }
    }


}

