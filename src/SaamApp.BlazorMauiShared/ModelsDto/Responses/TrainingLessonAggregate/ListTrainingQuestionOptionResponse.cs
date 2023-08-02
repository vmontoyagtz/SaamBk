using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestionOption
{
    public class ListTrainingQuestionOptionResponse : BaseResponse
    {
        public ListTrainingQuestionOptionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListTrainingQuestionOptionResponse()
        {
        }

        public List<TrainingQuestionOptionDto> TrainingQuestionOptions { get; set; } = new();

        public int Count { get; set; }
    }
}