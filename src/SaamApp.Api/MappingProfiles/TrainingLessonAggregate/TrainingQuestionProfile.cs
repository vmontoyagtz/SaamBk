using AutoMapper;
using SaamApp.BlazorMauiShared.Models.TrainingQuestion;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class TrainingQuestionProfile : Profile
    {
        public TrainingQuestionProfile()
        {
            CreateMap<TrainingQuestion, TrainingQuestionDto>();
            CreateMap<TrainingQuestionDto, TrainingQuestion>();
            CreateMap<CreateTrainingQuestionRequest, TrainingQuestion>();
            CreateMap<UpdateTrainingQuestionRequest, TrainingQuestion>();
            CreateMap<DeleteTrainingQuestionRequest, TrainingQuestion>();
        }
    }
}