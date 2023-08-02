using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateRegionAreaAdvisorCategoryException : ArgumentException
    {
        public DuplicateRegionAreaAdvisorCategoryException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}