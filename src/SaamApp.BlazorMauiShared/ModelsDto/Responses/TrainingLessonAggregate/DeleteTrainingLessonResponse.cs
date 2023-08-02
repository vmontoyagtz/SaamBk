using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingLesson
{
    public class DeleteTrainingLessonResponse : BaseResponse
    {
        public DeleteTrainingLessonResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteTrainingLessonResponse()
        {
        }
    }
}