using AutoMapper;
using SaamApp.BlazorMauiShared.Models.TrainingQuizHistory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class TrainingQuizHistoryProfile : Profile
    {
        public TrainingQuizHistoryProfile()
        {
            CreateMap<TrainingQuizHistory, TrainingQuizHistoryDto>();
            CreateMap<TrainingQuizHistoryDto, TrainingQuizHistory>();
            CreateMap<CreateTrainingQuizHistoryRequest, TrainingQuizHistory>();
            CreateMap<UpdateTrainingQuizHistoryRequest, TrainingQuizHistory>();
            CreateMap<DeleteTrainingQuizHistoryRequest, TrainingQuizHistory>();
        }
    }
}