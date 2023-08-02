using System;

namespace SaamApp.Domain.Exceptions
{
    public class AccountTypeNotFoundException : Exception
    {
        public AccountTypeNotFoundException(string message) : base(message)
        {
        }

        public AccountTypeNotFoundException(Guid accountTypeId) : base($"No accountType with id {accountTypeId} found.")
        {
        }
    }
}