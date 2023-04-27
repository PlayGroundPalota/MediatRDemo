using System;
using AutoMapper;
using FluentValidation;
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
            private readonly IValidator<CreateUserRequest> _validator;
            private readonly IMapper _mapper;

            public CreateUserHandler(IMapper mapper, ISingleSignOnUserRepository singleSignOnUserRepository, IValidator<CreateUserRequest> validator)
            {
                _singleSignOnUserRepository = singleSignOnUserRepository;
                _validator = validator;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var validationResults = await _validator.ValidateAsync(request.User, cancellationToken);
                if (!validationResults.IsValid)

                    throw new ValidationException(validationResults.Errors);

                await _singleSignOnUserRepository.InsertUser(_mapper.Map<SingleSignOnUserModel>(request.User));

                return Unit.Value;
            }
        }
    }


}

