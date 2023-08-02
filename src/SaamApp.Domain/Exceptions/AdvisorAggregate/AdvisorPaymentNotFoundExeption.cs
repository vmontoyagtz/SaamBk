using System;

namespace SaamApp.Domain.Exceptions
{
    public class AdvisorPaymentNotFoundException : Exception
    {
        public AdvisorPaymentNotFoundException(string message) : base(message)
        {
        }

        public AdvisorPaymentNotFoundException(int rowId) : base($"No advisorPayment with id {rowId} found.")
        {
        }
    }
}