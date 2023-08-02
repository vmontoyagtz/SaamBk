using System;

namespace SaamApp.Domain.Exceptions
{
    public class AdvisorNotFoundException : Exception
    {
        public AdvisorNotFoundException(string message) : base(message)
        {
        }

        public AdvisorNotFoundException(Guid advisorId) : base($"No advisor with id {advisorId} found.")
        {
        }
    }
}