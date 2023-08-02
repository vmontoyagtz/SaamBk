using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AdvisorRating;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AdvisorRatingProfile : Profile
    {
        public AdvisorRatingProfile()
        {
            CreateMap<AdvisorRating, AdvisorRatingDto>();
            CreateMap<AdvisorRatingDto, AdvisorRating>();
            CreateMap<CreateAdvisorRatingRequest, AdvisorRating>();
            CreateMap<UpdateAdvisorRatingRequest, AdvisorRating>();
            CreateMap<DeleteAdvisorRatingRequest, AdvisorRating>();
        }
    }
}