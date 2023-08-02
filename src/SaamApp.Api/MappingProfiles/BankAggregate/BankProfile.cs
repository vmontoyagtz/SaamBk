using AutoMapper;
using SaamApp.BlazorMauiShared.Models.Bank;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<Bank, BankDto>();
            CreateMap<BankDto, Bank>();
            CreateMap<CreateBankRequest, Bank>();
            CreateMap<UpdateBankRequest, Bank>();
            CreateMap<DeleteBankRequest, Bank>();
        }
    }
}