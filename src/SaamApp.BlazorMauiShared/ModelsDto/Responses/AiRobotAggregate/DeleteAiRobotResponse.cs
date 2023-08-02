using System;

namespace SaamApp.BlazorMauiShared.Models.AiRobot
{
    public class DeleteAiRobotResponse : BaseResponse
    {
        public DeleteAiRobotResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAiRobotResponse()
        {
        }
    }
}