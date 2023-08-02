using System;

namespace SaamApp.Domain.Exceptions
{
    public class CustomerPurchaseNotFoundException : Exception
    {
        public CustomerPurchaseNotFoundException(string message) : base(message)
        {
        }

        public CustomerPurchaseNotFoundException(Guid customerPurchaseId) : base(
            $"No customerPurchase with id {customerPurchaseId} found.")
        {
        }
    }
}