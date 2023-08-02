using AutoMapper;
using SaamApp.BlazorMauiShared.Models.DiscountCode;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class DiscountCodeProfile : Profile
    {
        public DiscountCodeProfile()
        {
            CreateMap<DiscountCode, DiscountCodeDto>();
            CreateMap<DiscountCodeDto, DiscountCode>();
            CreateMap<CreateDiscountCodeRequest, DiscountCode>();
            CreateMap<UpdateDiscountCodeRequest, DiscountCode>();
            CreateMap<DeleteDiscountCodeRequest, DiscountCode>();
        }
    }
}