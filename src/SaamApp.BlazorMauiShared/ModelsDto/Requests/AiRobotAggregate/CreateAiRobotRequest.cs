using System;

namespace SaamApp.BlazorMauiShared.Models.AiRobot
{
    public class CreateAiRobotRequest : BaseRequest
    {
        public string AiRobotName { get; set; }
        public string? AiRobotDescription { get; set; }
        public decimal AiRobotUnitPrice { get; set; }
        public bool AiRobotIsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
    }
}