using System;

namespace SaamApp.Domain.Exceptions
{
    public class BankNotFoundException : Exception
    {
        public BankNotFoundException(string message) : base(message)
        {
        }

        public BankNotFoundException(Guid bankId) : base($"No bank with id {bankId} found.")
        {
        }
    }
}