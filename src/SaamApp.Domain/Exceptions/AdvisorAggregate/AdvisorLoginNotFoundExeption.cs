using System;

namespace SaamApp.Domain.Exceptions
{
    public class AdvisorLoginNotFoundException : Exception
    {
        public AdvisorLoginNotFoundException(string message) : base(message)
        {
        }

        public AdvisorLoginNotFoundException(Guid advisorLoginId) : base(
            $"No advisorLogin with id {advisorLoginId} found.")
        {
        }
    }
}