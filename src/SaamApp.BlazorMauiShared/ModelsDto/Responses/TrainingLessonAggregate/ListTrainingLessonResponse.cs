using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingLesson
{
    public class ListTrainingLessonResponse : BaseResponse
    {
        public ListTrainingLessonResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListTrainingLessonResponse()
        {
        }

        public List<TrainingLessonDto> TrainingLessons { get; set; } = new();

        public int Count { get; set; }
    }
}