using AutoMapper;
using SaamApp.BlazorMauiShared.Models.BankAccount;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class BankAccountProfile : Profile
    {
        public BankAccountProfile()
        {
            CreateMap<BankAccount, BankAccountDto>();
            CreateMap<BankAccountDto, BankAccount>();
            CreateMap<CreateBankAccountRequest, BankAccount>();
            CreateMap<UpdateBankAccountRequest, BankAccount>();
            CreateMap<DeleteBankAccountRequest, BankAccount>();
        }
    }
}