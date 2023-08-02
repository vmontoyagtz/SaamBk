using System;

namespace SaamApp.Domain.Exceptions
{
    public class SerfinsaPaymentNotFoundException : Exception
    {
        public SerfinsaPaymentNotFoundException(string message) : base(message)
        {
        }

        public SerfinsaPaymentNotFoundException(Guid serfinsaPaymentId) : base(
            $"No serfinsaPayment with id {serfinsaPaymentId} found.")
        {
        }
    }
}