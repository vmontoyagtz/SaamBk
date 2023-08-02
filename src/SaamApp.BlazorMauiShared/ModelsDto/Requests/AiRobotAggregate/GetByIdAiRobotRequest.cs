using System;

namespace SaamApp.BlazorMauiShared.Models.AiRobot
{
    public class GetByIdAiRobotRequest : BaseRequest
    {
        public Guid AiRobotId { get; set; }
    }
}