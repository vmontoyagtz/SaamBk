using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingProgress
{
    public class GetByIdTrainingProgressRequest : BaseRequest
    {
        public Guid TrainingProgressId { get; set; }
    }
}