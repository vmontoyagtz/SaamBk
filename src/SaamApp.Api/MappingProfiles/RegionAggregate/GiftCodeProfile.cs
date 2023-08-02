using AutoMapper;
using SaamApp.BlazorMauiShared.Models.GiftCode;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class GiftCodeProfile : Profile
    {
        public GiftCodeProfile()
        {
            CreateMap<GiftCode, GiftCodeDto>();
            CreateMap<GiftCodeDto, GiftCode>();
            CreateMap<CreateGiftCodeRequest, GiftCode>();
            CreateMap<UpdateGiftCodeRequest, GiftCode>();
            CreateMap<DeleteGiftCodeRequest, GiftCode>();
        }
    }
}