using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAiRobotCategoryException : ArgumentException
    {
        public DuplicateAiRobotCategoryException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}