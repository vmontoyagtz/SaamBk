using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AiMemory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AiMemoryProfile : Profile
    {
        public AiMemoryProfile()
        {
            CreateMap<AiMemory, AiMemoryDto>();
            CreateMap<AiMemoryDto, AiMemory>();
            CreateMap<CreateAiMemoryRequest, AiMemory>();
            CreateMap<UpdateAiMemoryRequest, AiMemory>();
            CreateMap<DeleteAiMemoryRequest, AiMemory>();
        }
    }
}