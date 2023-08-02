using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingLesson
{
    public class UpdateTrainingLessonRequest : BaseRequest
    {
        public Guid TrainingLessonId { get; set; }
        public string TrainingLessonTitle { get; set; }
        public string TrainingLessonDescription { get; set; }
        public string TrainingLessonVimeoVideoId { get; set; }
        public string TrainingLessonVideoDuration { get; set; }
        public string TrainingLessonUserType { get; set; }
        public string? TrainingLessonPreviousLesson { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateTrainingLessonRequest FromDto(TrainingLessonDto trainingLessonDto)
        {
            return new UpdateTrainingLessonRequest
            {
                TrainingLessonId = trainingLessonDto.TrainingLessonId,
                TrainingLessonTitle = trainingLessonDto.TrainingLessonTitle,
                TrainingLessonDescription = trainingLessonDto.TrainingLessonDescription,
                TrainingLessonVimeoVideoId = trainingLessonDto.TrainingLessonVimeoVideoId,
                TrainingLessonVideoDuration = trainingLessonDto.TrainingLessonVideoDuration,
                TrainingLessonUserType = trainingLessonDto.TrainingLessonUserType,
                TrainingLessonPreviousLesson = trainingLessonDto.TrainingLessonPreviousLesson,
                TenantId = trainingLessonDto.TenantId
            };
        }
    }
}