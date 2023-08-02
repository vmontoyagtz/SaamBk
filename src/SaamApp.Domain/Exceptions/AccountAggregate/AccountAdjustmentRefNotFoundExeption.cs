using System;

namespace SaamApp.Domain.Exceptions
{
    public class AccountAdjustmentRefNotFoundException : Exception
    {
        public AccountAdjustmentRefNotFoundException(string message) : base(message)
        {
        }

        public AccountAdjustmentRefNotFoundException(Guid accountAdjustmentRefId) : base(
            $"No accountAdjustmentRef with id {accountAdjustmentRefId} found.")
        {
        }
    }
}