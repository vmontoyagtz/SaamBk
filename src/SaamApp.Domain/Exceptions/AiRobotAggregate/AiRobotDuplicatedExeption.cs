using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAiRobotException : ArgumentException
    {
        public DuplicateAiRobotException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}