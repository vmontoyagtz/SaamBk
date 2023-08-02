using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiRobot
{
    public class GetByIdAiRobotResponse : BaseResponse
    {
        public GetByIdAiRobotResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAiRobotResponse()
        {
        }

        public AiRobotDto AiRobot { get; set; } = new();
    }
}