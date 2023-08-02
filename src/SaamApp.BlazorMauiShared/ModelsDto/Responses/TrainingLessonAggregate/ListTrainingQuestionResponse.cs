using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingQuestion
{
    public class ListTrainingQuestionResponse : BaseResponse
    {
        public ListTrainingQuestionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListTrainingQuestionResponse()
        {
        }

        public List<TrainingQuestionDto> TrainingQuestions { get; set; } = new();

        public int Count { get; set; }
    }
}