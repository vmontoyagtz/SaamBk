using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateBusinessUnitDocumentException : ArgumentException
    {
        public DuplicateBusinessUnitDocumentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}