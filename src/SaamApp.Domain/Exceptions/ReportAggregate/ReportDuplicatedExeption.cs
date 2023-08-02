using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateReportException : ArgumentException
    {
        public DuplicateReportException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}