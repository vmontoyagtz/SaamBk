using System;

namespace SaamApp.Domain.Exceptions
{
    public class PaymentMethodNotFoundException : Exception
    {
        public PaymentMethodNotFoundException(string message) : base(message)
        {
        }

        public PaymentMethodNotFoundException(Guid paymentMethodId) : base(
            $"No paymentMethod with id {paymentMethodId} found.")
        {
        }
    }
}