using System;

namespace SaamApp.Domain.Exceptions
{
    public class ReportTypeNotFoundException : Exception
    {
        public ReportTypeNotFoundException(string message) : base(message)
        {
        }

        public ReportTypeNotFoundException(Guid reportTypeId) : base($"No reportType with id {reportTypeId} found.")
        {
        }
    }
}