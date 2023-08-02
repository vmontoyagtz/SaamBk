using System;

namespace SaamApp.Domain.Exceptions
{
    public class CustomerPaymentNotFoundException : Exception
    {
        public CustomerPaymentNotFoundException(string message) : base(message)
        {
        }

        public CustomerPaymentNotFoundException(int rowId) : base($"No customerPayment with id {rowId} found.")
        {
        }
    }
}