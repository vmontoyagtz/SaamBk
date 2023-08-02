using System;

namespace SaamApp.Domain.Exceptions
{
    public class ReportNotFoundException : Exception
    {
        public ReportNotFoundException(string message) : base(message)
        {
        }

        public ReportNotFoundException(Guid reportId) : base($"No report with id {reportId} found.")
        {
        }
    }
}