using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AccountAdjustmentRef;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AccountAdjustmentRefProfile : Profile
    {
        public AccountAdjustmentRefProfile()
        {
            CreateMap<AccountAdjustmentRef, AccountAdjustmentRefDto>();
            CreateMap<AccountAdjustmentRefDto, AccountAdjustmentRef>();
            CreateMap<CreateAccountAdjustmentRefRequest, AccountAdjustmentRef>();
            CreateMap<UpdateAccountAdjustmentRefRequest, AccountAdjustmentRef>();
            CreateMap<DeleteAccountAdjustmentRefRequest, AccountAdjustmentRef>();
        }
    }
}