using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiRobot
{
    public class CreateAiRobotResponse : BaseResponse
    {
        public CreateAiRobotResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAiRobotResponse()
        {
        }

        public AiRobotDto AiRobot { get; set; } = new();
    }
}