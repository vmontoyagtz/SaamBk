using System;

namespace SaamApp.Domain.Exceptions
{
    public class AdvisorCustomerNotFoundException : Exception
    {
        public AdvisorCustomerNotFoundException(string message) : base(message)
        {
        }

        public AdvisorCustomerNotFoundException(int rowId) : base($"No advisorCustomer with id {rowId} found.")
        {
        }
    }
}