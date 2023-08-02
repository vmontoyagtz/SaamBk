using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AiSession;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AiSessionProfile : Profile
    {
        public AiSessionProfile()
        {
            CreateMap<AiSession, AiSessionDto>();
            CreateMap<AiSessionDto, AiSession>();
            CreateMap<CreateAiSessionRequest, AiSession>();
            CreateMap<UpdateAiSessionRequest, AiSession>();
            CreateMap<DeleteAiSessionRequest, AiSession>();
        }
    }
}