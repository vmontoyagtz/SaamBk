using System;

namespace SaamApp.Domain.Exceptions
{
    public class UserSessionNotFoundException : Exception
    {
        public UserSessionNotFoundException(string message) : base(message)
        {
        }

        public UserSessionNotFoundException(Guid sessionId) : base($"No userSession with id {sessionId} found.")
        {
        }
    }
}