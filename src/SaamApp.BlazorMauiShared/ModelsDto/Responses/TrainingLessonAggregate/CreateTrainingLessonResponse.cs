using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingLesson
{
    public class CreateTrainingLessonResponse : BaseResponse
    {
        public CreateTrainingLessonResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateTrainingLessonResponse()
        {
        }

        public TrainingLessonDto TrainingLesson { get; set; } = new();
    }
}