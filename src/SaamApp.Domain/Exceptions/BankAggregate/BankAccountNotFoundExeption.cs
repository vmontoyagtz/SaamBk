using System;

namespace SaamApp.Domain.Exceptions
{
    public class BankAccountNotFoundException : Exception
    {
        public BankAccountNotFoundException(string message) : base(message)
        {
        }

        public BankAccountNotFoundException(Guid bankAccountId) : base($"No bankAccount with id {bankAccountId} found.")
        {
        }
    }
}