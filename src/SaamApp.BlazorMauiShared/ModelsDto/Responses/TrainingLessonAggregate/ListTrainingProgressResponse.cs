using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingProgress
{
    public class ListTrainingProgressResponse : BaseResponse
    {
        public ListTrainingProgressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListTrainingProgressResponse()
        {
        }

        public List<TrainingProgressDto> TrainingProgresses { get; set; } = new();

        public int Count { get; set; }
    }
}