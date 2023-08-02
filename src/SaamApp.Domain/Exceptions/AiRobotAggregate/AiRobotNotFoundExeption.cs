using System;

namespace SaamApp.Domain.Exceptions
{
    public class AiRobotNotFoundException : Exception
    {
        public AiRobotNotFoundException(string message) : base(message)
        {
        }

        public AiRobotNotFoundException(Guid aiRobotId) : base($"No aiRobot with id {aiRobotId} found.")
        {
        }
    }
}