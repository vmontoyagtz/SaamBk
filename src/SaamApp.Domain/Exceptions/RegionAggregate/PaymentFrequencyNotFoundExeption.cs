using System;

namespace SaamApp.Domain.Exceptions
{
    public class PaymentFrequencyNotFoundException : Exception
    {
        public PaymentFrequencyNotFoundException(string message) : base(message)
        {
        }

        public PaymentFrequencyNotFoundException(Guid paymentFrequencyId) : base(
            $"No paymentFrequency with id {paymentFrequencyId} found.")
        {
        }
    }
}