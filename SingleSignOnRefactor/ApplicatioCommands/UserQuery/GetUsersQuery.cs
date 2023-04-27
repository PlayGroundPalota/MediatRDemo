using System;
using MediatR;
using SingleSignOnRefactor.Models;
using SingleSignOnRefactor.Repository;

namespace SingleSignOnRefactor.ApplicatioCommands.UserQuery
{
    public class GetUsersQuery : IRequest<IEnumerable<SingleSignOnDTO>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<SingleSignOnDTO>>
    {
        private readonly ISingleSignOnUserRepository _singleSignOnUserRepository;

        public GetUsersQueryHandler(ISingleSignOnUserRepository singleSignOnUserRepository)
        {
            _singleSignOnUserRepository = singleSignOnUserRepository;
        }

        public async Task<IEnumerable<SingleSignOnDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _singleSignOnUserRepository.GetUsers();
        }
    }
}

