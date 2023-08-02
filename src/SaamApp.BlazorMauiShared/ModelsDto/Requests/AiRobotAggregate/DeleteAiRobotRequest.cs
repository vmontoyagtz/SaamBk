using System;

namespace SaamApp.BlazorMauiShared.Models.AiRobot
{
    public class DeleteAiRobotRequest : BaseRequest
    {
        public Guid AiRobotId { get; set; }
    }
}