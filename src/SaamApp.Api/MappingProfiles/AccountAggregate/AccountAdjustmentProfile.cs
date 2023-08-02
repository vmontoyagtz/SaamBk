using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AccountAdjustment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AccountAdjustmentProfile : Profile
    {
        public AccountAdjustmentProfile()
        {
            CreateMap<AccountAdjustment, AccountAdjustmentDto>();
            CreateMap<AccountAdjustmentDto, AccountAdjustment>();
            CreateMap<CreateAccountAdjustmentRequest, AccountAdjustment>();
            CreateMap<UpdateAccountAdjustmentRequest, AccountAdjustment>();
            CreateMap<DeleteAccountAdjustmentRequest, AccountAdjustment>();
        }
    }
}