using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiRobot
{
    public class ListAiRobotResponse : BaseResponse
    {
        public ListAiRobotResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAiRobotResponse()
        {
        }

        public List<AiRobotDto> AiRobots { get; set; } = new();

        public int Count { get; set; }
    }
}