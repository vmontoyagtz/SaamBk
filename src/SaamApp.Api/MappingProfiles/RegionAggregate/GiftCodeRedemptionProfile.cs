using AutoMapper;
using SaamApp.BlazorMauiShared.Models.GiftCodeRedemption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class GiftCodeRedemptionProfile : Profile
    {
        public GiftCodeRedemptionProfile()
        {
            CreateMap<GiftCodeRedemption, GiftCodeRedemptionDto>();
            CreateMap<GiftCodeRedemptionDto, GiftCodeRedemption>();
            CreateMap<CreateGiftCodeRedemptionRequest, GiftCodeRedemption>();
            CreateMap<UpdateGiftCodeRedemptionRequest, GiftCodeRedemption>();
            CreateMap<DeleteGiftCodeRedemptionRequest, GiftCodeRedemption>();
        }
    }
}