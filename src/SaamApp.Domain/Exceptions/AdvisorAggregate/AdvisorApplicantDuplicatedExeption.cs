using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAdvisorApplicantException : ArgumentException
    {
        public DuplicateAdvisorApplicantException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}