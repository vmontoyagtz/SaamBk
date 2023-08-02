using System;

namespace SaamApp.Domain.Exceptions
{
    public class RegionNotFoundException : Exception
    {
        public RegionNotFoundException(string message) : base(message)
        {
        }

        public RegionNotFoundException(Guid regionId) : base($"No region with id {regionId} found.")
        {
        }
    }
}