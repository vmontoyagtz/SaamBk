using AutoMapper;
using SaamApp.BlazorMauiShared.Models.RatingReason;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class RatingReasonProfile : Profile
    {
        public RatingReasonProfile()
        {
            CreateMap<RatingReason, RatingReasonDto>();
            CreateMap<RatingReasonDto, RatingReason>();
            CreateMap<CreateRatingReasonRequest, RatingReason>();
            CreateMap<UpdateRatingReasonRequest, RatingReason>();
            CreateMap<DeleteRatingReasonRequest, RatingReason>();
        }
    }
}