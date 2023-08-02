using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AiErrorLog;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AiErrorLogProfile : Profile
    {
        public AiErrorLogProfile()
        {
            CreateMap<AiErrorLog, AiErrorLogDto>();
            CreateMap<AiErrorLogDto, AiErrorLog>();
            CreateMap<CreateAiErrorLogRequest, AiErrorLog>();
            CreateMap<UpdateAiErrorLogRequest, AiErrorLog>();
            CreateMap<DeleteAiErrorLogRequest, AiErrorLog>();
        }
    }
}