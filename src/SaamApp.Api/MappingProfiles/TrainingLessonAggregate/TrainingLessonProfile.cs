using AutoMapper;
using SaamApp.BlazorMauiShared.Models.TrainingLesson;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class TrainingLessonProfile : Profile
    {
        public TrainingLessonProfile()
        {
            CreateMap<TrainingLesson, TrainingLessonDto>();
            CreateMap<TrainingLessonDto, TrainingLesson>();
            CreateMap<CreateTrainingLessonRequest, TrainingLesson>();
            CreateMap<UpdateTrainingLessonRequest, TrainingLesson>();
            CreateMap<DeleteTrainingLessonRequest, TrainingLesson>();
        }
    }
}