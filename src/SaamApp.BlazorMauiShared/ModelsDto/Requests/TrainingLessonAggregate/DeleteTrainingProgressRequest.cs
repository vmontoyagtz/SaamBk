using System;

namespace SaamApp.BlazorMauiShared.Models.TrainingProgress
{
    public class DeleteTrainingProgressRequest : BaseRequest
    {
        public Guid TrainingProgressId { get; set; }
    }
}