using System;

namespace SaamApp.Domain.Exceptions
{
    public class DuplicateFinancialAccountingPeriodException : ArgumentException
    {
        public DuplicateFinancialAccountingPeriodException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}