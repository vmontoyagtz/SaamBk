using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TrainingProgress
{
    public class CreateTrainingProgressResponse : BaseResponse
    {
        public CreateTrainingProgressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateTrainingProgressResponse()
        {
        }

        public TrainingProgressDto TrainingProgress { get; set; } = new();
    }
}