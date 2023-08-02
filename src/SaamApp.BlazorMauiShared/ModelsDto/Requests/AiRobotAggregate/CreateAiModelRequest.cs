using System;

namespace SaamApp.BlazorMauiShared.Models.AiModel
{
    public class CreateAiModelRequest : BaseRequest
    {
        public string ModelName { get; set; }
        public string? ModelDescription { get; set; }
        public string? TrainingData { get; set; }
        public DateTime TrainingDate { get; set; }
        public decimal Accuracy { get; set; }
        public bool IsActive { get; set; }
        public Guid TenantId { get; set; }
    }
}