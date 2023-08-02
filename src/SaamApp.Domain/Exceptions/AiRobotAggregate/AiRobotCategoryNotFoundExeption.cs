using System;

namespace SaamApp.Domain.Exceptions
{
    public class AiRobotCategoryNotFoundException : Exception
    {
        public AiRobotCategoryNotFoundException(string message) : base(message)
        {
        }

        public AiRobotCategoryNotFoundException(int rowId) : base($"No aiRobotCategory with id {rowId} found.")
        {
        }
    }
}