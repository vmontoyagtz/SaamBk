using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingLesson
{
    public class UpdateTrainingLessonResponse : BaseResponse
    {
        public UpdateTrainingLessonResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateTrainingLessonResponse()
        {
        }

        public TrainingLessonDto TrainingLesson { get; set; } = new();
    }
}