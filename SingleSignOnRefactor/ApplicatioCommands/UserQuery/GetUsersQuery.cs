using System;
using AutoMapper;
using MediatR;
using SingleSignOnRefactor.Models;
using SingleSignOnRefactor.Repository;

namespace SingleSignOnRefactor.ApplicatioCommands.UserQuery
{
    public class GetUsersQuery : IRequest<IEnumerable<QueryUserResponse>>
    {
        public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<QueryUserResponse>>
        {
            private readonly ISingleSignOnUserRepository _singleSignOnUserRepository;
            private readonly IMapper _mapper;

            public GetUsersQueryHandler(ISingleSignOnUserRepository singleSignOnUserRepository, IMapper mapper)
            {
                _singleSignOnUserRepository = singleSignOnUserRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<QueryUserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                return _mapper.Map<IEnumerable<QueryUserResponse>>(await _singleSignOnUserRepository.GetUsers());
            }
        }
    }


}

