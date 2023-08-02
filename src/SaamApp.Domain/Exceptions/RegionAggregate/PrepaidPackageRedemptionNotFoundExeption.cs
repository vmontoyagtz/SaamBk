using System;

namespace SaamApp.Domain.Exceptions
{
    public class PrepaidPackageRedemptionNotFoundException : Exception
    {
        public PrepaidPackageRedemptionNotFoundException(string message) : base(message)
        {
        }

        public PrepaidPackageRedemptionNotFoundException(Guid prepaidPackageRedemptionId) : base(
            $"No prepaidPackageRedemption with id {prepaidPackageRedemptionId} found.")
        {
        }
    }
}