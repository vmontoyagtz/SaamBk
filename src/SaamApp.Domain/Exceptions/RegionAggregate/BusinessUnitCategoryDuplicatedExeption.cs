using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateBusinessUnitCategoryException : ArgumentException
    {
        public DuplicateBusinessUnitCategoryException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}