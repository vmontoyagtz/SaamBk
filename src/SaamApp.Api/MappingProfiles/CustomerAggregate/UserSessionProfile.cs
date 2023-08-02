using AutoMapper;
using SaamApp.BlazorMauiShared.Models.UserSession;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class UserSessionProfile : Profile
    {
        public UserSessionProfile()
        {
            CreateMap<UserSession, UserSessionDto>();
            CreateMap<UserSessionDto, UserSession>();
            CreateMap<CreateUserSessionRequest, UserSession>();
            CreateMap<UpdateUserSessionRequest, UserSession>();
            CreateMap<DeleteUserSessionRequest, UserSession>();
        }
    }
}