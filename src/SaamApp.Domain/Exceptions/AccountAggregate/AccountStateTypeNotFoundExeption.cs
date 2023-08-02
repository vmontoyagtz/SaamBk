using System;

namespace SaamApp.Domain.Exceptions
{
    public class AccountStateTypeNotFoundException : Exception
    {
        public AccountStateTypeNotFoundException(string message) : base(message)
        {
        }

        public AccountStateTypeNotFoundException(Guid accountStateTypeId) : base(
            $"No accountStateType with id {accountStateTypeId} found.")
        {
        }
    }
}