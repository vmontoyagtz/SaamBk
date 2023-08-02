using AutoMapper;
using SaamApp.BlazorMauiShared.Models.TrainingProgress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class TrainingProgressProfile : Profile
    {
        public TrainingProgressProfile()
        {
            CreateMap<TrainingProgress, TrainingProgressDto>();
            CreateMap<TrainingProgressDto, TrainingProgress>();
            CreateMap<CreateTrainingProgressRequest, TrainingProgress>();
            CreateMap<UpdateTrainingProgressRequest, TrainingProgress>();
            CreateMap<DeleteTrainingProgressRequest, TrainingProgress>();
        }
    }
}