using System;
using AutoMapper;
using SingleSignOnRefactor.ApplicatioCommands.CreateUser;
using SingleSignOnRefactor.ApplicatioCommands.UserQuery;
using SingleSignOnRefactor.Models;

namespace SingleSignOnRefactor.Helpers
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<SingleSignOnUserModel, CreateUserRequest>().ReverseMap();
            CreateMap<SingleSignOnDTO, QueryUserResponse>().ReverseMap();
        }
    }
}

