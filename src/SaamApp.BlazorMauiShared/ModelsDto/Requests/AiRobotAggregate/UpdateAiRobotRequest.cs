using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiRobot
{
    public class UpdateAiRobotRequest : BaseRequest
    {
        public Guid AiRobotId { get; set; }
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

        public static UpdateAiRobotRequest FromDto(AiRobotDto aiRobotDto)
        {
            return new UpdateAiRobotRequest
            {
                AiRobotId = aiRobotDto.AiRobotId,
                AiRobotName = aiRobotDto.AiRobotName,
                AiRobotDescription = aiRobotDto.AiRobotDescription,
                AiRobotUnitPrice = aiRobotDto.AiRobotUnitPrice,
                AiRobotIsActive = aiRobotDto.AiRobotIsActive,
                CreatedAt = aiRobotDto.CreatedAt,
                CreatedBy = aiRobotDto.CreatedBy,
                UpdatedAt = aiRobotDto.UpdatedAt,
                UpdatedBy = aiRobotDto.UpdatedBy,
                IsDeleted = aiRobotDto.IsDeleted,
                TenantId = aiRobotDto.TenantId
            };
        }
    }
}