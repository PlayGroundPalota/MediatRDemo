using System;
using MediatR;
using SingleSignOnRefactor.Models;
using SingleSignOnRefactor.Repository;

namespace SingleSignOnRefactor.ApplicatioCommands.UserQuery
{
    public class GetUserByIdQuery : IRequest<SingleSignOnDTO>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            this.Id = id;
        }
    }

    public class GetUserByLegacyIdQueryHandler : IRequestHandler<GetUserByIdQuery, SingleSignOnDTO>
    {
        private readonly ISingleSignOnUserRepository _singleSignOnUserRepository;

        public GetUserByLegacyIdQueryHandler(ISingleSignOnUserRepository singleSignOnUserRepository)
        {
            _singleSignOnUserRepository = singleSignOnUserRepository;
        }
        public async Task<SingleSignOnDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _singleSignOnUserRepository.GetUser(request.Id);
            if (user is not null) return user;
            return new SingleSignOnDTO();
        }
    }
}

