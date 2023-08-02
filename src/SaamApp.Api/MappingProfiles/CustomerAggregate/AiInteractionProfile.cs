using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AiInteraction;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AiInteractionProfile : Profile
    {
        public AiInteractionProfile()
        {
            CreateMap<AiInteraction, AiInteractionDto>();
            CreateMap<AiInteractionDto, AiInteraction>();
            CreateMap<CreateAiInteractionRequest, AiInteraction>();
            CreateMap<UpdateAiInteractionRequest, AiInteraction>();
            CreateMap<DeleteAiInteractionRequest, AiInteraction>();
        }
    }
}