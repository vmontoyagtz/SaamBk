using System;

namespace SaamApp.Domain.Exceptions
{
    public class GiftCodeNotFoundException : Exception
    {
        public GiftCodeNotFoundException(string message) : base(message)
        {
        }

        public GiftCodeNotFoundException(Guid giftCodeId) : base($"No giftCode with id {giftCodeId} found.")
        {
        }
    }
}