using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateRegionException : ArgumentException
    {
        public DuplicateRegionException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}