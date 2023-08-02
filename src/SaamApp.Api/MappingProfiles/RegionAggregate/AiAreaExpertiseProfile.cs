using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AiAreaExpertise;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AiAreaExpertiseProfile : Profile
    {
        public AiAreaExpertiseProfile()
        {
            CreateMap<AiAreaExpertise, AiAreaExpertiseDto>();
            CreateMap<AiAreaExpertiseDto, AiAreaExpertise>();
            CreateMap<CreateAiAreaExpertiseRequest, AiAreaExpertise>();
            CreateMap<UpdateAiAreaExpertiseRequest, AiAreaExpertise>();
            CreateMap<DeleteAiAreaExpertiseRequest, AiAreaExpertise>();
        }
    }
}