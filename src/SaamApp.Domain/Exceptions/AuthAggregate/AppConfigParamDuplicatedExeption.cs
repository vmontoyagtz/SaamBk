using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateAppConfigParamException : ArgumentException
    {
        public DuplicateAppConfigParamException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}