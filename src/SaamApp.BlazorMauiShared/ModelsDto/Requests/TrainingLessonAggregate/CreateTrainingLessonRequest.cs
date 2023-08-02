using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingLesson
{
    public class CreateTrainingLessonRequest : BaseRequest
    {
        public string TrainingLessonTitle { get; set; }
        public string TrainingLessonDescription { get; set; }
        public string TrainingLessonVimeoVideoId { get; set; }
        public string TrainingLessonVideoDuration { get; set; }
        public string TrainingLessonUserType { get; set; }
        public string? TrainingLessonPreviousLesson { get; set; }
        public Guid TenantId { get; set; }
    }
}