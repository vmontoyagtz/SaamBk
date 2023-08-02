using System;

namespace SaamApp.Domain.Exceptions
{
    public class AdvisorApplicantNotFoundException : Exception
    {
        public AdvisorApplicantNotFoundException(string message) : base(message)
        {
        }

        public AdvisorApplicantNotFoundException(Guid advisorApplicantId) : base(
            $"No advisorApplicant with id {advisorApplicantId} found.")
        {
        }
    }
}