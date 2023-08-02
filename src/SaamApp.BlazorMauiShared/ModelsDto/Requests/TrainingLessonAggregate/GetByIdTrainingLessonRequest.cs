using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingLesson
{
    public class GetByIdTrainingLessonRequest : BaseRequest
    {
        public Guid TrainingLessonId { get; set; }
    }
}