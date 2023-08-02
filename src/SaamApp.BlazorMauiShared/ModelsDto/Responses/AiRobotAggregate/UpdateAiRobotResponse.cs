using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiRobot
{
    public class UpdateAiRobotResponse : BaseResponse
    {
        public UpdateAiRobotResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAiRobotResponse()
        {
        }

        public AiRobotDto AiRobot { get; set; } = new();
    }
}