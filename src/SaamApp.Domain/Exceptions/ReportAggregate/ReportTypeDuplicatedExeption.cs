using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateReportTypeException : ArgumentException
    {
        public DuplicateReportTypeException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}