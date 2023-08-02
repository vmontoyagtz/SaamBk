using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingLesson
{
    public class DeleteTrainingLessonRequest : BaseRequest
    {
        public Guid TrainingLessonId { get; set; }
    }
}