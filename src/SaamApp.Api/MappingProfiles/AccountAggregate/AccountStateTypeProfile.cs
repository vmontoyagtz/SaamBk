using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AccountStateType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AccountStateTypeProfile : Profile
    {
        public AccountStateTypeProfile()
        {
            CreateMap<AccountStateType, AccountStateTypeDto>();
            CreateMap<AccountStateTypeDto, AccountStateType>();
            CreateMap<CreateAccountStateTypeRequest, AccountStateType>();
            CreateMap<UpdateAccountStateTypeRequest, AccountStateType>();
            CreateMap<DeleteAccountStateTypeRequest, AccountStateType>();
        }
    }
}