using AutoMapper;
using SaamApp.BlazorMauiShared.Models.TrainingQuestionOption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class TrainingQuestionOptionProfile : Profile
    {
        public TrainingQuestionOptionProfile()
        {
            CreateMap<TrainingQuestionOption, TrainingQuestionOptionDto>();
            CreateMap<TrainingQuestionOptionDto, TrainingQuestionOption>();
            CreateMap<CreateTrainingQuestionOptionRequest, TrainingQuestionOption>();
            CreateMap<UpdateTrainingQuestionOptionRequest, TrainingQuestionOption>();
            CreateMap<DeleteTrainingQuestionOptionRequest, TrainingQuestionOption>();
        }
    }
}