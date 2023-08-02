using System;

namespace SaamApp.Domain.Exceptions
{
    public class GiftCodeRedemptionNotFoundException : Exception
    {
        public GiftCodeRedemptionNotFoundException(string message) : base(message)
        {
        }

        public GiftCodeRedemptionNotFoundException(Guid giftCodeRedemptionId) : base(
            $"No giftCodeRedemption with id {giftCodeRedemptionId} found.")
        {
        }
    }
}