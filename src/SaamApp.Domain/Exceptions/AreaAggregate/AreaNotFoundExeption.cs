using System;

namespace SaamApp.Domain.Exceptions
{
    public class AreaNotFoundException : Exception
    {
        public AreaNotFoundException(string message) : base(message)
        {
        }

        public AreaNotFoundException(Guid areaId) : base($"No area with id {areaId} found.")
        {
        }
    }
}