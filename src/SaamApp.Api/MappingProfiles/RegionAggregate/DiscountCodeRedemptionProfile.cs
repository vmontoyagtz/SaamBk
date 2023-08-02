using AutoMapper;
using SaamApp.BlazorMauiShared.Models.DiscountCodeRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class DiscountCodeRedemptionProfile : Profile
    {
        public DiscountCodeRedemptionProfile()
        {
            CreateMap<DiscountCodeRedemption, DiscountCodeRedemptionDto>();
            CreateMap<DiscountCodeRedemptionDto, DiscountCodeRedemption>();
            CreateMap<CreateDiscountCodeRedemptionRequest, DiscountCodeRedemption>();
            CreateMap<UpdateDiscountCodeRedemptionRequest, DiscountCodeRedemption>();
            CreateMap<DeleteDiscountCodeRedemptionRequest, DiscountCodeRedemption>();
        }
    }
}