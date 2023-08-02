using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingLesson
{
    public class GetByIdTrainingLessonResponse : BaseResponse
    {
        public GetByIdTrainingLessonResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdTrainingLessonResponse()
        {
        }

        public TrainingLessonDto TrainingLesson { get; set; } = new();
    }
}