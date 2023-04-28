using System;
using AutoMapper;
using MediatR;
using SingleSignOnRefactor.Helpers;
using SingleSignOnRefactor.Models;
using SingleSignOnRefactor.Repository;

namespace SingleSignOnRefactor.ApplicatioCommands.UserQuery
{
    public class GetUserByIdQuery : IRequest<QueryUserResponse>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            this.Id = id;
        }

        public class GetUserByLegacyIdQueryHandler : IRequestHandler<GetUserByIdQuery, QueryUserResponse>
        {
            private readonly ISingleSignOnUserRepository _singleSignOnUserRepository;
            private readonly IMapper _mapper;

            public GetUserByLegacyIdQueryHandler(IMapper mapper, ISingleSignOnUserRepository singleSignOnUserRepository)
            {
                _singleSignOnUserRepository = singleSignOnUserRepository;
                _mapper = mapper;
            }
            public async Task<QueryUserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var UserId = request.Id;
                var user = await _singleSignOnUserRepository.GetUser(request.Id);
                if (user == null)
                {
                    throw new EntityNotFoundException($"User with ID {UserId} not found");
                }

                return _mapper.Map<QueryUserResponse>(await _singleSignOnUserRepository.GetUser(UserId));
            }
        }
    }


}

