using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AccountType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AccountTypeProfile : Profile
    {
        public AccountTypeProfile()
        {
            CreateMap<AccountType, AccountTypeDto>();
            CreateMap<AccountTypeDto, AccountType>();
            CreateMap<CreateAccountTypeRequest, AccountType>();
            CreateMap<UpdateAccountTypeRequest, AccountType>();
            CreateMap<DeleteAccountTypeRequest, AccountType>();
        }
    }
}